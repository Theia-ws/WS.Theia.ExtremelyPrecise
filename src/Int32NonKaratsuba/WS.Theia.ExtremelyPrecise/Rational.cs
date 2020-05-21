using System;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using ContainerType = System.UInt32;
using OuterInterfaceType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise {

	/// <summary>
	/// 任意の大きさを持つ有理数を、誤差を発生させずに表現します。
	/// </summary>
	[Serializable]
	public struct Rational:IComparable, IComparable<Rational>, IEquatable<Rational>, IFormattable {

		/// <summary>
		/// Boolean 値を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">Boolean値(true=One、false=Zeroと認識します)。</param>
		public Rational(bool value) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=value ? 1 : 0;
			this.Denominator=1;
#else
			this.Sign=false;
			this.Infinity=false;
			this.Numerator=value ? BigUInteger.One : BigUInteger.Zero;
			this.Denominator=BigUInteger.One;
#endif
		}

		/// <summary>
		/// バイト配列の値を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="sign">符号を示す値（false＝プラス、true=マイナス）。</param>
		/// <param name="numerator">分子を表すリトルエンディアン順に格納されたバイト値の配列。</param>
		/// <param name="denominator">分母を表すリトルエンディアン順に格納されたバイト値の配列。</param>
		public Rational(bool sign,byte[] numerator,byte[] denominator) {
#if DEBUG&&!DLLDEBUG
			//TODO:これあまり良い方法ではない
			this.Numerator=BitConverter.ToDouble(numerator,0)/BitConverter.ToDouble(denominator,0);
			this.Denominator=1d;
#else
			this.Sign=sign;
			this.Infinity=false;
			this.Numerator=new BigUInteger(numerator);
			this.Denominator=new BigUInteger(denominator);
#endif
		}

		/// <summary>
		/// Decimal 値を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">10 進数値。</param>
		public Rational(decimal value) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=(double)value;
			this.Denominator=1;
#else
			this.Sign=value<0;
			this.Infinity=false;
			var workAreaArrayy = value.ToString("E29",CultureInfo.CurrentCulture).Split(new string[] { "E" },StringSplitOptions.None);
			var nfi = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture);
			this.Numerator=BigUInteger.Parse(workAreaArrayy[0].Replace(nfi.NumberDecimalSeparator,"").Replace(nfi.NegativeSign,""));
			var exponential = int.Parse(workAreaArrayy[1],NumberStyles.Number,CultureInfo.CurrentCulture)-29;
			this.Denominator=Math.Pow(BigUInteger.Ten,-exponential);
			this.Trim();
#endif
		}

		/// <summary>
		/// 倍精度浮動小数点値を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">倍精度浮動小数点数値。</param>
		public Rational(double value) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=value;
			this.Denominator=1;
#else
			if(double.IsNegativeInfinity(value)) {
				this.Sign=true;
				this.Numerator=BigUInteger.One;
				this.Denominator=BigUInteger.One;
				this.Infinity=true;
				return;
			} else if(double.IsPositiveInfinity(value)) {
				this.Sign=false;
				this.Numerator=BigUInteger.One;
				this.Denominator=BigUInteger.One;
				this.Infinity=true;
				return;
			} else if(double.IsNaN(value)) {
				this.Sign=false;
				this.Numerator=BigUInteger.Zero;
				this.Denominator=BigUInteger.Zero;
				this.Infinity=false;
				return;
			}
			this.Sign=value<0;
			this.Infinity=false;
			var workAreaArrayy = value.ToString("E16",CultureInfo.CurrentCulture).Split(new string[] { "E" },StringSplitOptions.None);
			var nfi = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture);
			this.Numerator=BigUInteger.Parse(workAreaArrayy[0].Replace(nfi.NumberDecimalSeparator,"").Replace(nfi.NegativeSign,""));
			var exponential = int.Parse(workAreaArrayy[1],NumberStyles.Number,CultureInfo.CurrentCulture)-16;
			if(exponential>0) {
				this.Numerator*=Math.Pow(BigUInteger.Ten,exponential);
				this.Denominator=BigUInteger.One;
			} else {
				this.Denominator=Math.Pow(BigUInteger.Ten,-exponential);
			}
			this.Trim();
#endif
		}

		/// <summary>
		/// 32 ビット符号付き整数値を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">32 ビット符号付き整数値。</param>
		public Rational(int value) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=value;
			this.Denominator=1;
#else
			this.Sign=value<0;
			this.Infinity=false;
			if(value==int.MinValue) {
				this.Numerator=new BigUInteger(int.MaxValue)+BigUInteger.One;
			} else { 
				this.Numerator=new BigUInteger(System.Math.Abs(value));
			}
			this.Denominator=BigUInteger.One;
#endif
		}

		/// <summary>
		/// 64 ビット符号付き整数値を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">64 ビット符号付き整数値。</param>
		public Rational(long value) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=value;
			this.Denominator=1;
#else
			this.Sign=value<0;
			this.Infinity=false;
			if(value==long.MinValue) {
				this.Numerator=new BigUInteger(long.MaxValue)+BigUInteger.One;
			} else {
				this.Numerator=new BigUInteger(System.Math.Abs(value));
			}
			this.Denominator=BigUInteger.One;
#endif
		}

		/// <summary>
		/// 単精度浮動小数点値を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">単精度浮動小数点数値。</param>
		public Rational(float value) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=value;
			this.Denominator=1;
#else
			//TOTO:Rational.Multiply((Rational) Single.MaxValue, 2)の様な上限に近い値を初期化する時に失敗している可能性。Doubleにも同様の可能性あり
			if(float.IsNegativeInfinity(value)) {
				this.Sign=true;
				this.Numerator=BigUInteger.One;
				this.Denominator=BigUInteger.One;
				this.Infinity=true;
				return;
			} else if(float.IsPositiveInfinity(value)) {
				this.Sign=false;
				this.Numerator=BigUInteger.One;
				this.Denominator=BigUInteger.One;
				this.Infinity=true;
				return;
			} else if(float.IsNaN(value)) {
				this.Sign=false;
				this.Numerator=BigUInteger.Zero;
				this.Denominator=BigUInteger.Zero;
				this.Infinity=false;
				return;
			}
			this.Sign=value<0;
			this.Infinity=false;
			var workAreaArrayy = value.ToString("E7",CultureInfo.CurrentCulture).Split(new string[] { "E" },StringSplitOptions.None);
			var nfi = NumberFormatInfo.GetInstance(CultureInfo.CurrentCulture);
			this.Numerator=BigUInteger.Parse(workAreaArrayy[0].Replace(nfi.NumberDecimalSeparator,"").Replace(nfi.NegativeSign,""));
			var exponential = int.Parse(workAreaArrayy[1],NumberStyles.Number,CultureInfo.CurrentCulture)-7;
			if(exponential>0) {
				this.Numerator*=Math.Pow(BigUInteger.Ten,exponential);
				this.Denominator=BigUInteger.One;
			} else {
				this.Denominator=Math.Pow(BigUInteger.Ten,-exponential);
			}
			this.Trim();
#endif
		}

		/// <summary>
		/// 32 ビット符号なし整数値を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">32 ビットの符号なし整数値。</param>
		public Rational(uint value) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=value;
			this.Denominator=1;
#else
			this.Sign=false;
			this.Infinity=false;
			this.Numerator=new BigUInteger(value);
			this.Denominator=BigUInteger.One;
#endif
		}

		/// <summary>
		/// 64 ビット符号なし整数値を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">符号なし 64 ビット整数。</param>
		public Rational(ulong value) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=value;
			this.Denominator=1;
#else
			this.Sign=false;
			this.Infinity=false;
			this.Numerator=new BigUInteger(value);
			this.Denominator=BigUInteger.One;
#endif
		}

		/// <summary>
		/// BigUIntegerを使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="sign">符号</param>
		/// <param name="numerator">分子</param>
		/// <param name="denominator">分母</param>
		internal Rational(bool sign,BigUInteger numerator,BigUInteger denominator) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=(double)numerator.Value/(double)denominator.Value;
			this.Denominator=1d;
#else
			this.Sign=sign;
			this.Infinity=false;
			this.Numerator=numerator;
			this.Denominator=denominator;
#endif
		}

		//TODO:できればInternalにしたいな
		/// <summary>
		/// コンテナ配列を使用して、Rational 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="sign">符号</param>
		/// <param name="numerator">分子</param>
		/// <param name="denominator">分母</param>
		internal Rational(bool sign,ContainerType[] numerator,ContainerType[] denominator) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=(double)numerator[0]/(double)denominator[0];
			this.Denominator=1d;
#else
			this.Sign=sign;
			this.Infinity=false;
			this.Numerator=new BigUInteger(numerator);
			this.Denominator=new BigUInteger(denominator);
#endif
		}

		internal Rational(bool sign,OuterInterfaceType[] numerator,OuterInterfaceType[] denominator) {
#if DEBUG&&!DLLDEBUG
			this.Numerator=(double)numerator[0]/(double)denominator[0];
			this.Denominator=1d;
#else
			this.Sign=sign;
			this.Infinity=false;
			this.Numerator=new BigUInteger(numerator);
			this.Denominator=new BigUInteger(denominator);
#endif
		}

		/// <summary>
		/// 現在の Rational オブジェクトの値が偶数かどうかを示します。
		/// </summary>
		public bool IsEven {
			get {
#if DEBUG&&!DLLDEBUG
				return this.Numerator%2==0;
#else
				if(IsInfinity(this)||IsNaN(this)) {
					return false;
				}
				return (this%2).IsZero;
#endif
			}
		}

		/// <summary>
		/// 現在の Rational オブジェクトの値が One かどうかを示します。
		/// </summary>
		public bool IsOne {
			get {
#if DEBUG&&!DLLDEBUG
				return this.Numerator==this.Denominator;
#else
				if(IsInfinity(this)||this.Sign||IsNaN(this)) {
					return false;
				}

				return this.Numerator==this.Denominator;
#endif
			}
		}

		/// <summary>
		/// 現在の Rational オブジェクトの値が 2 の累乗かどうかを示します。
		/// </summary>
		public bool IsPowerOfTwo {
			get {
#if DEBUG&&!DLLDEBUG
				if(this.Numerator%1!=0) {
					return false;
				}
				var numTmp = this.Numerator;
				double remainder;
				while(numTmp>1) {
					remainder=numTmp%2;
					if(remainder>0) {
						return false;
					}
					numTmp/=2;
				}
				return true;
#else
				if(IsInfinity(this)||this.Sign||IsNaN(this)||this.IsZero) {
					return false;
				}
				var value = this.Trim();
				if(!value.Denominator.IsOne) {
					return false;
				}

				return (value&(value-1)).IsZero;

#endif
			}
		}

		/// <summary>
		/// 現在の Rational オブジェクトの値が Zero かどうかを示します。
		/// </summary>
		public bool IsZero {
			get {
#if DEBUG&&!DLLDEBUG
				return this.Numerator==0&&this.Denominator!=0;
#else
				return !this.Infinity&&!Rational.IsNaN(this)&&this.Numerator.IsZero;
#endif
			}
		}

		/// <summary>
		/// 負の 1 (-1) を表す値を取得します。
		/// </summary>
		public static Rational MinusOne {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= new Rational(-1);
#else
			= new Rational(true,BigUInteger.One,BigUInteger.One);
#endif

		/// <summary>
		/// 正の 1 (1) を表す値を取得します。
		/// </summary>
		public static Rational One {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= new Rational(1);
#else
			= new Rational(false,BigUInteger.One,BigUInteger.One);
#endif

		//TODO:Publicにしてもいいかも…
		/// <summary>
		/// 正の 10 (10) を表す値を取得します。
		/// </summary>
		internal static Rational Ten {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= new Rational(10);
#else
			= new Rational(false,BigUInteger.Ten,BigUInteger.One);
#endif

		//TODO:Publicにしてもいいかも…
		/// <summary>
		/// 正の 2 (2) を表す値を取得します。
		/// </summary>
		internal static Rational Tow {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= new Rational(2);
#else
			= new Rational(false,BigUInteger.Tow,BigUInteger.One);
#endif

		/// <summary>
		/// 0 (ゼロ) を表す値を取得します。
		/// </summary>
		public static Rational Zero {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= new Rational(0);
#else
			= new Rational(false,BigUInteger.Zero,BigUInteger.One);
#endif

		/// <summary>
		/// 非数(NaN) の値を表します。 このフィールドは定数です。
		/// </summary>
		public static Rational NaN {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= double.NaN;
#else
		= new Rational(false,BigUInteger.Zero,BigUInteger.Zero);
#endif

		/// <summary>
		/// 負の無限大を表します。 このフィールドは定数です。
		/// </summary>
		public static Rational NegativeInfinity {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= double.NegativeInfinity;
#else
		= new Rational(true,BigUInteger.One,BigUInteger.One) {
			Infinity=true
		};
#endif

		/// <summary>
		/// 正の無限大を表します。 このフィールドは定数です。
		/// </summary>
		public static Rational PositiveInfinity {
			get;
		}
#if DEBUG&&!DLLDEBUG
		 = double.PositiveInfinity;
#else
		= new Rational(false,BigUInteger.One,BigUInteger.One) {
			Infinity=true
		};
#endif

		/// <summary>
		/// 2 つの Rational 値を加算し、その結果を返します。
		/// </summary>
		/// <param name="left">加算する 1 番目の値。</param>
		/// <param name="right">加算する 2 番目の値。</param>
		/// <returns>left と right の合計。</returns>
		public static Rational Add(Rational left,Rational right) {
			return left+right;
		}

		/// <summary>
		/// 2 つの Rational 値に対し、ビットごとの And 演算を実行します。
		/// </summary>
		/// <param name="left">And演算する最初の値。</param>
		/// <param name="right">And演算する2 番目の値。</param>
		/// <returns>ビットごとの And 演算の結果。</returns>
		public static Rational BitwiseAnd(Rational left,Rational right) {
			return left&right;
		}

		/// <summary>
		/// 2 つの Rational 値に対し、ビットごとの Or 演算を実行します。
		/// </summary>
		/// <param name="left">Or演算する最初の値。</param>
		/// <param name="right">Or演算する2 番目の値。</param>
		/// <returns>ビットごとの Or 演算の結果。</returns>
		public static Rational BitwiseOr(Rational left,Rational right) {
			return left|right;
		}

		/// <summary>
		/// 2 つの Rational 値を比較し、1 番目の値が 2 番目の値よりも小さいか、同じか、または大きいかを示す整数を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>left と right の相対値を示す符号付き整数。</returns>
		public static int Compare(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator.CompareTo(right.Numerator);
#else

			if(IsNaN(left)) {
				return IsNaN(right) ? 0 : -1;
			} else if(IsNaN(right)) {
				return 1;
			}

			if(IsInfinity(left)) {
				if(left.Sign) {
					return IsNegativeInfinity(right) ? 0 : -1;
				}
				return IsPositiveInfinity(right) ? 0 : 1;
			} else if(IsInfinity(right)) {
				return right.Sign ? 1 : -1;
			}

			if(!left.Sign&&right.Sign) {
				return 1;
			}
			if(left.Sign&&!right.Sign) {
				return -1;
			}

			var (leftNumerator, rightNumerator)=Rational.NumeratorDenominatorUnification(left,right);

			return left.Sign ? leftNumerator.CompareTo(rightNumerator)*-1 : leftNumerator.CompareTo(rightNumerator);

#endif
		}

		/// <summary>
		/// Rational 値を複製します。
		/// </summary>
		/// <returns>複製したRational値のオブジェクト。</returns>
		public Rational Clone() {
#if DEBUG&&!DLLDEBUG
			return new Rational(this.Numerator);
#else
			if(IsInfinity(this)) {
				return this.Sign ? Rational.NegativeInfinity : Rational.PositiveInfinity;
			} else if(Rational.IsNaN(this)) {
				return Rational.NaN;
			}
			//TODO:Clone機能必要か検討する

			return new Rational(this.Sign,this.Numerator.Clone(),this.Denominator.Clone());

#endif
		}

		/// <summary>
		/// このインスタンスと 10 進数を比較し、このインスタンスの値が 10 進数の値よりも小さいか、同じか、または大きいかを示す整数を返します。
		/// </summary>
		/// <param name="other">比較する 10 進数。</param>
		/// <returns>このインスタンスと other の相対的な値を示す符号付き整数値です (次の表を参照)。 
		///戻り値
		///説明 
		///0 より小さい値
		///現在のインスタンスは other より小さい。 
		///0 
		///現在のインスタンスと other は等しい。 
		///0 より大きい値
		///現在のインスタンスは other より大きい。</returns>
		public int CompareTo(decimal other) {
#if DEBUG&&!DLLDEBUG
			Rational rationalOther = other;
			return this>rationalOther ? 1 : this==rationalOther ? 0 : -1;
#else
			return Compare(this,other);
#endif
		}

		/// <summary>
		/// このインスタンスと 倍精度浮動小数点数を比較し、このインスタンスの値が 倍精度浮動小数点数の値よりも小さいか、同じか、または大きいかを示す整数を返します。
		/// </summary>
		/// <param name="other">比較する 倍精度浮動小数点数。</param>
		/// <returns>このインスタンスと other の相対的な値を示す符号付き整数値です (次の表を参照)。 
		///戻り値
		///説明 
		///0 より小さい値
		///現在のインスタンスは other より小さい。 
		///0 
		///現在のインスタンスと other は等しい。 
		///0 より大きい値
		///現在のインスタンスは other より大きい。</returns>
		public int CompareTo(double other) {
#if DEBUG&&!DLLDEBUG
			Rational rationalOther = other;
			return this>rationalOther ? 1 : this==rationalOther ? 0 : -1;
#else
			return Compare(this,other);
#endif
		}

		/// <summary>
		/// このインスタンスと符号付き 64 ビット整数を比較し、このインスタンスの値が符号付き 64 ビット整数の値よりも小さいか、同じか、または大きいかを示す整数を返します。
		/// </summary>
		/// <param name="other">比較する符号付き 64 ビット整数。</param>
		/// <returns>このインスタンスと other の相対的な値を示す符号付き整数値です (次の表を参照)。 
		///戻り値
		///説明 
		///0 より小さい値
		///現在のインスタンスは other より小さい。 
		///0 
		///現在のインスタンスと other は等しい。 
		///0 より大きい値
		///現在のインスタンスは other より大きい。</returns>
		public int CompareTo(long other) {
#if DEBUG&&!DLLDEBUG
			Rational rationalOther = other;
			return this>rationalOther ? 1 : this==rationalOther ? 0 : -1;
#else
			return Compare(this,other);
#endif
		}

		/// <summary>
		/// このインスタンスと指定したオブジェクトを比較し、このインスタンスの値が指定したオブジェクトの値よりも小さいか、同じか、または大きいかを示す整数を返します。
		/// </summary>
		/// <param name="other">比較対象のオブジェクト。</param>
		/// <returns>現在のインスタンスと other パラメーターの関係を示す符号付き整数 (次の表を参照)。
		///戻り値
		///説明 
		///0 より小さい値
		///現在のインスタンスは other より小さい。 
		///0 
		///現在のインスタンスと other は等しい。 
		///0 より大きい値
		///現在のインスタンスは other より大きい。</returns>
		public int CompareTo(object other) {
#if DEBUG&&!DLLDEBUG
			try {
				var rationalOther = (Rational)other;
				return this>rationalOther ? 1 : this==rationalOther ? 0 : -1;
			} catch(Exception e) {
				throw new ArgumentException("",e);
			}
#else
			if(other==null) {
				return 1;
			}
			try {
				return Compare(this,(Rational)other);
			} catch(Exception e) {
				//TODO:メッセージ何とかする
				throw new ArgumentException("",e);
			}
#endif
		}

		/// <summary>
		/// このインスタンスと Rational を比較し、このインスタンスの値が Rational の値よりも小さいか、同じか、または大きいかを示す整数を返します。
		/// </summary>
		/// <param name="other">比較する Rational 。</param>
		/// <returns>このインスタンスと other の相対的な値を示す符号付き整数値です (次の表を参照)。 
		///戻り値
		///説明 
		///0 より小さい値
		///現在のインスタンスは other より小さい。 
		///0 
		///現在のインスタンスと other は等しい。 
		///0 より大きい値
		///現在のインスタンスは other より大きい。</returns>
		public int CompareTo(Rational other) {
#if DEBUG&&!DLLDEBUG
			return this>other ? 1 : this==other ? 0 : -1;
#else
			return Compare(this,other);
#endif
		}

		/// <summary>
		/// このインスタンスと符号なし 64 ビット整数を比較し、このインスタンスの値が符号なし 64 ビット整数の値よりも小さいか、同じか、または大きいかを示す整数を返します。
		/// </summary>
		/// <param name="other">比較する符号なし 64 ビット整数。</param>
		/// <returns>このインスタンスと other の相対的な値を示す符号付き整数値です (次の表を参照)。 
		///戻り値
		///説明 
		///0 より小さい値
		///現在のインスタンスは other より小さい。 
		///0 
		///現在のインスタンスと other は等しい。 
		///0 より大きい値
		///現在のインスタンスは other より大きい。</returns>
		public int CompareTo(ulong other) {
#if DEBUG&&!DLLDEBUG
			Rational rationalOther = other;
			return this>rationalOther ? 1 : this==rationalOther ? 0 : -1;
#else
			return Compare(this,other);
#endif
		}

		/// <summary>
		/// Rational 値を 1 だけデクリメントします。
		/// </summary>
		/// <param name="value">デクリメントする値。</param>
		/// <returns>value パラメーターの値を 1 だけデクリメントした値。</returns>
		public static Rational Decrement(Rational value) {
			return --value;
		}

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// 2つの値の通分を行います。
		/// </summary>
		/// <param name="left">通分前のleft。</param>
		/// <param name="right">通分前のright。</param>
		/// <returns>通分後のleft。通分後のright。</returns>
		private static (Rational Left, Rational Right) DenominatorUnification(Rational left,Rational right) {

			if(left.Denominator==right.Denominator) {
				return (left, right);
			}

			var gcd = BigUInteger.GreatestCommonDivisor(left.Denominator,right.Denominator);

			var denominator = left.Denominator/gcd*right.Denominator;
			var sign = left.Sign&&right.Sign;

			return (new Rational(sign ? false : left.Sign,right.Denominator/gcd*left.Numerator,denominator), new Rational(sign ? false : right.Sign,left.Denominator/gcd*right.Numerator,denominator));

		}

#endif

		/// <summary>
		/// 一方の Rational 値をもう一方の値で除算し、その結果を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>除算の商。</returns>
		public static Rational Divide(Rational dividend,Rational divisor) {
			return dividend/divisor;
		}

		/// <summary>
		/// 現在のインスタンスの値と 10進数の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する 10進数の値。</param>
		/// <returns> 10進数の値の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(decimal other) {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.Equals(other);
#else
			return Rational.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と倍精度浮動小数点数の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する倍精度浮動小数点数の値。</param>
		/// <returns> 倍精度浮動小数点数の値の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(double other) {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.Equals(other);
#else
			if(Rational.IsNaN(this)) {
				return double.IsNaN(other);
			} else if(double.IsNaN(other)) {
				return false;
			}
			return Rational.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と符号付き 64 ビット整数の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する符号付き 64 ビット整数値。</param>
		/// <returns>符号付き 64 ビット整数の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(long other) {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.Equals(other);
#else
			return Rational.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と指定されたオブジェクトの値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="obj">比較対象のオブジェクト。</param>
		/// <returns>obj 引数が 数値 で、その値が現在の Rational インスタンスの値と等しい場合は true。それ以外の場合は false。</returns>
		public override bool Equals(object obj) {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.Equals(obj);
#else

			if(!(obj is Rational)) {
				return false;
			}
			var other = (Rational)obj;
			if(Rational.IsNaN(this)) {
				return Rational.IsNaN((Rational)other);
			} else if(Rational.IsNaN((Rational)other)) {
				return false;
			}
			return Rational.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と Rational の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する Rational 値。</param>
		/// <returns> Rational の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(Rational other) {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.Equals(other.Numerator);
#else
			if(Rational.IsNaN(this)) {
				return Rational.IsNaN(other);
			} else if(Rational.IsNaN(other)) {
				return false;
			}
			return Rational.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と符号無し 64 ビット整数の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する符号無し 64 ビット整数値。</param>
		/// <returns>符号無し 64 ビット整数の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(ulong other) {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.Equals(other);
#else
			return Rational.Equality(this,other);
#endif
		}

		/// <summary>
		/// 2 つの Rational オブジェクトの値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値。</param>
		/// <param name="right">比較する 2 番目の値。</param>
		/// <returns>left パラメーターと right パラメーターが同じ値の場合は true。それ以外の場合は false。</returns>
		public static bool Equals(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator.Equals(right.Numerator);
#else
			if(Rational.IsNaN(left)) {
				return Rational.IsNaN(right);
			} else if(Rational.IsNaN(right)) {
				return false;
			}
			return Rational.Equality(left,right);
#endif
		}

		/// <summary>
		/// OLE オートメーション通貨値を格納している指定した 64 ビット符号付き整数を、それと等価の Rational 値に変換します。
		/// </summary>
		/// <param name="cy">OLE オートメーション通貨値。</param>
		/// <returns>cy と等価の値を格納している Rational。</returns>
		public static Rational FromOACurrency(long cy) {
			return new Rational(cy)/new Rational(10000);
		}

		/// <summary>
		/// 現在の Rational オブジェクトのハッシュ コードを返します。
		/// </summary>
		/// <returns>32 ビット符号付き整数ハッシュ コード。</returns>
		public override int GetHashCode() {

			int result;

			using(var memSt = new MemoryStream())
			using(var md5csp = new MD5CryptoServiceProvider()) {
				new BinaryFormatter().Serialize(memSt,this);
				memSt.Position=0;
				result=BitConverter.ToInt32(md5csp.ComputeHash(memSt),0);
			}

			return result;

		}

		/// <summary>
		/// TypeCode 値型の Object を返します。
		/// </summary>
		/// <returns>列挙型定数 Object。</returns>
		public TypeCode GetTypeCode() {
			return TypeCode.Object;
		}

		/// <summary>
		/// 2 つの Rational 値の最大公約数を求めます。
		/// </summary>
		/// <param name="left">最大公約数を求める最初の値。</param>
		/// <param name="right">最大公約数を求める2 番目の値。</param>
		/// <returns>left と right の最大公約数。</returns>
		public static Rational GreatestCommonDivisor(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			if(left.Numerator%1!=0) {
				throw new ArgumentException("小数を含む値です。",nameof(left));
			}
			if(right.Numerator%1!=0) {
				throw new ArgumentException("小数を含む値です。",nameof(right));
			}

			if(left==right) {
				return Math.Abs(left);
			}
			Rational big;
			Rational small;
			{
				Rational absLeft = Math.Abs(left);
				Rational absRight = Math.Abs(right);
				if(absLeft>absRight) {
					big=absLeft;
					small=absRight;
				} else {
					small=absLeft;
					big=absRight;
				}
			}
			for(var remainder = big%small;remainder!=0;remainder=big%small) {
				if(remainder>=small) {
					big=remainder;
				} else {
					big=small;
					small=remainder;
				}
			}
			return small;
#else
			if(Rational.IsNaN(left)||Rational.IsNaN(right)) {
				return NaN;
			}
			if(IsInfinity(left)) {
				return right;
			} else if(IsInfinity(right)) {
				return left;
			}
			if(left.IsZero) {
				return right;
			} else if(right.IsZero) {
				return left;
			}
			return new Rational(left.Sign&right.Sign,BigUInteger.GreatestCommonDivisor(left.Numerator,right.Numerator),BigUInteger.GreatestCommonDivisor(left.Denominator,right.Denominator));
#endif
		}

		/// <summary>
		/// Rational 値を 1 だけインクリメントします。
		/// </summary>
		/// <param name="value">インクリメントする値。</param>
		/// <returns>value パラメーターの値を 1 だけインクリメントした値。</returns>
		public static Rational Increment(Rational value) {
			return ++value;
		}

#if !DEBUG||DLLDEBUG
		private static Rational InternalAdd(Rational left,Rational right) {

			if(Rational.IsNaN(left)||Rational.IsNaN(right)) {
				return NaN;
			}

			if(Rational.IsInfinity(left)) {
				return Rational.IsInfinity(right) ? Rational.Zero : left;
			} else if(Rational.IsInfinity(right)) {
				return right;
			}

			(left, right)=Rational.DenominatorUnification(left,right);

			bool sign;
			BigUInteger biggerNumerator;
			BigUInteger smallerNumerator;

			if(left.Numerator>right.Numerator) {
				sign=left.Sign;
				biggerNumerator=left.Numerator;
				smallerNumerator=right.Numerator;
			} else {
				sign=right.Sign;
				biggerNumerator=right.Numerator;
				smallerNumerator=left.Numerator;
			}

			return new Rational(sign,left.Sign==right.Sign ? biggerNumerator+smallerNumerator : biggerNumerator-smallerNumerator,left.Denominator).Trim();

		}
#endif

		/// <summary>
		/// 指定した数値が負または正の無限大と評価されるかどうかを示す値を返します。
		/// </summary>
		/// <param name="value">無限大か確認するRational 値。</param>
		/// <returns>value が PositiveInfinity または NegativeInfinity と評価される場合は true。それ以外の場合は false。</returns>
		public static bool IsInfinity(Rational value) {
#if DEBUG&&!DLLDEBUG
			return double.IsInfinity(value.Numerator);
#else
			return value.Infinity;
#endif
		}

		/// <summary>
		/// 指定した値が非数値 (NaN) かどうかを示す値を返します。
		/// </summary>
		/// <param name="value">NaNか確認するRational 値。</param>
		/// <returns>value が NaN と評価される場合は true。それ以外の場合は false。</returns>
		public static bool IsNaN(Rational value) {
#if DEBUG&&!DLLDEBUG
			return double.IsNaN(value.Numerator);
#else
			return value.Denominator.IsZero;
#endif
		}
		/// <summary>
		/// 指定した数値が負の無限大と評価されるかどうかを示す値を返します。
		/// </summary>
		/// <param name="value">負の無限大か確認するRational値。</param>
		/// <returns>value が NegativeInfinity と評価される場合は true。それ以外の場合は false。</returns>
		public static bool IsNegativeInfinity(Rational value) {
#if DEBUG&&!DLLDEBUG
			return double.IsNegativeInfinity(value.Numerator);
#else
			return value.Sign&&IsInfinity(value);
#endif
		}

		/// <summary>
		/// 指定した数値が正の無限大と評価されるかどうかを示す値を返します。
		/// </summary>
		/// <param name="value">正の無限大か確認するRational値。</param>
		/// <returns>value が PositiveInfinity と評価される場合は true。それ以外の場合は false。</returns>
		public static bool IsPositiveInfinity(Rational value) {
#if DEBUG&&!DLLDEBUG
			return double.IsPositiveInfinity(value.Numerator);
#else
			return !value.Sign&&IsInfinity(value);
#endif
		}

		/// <summary>
		/// 指定されたビット数だけ Rational 値を左にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value を左にシフトするビット数。</param>
		/// <returns>指定されたビット数だけ左にシフトした値。</returns>
		public static Rational LeftShift(Rational value,int shift) {
			return value<<shift;
		}

		/// <summary>
		/// 指定された 2 つの Rational 値の除算の結果生じた剰余を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>除算の結果生じた剰余。</returns>
		public static Rational Mod(Rational dividend,Rational divisor) {
			return dividend%divisor;
		}

		/// <summary>
		/// 数値を別の数値で累乗し、それをさらに別の数値で割った結果生じた剰余を求めます。
		/// </summary>
		/// <param name="value">指数 exponent で累乗する数値。</param>
		/// <param name="exponent">value の指数。</param>
		/// <param name="modulus">value をexponent で累乗した結果を除算する時の除数。</param>
		/// <returns>value をexponentで累乗し modulus で割った結果生じた剰余。</returns>
		public static Rational ModPow(Rational value,Rational exponent,Rational modulus) {
			//TODO:ExtendMathまたはMathにあるべきメソッドではないか？
			return Math.Pow(value,exponent)%modulus;
		}

		/// <summary>
		/// 2 つの Rational 値の積を返します。
		/// </summary>
		/// <param name="left">乗算対象の最初の数。</param>
		/// <param name="right">乗算対象の 2 番目の数。</param>
		/// <returns>left と rightパラメーターの積。</returns>
		public static Rational Multiply(Rational left,Rational right) {
			return left*right;
		}

		/// <summary>
		/// 指定された Rational 値の符号を反転します。
		/// </summary>
		/// <param name="value">符号を反転させる値。</param>
		/// <returns>value パラメーターに -1 を乗算した結果。</returns>
		public static Rational Negate(Rational value) {
			return -value;
		}

		#if !DEBUG||DLLDEBUG

		/// <summary>
		/// 2つの値の通分を行い分子のみを返却します。
		/// </summary>
		/// <param name="left">通分前のleft。</param>
		/// <param name="right">通分前のright。</param>
		/// <returns>通分後のleftの分子。通分後のrightの分子。</returns>
		private static (BigUInteger leftNumerator, BigUInteger rightNumerator) NumeratorDenominatorUnification(Rational left,Rational right) {

			if(left.Denominator==right.Denominator) {
				return (left.Numerator, right.Numerator);
			}

			var gcd = BigUInteger.GreatestCommonDivisor(left.Denominator,right.Denominator);
			return (right.Denominator/gcd*left.Numerator, left.Denominator/gcd*right.Numerator);

		}

#endif

		/// <summary>
		/// Rational 値のビットごとの 1 の補数を返します。
		/// </summary>
		/// <param name="value">1の補数を取得したい値。</param>
		/// <returns>value のビットごとの 1 の補数。</returns>
		public static Rational OnesComplement(Rational value) {
			return ~value;
		}

		/// <summary>
		/// 数値の文字列形式を、それと等価の Rational に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public static Rational Parse(String value) {
#if DEBUG&&!DLLDEBUG
			return new Rational(double.Parse(value,CultureInfo.CurrentCulture));
#else
			return Parse(value,CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 指定のスタイルで表現された数値の文字列形式を、それと等価な Rational に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <param name="style">value に許可されている書式を指定する列挙値のビットごとの組み合わせ。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public static Rational Parse(String value,NumberStyles style) {
#if DEBUG&&!DLLDEBUG
			return new Rational(double.Parse(value,style,CultureInfo.CurrentCulture));
#else
			return Parse(value,style,CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 指定されたカルチャ固有の書式で表現された文字列形式の数値を、それと等価の Rational に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <param name="provider">value に関するカルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public static Rational Parse(String value,IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return new Rational(double.Parse(value,provider));
#else
			return Parse(value,NumberStyles.Number|NumberStyles.AllowExponent,provider);
#endif
		}

		/// <summary>
		/// 指定したスタイルおよびカルチャ固有の書式の数値の文字列形式を、それと等価の Rational に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <param name="style">value に許可されている書式を指定する列挙値のビットごとの組み合わせ。</param>
		/// <param name="provider">value に関するカルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public static Rational Parse(String value,NumberStyles style,IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return new Rational(double.Parse(value,style,provider));
#else
			if(value==null) {
				throw new ArgumentNullException(nameof(value));
			}
			return new Parser(style,provider).ParseRational(value);
#endif
		}

		/// <summary>
		/// Rational オペランドの値を返します。 オペランドの符号は変更されません。
		/// </summary>
		/// <param name="value">符号を反転させない値。</param>
		/// <returns>value パラメーターと等価な値。</returns>
		public static Rational Plus(Rational value) {
			return value;
		}

		/// <summary>
		/// 指定されたビット数だけ Rational 値を右にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value を右にシフトするビット数。</param>
		/// <returns>指定されたビット数だけ右にシフトされた値。</returns>
		public static Rational RightShift(Rational value,int shift) {
			return value>>shift;
		}

#if !DEBUG||DLLDEBUG
		/// <summary>
		/// 指定されたビット数だけ Rational 値をシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value をシフトするビット数。(プラスの場合左シフト、マイナスの場合右シフトとして扱います)</param>
		/// <returns>指定されたビット数だけシフトされた値。</returns>
		private static Rational Shift(Rational value,int shift) {
			if(IsInfinity(value)) {
				return value.Sign ? NegativeInfinity : PositiveInfinity;
			}
			if(IsNaN(value)) {
				return value;
			}
			if(shift==0) {
				return value;
			}

			var arrayShift = System.Math.DivRem(System.Math.Abs(shift),BigUInteger.ContainerItemSizeWithBit,out var innerShift);

			return shift>0 ? new Rational(value.Sign,BigUInteger.LeftShift(value.Numerator,arrayShift,innerShift),value.Denominator) : new Rational(value.Sign,value.Numerator,BigUInteger.LeftShift(value.Denominator,arrayShift,innerShift));

		}
#endif

		/// <summary>
		/// Rational 値を別の値から減算し、その結果を返します。
		/// </summary>
		/// <param name="left">減算される値 (被減数)。</param>
		/// <param name="right">減算する値 (減数)。</param>
		/// <returns>left から right を減算した結果。</returns>
		public static Rational Subtract(Rational left,Rational right) {
			return left-right;
		}

		/// <summary>
		/// 指定した Rational の値を、等価の 8 ビット符号なし整数に変換します。
		/// </summary>
		/// <param name="value">変換するRational。</param>
		/// <returns>value と等価の 8 ビット符号なし整数。</returns>
		public static byte ToByte(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>byte.MaxValue||val<byte.MinValue) {
				throw new OverflowException();
			}
			return (byte)val;
#else
			if(value.Sign||value>byte.MaxValue) {
				throw new OverflowException();
			}
			return (byte)(value.Numerator/value.Denominator).Value[0];
#endif
		}

		/// <summary>
		/// Rational 値をバイト配列に変換します。
		/// </summary>
		/// <returns>現在の Rational オブジェクトをバイトの配列に変換した値。</returns>
		public (bool Sign, byte[] Numerator, byte[] Denominator, bool Infinity) ToByteArray() {
#if DEBUG&&!DLLDEBUG

			return (this.Numerator<0, BitConverter.GetBytes(this.Numerator), BitConverter.GetBytes(this.Denominator),double.IsInfinity(this.Numerator));
#else
			return (this.Sign, this.Numerator.ToByteArray(), this.Denominator.ToByteArray(), this.Infinity);
#endif
		}

#if !DEBUG||DLLDEBUG
		public (bool Sign, ContainerType[] Numerator, ContainerType[] Denominator, bool Infinity) ToContainerArray() {
			return (this.Sign, this.Numerator.ToContainerArray(), this.Denominator.ToContainerArray(), this.Infinity);
		}
#endif

		/// <summary>
		/// 指定した Rational の値を、それと等価の倍精度浮動小数点数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>valueと等価の倍精度浮動小数点数。</returns>
		public static double ToDouble(Rational value) {
#if DEBUG&&!DLLDEBUG
			return value.Numerator;
#else
			if(IsNegativeInfinity(value)) {
				return double.NegativeInfinity;
			}
			if(IsPositiveInfinity(value)) {
				return double.PositiveInfinity;
			}
			if(IsNaN(value)) {
				return double.NaN;
			}
			if(value>double.MaxValue) {
				return double.PositiveInfinity;
			} else if(value<double.MinValue) {
				return double.NegativeInfinity;
			}

			var tmp = Math.Round(value,341,MidpointRounding.AwayFromZero);
			var (integerPart, fractionalPart)=Math.DivRem(tmp.Numerator,tmp.Denominator);

			var resultIntegerPart = 0d;
			var resultFractionalPart = 0d;

			if(tmp.Sign) {
				for(var counter = integerPart.Value.Length-1;counter>=0;counter--) {
					resultIntegerPart*=(double)ContainerType.MaxValue+1;
					resultIntegerPart-=integerPart.Value[counter];
				}

				for(var counter = fractionalPart.Value.Length-1;counter>=0;counter--) {
					resultFractionalPart*=(double)ContainerType.MaxValue+1;
					resultFractionalPart-=fractionalPart.Value[counter];
				}
			} else {
				for(var counter = integerPart.Value.Length-1;counter>=0;counter--) {
					resultIntegerPart*=(double)ContainerType.MaxValue+1;
					resultIntegerPart+=integerPart.Value[counter];
				}

				for(var counter = fractionalPart.Value.Length-1;counter>=0;counter--) {
					resultFractionalPart*=(double)ContainerType.MaxValue+1;
					resultFractionalPart+=fractionalPart.Value[counter];
				}
			}

			for(var counter = 0;counter<341;counter++) {
				resultFractionalPart/=10;
			}

			return resultIntegerPart+resultFractionalPart;

#endif
		}

		/// <summary>
		/// 指定した Rational の値を、等価の 16 ビット符号付き整数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>value と等価の 16 ビット符号付き整数。</returns>
		public static short ToInt16(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>short.MaxValue||val<short.MinValue) {
				throw new OverflowException();
			}
			return (short)val;
#else
			if(value>short.MaxValue||value<short.MinValue||IsInfinity(value)) {
				throw new OverflowException();
			}

			var result = (short)(value.Numerator/value.Denominator).Value[0];
			if(value.Sign) {
				result*=-1;
			}
			return result;
#endif
		}

		/// <summary>
		/// 指定した Rational の値を、等価の 32 ビット符号付き整数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>value と等価の 32 ビット符号付き整数。</returns>
		public static int ToInt32(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>int.MaxValue||val<int.MinValue) {
				throw new OverflowException();
			}
			return (int)val;
#else
			if(value>int.MaxValue||value<int.MinValue||IsInfinity(value)) {
				throw new OverflowException();
			}

			var result = (int)(value.Numerator/value.Denominator).Value[0];
			if(value.Sign) {
				result*=-1;
			}
			return result;
#endif
		}

		/// <summary>
		/// 指定した Rational の値を、等価の 64 ビット符号付き整数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>value と等価の 64 ビット符号付き整数。</returns>
		public static long ToInt64(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>long.MaxValue||val<long.MinValue) {
				throw new OverflowException();
			}
			return (long)val;
#else
			if(value>long.MaxValue||value<long.MinValue||IsInfinity(value)) {
				throw new OverflowException();
			}

			var rationalResult = value.Numerator/value.Denominator;
			var result = rationalResult.Value.Length>1?(long)(rationalResult.Value[0])|((long)(rationalResult.Value[1])<<BigUInteger.ContainerItemSizeWithBit): (long)(rationalResult.Value[0]);
			if(value.Sign) {
				result*=-1;
			}
			return result;
#endif
		}

		/// <summary>
		/// 指定した Rational 値を、64 ビット符号付き整数に格納されるそれと等価の OLE オートメーション通貨値に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>value と等価の OLE オートメーション値を格納する 64 ビット符号付き整数。</returns>
		public static long ToOACurrency(Rational value) {
			return (long)Math.Round(value*10000,0,MidpointRounding.AwayFromZero);
		}

		/// <summary>
		/// 指定した Rational の値を、等価の 8 ビット符号付き整数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>value と等価の 8 ビット符号付き整数。</returns>
		public static sbyte ToSByte(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>sbyte.MaxValue||val<sbyte.MinValue) {
				throw new OverflowException();
			}
			return (sbyte)val;
#else
			if(value>sbyte.MaxValue||value<sbyte.MinValue||IsInfinity(value)) {
				throw new OverflowException();
			}

			var result = (sbyte)(value.Numerator/value.Denominator).Value[0];
			if(value.Sign) {
				result*=-1;
			}
			return result;
#endif
		}

		/// <summary>
		/// 指定した Rational の値を、それと等価の単精度浮動小数点数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>valueと等価の単精度浮動小数点数。</returns>
		public static float ToSingle(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>float.MaxValue||val<float.MinValue) {
				throw new OverflowException();
			}
			return (float)val;
#else
			if(IsNegativeInfinity(value)) {
				return float.NegativeInfinity;
			}
			if(IsPositiveInfinity(value)) {
				return float.PositiveInfinity;
			}
			if(IsNaN(value)) {
				return float.NaN;
			}
			if(value>float.MaxValue) {
				return float.PositiveInfinity;
			} else if(value<float.MinValue) {
				return float.NegativeInfinity;
			}

			var tmp = Math.Round(value,54,MidpointRounding.AwayFromZero);
			var (integerPart, fractionalPart)=Math.DivRem(tmp.Numerator,tmp.Denominator);

			var resultIntegerPart = 0f;
			var resultFractionalPart = 0f;

			if(tmp.Sign) {
				for(var counter = integerPart.Value.Length-1;counter>=0;counter--) {
					resultIntegerPart*=(float)ContainerType.MaxValue+1;
					resultIntegerPart-=integerPart.Value[counter];
				}

				for(var counter = fractionalPart.Value.Length-1;counter>=0;counter--) {
					resultFractionalPart*=(float)ContainerType.MaxValue+1;
					resultFractionalPart-=fractionalPart.Value[counter];
				}
			} else {
				for(var counter = integerPart.Value.Length-1;counter>=0;counter--) {
					resultIntegerPart*=(float)ContainerType.MaxValue+1;
					resultIntegerPart+=integerPart.Value[counter];
				}

				for(var counter = fractionalPart.Value.Length-1;counter>=0;counter--) {
					resultFractionalPart*=(float)ContainerType.MaxValue+1;
					resultFractionalPart+=fractionalPart.Value[counter];
				}
			}

			for(var counter = 0;counter<54;counter++) {
				resultFractionalPart/=10;
			}

			return resultIntegerPart+resultFractionalPart;

#endif
		}

		/// <summary>
		/// 現在の Rational オブジェクトの数値を等価の文字列形式に変換します。
		/// </summary>
		/// <returns>現在の Rational 値の文字列形式。</returns>
		public override string ToString() {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.ToString(CultureInfo.CurrentCulture);
#else
			return ToString(CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 指定されたカルチャ固有の書式情報を使用して、現在の Rational オブジェクトの数値をそれと等価の文字列形式に変換します。
		/// </summary>
		/// <param name="provider">カルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>現在の Rational 値の文字列形式を、provider パラメーターで指定されている形式で表現した値。</returns>
		public string ToString(IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.ToString(provider);
#else
			return ToString("G",provider);
#endif
		}

		/// <summary>
		/// 指定された書式を使用して、現在の Rational オブジェクトの数値をそれと等価な文字列形式に変換します。
		/// </summary>
		/// <param name="format">標準またはカスタムの数値書式指定文字列。</param>
		/// <returns>現在の Rational 値の文字列形式を、format パラメーターで指定されている形式で表現した値。</returns>
		public string ToString(String format) {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.ToString(format,CultureInfo.CurrentCulture);
#else
			return ToString(format,CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 指定された書式とカルチャ固有の書式情報を使用して、現在の Rational オブジェクトの数値をそれと等価の文字列形式に変換します。
		/// </summary>
		/// <param name="format">標準またはカスタムの数値書式指定文字列。</param>
		/// <param name="provider">カルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>format パラメーターと providerパラメーターで指定されている現在の Rational 値の文字列表現。</returns>
		public string ToString(String format,IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return this.Numerator.ToString(format,provider);
#else
			return new Formatter(format,provider).Format(this);
#endif
		}

		/// <summary>
		/// 指定した Rational の値を、等価の 16 ビット符号なし整数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>value の値と等価の 16 ビット符号なし整数。</returns>
		public static ushort ToUInt16(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>ushort.MaxValue||val<ushort.MinValue) {
				throw new OverflowException();
			}
			return (ushort)val;
#else
			if(value.Sign||value>ushort.MaxValue||IsInfinity(value)) {
				throw new OverflowException();
			}

			return (ushort)(value.Numerator/value.Denominator).Value[0];
#endif
		}

		/// <summary>
		/// 指定した Rational の値を、等価の 32 ビット符号なし整数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>value の値と等価の 32 ビット符号なし整数。</returns>
		public static uint ToUInt32(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>uint.MaxValue||val<uint.MinValue) {
				throw new OverflowException();
			}
			return (uint)val;
#else
			if(value.Sign||value>uint.MaxValue||IsInfinity(value)) {
				throw new OverflowException();
			}

			return (uint)(value.Numerator/value.Denominator).Value[0];
#endif
		}

		/// <summary>
		/// 指定した Rational の値を、等価の 64 ビット符号なし整数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>value の値と等価の 64 ビット符号なし整数。</returns>
		public static ulong ToUInt64(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>ulong.MaxValue||val<ulong.MinValue) {
				throw new OverflowException();
			}
			return (ulong)val;
#else
			if(value.Sign||value>ulong.MaxValue||IsInfinity(value)) {
				throw new OverflowException();
			}

			var rationalResult = value.Numerator/value.Denominator;
			return rationalResult.Value.Length>1?(ulong)(rationalResult.Value[0])|((ulong)(rationalResult.Value[1])<<BigUInteger.ContainerItemSizeWithBit): (ulong)(rationalResult.Value[0]);
#endif
		}

		/// <summary>
		/// 指定した Rational の値を、等価の 10進数に変換します。
		/// </summary>
		/// <param name="value">変換する Rational。</param>
		/// <returns>value と等価の 10進数。</returns>
		public static decimal ToDecimal(Rational value) {
#if DEBUG&&!DLLDEBUG
			var val = value.Numerator;
			if(val>(double)decimal.MaxValue||val<(double)decimal.MinValue) {
				throw new OverflowException();
			}
			return (decimal)val;
#else

			if(value>decimal.MaxValue||value<decimal.MinValue||IsInfinity(value)||IsNaN(value)) {
				throw new OverflowException();
			}

			var tmp = Math.Round(value,29,MidpointRounding.AwayFromZero);
			var (integerPart, fractionalPart)=Math.DivRem(tmp.Numerator,tmp.Denominator);

			var resultIntegerPart = 0m;
			var resultFractionalPart = 0m;

			if(tmp.Sign) {
				for(var counter = integerPart.Value.Length-1;counter>=0;counter--) {
					resultIntegerPart*=(decimal)ContainerType.MaxValue+1;
					resultIntegerPart-=integerPart.Value[counter];
				}

				for(var counter = fractionalPart.Value.Length-1;counter>=0;counter--) {
					resultFractionalPart*=(decimal)ContainerType.MaxValue+1;
					resultFractionalPart-=fractionalPart.Value[counter];
				}
			} else {
				for(var counter = integerPart.Value.Length-1;counter>=0;counter--) {
					resultIntegerPart*=(decimal)ContainerType.MaxValue+1;
					resultIntegerPart+=integerPart.Value[counter];
				}

				for(var counter = fractionalPart.Value.Length-1;counter>=0;counter--) {
					resultFractionalPart*=(decimal)ContainerType.MaxValue+1;
					resultFractionalPart+=fractionalPart.Value[counter];
				}
			}

			for(var counter = 0;counter<29;counter++) {
				resultFractionalPart/=10;
			}

			return resultIntegerPart+resultFractionalPart;

#endif
		}

		/// <summary>
		/// 肥大化した内部表現をトリミングします
		/// </summary>
		/// <returns>トリミングしたRational値</returns>
		public Rational Trim() {

#if !DEBUG||DLLDEBUG
			if(this.Numerator==this.Denominator) {
				this.Numerator=BigUInteger.One;
				this.Denominator=BigUInteger.One;
			} else if(this.IsZero) {
				this.Numerator=BigUInteger.Zero;
				this.Denominator=BigUInteger.One;
			} else if(!IsNaN(this)||!IsInfinity(this)) {
				var gcd = BigUInteger.GreatestCommonDivisor(this.Numerator,this.Denominator);
				this.Numerator/=gcd;
				this.Denominator/=gcd;
			}
#endif

			return this;

		}

		/// <summary>
		/// 数値の文字列形式を対応する Rational 表現に変換できるかどうかを試行し、変換に成功したかどうかを示す値を返します。
		/// </summary>
		/// <param name="value">数値の文字列形式。</param>
		/// <returns>valueが正常に変換できた場合はtrue。それ以外の場合はfalse。このメソッドから制御が戻るときに、valueと等価の Rational が格納されます。value パラメーターが null の場合、または正しい形式ではない場合、変換は失敗します。変換に失敗した場合このパラメーターは初期化せずに渡されます。</returns>
		public static (bool status, Rational result) TryParse(String value) {
#if DEBUG&&!DLLDEBUG
			return (double.TryParse(value,out var result), new Rational(result));
#else
			return TryParse(value,NumberStyles.Number|NumberStyles.AllowExponent,CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 数値の文字列形式を対応する Rational 表現に変換できるかどうかを試行し、変換に成功したかどうかを示す値を返します。
		/// </summary>
		/// <param name="value">数値の文字列形式。</param>
		/// <param name="style">value で存在する可能性を持つスタイル要素を示す、列挙値のビットごとの組み合わせ。 通常指定する値は Integer です。</param>
		/// <param name="provider">value に関するカルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>valueが正常に変換できた場合はtrue。それ以外の場合はfalse。このメソッドから制御が戻るときに、valueと等価の Rational が格納されます。value パラメーターが null の場合、または正しい形式ではない場合、変換は失敗します。変換に失敗した場合このパラメーターは初期化せずに渡されます。</returns>
		public static (bool status, Rational result) TryParse(String value,NumberStyles style,IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return (double.TryParse(value,style,provider,out var result), new Rational(result));
#else
			try {
				//TODO:TryCatchではない方が速いかも。けれど内部処理の面で修正が難しい。優先度は低いので後ほど考える。
				return (true, Parse(value,style,provider));
			} catch(Exception ex) when(ex is ArgumentNullException||ex is FormatException||ex is ArgumentException||ex is OverflowException) {
				return (false, Rational.NaN);
			}
#endif
		}

		/// <summary>
		/// 2 つの Rational 値に対し、ビットごとの排他的 Or (XOr) 演算を実行します。
		/// </summary>
		/// <param name="left">排他的 Or演算する最初の値。</param>
		/// <param name="right">排他的 Or演算する2 番目の値。</param>
		/// <returns>ビットごとの Or 演算の結果。</returns>
		public static Rational Xor(Rational left,Rational right) {
			return left^right;
		}

		/// <summary>
		/// 指定された 2 つの Rational オブジェクトの値を加算します。
		/// </summary>
		/// <param name="left">加算する 1 番目の値。</param>
		/// <param name="right">加算する 2 番目の値。</param>
		/// <returns>left と right の合計。</returns>
		public static Rational operator +(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator+right.Numerator;
#else
			return InternalAdd(left,right);
#endif
		}

		/// <summary>
		/// 2 つの Rational 値に対し、ビットごとの And 演算を実行します。
		/// </summary>
		/// <param name="left">And演算する最初の値。</param>
		/// <param name="right">And演算する2 番目の値。</param>
		/// <returns>ビットごとの And 演算の結果。</returns>
		public static Rational operator &(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			var resultArray = BitConverter.GetBytes(left.Numerator);
			var rightArray = BitConverter.GetBytes(right.Numerator);
			for(var counter = 0;counter<resultArray.Length;counter++) {
				resultArray[counter]&=rightArray[counter];
			}
			return BitConverter.ToDouble(resultArray,0);
#else
			if(IsNaN(left)||IsNaN(right)) {
				return Rational.NaN;
			} else if(IsInfinity(left)&&IsInfinity(right)) {
				return left.Sign==right.Sign ? Rational.PositiveInfinity : Rational.NegativeInfinity;
			}
			(left, right)=Rational.DenominatorUnification(left,right);
			return new Rational(left.Sign&&right.Sign,left.Numerator&right.Numerator,left.Denominator).Trim();
#endif
		}

		/// <summary>
		/// 2 つの Rational 値に対し、ビットごとの Or 演算を実行します。
		/// </summary>
		/// <param name="left">Or演算する最初の値。</param>
		/// <param name="right">Or演算する2 番目の値。</param>
		/// <returns>ビットごとの Or 演算の結果。</returns>
		public static Rational operator |(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			var resultArray = BitConverter.GetBytes(left.Numerator);
			var rightArray = BitConverter.GetBytes(right.Numerator);
			for(var counter = 0;counter<resultArray.Length;counter++) {
				resultArray[counter]|=rightArray[counter];
			}
			return BitConverter.ToDouble(resultArray,0);
#else
			if(IsNaN(left)||IsNaN(right)) {
				return Rational.NaN;
			} else if(IsInfinity(left)||IsInfinity(right)) {
				return left.Sign==right.Sign ? Rational.PositiveInfinity : Rational.NegativeInfinity;
			}
			(left, right)=Rational.DenominatorUnification(left,right);
			return new Rational(left.Sign||right.Sign,left.Numerator|right.Numerator,left.Denominator).Trim();
#endif
		}

		/// <summary>
		/// Rational 値を 1 だけデクリメントします。
		/// </summary>
		/// <param name="value">デクリメントする値。</param>
		/// <returns>value パラメーターの値を 1 だけデクリメントした値。</returns>
		public static Rational operator --(Rational value) {
#if DEBUG&&!DLLDEBUG
			return value.Numerator-1;
#else

			if(IsInfinity(value)||IsNaN(value)) {
				return value;
			} else if(value.Sign) {
				return new Rational(value.Sign,value.Numerator+value.Denominator,value.Denominator);
			} else {
				if(value.Denominator>value.Numerator) {
					return new Rational(true,value.Denominator-value.Numerator,value.Denominator);
				} else {
					return new Rational(value.Sign,value.Numerator-value.Denominator,value.Denominator);
				}

			}

#endif
		}

		/// <summary>
		/// 一方の Rational 値をもう一方の値で除算し、その結果を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>除算の結果 。</returns>
		public static Rational operator /(Rational dividend,Rational divisor) {
#if DEBUG&&!DLLDEBUG
			return dividend.Numerator/divisor.Numerator;
#else
			if(IsNaN(dividend)||IsNaN(divisor)||IsInfinity(divisor)) {
				return NaN;
			}
			if(divisor.Numerator.IsZero) {
				if(dividend.IsZero) {
					return NaN;
				}
				return divisor.Sign==dividend.Sign ? PositiveInfinity : NegativeInfinity;
			}
			if(IsInfinity(dividend)) {
				return dividend;
			}
			var numeratorGcd = BigUInteger.GreatestCommonDivisor(dividend.Numerator,divisor.Numerator);
			var denominatorGcd = BigUInteger.GreatestCommonDivisor(divisor.Denominator,dividend.Denominator);
			return new Rational(dividend.Sign!=divisor.Sign,(dividend.Numerator/numeratorGcd)*(divisor.Denominator/denominatorGcd),(dividend.Denominator/denominatorGcd)*(divisor.Numerator/numeratorGcd)).Trim();
#endif
		}

		/// <summary>
		/// 2 つの Rational オブジェクトの値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>left パラメーターと right パラメーターが同じ値の場合は true。それ以外の場合は false。</returns>
		public static bool operator ==(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator==right.Numerator;
#else
			if(IsNaN(left)||IsNaN(right)) {
				return false;
			}

			return Equality(left,right);

#endif
		}

#if !DEBUG||DLLDEBUG
		/// <summary>
		/// 2 つの Rational オブジェクトの値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>left パラメーターと right パラメーターが同じ値の場合は true。それ以外の場合は false。</returns>
		private static bool Equality(Rational left,Rational right) {
			if(left.Infinity) {
				if(right.Infinity) {
					return left.Sign==right.Sign;
				}
				return false;
			} else if(right.Infinity) {
				return false;
			}
			if(left.Sign!=right.Sign) {
				return false;
			}

			var (leftNumerator, rightNumerator)=Rational.NumeratorDenominatorUnification(left,right);

			return leftNumerator==rightNumerator;
		}
#endif

		/// <summary>
		/// 2 つの Rational 値に対し、ビットごとの排他的 Or (XOr) 演算を実行します。
		/// </summary>
		/// <param name="left">排他的 Or演算する最初の値。</param>
		/// <param name="right">排他的 Or演算するビットごとの Or 演算の結果。</param>
		/// <returns>ビットごとの Or 演算の結果。</returns>
		public static Rational operator ^(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			var resultArray = BitConverter.GetBytes(left.Numerator);
			var rightArray = BitConverter.GetBytes(right.Numerator);
			for(var counter = 0;counter<resultArray.Length;counter++) {
				resultArray[counter]^=rightArray[counter];
			}
			return BitConverter.ToDouble(resultArray,0);
#else
			if(IsNaN(left)||IsNaN(right)) {
				return Rational.NaN;
			} else if(IsInfinity(left)^IsInfinity(right)) {
				return left.Sign==right.Sign ? Rational.PositiveInfinity : Rational.NegativeInfinity;
			}
			(left,right)=Rational.DenominatorUnification(left,right);
			return new Rational(left.Sign||right.Sign,left.Numerator^right.Numerator,left.Denominator).Trim();
#endif
		}

		/// <summary>
		/// Rational 値から Byte 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Byte 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なByte値。</returns>
		public static explicit operator byte(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (byte)value.Numerator;
#else
			return ToByte(value);
#endif
		}

		/// <summary>
		/// Rational 値から SByte 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">SByte値 へと変換する値。</param>
		/// <returns>valueパラメータと等価なSByte値。</returns>
		public static explicit operator sbyte(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (sbyte)value.Numerator;
#else
			return ToSByte(value);
#endif
		}

		/// <summary>
		/// Rational 値から Int32 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Int32 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なInt32値。</returns>
		public static explicit operator int(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (int)value.Numerator;
#else
			return ToInt32(value);
#endif
		}

		/// <summary>
		/// Rational 値から UInt32 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">UInt32 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なUInt32値。</returns>
		public static explicit operator uint(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (uint)value.Numerator;
#else
			return ToUInt32(value);
#endif
		}

		/// <summary>
		/// Rational 値から Int16 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Int16 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なInt16値。</returns>
		public static explicit operator short(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (short)value.Numerator;
#else
			return ToInt16(value);
#endif
		}

		/// <summary>
		/// Rational 値から UInt16 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">UInt16 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なUInt16値。</returns>
		public static explicit operator ushort(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (ushort)value.Numerator;
#else
			return ToUInt16(value);
#endif
		}

		/// <summary>
		/// Rational 値から Int64 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Int64 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なInt64値。</returns>
		public static explicit operator long(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (long)value.Numerator;
#else
			return ToInt64(value);
#endif
		}

		/// <summary>
		/// Rational 値から UInt64 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">UInt64 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なUInt64値。</returns>
		public static explicit operator ulong(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (ulong)value.Numerator;
#else
			return ToUInt64(value);
#endif
		}

		/// <summary>
		/// Rational 値から単精度浮動小数点への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">単精度浮動小数点へと変換する値。</param>
		/// <returns>valueパラメータと等価な単精度浮動小数点。</returns>
		public static explicit operator float(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (float)value.Numerator;
#else
			return ToSingle(value);
#endif
		}

		/// <summary>
		/// Rational 値から倍精度浮動小数点値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">倍精度浮動小数点値へと変換する値。</param>
		/// <returns>valueパラメータと等価な倍精度浮動小数点値。</returns>
		public static explicit operator double(Rational value) {
#if DEBUG&&!DLLDEBUG
			return value.Numerator;
#else
			return ToDouble(value);
#endif
		}

		/// <summary>
		/// Rational 値からBoolean値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Boolean値へと変換する値。</param>
		/// <returns>valueパラメータと等価なBoolean値。（0の場合false、それ以外の場合true）</returns>
		public static explicit operator bool(Rational value) {
			return !value.IsZero;
		}

		/// <summary>
		/// Rational 値から Decimal 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Decimal値へと変換する値。</param>
		/// <returns>valueパラメータと等価なDecimal値。</returns>
		public static explicit operator decimal(Rational value) {
#if DEBUG&&!DLLDEBUG
			return (decimal)value.Numerator;
#else
			return ToDecimal(value);
#endif
		}

		/// <summary>
		/// Rational 値がもう 1 つの Rational 値より大きいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>true が left より大きい場合は right。それ以外の場合は false。</returns>
		public static bool operator >(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator>right.Numerator;
#else
			return IsNaN(left)||IsNaN(right) ? false : Compare(left,right)>0;
#endif
		}



		/// <summary>
		/// Rational 値がもう 1 つの Rational 値以上かどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>true が left より大きい場合は right。それ以外の場合は false。</returns>
		public static bool operator >=(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator>=right.Numerator;
#else
			return IsNaN(left)||IsNaN(right) ? false : Compare(left,right)>=0;
#endif
		}

		/// <summary>
		/// Byte 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(byte value) {
			return new Rational(value);
		}

		/// <summary>
		/// SByte 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(sbyte value) {
			return new Rational(value);
		}

		/// <summary>
		/// Int32 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(int value) {
			return new Rational(value);
		}

		/// <summary>
		/// UInt32 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(uint value) {
			return new Rational(value);
		}

		/// <summary>
		/// Int16 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(short value) {
			return new Rational(value);
		}

		/// <summary>
		/// UInt16 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(ushort value) {
			return new Rational(value);
		}

		/// <summary>
		/// Int64 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(long value) {
			return new Rational(value);
		}

		/// <summary>
		/// UInt64 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(ulong value) {
			return new Rational(value);
		}

		/// <summary>
		/// Single 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(float value) {
			return new Rational(value);
		}

		/// <summary>
		/// Double 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(double value) {
			return new Rational(value);
		}

		/// <summary>
		/// Boolean 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(bool value) {
			return new Rational(value);
		}

		/// <summary>
		/// decimal 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(decimal value) {
			return new Rational(value);
		}

		/// <summary>
		/// BigUInteger 値から Rational 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">Rational へと変換する値。</param>
		/// <returns>valueパラメータと等価なRational値。</returns>
		public static implicit operator Rational(BigUInteger value) {
			return new Rational(false,value,BigUInteger.One);
		}

		/// <summary>
		/// Rational 値を 1 だけインクリメントします。
		/// </summary>
		/// <param name="value">インクリメントする値。</param>
		/// <returns>value パラメーターの値を 1 だけインクリメントした値。</returns>
		public static Rational operator ++(Rational value) {
#if DEBUG&&!DLLDEBUG
			return value.Numerator+1;
#else

			if(IsInfinity(value)||IsNaN(value)) {
				return value;
			} else if(value.Sign) {
				if(value.Denominator>value.Numerator) {
					return new Rational(false,value.Denominator-value.Numerator,value.Denominator);
				} else {
					return new Rational(value.Sign,value.Numerator-value.Denominator,value.Denominator);
				}
			} else {
				return new Rational(value.Sign,value.Numerator+value.Denominator,value.Denominator);
			}

#endif
		}

		/// <summary>
		/// 2 つの Rational オブジェクトの値が異なるかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>left と right が等しくない場合は true。それ以外の場合は false。</returns>
		public static bool operator !=(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator!=right.Numerator;
#else
			return !(left==right);
#endif
		}

		/// <summary>
		/// 指定されたビット数だけ Rational 値を左にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value を左にシフトするビット数。</param>
		/// <returns>指定されたビット数だけ左にシフトされた値。</returns>
		public static Rational operator <<(Rational value,int shift) {
#if DEBUG&&!DLLDEBUG
			return value.Numerator*System.Math.Pow(2,shift);
#else
			return Shift(value,shift);
#endif
		}

		/// <summary>
		/// Rational 値がもう 1 つの Rational 値より小さいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値。</param>
		/// <param name="right">比較する 2 番目の値。</param>
		/// <returns>left が right より小さい場合は true。それ以外の場合は false。</returns>
		public static bool operator <(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator<right.Numerator;
#else
			return IsNaN(left)||IsNaN(right) ? false : Compare(left,right)<0;
#endif
		}

		/// <summary>
		/// Rational 値がもう 1 つの Rational 値以下かどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値。</param>
		/// <param name="right">比較する 2 番目の値。</param>
		/// <returns>left が right 以下の場合は true。それ以外の場合は false。</returns>
		public static bool operator <=(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator<=right.Numerator;
#else
			return IsNaN(left)||IsNaN(right) ? false : Compare(left,right)<=0;
#endif
		}

		/// <summary>
		/// 指定された 2 つの Rational 値の除算の結果生じた剰余を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>除算の結果生じた剰余。</returns>
		public static Rational operator %(Rational dividend,Rational divisor) {
#if DEBUG&&!DLLDEBUG
			return dividend.Numerator%divisor.Numerator;
#else
			if(IsNaN(dividend)||IsNaN(divisor)||IsInfinity(divisor)) {
				return NaN;
			}
			if(divisor.Numerator.IsZero) {
				if(dividend.IsZero) {
					return NaN;
				}
				return divisor.Sign==dividend.Sign ? PositiveInfinity : NegativeInfinity;
			}
			if(IsInfinity(dividend)) {
				return dividend;
			}

			//TODO:事前に公約数で割る処理を入れた方が良い?
			var divisorContaner = dividend.Denominator*divisor.Numerator;
			return new Rational(dividend.Sign!=divisor.Sign,((dividend.Numerator%divisorContaner)*divisor.Denominator)%divisorContaner,dividend.Denominator*divisor.Denominator).Trim();
#endif
		}

		/// <summary>
		/// 2 つの Rational 値の積を返します。
		/// </summary>
		/// <param name="left">乗算対象の最初の数。</param>
		/// <param name="right">乗算対象の 2 番目の数。</param>
		/// <returns>left と right の積。</returns>
		public static Rational operator *(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator*right.Numerator;
#else
			if(IsNaN(left)||IsNaN(right)) {
				return NaN;
			}
			if(IsInfinity(left)||IsInfinity(right)) {
				return left.Sign==right.Sign ? PositiveInfinity : NegativeInfinity;
			}
			var lrgcd = BigUInteger.GreatestCommonDivisor(left.Numerator,right.Denominator);
			var rlgcd = BigUInteger.GreatestCommonDivisor(right.Numerator,left.Denominator);
			return new Rational(left.Sign!=right.Sign,((left.Numerator/lrgcd)*(right.Numerator/rlgcd)),((left.Denominator/rlgcd)*(right.Denominator/lrgcd))).Trim();
#endif
		}

		/// <summary>
		/// Rational 値のビットごとの 1 の補数を返します。
		/// </summary>
		/// <param name="value">1の補数を取得したい値。</param>
		/// <returns>value のビットごとの 1 の補数。</returns>
		public static Rational operator ~(Rational value) {
#if DEBUG&&!DLLDEBUG
			var resultArray = BitConverter.GetBytes(value.Numerator);
			for(var counter = 0;counter<resultArray.Length;counter++) {
				resultArray[counter]=(byte)~resultArray[counter];
			}
			return BitConverter.ToDouble(resultArray,0);
#else
			if(IsInfinity(value)) {
				return value.Sign ? PositiveInfinity : NegativeInfinity;
			}
			return new Rational(!value.Sign,~value.Numerator,value.Denominator).Trim();
#endif
		}

		/// <summary>
		/// 指定されたビット数だけ Rational 値を右にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value を右にシフトするビット数。</param>
		/// <returns>指定されたビット数だけ右にシフトされた値。</returns>
		public static Rational operator >>(Rational value,int shift) {
#if DEBUG&&!DLLDEBUG
			return value.Numerator/System.Math.Pow(2,shift);
#else
			return Shift(value,-shift);
#endif
		}

		/// <summary>
		/// Rational 値をもう 1 つの Rational 値から減算します。
		/// </summary>
		/// <param name="left">減算される値 (被減数)。</param>
		/// <param name="right">減算する値 (減数)。</param>
		/// <returns>left から right を減算した結果。</returns>
		public static Rational operator -(Rational left,Rational right) {
#if DEBUG&&!DLLDEBUG
			return left.Numerator-right.Numerator;
#else
			return InternalAdd(left,-right);
#endif
		}

		/// <summary>
		/// 指定された Rational 値の符号を反転します。
		/// </summary>
		/// <param name="value">符号を反転させる値。</param>
		/// <returns>value パラメーターに -1 を乗算した結果。</returns>
		public static Rational operator -(Rational value) {
#if DEBUG&&!DLLDEBUG
			return value.Numerator*-1;
#else
			if(IsInfinity(value)) {
				return value.Sign ? PositiveInfinity : NegativeInfinity;
			}
			return new Rational(!value.Sign,value.Numerator,value.Denominator);
#endif
		}

		/// <summary>
		/// Rational オペランドの値を返します。 オペランドの符号は変更されません。
		/// </summary>
		/// <param name="value">符号を反転させない値。</param>
		/// <returns>value パラメーターと等価な値。</returns>
		public static Rational operator +(Rational value) {
#if DEBUG&&!DLLDEBUG
			return value;
#else
			return value;
#endif
		}

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// 演算精度を取得設定します。無理数の演算打切り、ToStringの変換打切り等に使用します。
		/// </summary>
		public static int Accuracy {
			get {
				return _Accuracy;
			}
			set {
				if(value<0) {
					RoundInternalInfrator=Math.Pow(BigUInteger.Ten,System.Math.Abs(value)-1);
					RoundInfrator=RoundInternalInfrator*BigUInteger.Ten;
				} else {
					RoundInfrator=Math.Pow(BigUInteger.Ten,value);
					RoundInternalInfrator=RoundInfrator*BigUInteger.Ten;

					if(Accuracy<value) {
						Math.E=Rational.Tow;
						var denominator = BigUInteger.Tow;
						//TODO:Piのリロード処理が必要
						for(var accuracy = 2u;accuracy<=value;) {
							Math.E+=new Rational(false,BigUInteger.One,denominator);
							accuracy++;
							denominator*=new BigUInteger(accuracy);
						}
					}

				}

				_Accuracy=value;
			}
		}

		private static int _Accuracy = 1000;

#endif

		/// <summary>
		/// 分母
		/// </summary>
		internal
#if DEBUG&&!DLLDEBUG
			double
#else
		BigUInteger
#endif
			Denominator {
			get;
#if !DEBUG||DLLDEBUG
			set;
#endif
		}

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// 無限大
		/// </summary>
		private bool Infinity {
			get;
			set;
		}

		internal static BigUInteger RoundInfrator {
			get;
			private set;
		} = new BigUInteger(new OuterInterfaceType[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,7937138045914972160,11151642372436540647,2446674729804092815,11226094294443200128,9249967242163491027,11855572604451412841,13594583091842712964,4307584289988179617,14305202779558730011,4240521022316312398,6722459159443608745,7949200002432215832,15926694323032735615,3790687172139468,10053659588727441018,3438267197708030823,9418037243507746956,10649755547831423900,11582201291752330384,1611538053064194173,11710174023569989792,9099128256937943680,11344865295827694237,10754633901712100925,16184643626624795573,10709445966925288251,1615109362280013446,6147706922323569578,13947585262872041257,17377847844618386152,7062560128487761698,15560320250851659439,11679077583573603823,11810950552883541402,5385891509032596167,1577186046341739227,274216859525772976 });

		internal static BigUInteger RoundInternalInfrator {
			get;
			private set;
		} = new BigUInteger(new OuterInterfaceType[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,5584404164311515136,835959282108096778,6020003224331376540,1580478502174691585,265952053087152196,7875261602256818719,6818622402460268334,6182354752462692945,13924819279620438800,5511722075744020755,11884359373307432604,5705023729483951859,11692990640650943226,37906871721394688,8302875518726652100,15935927903370756619,1946652066529711481,14263835109766480925,5141548475265994149,16115380530641941736,6421275793442588224,17204306274541230342,2768188516019632678,15312618648573251176,14272483676571542807,14860739300705124438,16151093622800134465,6136837002107040932,10348644112753551261,7757781782797896983,15285369063748962141,8029249918840181465,6110311393478728542,7429041086578104330,16965426942906858444,15771860463417392272,2742168595257729760 });

#endif

		/// <summary>
		/// 分子
		/// </summary>
		internal
#if DEBUG&&!DLLDEBUG
			double
#else
		BigUInteger
#endif
			Numerator {
			get;
#if !DEBUG||DLLDEBUG
			set;
#endif
		}

		/// <summary>
		/// 符号
		/// </summary>
		internal bool Sign {
#if DEBUG&&!DLLDEBUG
			get {
				return System.Math.Sign(this.Numerator)<0^System.Math.Sign(this.Denominator)<0;
			}
#else
			get;
#endif
		}

	}
}