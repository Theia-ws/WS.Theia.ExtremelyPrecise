using System;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using ContainerType = System.UInt64;
using OuterInterfaceType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise {

	/// <summary>
	/// 任意の大きさを持つ有理数を、誤差を発生させずに表現します。
	/// </summary>
	[Serializable]
	public struct BigUInteger:IComparable, IComparable<BigUInteger>, IEquatable<BigUInteger>, IFormattable {

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// コンテナの定数を初期化します。
		/// </summary>
		static BigUInteger() {

			BigUInteger.ContainerItemSizeWithBit=sizeof(ContainerType)*8;

			ContainerType decimalChunkShifter = 10;
			BigUInteger.DecimalChunkOder=1;
			for(var loopEnd = ContainerType.MaxValue/10;decimalChunkShifter<=loopEnd;decimalChunkShifter*=10) {
				BigUInteger.DecimalChunkOder++;
			}
			BigUInteger.DecimalChunkShifter=new BigUInteger(decimalChunkShifter);

		}

#endif

		/// <summary>
		/// Boolean 値を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">Boolean値(true=One、false=Zeroと認識します)。</param>
		public BigUInteger(bool value) {
#if DEBUG&&!DLLDEBUG
			this.Value=value ? 1ul : 0ul;
#else
			this.Value=value ? BigInteger.One : BigInteger.Zero;
#endif
		}

		/// <summary>
		/// バイト配列の値を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">BigInteger構造体の値を表すリトルエンディアン順に格納されたバイト値の配列。</param>
		public BigUInteger(byte[] value) {
#if DEBUG&&!DLLDEBUG
			//TODO:これあまり良い方法ではない
			this.Value=BitConverter.ToUInt64(value,0);
#else
			var internalArray = new byte[value.Length+1];
			Array.Copy(value,internalArray,value.Length);
			
			this.Value=new BigInteger(internalArray);
			this.Trim();
#endif
		}

		/// <summary>
		/// Decimal 値を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">10 進数値。</param>
		public BigUInteger(decimal value) {
#if DEBUG&&!DLLDEBUG
			this.Value=(ulong)value;
#else
			if(value<0) {
				throw new OverflowException();
			}
			this.Value=BigUInteger.Parse(System.Math.Truncate(value).ToString("E29",CultureInfo.CurrentCulture)).Value;
#endif
		}

		/// <summary>
		/// 倍精度浮動小数点値を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">倍精度浮動小数点数値。</param>
		public BigUInteger(double value) {
#if DEBUG&&!DLLDEBUG
			this.Value=(ulong)value;
#else
			if(double.IsNegativeInfinity(value)||double.IsPositiveInfinity(value)||double.IsNaN(value)||value<0) {
				throw new OverflowException();
			}
			this.Value=BigUInteger.Parse(System.Math.Truncate(value).ToString("E16",CultureInfo.CurrentCulture)).Value;
#endif
		}

		/// <summary>
		/// 32 ビット符号付き整数値を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">32 ビット符号付き整数値。</param>
		public BigUInteger(int value) {
#if DEBUG&&!DLLDEBUG
			this.Value=(ulong)value;
#else
			if(value<0) {
				throw new OverflowException();
			}
			//TODO:コンテナサイズを変える時に修正する事
			this.Value=new BigInteger(value);
#endif
		}

		/// <summary>
		/// 64 ビット符号付き整数値を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">64 ビット符号付き整数値。</param>
		public BigUInteger(long value) {
#if DEBUG&&!DLLDEBUG
			this.Value=(ulong)value;
#else
			if(value<0) {
				throw new OverflowException();
			}
			//TODO:コンテナサイズを変える時に修正する事
			this.Value=new BigInteger(value);
#endif
		}

		/// <summary>
		/// 単精度浮動小数点値を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">単精度浮動小数点数値。</param>
		public BigUInteger(float value) {
#if DEBUG&&!DLLDEBUG
			this.Value=(ulong)value;
#else
			if(float.IsNegativeInfinity(value)||float.IsPositiveInfinity(value)||float.IsNaN(value)||value<0) {
				throw new OverflowException();
			}
			this.Value=BigUInteger.Parse(System.Math.Truncate(value).ToString("E7",CultureInfo.CurrentCulture)).Value;
#endif
		}

		/// <summary>
		/// 32 ビット符号なし整数値を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">32 ビットの符号なし整数値。</param>
		public BigUInteger(uint value) {
#if DEBUG&&!DLLDEBUG
			this.Value=(ulong)value;
#else
			//TODO:コンテナサイズを変える時に修正する事
			this.Value=new BigInteger(value);
#endif
		}

		/// <summary>
		/// 64 ビット符号なし整数値を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="value">符号なし 64 ビット整数。</param>
		public BigUInteger(ulong value) {
#if DEBUG&&!DLLDEBUG
			this.Value=(ulong)value;
#else
			//TODO:コンテナサイズを変える時に修正する事
			this.Value=new BigInteger(value);
#endif
		}

		//TODO:できればInternalにしたいな
		/// <summary>
		/// コンテナ配列を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="numerator">分子</param>
		internal BigUInteger(OuterInterfaceType[] Numerator) {
#if DEBUG&&!DLLDEBUG
			this.Value=(ulong)Numerator[0];
#else
			//TODO:コンテナサイズを変える時に修正する事
			var ContainerItemSizeWithByte = sizeof(OuterInterfaceType);

			var temp = new byte[ContainerItemSizeWithByte];
			var numerator = new byte[Numerator.Length*ContainerItemSizeWithByte];

			for(int numeratorCounter = 0, containerCounter = 0;containerCounter<Numerator.Length;containerCounter++, numeratorCounter+=ContainerItemSizeWithByte) {
				temp=BitConverter.GetBytes(Numerator[containerCounter]);
				Array.Copy(temp,0,numerator,numeratorCounter,ContainerItemSizeWithByte);
			}

			this.Value=new BigInteger(numerator);
			this.Trim();
#endif
		}

		/// <summary>
		/// 現在の BigUInteger オブジェクトの値が偶数かどうかを示します。
		/// </summary>
		public bool IsEven {
			get {
#if DEBUG&&!DLLDEBUG
				return this.Value%2==0;
#else
				return (this%2).IsZero;
#endif
			}
		}

		/// <summary>
		/// 現在の BigUInteger オブジェクトの値が One かどうかを示します。
		/// </summary>
		public bool IsOne {
			get {
#if DEBUG&&!DLLDEBUG
				return this.Value==1;
#else
				return this.Value.IsOne;
#endif
			}
		}

		/// <summary>
		/// 現在の BigUInteger オブジェクトの値が 2 の累乗かどうかを示します。
		/// </summary>
		public bool IsPowerOfTwo {
			get {
#if DEBUG&&!DLLDEBUG
				return (this.Value&(this.Value-1))==0ul;
#else
				if(this.IsZero) {
					return false;
				}

				return (this&(this-1)).IsZero;

#endif
			}
		}

		/// <summary>
		/// 現在の BigUInteger オブジェクトの値が Zero かどうかを示します。
		/// </summary>
		public bool IsZero {
			get {
#if DEBUG&&!DLLDEBUG
				return this.Value==0;
#else
				return this.Value.IsZero;
#endif
			}
		}

		/// <summary>
		/// 正の 1 (1) を表す値を取得します。
		/// </summary>
		public static BigUInteger One {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= new BigUInteger(1);
#else
			= new BigUInteger(new ContainerType[] { 1 });
#endif

		//TODO:Publicにしてもいいかも…
		/// <summary>
		/// 正の 10 (10) を表す値を取得します。
		/// </summary>
		internal static BigUInteger Ten {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= new BigUInteger(10);
#else
			= new BigUInteger(new ContainerType[] { 10 });
#endif

		//TODO:Publicにしてもいいかも…
		/// <summary>
		/// 正の 2 (2) を表す値を取得します。
		/// </summary>
		internal static BigUInteger Tow {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= new BigUInteger(2);
#else
			= new BigUInteger(new ContainerType[] { 2 });
#endif

		/// <summary>
		/// 0 (ゼロ) を表す値を取得します。
		/// </summary>
		public static BigUInteger Zero {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= new BigUInteger(0);
#else
			= new BigUInteger(new ContainerType[] { 0 });
#endif

		/// <summary>
		/// 2 つの BigUInteger 値を加算し、その結果を返します。
		/// </summary>
		/// <param name="left">加算する 1 番目の値。</param>
		/// <param name="right">加算する 2 番目の値。</param>
		/// <returns>left と right の合計。</returns>
		public static BigUInteger Add(BigUInteger left,BigUInteger right) {
			return left+right;
		}

		/// <summary>
		/// 2 つの BigUInteger 値に対し、ビットごとの And 演算を実行します。
		/// </summary>
		/// <param name="left">And演算する最初の値。</param>
		/// <param name="right">And演算する2 番目の値。</param>
		/// <returns>ビットごとの And 演算の結果。</returns>
		public static BigUInteger BitwiseAnd(BigUInteger left,BigUInteger right) {
			return left&right;
		}

		/// <summary>
		/// 2 つの BigUInteger 値に対し、ビットごとの Or 演算を実行します。
		/// </summary>
		/// <param name="left">Or演算する最初の値。</param>
		/// <param name="right">Or演算する2 番目の値。</param>
		/// <returns>ビットごとの Or 演算の結果。</returns>
		public static BigUInteger BitwiseOr(BigUInteger left,BigUInteger right) {
			return left|right;
		}

		/// <summary>
		/// 2 つの BigUInteger 値を比較し、1 番目の値が 2 番目の値よりも小さいか、同じか、または大きいかを示す整数を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>left と right の相対値を示す符号付き整数。</returns>
		public static int Compare(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return left.Value.CompareTo(right.Value);
#else
			return left.Value.CompareTo(right.Value);
#endif
		}

		/// <summary>
		/// BigUInteger 値を複製します。
		/// </summary>
		/// <returns>複製したBigUInteger値のオブジェクト。</returns>
		public BigUInteger Clone() {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(this.Value);
#else
			//TODO:Clone機能必要か検討する
			return new BigUInteger() { Value=new BigInteger(this.Value.ToByteArray()) };

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
			BigUInteger BigUIntegerOther = other;
			return this>BigUIntegerOther ? 1 : this==BigUIntegerOther ? 0 : -1;
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
			BigUInteger BigUIntegerOther = other;
			return this>BigUIntegerOther ? 1 : this==BigUIntegerOther ? 0 : -1;
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
			BigUInteger BigUIntegerOther = other;
			return this>BigUIntegerOther ? 1 : this==BigUIntegerOther ? 0 : -1;
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
				var BigUIntegerOther = (BigUInteger)other;
				return this>BigUIntegerOther ? 1 : this==BigUIntegerOther ? 0 : -1;
			} catch(Exception e) {
				throw new ArgumentException(string.Empty,e);
			}
#else
			if(other==null) {
				return 1;
			}
			try {
				return Compare(this,(BigUInteger)other);
			} catch(Exception e) {
				//TODO:メッセージ何とかする
				throw new ArgumentException(string.Empty,e);
			}
#endif
		}

		/// <summary>
		/// このインスタンスと BigUInteger を比較し、このインスタンスの値が BigUInteger の値よりも小さいか、同じか、または大きいかを示す整数を返します。
		/// </summary>
		/// <param name="other">比較する BigUInteger 。</param>
		/// <returns>このインスタンスと other の相対的な値を示す符号付き整数値です (次の表を参照)。 
		///戻り値
		///説明 
		///0 より小さい値
		///現在のインスタンスは other より小さい。 
		///0 
		///現在のインスタンスと other は等しい。 
		///0 より大きい値
		///現在のインスタンスは other より大きい。</returns>
		public int CompareTo(BigUInteger other) {
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
			BigUInteger BigUIntegerOther = other;
			return this>BigUIntegerOther ? 1 : this==BigUIntegerOther ? 0 : -1;
#else
			return Compare(this,other);
#endif
		}

		/// <summary>
		/// BigUInteger 値を 1 だけデクリメントします。
		/// </summary>
		/// <param name="value">デクリメントする値。</param>
		/// <returns>value パラメーターの値を 1 だけデクリメントした値。</returns>
		public static BigUInteger Decrement(BigUInteger value) {
			return --value;
		}

		/// <summary>
		/// 一方の BigUInteger 値をもう一方の値で除算し、その結果を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>除算の商。</returns>
		public static BigUInteger Divide(BigUInteger dividend,BigUInteger divisor) {
			return dividend/divisor;
		}

		/// <summary>
		/// 現在のインスタンスの値と 10進数の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する 10進数の値。</param>
		/// <returns> 10進数の値の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(decimal other) {
#if DEBUG&&!DLLDEBUG
			return this.Value.Equals(other);
#else
			return BigUInteger.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と倍精度浮動小数点数の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する倍精度浮動小数点数の値。</param>
		/// <returns> 倍精度浮動小数点数の値の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(double other) {
#if DEBUG&&!DLLDEBUG
			return this.Value.Equals(other);
#else
			if(double.IsNaN(other)) {
				return false;
			}
			return BigUInteger.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と符号付き 64 ビット整数の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する符号付き 64 ビット整数値。</param>
		/// <returns>符号付き 64 ビット整数の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(long other) {
#if DEBUG&&!DLLDEBUG
			return this.Value.Equals(other);
#else
			return BigUInteger.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と指定されたオブジェクトの値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="obj">比較対象のオブジェクト。</param>
		/// <returns>obj 引数が 数値 で、その値が現在の BigUInteger インスタンスの値と等しい場合は true。それ以外の場合は false。</returns>
		public override bool Equals(object obj) {
#if DEBUG&&!DLLDEBUG
			return this.Value.Equals(obj);
#else

			if(!(obj is BigUInteger)) {
				return false;
			}
			var other = (BigUInteger)obj;
			return BigUInteger.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と BigUInteger の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する BigUInteger 値。</param>
		/// <returns> BigUInteger の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(BigUInteger other) {
#if DEBUG&&!DLLDEBUG
			return this.Value.Equals(other.Value);
#else
			return BigUInteger.Equality(this,other);
#endif
		}

		/// <summary>
		/// 現在のインスタンスの値と符号無し 64 ビット整数の値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="other">比較する符号無し 64 ビット整数値。</param>
		/// <returns>符号無し 64 ビット整数の値と現在のインスタンスの値が等しい場合は true。それ以外の場合は false。</returns>
		public bool Equals(ulong other) {
#if DEBUG&&!DLLDEBUG
			return this.Value.Equals(other);
#else
			return BigUInteger.Equality(this,other);
#endif
		}

		/// <summary>
		/// 2 つの BigUInteger オブジェクトの値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値。</param>
		/// <param name="right">比較する 2 番目の値。</param>
		/// <returns>left パラメーターと right パラメーターが同じ値の場合は true。それ以外の場合は false。</returns>
		public static bool Equals(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return left.Value.Equals(right.Value);
#else
			return BigUInteger.Equality(left,right);
#endif
		}

		/// <summary>
		/// OLE オートメーション通貨値を格納している指定した 64 ビット符号付き整数を、それと等価の BigUInteger 値に変換します。
		/// </summary>
		/// <param name="cy">OLE オートメーション通貨値。</param>
		/// <returns>cy と等価の値を格納している BigUInteger。</returns>
		public static BigUInteger FromOACurrency(long cy) {
			return new BigUInteger(cy)/new BigUInteger(10000);
		}

		/// <summary>
		/// 現在の BigUInteger オブジェクトのハッシュ コードを返します。
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
		/// 2 つの BigUInteger 値の最大公約数を求めます。
		/// </summary>
		/// <param name="left">最大公約数を求める最初の値。</param>
		/// <param name="right">最大公約数を求める2 番目の値。</param>
		/// <returns>left と right の最大公約数。</returns>
		public static BigUInteger GreatestCommonDivisor(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			if(left.Value%1!=0) {
				throw new ArgumentException("小数を含む値です。",nameof(left));
			}
			if(right.Value%1!=0) {
				throw new ArgumentException("小数を含む値です。",nameof(right));
			}

			if(left==right) {
				return left;
			}
			BigUInteger big;
			BigUInteger small;
			{
				BigUInteger absLeft = left;
				BigUInteger absRight = right;
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
			if(left.IsOne||right.IsOne) {
				return BigUInteger.One;
			} else if(left.IsZero) {
				return right;
			} else if(right.IsZero) {
				return left;
			}

			var cmp = Compare(left,right);
			if(cmp==0) {
				return left;
			}

			BigUInteger big;
			BigUInteger small;
			if(cmp>0) {
				big=left;
				small=right;
			} else {
				big=right;
				small=left;
			}

			var reminder = Mod(big,small);

			while(!reminder.IsZero) {
				cmp=Compare(small,reminder);
				if(cmp>0) {
					big=small;
					small=reminder;
				} else if(cmp<0) {
					big=reminder;
				} else {
					return small;
				}
				reminder=Mod(big,small);
			}

			return small;
#endif
		}

		/// <summary>
		/// BigUInteger 値を 1 だけインクリメントします。
		/// </summary>
		/// <param name="value">インクリメントする値。</param>
		/// <returns>value パラメーターの値を 1 だけインクリメントした値。</returns>
		public static BigUInteger Increment(BigUInteger value) {
			return ++value;
		}

		/// <summary>
		/// 指定されたビット数だけ BigUInteger 値を左にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value を左にシフトするビット数。</param>
		/// <returns>指定されたビット数だけ左にシフトした値。</returns>
		public static BigUInteger LeftShift(BigUInteger value,int shift) {
			return value<<shift;
		}

		/// <summary>
		/// 指定された 2 つの BigUInteger 値の除算の結果生じた剰余を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>除算の結果生じた剰余。</returns>
		public static BigUInteger Mod(BigUInteger dividend,BigUInteger divisor) {
			return dividend%divisor;
		}

		/// <summary>
		/// 数値を別の数値で累乗し、それをさらに別の数値で割った結果生じた剰余を求めます。
		/// </summary>
		/// <param name="value">指数 exponent で累乗する数値。</param>
		/// <param name="exponent">value の指数。</param>
		/// <param name="modulus">value をexponent で累乗した結果を除算する時の除数。</param>
		/// <returns>value をexponentで累乗し modulus で割った結果生じた剰余。</returns>
		public static BigUInteger ModPow(BigUInteger value,BigUInteger exponent,BigUInteger modulus) {
			//TODO:ExtendMathまたはMathにあるべきメソッドではないか？
			return Math.Pow(value,exponent)%modulus;
		}

		/// <summary>
		/// 2 つの BigUInteger 値の積を返します。
		/// </summary>
		/// <param name="left">乗算対象の最初の数。</param>
		/// <param name="right">乗算対象の 2 番目の数。</param>
		/// <returns>left と rightパラメーターの積。</returns>
		public static BigUInteger Multiply(BigUInteger left,BigUInteger right) {
			return left*right;
		}

		/// <summary>
		/// BigUInteger 値のビットごとの 1 の補数を返します。
		/// </summary>
		/// <param name="value">1の補数を取得したい値。</param>
		/// <returns>value のビットごとの 1 の補数。</returns>
		public static BigUInteger OnesComplement(BigUInteger value) {
			return ~value;
		}

		/// <summary>
		/// 数値の文字列形式を、それと等価の BigUInteger に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public static BigUInteger Parse(String value) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(double.Parse(value,CultureInfo.CurrentCulture));
#else
			return Parse(value,CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 指定のスタイルで表現された数値の文字列形式を、それと等価な BigUInteger に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <param name="style">value に許可されている書式を指定する列挙値のビットごとの組み合わせ。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public static BigUInteger Parse(String value,NumberStyles style) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(double.Parse(value,style,CultureInfo.CurrentCulture));
#else
			return Parse(value,style,CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 指定されたカルチャ固有の書式で表現された文字列形式の数値を、それと等価の BigUInteger に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <param name="provider">value に関するカルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public static BigUInteger Parse(String value,IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(double.Parse(value,provider));
#else
			return Parse(value,NumberStyles.Number|NumberStyles.AllowExponent,provider);
#endif
		}

		/// <summary>
		/// 指定したスタイルおよびカルチャ固有の書式の数値の文字列形式を、それと等価の BigUInteger に変換します。
		/// </summary>
		/// <param name="value">変換する数値を含んだ文字列。</param>
		/// <param name="style">value に許可されている書式を指定する列挙値のビットごとの組み合わせ。</param>
		/// <param name="provider">value に関するカルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>value パラメーターで指定されている数値と等価の値。</returns>
		public static BigUInteger Parse(String value,NumberStyles style,IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(double.Parse(value,style,provider));
#else
			if(value==null) {
				throw new ArgumentNullException(nameof(value));
			}
			return new BigUInteger() { Value=BigInteger.Parse(value,style,provider) };
#endif
		}

		/// <summary>
		/// BigUInteger オペランドの値を返します。 オペランドの符号は変更されません。
		/// </summary>
		/// <param name="value">符号を反転させない値。</param>
		/// <returns>value パラメーターと等価な値。</returns>
		public static BigUInteger Plus(BigUInteger value) {
			return value;
		}

		/// <summary>
		/// 指定されたビット数だけ BigUInteger 値を右にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value を右にシフトするビット数。</param>
		/// <returns>指定されたビット数だけ右にシフトされた値。</returns>
		public static BigUInteger RightShift(BigUInteger value,int shift) {
			return value>>shift;
		}

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// 指定されたビット数だけBigUIntegerの値を左にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="arrayShift">配列項目としてシフトする量。</param>
		/// <param name="innerShift">配列内でシフトするビット数。</param>
		/// <returns>指定されたビット数だけ左にシフトされた値。</returns>
		public static BigUInteger LeftShift(BigUInteger value,int arrayShift,int innerShift) {
			return new BigUInteger() {
				Value=value.Value<<arrayShift*BigUInteger.ContainerItemSizeWithBit+innerShift
			};
		}

		/// <summary>
		/// 指定されたビット数だけBigUIntegerの値を右にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="arrayShift">配列項目としてシフトする量。</param>
		/// <param name="innerShift">配列内でシフトするビット数。</param>
		/// <returns>指定されたビット数だけ右にシフトされた値。</returns>
		public static BigUInteger RightShift(BigUInteger value,int arrayShift,int innerShift) {
			return new BigUInteger() {
				Value=value.Value>>arrayShift*BigUInteger.ContainerItemSizeWithBit+innerShift
			};
		}

		/// <summary>
		/// 指定されたビット数だけ BigUInteger 値をシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value をシフトするビット数。(プラスの場合左シフト、マイナスの場合右シフトとして扱います)</param>
		/// <returns>指定されたビット数だけシフトされた値。</returns>
		private static BigUInteger Shift(BigUInteger value,int shift) {

			if(shift==0) {
				return value;
			}

			var arrayShift = System.Math.DivRem(System.Math.Abs(shift),BigUInteger.ContainerItemSizeWithBit,out var innerShift);

			return shift>0 ? BigUInteger.LeftShift(value,arrayShift,innerShift) : BigUInteger.RightShift(value,arrayShift,innerShift);

		}
#endif

		/// <summary>
		/// BigUInteger 値を別の値から減算し、その結果を返します。
		/// </summary>
		/// <param name="left">減算される値 (被減数)。</param>
		/// <param name="right">減算する値 (減数)。</param>
		/// <returns>left から right を減算した結果。</returns>
		public static BigUInteger Subtract(BigUInteger left,BigUInteger right) {
			return left-right;
		}

		/// <summary>
		/// 指定した BigUInteger の値を、等価の 8 ビット符号なし整数に変換します。
		/// </summary>
		/// <param name="value">変換するBigUInteger。</param>
		/// <returns>value と等価の 8 ビット符号なし整数。</returns>
		public static byte ToByte(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (byte)value.Value;
#else
			if(value>byte.MaxValue) {
				throw new OverflowException();
			}
			return (byte)value.Value;
#endif
		}

		/// <summary>
		/// BigUInteger 値をバイト配列に変換します。
		/// </summary>
		/// <returns>現在の BigUInteger オブジェクトをバイトの配列に変換した値。</returns>
		public byte[] ToByteArray() {
#if DEBUG&&!DLLDEBUG

			return BitConverter.GetBytes(this.Value);
#else
			return this.Value.ToByteArray();
#endif
		}

#if !DEBUG||DLLDEBUG
		public ContainerType[] ToContainerArray() {
			var byteArray=this.Value.ToByteArray();
			var result = new ContainerType[byteArray.Length/BigUInteger.ContainerItemSizeWithByte+1];
			for(int inputCounter = 0, outputCounter = 0;inputCounter<byteArray.Length;inputCounter+=BigUInteger.ContainerItemSizeWithByte, outputCounter++) {
				result[outputCounter]=BitConverter.ToUInt64(byteArray,inputCounter);
			}
			return result;
		}
#endif

		/// <summary>
		/// 指定した BigUInteger の値を、それと等価の倍精度浮動小数点数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>valueと等価の倍精度浮動小数点数。</returns>
		public static double ToDouble(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (double)value.Value;
#else
			return (double)value.Value;

#endif
		}

		/// <summary>
		/// 指定した BigUInteger の値を、等価の 16 ビット符号付き整数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>value と等価の 16 ビット符号付き整数。</returns>
		public static short ToInt16(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (short)value.Value;
#else
			if(value>short.MaxValue) {
				throw new OverflowException();
			}
			//TODO:コンテナサイズを変える時に修正する事
			return (short)value.Value;
#endif
		}

		/// <summary>
		/// 指定した BigUInteger の値を、等価の 32 ビット符号付き整数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>value と等価の 32 ビット符号付き整数。</returns>
		public static int ToInt32(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (int)value.Value;
#else
			if(value>int.MaxValue) {
				throw new OverflowException();
			}
			//TODO:コンテナサイズを変える時に修正する事
			return (int)value.Value;
#endif
		}

		/// <summary>
		/// 指定した BigUInteger の値を、等価の 64 ビット符号付き整数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>value と等価の 64 ビット符号付き整数。</returns>
		public static long ToInt64(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (long)value.Value;
#else
			if(value>long.MaxValue) {
				throw new OverflowException();
			}
			//TODO:コンテナサイズを変える時に修正する事
			return (long)value.Value;
#endif
		}

		/// <summary>
		/// 指定した BigUInteger の値を、等価の 8 ビット符号付き整数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>value と等価の 8 ビット符号付き整数。</returns>
		public static sbyte ToSByte(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (sbyte)value.Value;
#else
			if(value>sbyte.MaxValue) {
				throw new OverflowException();
			}

			return (sbyte)value.Value;
#endif
		}

		/// <summary>
		/// 指定した BigUInteger の値を、それと等価の単精度浮動小数点数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>valueと等価の単精度浮動小数点数。</returns>
		public static float ToSingle(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (float)value.Value;
#else

			if(value>float.MaxValue) {
				return float.PositiveInfinity;
			}

			return (float)value.Value;

#endif
		}

		/// <summary>
		/// 現在の BigUInteger オブジェクトの数値を等価の文字列形式に変換します。
		/// </summary>
		/// <returns>現在の BigUInteger 値の文字列形式。</returns>
		public override string ToString() {
#if DEBUG&&!DLLDEBUG
			return this.Value.ToString(CultureInfo.CurrentCulture);
#else
			return ToString(CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 指定されたカルチャ固有の書式情報を使用して、現在の BigUInteger オブジェクトの数値をそれと等価の文字列形式に変換します。
		/// </summary>
		/// <param name="provider">カルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>現在の BigUInteger 値の文字列形式を、provider パラメーターで指定されている形式で表現した値。</returns>
		public string ToString(IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return this.Value.ToString(provider);
#else
			return ToString("G",provider);
#endif
		}

		/// <summary>
		/// 指定された書式を使用して、現在の BigUInteger オブジェクトの数値をそれと等価な文字列形式に変換します。
		/// </summary>
		/// <param name="format">標準またはカスタムの数値書式指定文字列。</param>
		/// <returns>現在の BigUInteger 値の文字列形式を、format パラメーターで指定されている形式で表現した値。</returns>
		public string ToString(String format) {
#if DEBUG&&!DLLDEBUG
			return this.Value.ToString(format,CultureInfo.CurrentCulture);
#else
			return ToString(format,CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 指定された書式とカルチャ固有の書式情報を使用して、現在の BigUInteger オブジェクトの数値をそれと等価の文字列形式に変換します。
		/// </summary>
		/// <param name="format">標準またはカスタムの数値書式指定文字列。</param>
		/// <param name="provider">カルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>format パラメーターと providerパラメーターで指定されている現在の BigUInteger 値の文字列表現。</returns>
		public string ToString(String format,IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return this.Value.ToString(format,provider);
#else
			return this.Value.ToString(format,provider);
#endif
		}

		/// <summary>
		/// 指定した BigUInteger の値を、等価の 16 ビット符号なし整数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>value の値と等価の 16 ビット符号なし整数。</returns>
		public static ushort ToUInt16(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (ushort)value.Value;
#else
			if(value>ushort.MaxValue) {
				throw new OverflowException();
			}
			//TODO:コンテナサイズを変える時に修正する事-
			return (ushort)value.Value;
#endif
		}

		/// <summary>
		/// 指定した BigUInteger の値を、等価の 32 ビット符号なし整数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>value の値と等価の 32 ビット符号なし整数。</returns>
		public static uint ToUInt32(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (uint)value.Value;
#else
			if(value>uint.MaxValue) {
				throw new OverflowException();
			}
			//TODO:コンテナサイズを変える時に修正する事
			return (uint)value.Value;
#endif
		}

		/// <summary>
		/// 指定した BigUInteger の値を、等価の 64 ビット符号なし整数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>value の値と等価の 64 ビット符号なし整数。</returns>
		public static ulong ToUInt64(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (ulong)value.Value;
#else
			if(value>ulong.MaxValue) {
				throw new OverflowException();
			}

			//TODO:コンテナサイズを変える時に修正する事
			return (ulong)value.Value;
#endif
		}

		/// <summary>
		/// 指定した BigUInteger の値を、等価の 10進数に変換します。
		/// </summary>
		/// <param name="value">変換する BigUInteger。</param>
		/// <returns>value と等価の 10進数。</returns>
		public static decimal ToDecimal(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (decimal)value.Value;
#else
			return (decimal)value.Value;
#endif
		}

		/// <summary>
		/// 肥大化した内部表現をトリミングします
		/// </summary>
		/// <returns>トリミングしたBigUInteger値</returns>
		public BigUInteger Trim() {

			return this;

		}

		/// <summary>
		/// 数値の文字列形式を対応する BigUInteger 表現に変換できるかどうかを試行し、変換に成功したかどうかを示す値を返します。
		/// </summary>
		/// <param name="value">数値の文字列形式。</param>
		/// <returns>valueが正常に変換できた場合はtrue。それ以外の場合はfalse。このメソッドから制御が戻るときに、valueと等価の BigUInteger が格納されます。value パラメーターが null の場合、または正しい形式ではない場合、変換は失敗します。変換に失敗した場合このパラメーターは初期化せずに渡されます。</returns>
		public static (bool status, BigUInteger result) TryParse(String value) {
#if DEBUG&&!DLLDEBUG
			return (double.TryParse(value,out var result), new BigUInteger(result));
#else
			return TryParse(value,NumberStyles.Number|NumberStyles.AllowExponent,CultureInfo.CurrentCulture);
#endif
		}

		/// <summary>
		/// 数値の文字列形式を対応する BigUInteger 表現に変換できるかどうかを試行し、変換に成功したかどうかを示す値を返します。
		/// </summary>
		/// <param name="value">数値の文字列形式。</param>
		/// <param name="style">value で存在する可能性を持つスタイル要素を示す、列挙値のビットごとの組み合わせ。 通常指定する値は Integer です。</param>
		/// <param name="provider">value に関するカルチャ固有の書式情報を提供するオブジェクト。</param>
		/// <returns>valueが正常に変換できた場合はtrue。それ以外の場合はfalse。このメソッドから制御が戻るときに、valueと等価の BigUInteger が格納されます。value パラメーターが null の場合、または正しい形式ではない場合、変換は失敗します。変換に失敗した場合このパラメーターは初期化せずに渡されます。</returns>
		public static (bool status, BigUInteger result) TryParse(String value,NumberStyles style,IFormatProvider provider) {
#if DEBUG&&!DLLDEBUG
			return (double.TryParse(value,style,provider,out var result), new BigUInteger(result));
#else
			try {
				//TODO:TryCatchではない方が速いかも。けれど内部処理の面で修正が難しい。優先度は低いので後ほど考える。
				return (true, Parse(value,style,provider));
			} catch(Exception ex) when(ex is ArgumentNullException||ex is FormatException||ex is ArgumentException||ex is OverflowException) {
				return (false, BigUInteger.Zero);
			}
#endif
		}

		/// <summary>
		/// 2 つの BigUInteger 値に対し、ビットごとの排他的 Or (XOr) 演算を実行します。
		/// </summary>
		/// <param name="left">排他的 Or演算する最初の値。</param>
		/// <param name="right">排他的 Or演算する2 番目の値。</param>
		/// <returns>ビットごとの Or 演算の結果。</returns>
		public static BigUInteger Xor(BigUInteger left,BigUInteger right) {
			return left^right;
		}

		/// <summary>
		/// 指定された 2 つの BigUInteger オブジェクトの値を加算します。
		/// </summary>
		/// <param name="left">加算する 1 番目の値。</param>
		/// <param name="right">加算する 2 番目の値。</param>
		/// <returns>left と right の合計。</returns>
		public static BigUInteger operator +(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(left.Value+right.Value);
#else
			return new BigUInteger() { Value=left.Value+right.Value };
#endif
		}

		/// <summary>
		/// 2 つの BigUInteger 値に対し、ビットごとの And 演算を実行します。
		/// </summary>
		/// <param name="left">And演算する最初の値。</param>
		/// <param name="right">And演算する2 番目の値。</param>
		/// <returns>ビットごとの And 演算の結果。</returns>
		public static BigUInteger operator &(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(left.Value&right.Value);
#else
			var leftArray=left.Value.ToByteArray();
			var rightArray=right.ToByteArray();
			var result = new byte[System.Math.Max(leftArray.Length,rightArray.Length)+1];
			var loopEnd=System.Math.Min(leftArray.Length,rightArray.Length);
			for(var counter=0;counter<loopEnd;counter++) {
				result[counter]=(byte)(leftArray[counter]&rightArray[counter]);
			}
			return new BigUInteger(result);
#endif
		}

		/// <summary>
		/// 2 つの BigUInteger 値に対し、ビットごとの Or 演算を実行します。
		/// </summary>
		/// <param name="left">Or演算する最初の値。</param>
		/// <param name="right">Or演算する2 番目の値。</param>
		/// <returns>ビットごとの Or 演算の結果。</returns>
		public static BigUInteger operator |(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(left.Value|right.Value);
#else
			var leftArray = left.Value.ToByteArray();
			var rightArray = right.ToByteArray();
			var result = new byte[System.Math.Max(leftArray.Length,rightArray.Length)+1];
			var loopEnd = System.Math.Min(leftArray.Length,rightArray.Length);
			for(var counter = 0;counter<loopEnd;counter++) {
				result[counter]=(byte)(leftArray[counter]|rightArray[counter]);
			}
			for(var counter = loopEnd;counter<leftArray.Length;counter++) {
				result[counter]=leftArray[counter];
			}
			for(var counter = loopEnd;counter<rightArray.Length;counter++) {
				result[counter]=rightArray[counter];
			}
			return new BigUInteger(result);
#endif
		}

		/// <summary>
		/// BigUInteger 値を 1 だけデクリメントします。
		/// </summary>
		/// <param name="value">デクリメントする値。</param>
		/// <returns>value パラメーターの値を 1 だけデクリメントした値。</returns>
		public static BigUInteger operator --(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(value.Value-1);
#else
			return value-BigUInteger.One;
#endif
		}

		/// <summary>
		/// 一方の BigUInteger 値をもう一方の値で除算し、その結果を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>除算の結果 。</returns>
		public static BigUInteger operator /(BigUInteger dividend,BigUInteger divisor) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(dividend.Value/divisor.Value);
#else
			return Math.DivRem(dividend,divisor).Quotient;
#endif
		}

		/// <summary>
		/// 2 つの BigUInteger オブジェクトの値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>left パラメーターと right パラメーターが同じ値の場合は true。それ以外の場合は false。</returns>
		public static bool operator ==(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return left.Value==right.Value;
#else
			return Equality(left,right);
#endif
		}

#if !DEBUG||DLLDEBUG
		/// <summary>
		/// 2 つの BigUInteger オブジェクトの値が等しいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>left パラメーターと right パラメーターが同じ値の場合は true。それ以外の場合は false。</returns>
		private static bool Equality(BigUInteger left,BigUInteger right) {
			return left.Value==right.Value;
		}
#endif

		/// <summary>
		/// 2 つの BigUInteger 値に対し、ビットごとの排他的 Or (XOr) 演算を実行します。
		/// </summary>
		/// <param name="left">排他的 Or演算する最初の値。</param>
		/// <param name="right">排他的 Or演算するビットごとの Or 演算の結果。</param>
		/// <returns>ビットごとの Or 演算の結果。</returns>
		public static BigUInteger operator ^(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(left.Value^left.Value);
#else
			var leftArray = left.Value.ToByteArray();
			var rightArray = right.ToByteArray();
			var result = new byte[System.Math.Max(leftArray.Length,rightArray.Length)+1];
			var loopEnd = System.Math.Min(leftArray.Length,rightArray.Length);
			for(var counter = 0;counter<loopEnd;counter++) {
				result[counter]=(byte)(leftArray[counter]^rightArray[counter]);
			}
			for(var counter = loopEnd;counter<leftArray.Length;counter++) {
				result[counter]=leftArray[counter];
			}
			for(var counter = loopEnd;counter<rightArray.Length;counter++) {
				result[counter]=rightArray[counter];
			}
			return new BigUInteger(result);
#endif
		}

		/// <summary>
		/// BigUInteger 値から Byte 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Byte 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なByte値。</returns>
		public static explicit operator byte(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (byte)value.Value;
#else
			return ToByte(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値から SByte 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">SByte値 へと変換する値。</param>
		/// <returns>valueパラメータと等価なSByte値。</returns>
		public static explicit operator sbyte(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (sbyte)value.Value;
#else
			return ToSByte(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値から Int32 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Int32 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なInt32値。</returns>
		public static explicit operator int(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (int)value.Value;
#else
			return ToInt32(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値から UInt32 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">UInt32 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なUInt32値。</returns>
		public static explicit operator uint(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (uint)value.Value;
#else
			return ToUInt32(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値から Int16 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Int16 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なInt16値。</returns>
		public static explicit operator short(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (short)value.Value;
#else
			return ToInt16(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値から UInt16 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">UInt16 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なUInt16値。</returns>
		public static explicit operator ushort(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (ushort)value.Value;
#else
			return ToUInt16(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値から Int64 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Int64 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なInt64値。</returns>
		public static explicit operator long(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (long)value.Value;
#else
			return ToInt64(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値から UInt64 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">UInt64 値へと変換する値。</param>
		/// <returns>valueパラメータと等価なUInt64値。</returns>
		public static explicit operator ulong(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (ulong)value.Value;
#else
			return ToUInt64(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値から単精度浮動小数点への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">単精度浮動小数点へと変換する値。</param>
		/// <returns>valueパラメータと等価な単精度浮動小数点。</returns>
		public static explicit operator float(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (float)value.Value;
#else
			return ToSingle(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値から倍精度浮動小数点値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">倍精度浮動小数点値へと変換する値。</param>
		/// <returns>valueパラメータと等価な倍精度浮動小数点値。</returns>
		public static explicit operator double(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return value.Value;
#else
			return ToDouble(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値からBoolean値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Boolean値へと変換する値。</param>
		/// <returns>valueパラメータと等価なBoolean値。（0の場合false、それ以外の場合true）</returns>
		public static explicit operator bool(BigUInteger value) {
			return !value.IsZero;
		}

		/// <summary>
		/// BigUInteger 値から Decimal 値への明示的な変換を定義します。
		/// </summary>
		/// <param name="value">Decimal値へと変換する値。</param>
		/// <returns>valueパラメータと等価なDecimal値。</returns>
		public static explicit operator decimal(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return (decimal)value.Value;
#else
			return ToDecimal(value);
#endif
		}

		/// <summary>
		/// BigUInteger 値がもう 1 つの BigUInteger 値より大きいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>true が left より大きい場合は right。それ以外の場合は false。</returns>
		public static bool operator >(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return left.Value>right.Value;
#else
			return Compare(left,right)>0;
#endif
		}



		/// <summary>
		/// BigUInteger 値がもう 1 つの BigUInteger 値以上かどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>true が left より大きい場合は right。それ以外の場合は false。</returns>
		public static bool operator >=(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return left.Value>=right.Value;
#else
			return Compare(left,right)>=0;
#endif
		}

		/// <summary>
		/// Byte 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(byte value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// SByte 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(sbyte value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// Int32 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(int value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// UInt32 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(uint value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// Int16 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(short value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// UInt16 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(ushort value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// Int64 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(long value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// UInt64 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(ulong value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// Single 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(float value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// Double 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(double value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// Boolean 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(bool value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// decimal 値から BigUInteger 値への暗黙的な変換を定義します。
		/// </summary>
		/// <param name="value">BigUInteger へと変換する値。</param>
		/// <returns>valueパラメータと等価なBigUInteger値。</returns>
		public static implicit operator BigUInteger(decimal value) {
			return new BigUInteger(value);
		}

		/// <summary>
		/// BigUInteger 値を 1 だけインクリメントします。
		/// </summary>
		/// <param name="value">インクリメントする値。</param>
		/// <returns>value パラメーターの値を 1 だけインクリメントした値。</returns>
		public static BigUInteger operator ++(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(value.Value+1);
#else
			return value+BigUInteger.One;
#endif
		}

		/// <summary>
		/// 2 つの BigUInteger オブジェクトの値が異なるかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値です。</param>
		/// <param name="right">比較する 2 番目の値です。</param>
		/// <returns>left と right が等しくない場合は true。それ以外の場合は false。</returns>
		public static bool operator !=(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return left.Value!=right.Value;
#else
			return !(left==right);
#endif
		}

		/// <summary>
		/// 指定されたビット数だけ BigUInteger 値を左にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value を左にシフトするビット数。</param>
		/// <returns>指定されたビット数だけ左にシフトされた値。</returns>
		public static BigUInteger operator <<(BigUInteger value,int shift) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(value.Value<<shift);
#else
			return Shift(value,shift);
#endif
		}

		/// <summary>
		/// BigUInteger 値がもう 1 つの BigUInteger 値より小さいかどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値。</param>
		/// <param name="right">比較する 2 番目の値。</param>
		/// <returns>left が right より小さい場合は true。それ以外の場合は false。</returns>
		public static bool operator <(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return left.Value<right.Value;
#else
			return Compare(left,right)<0;
#endif
		}

		/// <summary>
		/// BigUInteger 値がもう 1 つの BigUInteger 値以下かどうかを示す値を返します。
		/// </summary>
		/// <param name="left">比較する最初の値。</param>
		/// <param name="right">比較する 2 番目の値。</param>
		/// <returns>left が right 以下の場合は true。それ以外の場合は false。</returns>
		public static bool operator <=(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return left.Value<=right.Value;
#else
			return Compare(left,right)<=0;
#endif
		}

		/// <summary>
		/// 指定された 2 つの BigUInteger 値の除算の結果生じた剰余を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>除算の結果生じた剰余。</returns>
		public static BigUInteger operator %(BigUInteger dividend,BigUInteger divisor) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(dividend.Value%divisor.Value);
#else
			//TODO:事前に公約数で割る処理を入れた方が良い?
			return Math.DivRem(dividend,divisor).Remainder;
#endif
		}

		/// <summary>
		/// 2 つの BigUInteger 値の積を返します。
		/// </summary>
		/// <param name="left">乗算対象の最初の数。</param>
		/// <param name="right">乗算対象の 2 番目の数。</param>
		/// <returns>left と right の積。</returns>
		public static BigUInteger operator *(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(left.Value*right.Value);
#else

			return new BigUInteger() { Value=left.Value*right.Value };

#endif
		}

		/// <summary>
		/// BigUInteger 値のビットごとの 1 の補数を返します。
		/// </summary>
		/// <param name="value">1の補数を取得したい値。</param>
		/// <returns>value のビットごとの 1 の補数。</returns>
		public static BigUInteger operator ~(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(~value.Value);
#else
			var valueArray = value.Value.ToByteArray();
			var result = new byte[valueArray.Length];
			for(var counter = 0;counter<valueArray.Length;counter++) {
				result[counter]=(byte)~valueArray[counter];
			}
			return new BigUInteger(result);
#endif
		}

		/// <summary>
		/// 指定されたビット数だけ BigUInteger 値を右にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="shift">value を右にシフトするビット数。</param>
		/// <returns>指定されたビット数だけ右にシフトされた値。</returns>
		public static BigUInteger operator >>(BigUInteger value,int shift) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(value.Value/(ulong)System.Math.Pow(2,shift));
#else
			return Shift(value,-shift);
#endif
		}

		/// <summary>
		/// BigUInteger 値をもう 1 つの BigUInteger 値から減算します。
		/// </summary>
		/// <param name="left">減算される値 (被減数)。</param>
		/// <param name="right">減算する値 (減数)。</param>
		/// <returns>left から right を減算した結果。</returns>
		public static BigUInteger operator -(BigUInteger left,BigUInteger right) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(left.Value-right.Value);
#else

			if(left<right) {
				throw new OverflowException();
			}

			return new BigUInteger() { Value=left.Value-right.Value };

#endif
		}

		/// <summary>
		/// BigUInteger オペランドの値を返します。 オペランドの符号は変更されません。
		/// </summary>
		/// <param name="value">符号を反転させない値。</param>
		/// <returns>value パラメーターと等価な値。</returns>
		public static BigUInteger operator +(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return value;
#else
			return value;
#endif
		}

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// コンテナ―アイテムのBitで示したサイズ。
		/// </summary>
		internal static int ContainerItemSizeWithBit {
			get;
		}

		/// <summary>
		/// コンテナ―アイテムのByteで示したサイズ。
		/// </summary>
		internal static int ContainerItemSizeWithByte {
			get;
		} = sizeof(ContainerType);

		/// <summary>
		/// 10進数表記の文字列をデータコンテナ―に入力する際、分割するサイズ。
		/// </summary>
		internal static int DecimalChunkOder {
			get;
		}

		/// <summary>
		/// 10進数表記の文字列をデータコンテナ―に入力する際、分割したデータ同士を結合する為に使用するシフト量。
		/// </summary>
		internal static BigUInteger DecimalChunkShifter {
			get;
		}

#endif

		/// <summary>
		/// 値
		/// </summary>
		internal
#if DEBUG&&!DLLDEBUG
			ulong
#else
		BigInteger
#endif
			Value {
			get;
			set;
		}

	}
}