#if !DEBUG||DLLDEBUG
using System;
using System.Globalization;
using ContainerType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise {
	/// <summary>
	/// 文字列を数値にパースします。
	/// </summary>
	internal class Parser {

		/// <summary>
		/// パーサーを初期化します。
		/// </summary>
		/// <param name="style">value に許可されている書式を指定する列挙値のビットごとの組み合わせ。</param>
		/// <param name="provider">value に関するカルチャ固有の書式情報を提供するオブジェクト。</param>
		public Parser(NumberStyles style,IFormatProvider provider) {

			var intStyle = (int)style;

			if(intStyle<0&&intStyle>=1024) {
				//TODO:メッセージ何とかする
				throw new ArgumentException("",nameof(style));
			}

			this.AllowLeadingWhite=(intStyle&0x1)>0;
			intStyle>>=1;
			this.AllowTrailingWhite=(intStyle&0x1)>0;
			intStyle>>=1;
			this.AllowLeadingSign=(intStyle&0x1)>0;
			intStyle>>=1;
			this.AllowTrailingSign=(intStyle&0x1)>0;
			intStyle>>=1;
			this.AllowParentheses=(intStyle&0x1)>0;
			intStyle>>=1;
			this.AllowDecimalPoint=(intStyle&0x1)>0;
			intStyle>>=1;
			this.AllowThousands=(intStyle&0x1)>0;
			intStyle>>=1;
			this.AllowExponent=(intStyle&0x1)>0;
			intStyle>>=1;
			this.AllowCurrencySymbol=(intStyle&0x1)>0;
			intStyle>>=1;
			this.AllowHexSpecifier=(intStyle&0x1)>0;

			if(this.AllowHexSpecifier) {
				//TODO:16進数からのフォーマットをするかしないか考える。（そもそもできるの？
				throw new ArgumentException("",nameof(style));
			}

			this.CultureInfo=provider as CultureInfo??CultureInfo.CurrentCulture;
			this.Nfi=NumberFormatInfo.GetInstance(provider);

		}

		/// <summary>
		/// 指定したスタイルおよびカルチャ固有の書式の数値の文字列形式を、それと等価の符号、分母、分子に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		private void Parse(string value) {

			if(AllowThousands) {
				value=value.Replace(this.Nfi.CurrencyGroupSeparator,"").Replace(this.Nfi.PercentGroupSeparator,"").Replace(this.Nfi.NumberGroupSeparator,"");
			}

			value=this.ParceExponentPart(value);

			var currencyIndex = value.IndexOf(this.Nfi.CurrencyDecimalSeparator,StringComparison.CurrentCulture);
			var numberIndex = this.Nfi.CurrencyDecimalSeparator!=this.Nfi.NumberDecimalSeparator ? value.IndexOf(this.Nfi.NumberDecimalSeparator,StringComparison.CurrentCulture) : -1;
			var percentIndex = this.Nfi.CurrencyDecimalSeparator!=this.Nfi.PercentDecimalSeparator&&this.Nfi.NumberDecimalSeparator!=this.Nfi.PercentDecimalSeparator ? value.IndexOf(this.Nfi.PercentDecimalSeparator,StringComparison.CurrentCulture) : -1;
			this.IntegerPart=string.Empty;
			this.FractionalPart=string.Empty;
			if(AllowDecimalPoint) {
				if(currencyIndex>-1) {
					if(numberIndex>-1||percentIndex>-1) {
						throw new FormatException();
					}
					this.IntegerPart=value.Substring(0,currencyIndex);
					this.FractionalPart=value.Substring(currencyIndex+this.Nfi.CurrencyDecimalSeparator.Length);
					if(this.FractionalPart.IndexOf(this.Nfi.CurrencyDecimalSeparator,StringComparison.CurrentCulture)>-1) {
						throw new FormatException();
					}
				} else if(numberIndex>-1) {
					if(percentIndex>-1) {
						throw new FormatException();
					}
					this.IntegerPart=value.Substring(0,numberIndex);
					this.FractionalPart=value.Substring(currencyIndex+this.Nfi.CurrencyDecimalSeparator.Length);
					if(this.FractionalPart.IndexOf(this.Nfi.NumberDecimalSeparator,StringComparison.CurrentCulture)>-1) {
						throw new FormatException();
					}
				} else if(percentIndex>-1) {
					this.IntegerPart=value.Substring(0,percentIndex);
					this.FractionalPart=value.Substring(currencyIndex+this.Nfi.CurrencyDecimalSeparator.Length);
					if(this.FractionalPart.IndexOf(this.Nfi.PercentDecimalSeparator,StringComparison.CurrentCulture)>-1) {
						throw new FormatException();
					}
				} else {
					this.IntegerPart=value;
				}
			} else {
				if(currencyIndex>-1||numberIndex>-1||percentIndex>-1) {
					throw new FormatException();
				}
				this.IntegerPart=value;
			}

			var fractionalPartLength = this.FractionalPart.Length;

			this.Numerator=this.PartParse(this.FractionalPart,this.PartParse(this.IntegerPart,BigUInteger.Zero));

			if(this.ExponentPartSign) {
				this.Denominator=Math.Pow(BigUInteger.Ten,this.ExponentPart+fractionalPartLength);
			} else if(this.ExponentPart>fractionalPartLength) {
				this.Denominator=BigUInteger.One;
				this.Numerator*=Math.Pow(BigUInteger.Ten,this.ExponentPart-fractionalPartLength);
			} else {
				this.Denominator=Math.Pow(BigUInteger.Ten,fractionalPartLength-this.ExponentPart);
			}

		}

		/// <summary>
		/// 指定したスタイルおよびカルチャ固有の書式の数値の文字列形式を、それと等価の BigUIntegerと符号のペア に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		private (bool Sign,BigUInteger Value) ParseBigUIntegerAndSign(string value) {

			value=value.ToUpper(this.CultureInfo);

			this.PrePerceCheck(value);

			value=ParseTrimer(value);

			(this.Sign, value)=this.PerceSymbole(value);

			this.Parse(value);

			return (Sign,this.Numerator/this.Denominator);
		}

		/// <summary>
		/// 指定したスタイルおよびカルチャ固有の書式の数値の文字列形式を、それと等価の BigUInteger に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public BigUInteger ParseBigUInteger(string value) {

			value=value.ToUpper(this.CultureInfo);

			this.PrePerceCheck(value);

			value=ParseTrimer(value);

			(this.Sign, value)=this.PerceSymbole(value);

			this.Parse(value);

			if(this.Sign&&this.Numerator>0) {
				throw new OverflowException();
			}

			return this.Numerator/this.Denominator;
		}

		/// <summary>
		/// 指定したスタイルおよびカルチャ固有の書式の数値の文字列形式を、それと等価の Rational に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public Rational ParseRational(string value) {

			value=value.ToUpper(this.CultureInfo);

			this.PrePerceCheck(value);

			value=ParseTrimer(value);

			if(value==this.Nfi.NaNSymbol) {
				return Rational.NaN;
			}

			(this.Sign, value)=this.PerceSymbole(value);

			this.Parse(value);

			return new Rational(this.Sign,this.Numerator,this.Denominator);
		}

		/// <summary>
		/// 文字列にスペースが含まれているかチェックする
		/// </summary>
		/// <param name="value">スペースが含まれているかチェックする文字列</param>
		/// <returns>チェック結果（含まれている場合はtrue、それ以外の場合はfalse）</returns>
		private static bool FindSpace(string value) {
			foreach(var findTarget in SpaceList) {
				if(value.IndexOf(findTarget)>-1) {
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// パースができるか事前チェックを行います。
		/// </summary>
		/// <param name="value">チェック対象の文字列。</param>
		private void PrePerceCheck(string value) {
			//TODO:パーサーの前空白、後ろ空白の許容非許容の処理が不適切　空白の許容範囲が広くなりすぎるだけなので演算上無害ではあるが…
			/*if(!AllowLeadingWhite&&FindSpace(value)) {
				throw new FormatException();
			}
			if(!AllowTrailingWhite&&FindSpace(value)) {
				throw new FormatException();
			}
			if(!AllowLeadingSign&&(value.IndexOf(this.Nfi.PositiveSign,StringComparison.CurrentCulture)>-1||value.IndexOf(this.Nfi.NegativeSign,StringComparison.CurrentCulture)>-1)) {
				throw new FormatException();
			}
			if(!AllowTrailingSign&&(value.IndexOf(this.Nfi.PositiveSign,StringComparison.CurrentCulture)>-1||value.IndexOf(this.Nfi.NegativeSign,StringComparison.CurrentCulture)>-1)) {
				throw new FormatException();
			}*/
			if(!AllowLeadingWhite&&!AllowTrailingWhite&&FindSpace(value)) {
				throw new FormatException();
			}
			if(!AllowLeadingSign&&!AllowTrailingSign&&(value.IndexOf(this.Nfi.PositiveSign,StringComparison.CurrentCulture)>-1||value.IndexOf(this.Nfi.NegativeSign,StringComparison.CurrentCulture)>-1)) {
				throw new FormatException();
			}
			if(!AllowParentheses&&(value.IndexOf("(",StringComparison.CurrentCulture)>-1||value.IndexOf(")",StringComparison.CurrentCulture)>-1)) {
				throw new FormatException();
			}
			if(!AllowDecimalPoint&&value.IndexOf(this.Nfi.CurrencyDecimalSeparator,StringComparison.CurrentCulture)>-1) {
				throw new FormatException();
			}
			if(!AllowThousands&&value.IndexOf(this.Nfi.NumberGroupSeparator,StringComparison.CurrentCulture)>-1) {
				throw new FormatException();
			}
			if(!AllowExponent&&value.IndexOf("E",StringComparison.CurrentCulture)>-1) {
				throw new FormatException();
			}
			if(!AllowCurrencySymbol&&value.IndexOf(this.Nfi.CurrencySymbol,StringComparison.CurrentCulture)>-1) {
				throw new FormatException();
			}

			if(AllowExponent) {
				if(!AllowDecimalPoint) {
					throw new FormatException();
				}
			}

		}

		/// <summary>
		/// 符号ををパースします。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <returns>符号（整数の場合はfalse、負数の場合はtrue）。符号を取り外した数値を含んだ文字列。</returns>
		private (bool Sign, string Value) PerceSymbole(string value) {

			var sign = false;
			var allowSignCheck = true;
			var allowSymboleCheck = true;

			if(AllowParentheses) {
				var startIndex = value.IndexOf("(",StringComparison.CurrentCulture);
				var endIndex = value.IndexOf(")",StringComparison.CurrentCulture);
				if(startIndex==0&&endIndex==value.Length-1) {
					value=value[1..^1];
					sign=true;
					allowSignCheck=false;
				}
			}
			value=ParseTrimer(value);

			bool tmpSign;
			(value, tmpSign, allowSignCheck)=CheckSign(value,allowSignCheck);
			sign|=tmpSign;
			value=ParseTrimer(value);

			if(allowSymboleCheck&&AllowCurrencySymbol) {
				if(value.Substring(0,1)==this.Nfi.CurrencySymbol) {
					value=value[1..];
					allowSymboleCheck=false;
				}
			}
			if(allowSymboleCheck&&AllowCurrencySymbol) {
				var signStartPoint = value.Length-2;
				if(value.Substring(signStartPoint,1)==this.Nfi.CurrencySymbol) {
					value=value[0..^1];
					//allowSymboleCheck=false;
				}
			}
			value=ParseTrimer(value);

			//(value, tmpSign, allowSignCheck)=CheckSign(value,allowSignCheck,AllowLeadingSign,AllowTrailingSign,this.Nfi);
			(value, tmpSign, _)=CheckSign(value,allowSignCheck);
			sign|=tmpSign;
			value=ParseTrimer(value);

			return (sign, value);

		}

		/// <summary>
		/// 指数部のパースします。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <returns></returns>
		private string ParceExponentPart(string value) {

			this.ExponentPart=BigUInteger.Zero;
			if(AllowExponent) {
				var upperSplitedValue = value.Split('E');
				var lowerSplitedValue = value.Split('e');

				if(upperSplitedValue.Length>2||lowerSplitedValue.Length>2) {
					throw new FormatException();
				}
				if(upperSplitedValue.Length==2) {
					if(lowerSplitedValue.Length==2) {
						throw new FormatException();
					}
					value=upperSplitedValue[0];
					(this.ExponentPartSign, this.ExponentPart)=new Parser(NumberStyles.Number|NumberStyles.AllowExponent,Nfi).ParseBigUIntegerAndSign(upperSplitedValue[1]);
				} else if(lowerSplitedValue.Length==2) {
					value=lowerSplitedValue[0];
					(this.ExponentPartSign, this.ExponentPart)=new Parser(NumberStyles.Number|NumberStyles.AllowExponent,Nfi).ParseBigUIntegerAndSign(lowerSplitedValue[1]);
				}

			}

			return value;

		}

		/// <summary>
		/// 現時点で符号が使用可能かチェックします。
		/// </summary>
		/// <param name="value">チェック対象の文字列</param>
		/// <param name="allowSignCheck">チェック前の時点で符号が使用可能かを示す値。</param>
		/// <returns>符号が使用可能かを示す値（使用可能な場合はtrue、それ以外の場合はfalse）</returns>
		private (string value, bool Sign, bool AllowSignCheck) CheckSign(string value,bool allowSignCheck) {
			var sign = false;
			if(allowSignCheck&&AllowLeadingSign) {
				if(value.Substring(0,1)==Nfi.NegativeSign) {
					value=value[1..];
					sign=true;
					allowSignCheck=false;
				} else if(value.Substring(0,1)==Nfi.PositiveSign) {
					value=value[1..];
					allowSignCheck=false;
				}
			}
			if(allowSignCheck&&AllowTrailingSign) {
				var signStartPoint = value.Length-2;
				if(value.Substring(signStartPoint,1)==Nfi.NegativeSign||value.Substring(signStartPoint,1)==Nfi.PositiveSign) {
					value=value[0..^1];
					sign=true;
					allowSignCheck=false;
				}
			}
			return (value, sign, allowSignCheck);
		}

		/// <summary>
		/// 文字列の中に含まれる空白を削除する。
		/// </summary>
		/// <param name="value">空白を削除したい文字列。</param>
		/// <returns>空白を削除した結果文字列。</returns>
		private string ParseTrimer(string value) {
			if(AllowLeadingWhite) {
				value=value.TrimStart(SpaceList);
			}
			if(AllowTrailingWhite) {
				value=value.TrimEnd(SpaceList);
			}
			return value;
		}

		/// <summary>
		/// ContanerTypeに確実に格納可能な最大桁数の数値に分割した文字列を順次格納し、先行する値とマージする。
		/// </summary>
		/// <param name="source">パース対象の文字列。</param>
		/// <param name="parcedValue">事前にパース済みの値。</param>
		/// <returns>事前にパース済みの値に追加でパースした値をマージした値。</returns>
		private BigUInteger PartParse(string source,BigUInteger parcedValue) {

			while(!string.IsNullOrEmpty(source)) {
				if(source.Length<=BigUInteger.DecimalChunkOder) {
					parcedValue*=new BigUInteger((ContainerType)System.Math.Pow(10,source.Length));
					parcedValue+=new BigUInteger(ContainerType.Parse(source,this.Nfi));
					source=string.Empty;
				} else {
					parcedValue*=BigUInteger.DecimalChunkShifter;
					parcedValue+=new BigUInteger(ContainerType.Parse(source.Substring(0,BigUInteger.DecimalChunkOder),this.Nfi));
					source=source.Substring(BigUInteger.DecimalChunkOder);
				}
			}

			return parcedValue;
		}

		/// <summary>
		/// 文字列の先頭に空白が存在する事を許容するかを示す値。
		/// </summary>
		private bool AllowLeadingWhite {
			get;
		}

		/// <summary>
		/// 文字列の末尾に空白が存在する事を許容するかを示す値。
		/// </summary>
		private bool AllowTrailingWhite {
			get;
		}

		/// <summary>
		/// 文字列の先頭に符号を付ける事を許容するかを示す値。
		/// </summary>
		private bool AllowLeadingSign {
			get;
		}

		/// <summary>
		/// 文字列の末尾に符号を付ける事を許容するかを示す値。
		/// </summary>
		private bool AllowTrailingSign {
			get;
		}

		/// <summary>
		/// パーセント記号を許容するかを示す値。
		/// </summary>
		private bool AllowParentheses {
			get;
		}

		/// <summary>
		/// 小数点を許容するかを示す値。
		/// </summary>
		private bool AllowDecimalPoint {
			get;
		}

		/// <summary>
		/// グループ区切り記号を許容するかを示す値。
		/// </summary>
		private bool AllowThousands {
			get;
		}

		/// <summary>
		/// 指数記号を許容するかを示す値。
		/// </summary>
		private bool AllowExponent {
			get;
		}

		/// <summary>
		/// 通貨記号を許容するかを示す値。
		/// </summary>
		private bool AllowCurrencySymbol {
			get;
		}

		/// <summary>
		/// 16進数表記を許容するかを示す値。
		/// </summary>
		private bool AllowHexSpecifier {
			get;
		}

		/// <summary>
		/// カルチャ固有の書式の数値の文字列形式を示すオブジェクト。
		/// </summary>
		private CultureInfo CultureInfo {
			get;
		}

		/// <summary>
		/// カルチャ固有の書式情報を提供するオブジェクト。</param>
		/// </summary>
		private NumberFormatInfo Nfi {
			get;
		}

		/// <summary>
		/// 指数部の符号。
		/// </summary>
		private bool ExponentPartSign {
			get;
			set;
		} = false;

		/// <summary>
		/// 指数部。
		/// </summary>
		private BigUInteger ExponentPart {
			get;
			set;
		} = BigUInteger.Zero;

		/// <summary>
		/// 小数部。
		/// </summary>
		private string FractionalPart {
			get;
			set;
		}

		/// <summary>
		/// 整数部。
		/// </summary>
		private string IntegerPart {
			get;
			set;
		}

		/// <summary>
		/// 分母
		/// </summary>
		private BigUInteger Denominator {
			get;
			set;
		}

		/// <summary>
		/// 分子
		/// </summary>
		private BigUInteger Numerator {
			get;
			set;
		}

		/// <summary>
		/// 符号
		/// </summary>
		internal bool Sign {
			get;
			set;
		}

		/// <summary>
		/// スペースとして扱う文字のリスト。
		/// </summary>
		private static char[] SpaceList {
			get;
		} = new char[] { Convert.ToChar(0x000A),Convert.ToChar(0x000B),Convert.ToChar(0x000C),Convert.ToChar(0x000D),Convert.ToChar(0x0020),Convert.ToChar(0x0009) };

	}
}
#endif