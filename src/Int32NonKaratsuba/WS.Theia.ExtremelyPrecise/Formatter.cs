#if !DEBUG||DLLDEBUG
using System;
using System.Globalization;
using System.Text;

namespace WS.Theia.ExtremelyPrecise {
	/// <summary>
	/// 指定された書式とカルチャ固有の書式情報を使用して、現在の Rational オブジェクトの数値をそれと等価の文字列形式に変換します。
	/// </summary>
	internal class Formatter {

		/// <summary>
		/// フォーマッターを初期化します。
		/// </summary>
		/// <param name="format">標準またはカスタムの数値書式指定文字列。</param>
		/// <param name="provider">カルチャ固有の書式情報を提供するオブジェクト。</param>
		public Formatter(string format,IFormatProvider provider) {
			this.Provider=provider;
			var nfi = NumberFormatInfo.GetInstance(provider);
			var cultureInfo = CultureInfo.CurrentCulture;
			format??="G";
			var type = format.Substring(0,1);
			this.Type=type.ToUpper(cultureInfo);

			this.NaNSymbol=nfi.NaNSymbol;
			this.NegativeInfinitySymbol=nfi.NegativeInfinitySymbol;
			this.PositiveInfinitySymbol=nfi.PositiveInfinitySymbol;

			if(this.Type=="C") {
				this.DecimalDigits=nfi.CurrencyDecimalDigits;
				this.DecimalSeparator=nfi.CurrencyDecimalSeparator;
				this.GroupSeparator=nfi.CurrencyGroupSeparator;
				this.GroupSizes=nfi.CurrencyGroupSizes;
				this.NegativePattern=nfi.CurrencyNegativePattern;
				this.NegativeSign=nfi.NegativeSign;
				this.PositivePattern=nfi.CurrencyPositivePattern;
				this.Symbol=nfi.CurrencySymbol;
			} else if(this.Type=="D") {
				if(format.Length>1) {
					throw new FormatException();
				}
				this.DecimalDigits=0;
				this.NegativeSign=nfi.NegativeSign;
				this.NegativePattern=nfi.NumberNegativePattern;
				return;
			} else if(this.Type=="E") {
				this.DecimalDigits=Rational.Accuracy;
				this.DecimalSeparator=nfi.NumberDecimalSeparator;
				this.NegativeSign=nfi.NegativeSign;
				this.PositiveSign=nfi.PositiveSign;
				this.Symbol=type;
			} else if(this.Type=="F") {
				this.DecimalDigits=nfi.NumberDecimalDigits;
				this.DecimalSeparator=nfi.NumberDecimalSeparator;
				this.NegativeSign=nfi.NegativeSign;
				this.NegativePattern=nfi.NumberNegativePattern;
			} else if(this.Type=="G") {
				this.DecimalDigits=Rational.Accuracy;
				this.DecimalSeparator=nfi.NumberDecimalSeparator;
				this.NegativeSign=nfi.NegativeSign;
				this.NegativePattern=nfi.NumberNegativePattern;
				this.PositiveSign=nfi.PositiveSign;
				this.Symbol=type=="g" ? "e" : "E";
			} else if(this.Type=="N") {
				this.DecimalDigits=nfi.NumberDecimalDigits;
				this.DecimalSeparator=nfi.NumberDecimalSeparator;
				this.GroupSeparator=nfi.NumberGroupSeparator;
				this.GroupSizes=nfi.NumberGroupSizes;
				this.NegativeSign=nfi.NegativeSign;
				this.NegativePattern=nfi.NumberNegativePattern;
			} else if(this.Type=="P") {
				this.DecimalDigits=nfi.PercentDecimalDigits;
				this.DecimalSeparator=nfi.PercentDecimalSeparator;
				this.GroupSeparator=nfi.PercentGroupSeparator;
				this.GroupSizes=nfi.PercentGroupSizes;
				this.NegativePattern=nfi.PercentNegativePattern;
				this.NegativeSign=nfi.NegativeSign;
				this.PositivePattern=nfi.PercentPositivePattern;
				this.Symbol=nfi.PercentSymbol;
			} else if(this.Type=="R") {
				this.DecimalDigits=Rational.Accuracy;
				this.DecimalSeparator=nfi.NumberDecimalSeparator;
				this.NegativeSign=nfi.NegativeSign;
				this.NegativePattern=nfi.NumberNegativePattern;
				this.PositiveSign=nfi.PositiveSign;
				this.Type="G";
				this.Symbol=type=="r" ? "e" : "E";
			} else {
				throw new FormatException();
			}

			if(format.Length>1) {
				try {
					this.DecimalDigits=int.Parse(format.Substring(1),provider);
				} catch(Exception ex) {
					//TODO:メッセージ何とかする
					throw new FormatException("",ex);
				}
			}

			return;
		}

		/// <summary>
		/// 指定された書式とカルチャ固有の書式情報を使用して、現在の BigUInteger オブジェクトの数値をそれと等価の文字列形式に変換します。
		/// </summary>
		/// <param name="value">BigUInteger オブジェクトの数値</param>
		/// <returns>Rational オブジェクトの数値を等価の文字列形式。</returns>
		public string Format(BigUInteger value) {

			this.Result.Clear();

			if(this.Type=="C") {
				this.TypeCFormat(value);
			} else if(this.Type=="D") {
				this.TypeDFormat(value);
			} else if(this.Type=="E") {
				this.TypeEFormat(value);
			} else if(this.Type=="F") {
				this.TypeFFormat(value);
			} else if(this.Type=="G") {
				this.TypeGFormat(value);
			} else if(this.Type=="N") {
				this.TypeNFormat(value);
			} else {
				this.TypePFormat(value);
			}

			return this.Result.ToString();

		}

		/// <summary>
		/// 指定された書式とカルチャ固有の書式情報を使用して、現在の Rational オブジェクトの数値をそれと等価の文字列形式に変換します。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		/// <returns>Rational オブジェクトの数値を等価の文字列形式。</returns>
		public string Format(Rational value) {

			if(Rational.IsNaN(value)) {
				return this.NaNSymbol;
			} else if(Rational.IsInfinity(value)) {
				return value.Sign ? this.NegativeInfinitySymbol : this.PositiveInfinitySymbol;
			}

			this.Result.Clear();

			if(this.Type=="C") {
				this.TypeCFormat(value);
			} else if(this.Type=="D") {
				this.TypeDFormat(value);
			} else if(this.Type=="E") {
				this.TypeEFormat(value);
			} else if(this.Type=="F") {
				this.TypeFFormat(value);
			} else if(this.Type=="G") {
				this.TypeGFormat(value);
			} else if(this.Type=="N") {
				this.TypeNFormat(value);
			} else {
				this.TypePFormat(value);
			}

			return this.Result.ToString();

		}

		/// <summary>
		/// フォーマットタイプがCの場合の処理。
		/// </summary>
		private void TypeCFormat() {

			this.GroupingNumberFormat();
			if(this.Sign) {
				if(this.NegativePattern==0) {
					//00	($n)
					this.SymboleBefore();
					this.Parentheses();
				} else if(this.NegativePattern==1) {
					//01	-$n
					this.SymboleBefore();
					this.SignBefore();
				} else if(this.NegativePattern==2) {
					//02	$ n
					this.SymboleSpaceBefore();
				} else if(this.NegativePattern==3) {
					//03	$n-
					this.SymboleBefore();
					this.SignAfter();
				} else if(this.NegativePattern==4) {
					//04	(n $)
					this.SymboleSpaceAfter();
					this.Parentheses();
				} else if(this.NegativePattern==5) {
					//05	-n$
					this.SignBefore();
					this.SymboleAfter();
				} else if(this.NegativePattern==6) {
					//06	n $
					this.SymboleSpaceAfter();
				} else if(this.NegativePattern==7) {
					//07	n$-
					this.SymboleAfter();
					this.SignAfter();
				} else if(this.NegativePattern==8) {
					//08	-n $
					this.SignBefore();
					this.SymboleSpaceAfter();
				} else if(this.NegativePattern==9) {
					//09	-$ n
					this.SymboleSpaceBefore();
					this.SignBefore();
				} else if(this.NegativePattern==10) {
					//10	n $-
					this.SymboleSpaceAfter();
					this.SignAfter();
				} else if(this.NegativePattern==11) {
					//11	$-n
					this.SignBefore();
					this.SymboleBefore();
				} else if(this.NegativePattern==12) {
					//12	$ -n
					this.SignBefore();
					this.SymboleSpaceBefore();
				} else if(this.NegativePattern==13) {
					//13	n-$
					this.SignAfter();
					this.SymboleAfter();
				} else if(this.NegativePattern==14) {
					//14	($ n)
					this.SymboleSpaceBefore();
					this.Parentheses();
				} else {
					//16	(n $)
					this.SymboleSpaceAfter();
					this.Parentheses();
				}
			} else {
				if(this.PositivePattern==0) {
					//00	$n
					this.SymboleBefore();
				} else if(this.PositivePattern==1) {
					//01	n$
					this.SymboleAfter();
				} else if(this.PositivePattern==2) {
					//02	$ n
					this.SymboleSpaceBefore();
				} else {
					//03	n $
					this.SymboleSpaceAfter();
				}
			}

		}

		/// <summary>
		/// フォーマットタイプがCの場合の処理。
		/// </summary>
		/// <param name="value">BigUInteger オブジェクトの数値</param>
		private void TypeCFormat(BigUInteger value) {
			this.PartSplitter(value);
			this.TypeCFormat();
		}

		/// <summary>
		/// フォーマットタイプがCの場合の処理。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		private void TypeCFormat(Rational value) {
			this.PartSplitter(value);
			this.TypeCFormat();
		}

		/// <summary>
		/// フォーマットタイプがDの場合の処理。
		/// </summary>
		private void TypeDFormat() {

			this.Result.Append(IntegerPartFormat());
			this.NumericNegativePattern();

		}

		/// <summary>
		/// フォーマットタイプがDの場合の処理。
		/// </summary>
		/// <param name="value">BigUInteger オブジェクトの数値</param>
		private void TypeDFormat(BigUInteger value) {

			//TODO:DIVREMと/で速度が違う場合は分離する
			this.PartSplitter(value);
			this.TypeDFormat();

		}

		/// <summary>
		/// フォーマットタイプがDの場合の処理。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		private void TypeDFormat(Rational value) {

			//TODO:DIVREMと/で速度が違う場合は分離する
			this.PartSplitter(value);
			this.TypeDFormat();

		}

		/// <summary>
		/// フォーマットタイプがEの場合の処理。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		private void TypeEFormat(BigUInteger value) {
			this.TypeEFormat(new Rational(false,value,BigUInteger.One));
		}

			/// <summary>
			/// フォーマットタイプがEの場合の処理。
			/// </summary>
			/// <param name="value">Rational オブジェクトの数値</param>
			private void TypeEFormat(Rational value) {

			var exponent = Rational.Zero;
			while(value>=Rational.Ten) {
				value/=Rational.Ten;
				exponent++;
			}
			while(value<Rational.One) {
				value*=Rational.Ten;
				exponent--;
			}
			this.PartSplitter(value);
			this.NonGroupingNumberFormat();
			if(this.Sign) {
				this.SignBefore();
			}
			this.SymboleAfter();
			this.Result.Append(exponent<0 ? this.NegativeSign : this.PositiveSign);
			this.Result.Append(Math.Abs(exponent).ToString("G",this.Provider));

		}

		/// <summary>
		/// フォーマットタイプがFの場合の処理。
		/// </summary>
		private void TypeFFormat() {

			this.NonGroupingNumberFormat();
			this.NumericNegativePattern();

		}

		/// <summary>
		/// フォーマットタイプがFの場合の処理。
		/// </summary>
		/// <param name="value">BigUInteger オブジェクトの数値</param>
		private void TypeFFormat(BigUInteger value) {

			this.PartSplitter(value);
			this.TypeFFormat();

		}

		/// <summary>
		/// フォーマットタイプがFの場合の処理。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		private void TypeFFormat(Rational value) {

			this.PartSplitter(value);
			this.TypeFFormat();

		}

		/// <summary>
		/// フォーマットタイプがGの場合の処理。
		/// </summary>
		private void TypeGFormat() {

			this.NonGroupingNumberFormat();
			this.NumericNegativePattern();

		}

		/// <summary>
		/// フォーマットタイプがGの場合の処理。
		/// </summary>
		/// <param name="value">BigUInteger オブジェクトの数値</param>
		private void TypeGFormat(BigUInteger value) {

			this.PartSplitter(value);
			this.TypeGFormat();

		}

		/// <summary>
		/// フォーマットタイプがGの場合の処理。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		private void TypeGFormat(Rational value) {

			this.PartSplitter(value);
			this.TypeGFormat();

		}

		/// <summary>
		/// フォーマットタイプがNの場合の処理。
		/// </summary>
		private void TypeNFormat() {

			this.GroupingNumberFormat();
			this.NumericNegativePattern();

		}

		/// <summary>
		/// フォーマットタイプがNの場合の処理。
		/// </summary>
		/// <param name="value">BigUInteger オブジェクトの数値</param>
		private void TypeNFormat(BigUInteger value) {

			this.PartSplitter(value);
			this.TypeNFormat();

		}

		/// <summary>
		/// フォーマットタイプがNの場合の処理。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		private void TypeNFormat(Rational value) {

			this.PartSplitter(value);
			this.TypeNFormat();

		}

		/// <summary>
		/// フォーマットタイプがPの場合の処理。
		/// </summary>
		private void TypePFormat() {

			this.GroupingNumberFormat();
			if(this.Sign) {
				if(this.NegativePattern==0) {
					//00	-n %
					this.SignBefore();
					this.SymboleSpaceAfter();
				} else if(this.NegativePattern==1) {
					//01	-n%
					this.SignBefore();
					this.SymboleAfter();
				} else if(this.NegativePattern==2) {
					//02	-%n
					this.SymboleBefore();
					this.SignBefore();
				} else if(this.NegativePattern==3) {
					//03	%-n
					this.SignBefore();
					this.SymboleBefore();
				} else if(this.NegativePattern==4) {
					//04	%n-
					this.SymboleBefore();
					this.SignAfter();
				} else if(this.NegativePattern==5) {
					//05	n-%
					this.SignAfter();
					this.SymboleAfter();
				} else if(this.NegativePattern==6) {
					//06	n%-
					this.SymboleAfter();
					this.SignAfter();
				} else if(this.NegativePattern==7) {
					//07	-% n
					this.SymboleSpaceBefore();
					this.SignBefore();
				} else if(this.NegativePattern==8) {
					//08	n %-
					this.SymboleAfter();
					this.SignAfter();
				} else if(this.NegativePattern==9) {
					//09	% n-
					this.SymboleSpaceBefore();
					this.SignAfter();
				} else if(this.NegativePattern==10) {
					//10	% -n
					this.SignBefore();
					this.SymboleSpaceBefore();
				} else {
					//11	n- %
					this.SignAfter();
					this.SymboleSpaceAfter();
				}
			} else {
				if(this.PositivePattern==0) {
					//00	n %
					this.SymboleSpaceAfter();
				} else if(this.PositivePattern==1) {
					//01	n%
					this.SymboleAfter();
				} else if(this.PositivePattern==2) {
					//02	% n
					this.SymboleSpaceBefore();
				} else {
					//03	%n
					this.SymboleBefore();
				}
			}

		}

		/// <summary>
		/// フォーマットタイプがPの場合の処理。
		/// </summary>
		/// <param name="value">BigUInteger オブジェクトの数値</param>
		private void TypePFormat(BigUInteger value) {

			this.PartSplitter(value*100);
			this.TypePFormat();

		}

		/// <summary>
		/// フォーマットタイプがPの場合の処理。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		private void TypePFormat(Rational value) {

			this.PartSplitter(value*100);
			this.TypePFormat();

		}

		/// <summary>
		/// Rationalオブジェクトの値を、整数部と小数部に分離します。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		private void PartSplitter(Rational value) {
			this.Sign=value.Sign;
			var rvalue = Math.Round(value,this.DecimalDigits,MidpointRounding.AwayFromZero);
			(this.IntegerPart, this.FractionalPart)=Math.DivRem(rvalue.Numerator,rvalue.Denominator);
		}

		/// <summary>
		/// Rationalオブジェクトの値を、整数部と小数部に分離します。
		/// </summary>
		/// <param name="value">Rational オブジェクトの数値</param>
		private void PartSplitter(BigUInteger value) {
			this.Sign=false;
			this.IntegerPart=value;
			this.FractionalPart=BigUInteger.Zero;
		}

		/// <summary>
		/// カンマ区切り等のグループ化しないフォーマットを行います。
		/// </summary>
		private void NonGroupingNumberFormat() {
			this.Result.Append(IntegerPartFormat());
			if(!this.FractionalPart.IsZero) {
				this.Result.Append(this.DecimalSeparator);
				this.Result.Append(FractionalPartFormat());
			}
		}

		/// <summary>
		/// カンマ区切り等のグループ化するフォーマットを行います。
		/// </summary>
		private void GroupingNumberFormat() {
			this.Result.Append(InsertGroupSeparator(IntegerPartFormat()));
			if(!this.FractionalPart.IsZero) {
				this.Result.Append(this.DecimalSeparator);
				this.Result.Append(FractionalPartFormat());
			}
		}

		/// <summary>
		/// 整数部のフォーマットを行います。
		/// </summary>
		/// <returns>整数部のフォーマット結果文字列。</returns>
		private StringBuilder IntegerPartFormat() {
			var result = new StringBuilder();
			BigUInteger cuttedValue;
			while(!this.IntegerPart.IsZero) {
				(this.IntegerPart, cuttedValue)=Math.DivRem(this.IntegerPart,BigUInteger.DecimalChunkShifter);
				if(this.IntegerPart.IsZero) {
					result.Insert(0,cuttedValue.Value[0].ToString(this.Provider));
				} else {
					result.Insert(0,cuttedValue.Value[0].ToString("D"+BigUInteger.DecimalChunkOder,this.Provider));
				}
			}
			if(result.Length==0) {
				result.Append("0");
			}
			return result;
		}

		/// <summary>
		/// 小数部のフォーマットを行います。
		/// </summary>
		/// <returns>小数部のフォーマット結果文字列。</returns>
		private string FractionalPartFormat() {
			var result = new StringBuilder();
			var infrator = Rational.RoundInfrator;

			BigUInteger cuttedValue;

			while(infrator>BigUInteger.DecimalChunkShifter) {
				infrator/=BigUInteger.DecimalChunkShifter;
				(cuttedValue, this.FractionalPart)=Math.DivRem(this.FractionalPart,infrator);
				result.Append(cuttedValue.Value[0].ToString("D"+BigUInteger.DecimalChunkOder,this.Provider));
				if(this.FractionalPart.IsZero) {
					return result.ToString().TrimEnd(new char[] { '0' });
				}
			}

			var fractionalPartOder = Rational.Accuracy%BigUInteger.DecimalChunkOder;
			if(fractionalPartOder!=0) {
				result.Append(this.FractionalPart.Value[0].ToString("D"+fractionalPartOder,this.Provider));
			}


			return result.ToString().TrimEnd(new char[] { '0' });
		}

		/// <summary>
		/// カンマ区切り等のグループ化を行います。
		/// </summary>
		/// <param name="insertTarget">グループ化を行う文字列。</param>
		/// <returns>グループ化された文字列。</returns>
		private StringBuilder InsertGroupSeparator(StringBuilder insertTarget) {
			for(int groupSizeIndex = 0, groupSize = this.GroupSizes[groupSizeIndex], insertTargetIndex = insertTarget.Length-groupSize;insertTargetIndex>0;insertTargetIndex-=groupSize) {
				insertTarget.Insert(insertTargetIndex,this.GroupSeparator);
				groupSizeIndex++;
				if(this.GroupSizes.Length>groupSizeIndex) {
					groupSize=this.GroupSizes[groupSizeIndex];
				}
			}
			return insertTarget;
		}

		/// <summary>
		/// パーセント記号、通貨記号、指数記号を使わない場合の符号付加処理を行います。
		/// </summary>
		private void NumericNegativePattern() {
			if(!this.Sign) {
				return;
			}

			if(this.NegativePattern==0) {
				//00	(n)
				this.Parentheses();
			} else if(this.NegativePattern==1) {
				//01	-n
				this.SignBefore();
			} else if(this.NegativePattern==2) {
				//02	- n
				this.SignSpaceBefore();
			} else if(this.NegativePattern==3) {
				//03	n-
				this.SignAfter();
			} else {
				//04	n -
				this.SignSpaceAfter();
			}

		}

		/// <summary>
		/// 負数を符号の代わりにかっこで囲います。
		/// </summary>
		private void Parentheses() {
			this.Result.Insert(0,"(");
			this.Result.Append(")");
		}

		/// <summary>
		/// 負数の符号を、数字の前に空白なしで表現します。
		/// </summary>
		private void SignBefore() {
			this.Result.Insert(0,this.NegativeSign);
		}

		/// <summary>
		/// 負数の符号を、数字の前に空白付きで表現します。
		/// </summary>
		private void SignSpaceBefore() {
			this.Result.Insert(0,this.NegativeSign);
			this.Result.Insert(1," ");
		}

		/// <summary>
		/// 負数の符号を、数字の後ろに空白なしで表現します。
		/// </summary>
		private void SignAfter() {
			this.Result.Append(this.NegativeSign);
		}

		/// <summary>
		/// 負数の符号を、数字の後ろに空白付きで表現します。
		/// </summary>
		private void SignSpaceAfter() {
			this.Result.Append(" ");
			this.Result.Append(this.NegativeSign);
		}

		/// <summary>
		/// パーセント記号、通貨記号、指数記号を、数字の前に空白なしで表現します。
		/// </summary>
		private void SymboleBefore() {
			this.Result.Insert(0,this.Symbol);
		}

		/// <summary>
		/// パーセント記号、通貨記号、指数記号を、数字の前に空白付きで表現します。
		/// </summary>
		private void SymboleSpaceBefore() {
			this.Result.Insert(0,this.Symbol);
			this.Result.Insert(1," ");
		}

		/// <summary>
		/// パーセント記号、通貨記号、指数記号を、数字の前に空白後ろで表現します。
		/// </summary>
		private void SymboleAfter() {
			this.Result.Append(this.Symbol);
		}

		/// <summary>
		/// パーセント記号、通貨記号、指数記号を、数字の前に空白後ろで表現します。
		/// </summary>
		private void SymboleSpaceAfter() {
			this.Result.Append(" ");
			this.Result.Append(this.Symbol);
		}

		/// <summary>
		/// フォーマット対象の符号。
		/// </summary>
		private bool Sign {
			get;
			set;
		}

		/// <summary>
		/// フォーマット対象の整数部。
		/// </summary>
		private BigUInteger IntegerPart {
			get;
			set;
		}

		/// <summary>
		/// フォーマット対象の小数部。
		/// </summary>
		private BigUInteger FractionalPart {
			get;
			set;
		}

		/// <summary>
		/// フォーマットする際の小数部の長さ。
		/// </summary>
		private int DecimalDigits {
			get;
		}

		/// <summary>
		/// 小数点として使用する記号。
		/// </summary>
		private string DecimalSeparator {
			get;
		}

		/// <summary>
		/// 整数部のグループ区切り記号。
		/// </summary>
		private string GroupSeparator {
			get;
		}

		/// <summary>
		/// 整数部のグループサイズ。
		/// </summary>
		private int[] GroupSizes {
			get;
		}

		/// <summary>
		/// NaNを示す記号。
		/// </summary>
		private string NaNSymbol {
			get;
		}

		/// <summary>
		/// 負の無限大記号。
		/// </summary>
		private string NegativeInfinitySymbol {
			get;
		}

		/// <summary>
		/// 負数の表記方法。
		/// </summary>
		private int NegativePattern {
			get;
		}

		/// <summary>
		/// 負数を表すの符号。
		/// </summary>
		private string NegativeSign {
			get;
		}

		/// <summary>
		/// 正の無限大記号。
		/// </summary>
		private string PositiveInfinitySymbol {
			get;
		}

		/// <summary>
		/// 正数の表記方法。
		/// </summary>
		private int PositivePattern {
			get;
		}

		/// <summary>
		/// 正数を表す符号。
		/// </summary>
		private string PositiveSign {
			get;
		}

		/// <summary>
		/// 書式設定を制御するオブジェクトが取得できるオブジェクト。
		/// </summary>
		private IFormatProvider Provider {
			get;
		}

		/// <summary>
		/// フォーマット結果を格納するStringBuilder。
		/// </summary>
		private StringBuilder Result {
			get;
		} = new StringBuilder();

		/// <summary>
		/// パーセント記号、通貨記号、指数記号のいずれか。
		/// </summary>
		private string Symbol {
			get;
		}

		/// <summary>
		/// フォーマットするのタイプ。
		/// </summary>
		private string Type {
			get;
		}

	}
}
#endif