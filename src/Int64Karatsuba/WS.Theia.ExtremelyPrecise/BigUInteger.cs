using System;
using System.Globalization;
using System.IO;
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
			BigUInteger.LowerMaskShifter=sizeof(ContainerType)*4;

			BigUInteger.UpperMask=0;
			for(var counter = 0;counter<BigUInteger.LowerMaskShifter;counter++) {
				BigUInteger.UpperMask<<=1;
				BigUInteger.UpperMask++;
			}

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
			this.Value=value ? new ContainerType[] { 1 } : new ContainerType[] { 0 };
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
			if(value==null) {
				throw new ArgumentNullException(nameof(value));
			}
			var resultLength = System.Math.DivRem(value.Length,BigUInteger.ContainerItemSizeWithByte,out int overItem);
			if(overItem>0) {
				resultLength++;
			}
			var result = new ContainerType[resultLength];
			var position = 0;
			var index = 0;
			for(var loopEnd = value.Length-overItem;position<loopEnd;position+=BigUInteger.ContainerItemSizeWithByte, index++) {
				//TODO:コンテナサイズを変える時に修正する事
				result[index]=BitConverter.ToUInt64(value,position);
			}
			if(position<value.Length) {
				var temp = new byte[BigUInteger.ContainerItemSizeWithByte];
				Array.Copy(value,position,temp,0,value.Length-position);
				//TODO:コンテナサイズを変える時に修正する事
				result[index]=BitConverter.ToUInt64(temp,0);
			}
			this.Value=result;
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
			this.Value=new ContainerType[] { (ContainerType)value };
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
			this.Value=new ContainerType[] { (ContainerType)value };
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
			this.Value=new ContainerType[] { value };
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
			this.Value=new ContainerType[] { value };
#endif
		}

		//TODO:できればInternalにしたいな
		/// <summary>
		/// コンテナ配列を使用して、BigUInteger 構造体の新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="numerator">分子</param>
		internal BigUInteger(OuterInterfaceType[] numerator) {
#if DEBUG&&!DLLDEBUG
			this.Value=(ulong)numerator[0];
#else
			this.Value=numerator;
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
				var index = 0;
				if(this.Value[index]!=1) {
					return false;
				}
				index++;

				for(var valueLength = this.Value.Length;index<valueLength;index++) {
					if(this.Value[index]!=0) {
						return false;
					}
				}

				return true;
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
				foreach(var val in this.Value) {
					if(val!=0) {
						return false;
					}
				}
				return true;
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

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// 指定された 2 つのBigUIntegerの値をマージ加算します。注意：destination BigUIntegerの値を破壊的に変更します。
		/// </summary>
		/// <param name="destination">マージ加算先となるBigUInteger。</param>
		/// <param name="data">マージ加算をするBigUInteger。</param>
		/// <returns>destinationにdataをマージ加算した値。</returns>
		public static BigUInteger MargeAdd(BigUInteger destination,BigUInteger data) {
			return BigUInteger.MargeAdd(destination,0,data,0,data.Value.Length);
		}

		/// <summary>
		/// 指定された 2 つのBigUIntegerの値をマージ加算します。注意：destinationデータコンテナ―の値を破壊的に変更します。
		/// </summary>
		/// <param name="destination">マージ加算先となるBigUInteger。</param>
		/// <param name="destinationPoint">マージ加算の開始場所になるインデックス。</param>
		/// <param name="data">マージ加算をするデータコンテナ―。</param>
		/// <returns>destinationにdataをマージ加算した値。</returns>
		public static BigUInteger MargeAdd(BigUInteger destination,int destinationPoint,BigUInteger data) {
			return BigUInteger.MargeAdd(destination,destinationPoint,data,0,data.Value.Length);
		}


		/// <summary>
		/// 指定された 2 つのBigUIntegerの値をマージ加算します。注意：destination BigUIntegerの値を破壊的に変更します。
		/// </summary>
		/// <param name="destination">マージ加算先となるBigUInteger。</param>
		/// <param name="data">マージ加算をするBigUInteger。</param>
		/// <param name="dataPoint">マージ加算するデータの開始インデックス。</param>
		/// <param name="length">マージ加算するデータの長さ。</param>
		/// <returns>destinationにdataをマージ加算した値。</returns>
		public static BigUInteger MargeAdd(BigUInteger destination,BigUInteger data,int dataPoint,int length) {
			return BigUInteger.MargeAdd(destination,0,data,dataPoint,length);
		}


		/// <summary>
		/// 指定された 2 つのBigUIntegerの値をマージ加算します。注意：destination BigUIntegerの値を破壊的に変更します。
		/// </summary>
		/// <param name="destination">マージ加算先となるBigUInteger。</param>
		/// <param name="destinationPoint">マージ加算の開始場所になるインデックス。</param>
		/// <param name="data">マージ加算をするBigUInteger。</param>
		/// <param name="dataPoint">マージ加算するデータの開始インデックス。</param>
		/// <param name="length">マージ加算するデータの長さ。</param>
		/// <returns>destinationにdataをマージ加算した値。</returns>
		public static BigUInteger MargeAdd(BigUInteger destination,int destinationPoint,BigUInteger data,int dataPoint,int length) {

			var loopEnd = System.Math.Min(System.Math.Min(destinationPoint+length,destination.Value.Length),destinationPoint+data.Value.Length);
			var overFlowFlgs = new bool[data.Value.Length];
			var overFlowMasterFlg = false;

			int dataCounter;
			int destinationCounter;
			int overFlowCounter;

			for(dataCounter=dataPoint, destinationCounter=destinationPoint;destinationCounter<loopEnd;dataCounter++, destinationCounter++) {
				unchecked {
					destination.Value[destinationCounter]+=data.Value[dataCounter];
				}
				if(destination.Value[destinationCounter]<data.Value[dataCounter]) {
					overFlowFlgs[dataCounter]=true;
					overFlowMasterFlg=true;
				} else {
					overFlowFlgs[dataCounter]=false;
				}
			}

			for(var shiftIndex = 1;overFlowMasterFlg;shiftIndex++) {
				overFlowMasterFlg=false;
				loopEnd=System.Math.Min(destination.Value.Length-destinationPoint+shiftIndex,overFlowFlgs.Length);
				for(overFlowCounter=0, dataCounter=destinationPoint+shiftIndex;overFlowCounter<loopEnd;overFlowCounter++, dataCounter++) {
					if(overFlowFlgs[overFlowCounter]) {
						if(ContainerType.MaxValue==destination.Value[dataCounter]) {
							overFlowFlgs[overFlowCounter]=true;
							overFlowMasterFlg=true;
						} else {
							overFlowFlgs[overFlowCounter]=false;
						}
						unchecked {
							destination.Value[dataCounter]++;
						}
					}
				}
			}

			return destination;

		}

#endif

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

			var compareStart = System.Math.Min(left.Value.Length,right.Value.Length)-1;

			for(var counter = left.Value.Length-1;counter>compareStart;counter--) {
				if(left.Value[counter]>0) {
					return 1;
				}
			}
			for(var counter = right.Value.Length-1;counter>compareStart;counter--) {
				if(right.Value[counter]>0) {
					return -1;
				}
			}

			for(var counter = compareStart;counter>=0;counter--) {
				if(left.Value[counter]>right.Value[counter]) {
					return 1;
				}
				if(left.Value[counter]<right.Value[counter]) {
					return -1;
				}
			}

			return 0;

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
			var value = new ContainerType[this.Value.Length];
			Array.Copy(this.Value,value,this.Value.Length);

			return new BigUInteger(value);

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
				throw new ArgumentException("",e);
			}
#else
			if(other==null) {
				return 1;
			}
			try {
				return Compare(this,(BigUInteger)other);
			} catch(Exception e) {
				//TODO:メッセージ何とかする
				throw new ArgumentException("",e);
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
			return new Parser(style,provider).ParseBigUInteger(value);
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
			var result = new ContainerType[value.Value.Length+1+arrayShift];


			for(int valueCounter = 0, resultCounter = arrayShift;valueCounter<value.Value.Length&&resultCounter<result.Length;valueCounter++, resultCounter++) {
				result[resultCounter]=value.Value[valueCounter]<<innerShift;
			}
			if(innerShift!=0) {
				for(int valueCounter = 0, resultCounter = arrayShift+1;valueCounter<value.Value.Length&&resultCounter<result.Length;valueCounter++, resultCounter++) {
					result[resultCounter]|=value.Value[valueCounter]>>ContainerItemSizeWithBit-innerShift;
				}
			}

			return new BigUInteger(result);
		}

		/// <summary>
		/// 指定されたビット数だけBigUIntegerの値を右にシフトします。
		/// </summary>
		/// <param name="value">ビットをシフトする対象の値。</param>
		/// <param name="arrayShift">配列項目としてシフトする量。</param>
		/// <param name="innerShift">配列内でシフトするビット数。</param>
		/// <returns>指定されたビット数だけ右にシフトされた値。</returns>
		public static BigUInteger RightShift(BigUInteger value,int arrayShift,int innerShift) {

			var arraySize = value.Value.Length-arrayShift;
			if(arraySize<1) {
				return BigUInteger.Zero;
			}
			var result = new ContainerType[arraySize];

			for(int valueCounter = arrayShift, resultCounter = 0;valueCounter<value.Value.Length&&resultCounter<result.Length;valueCounter++, resultCounter++) {
				result[resultCounter]=value.Value[valueCounter]>>innerShift;
			}
			if(innerShift!=0) {
				for(int valueCounter = arrayShift+1, resultCounter = 0;valueCounter<value.Value.Length&&resultCounter<result.Length;valueCounter++, resultCounter++) {
					result[resultCounter]|=value.Value[valueCounter]<<ContainerItemSizeWithBit-innerShift;
				}
			}

			return new BigUInteger(result);
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

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// 指定された 2 つのBigUIntegerの値をマージ減算します。注意：destination BigUIntegerの値を破壊的に変更します。
		/// </summary>
		/// <param name="destination">マージ減算先となるBigUInteger。</param>
		/// <param name="data">マージ減算をするBigUInteger。</param>
		/// <returns>destinationにdataをマージ減算した値。</returns>
		public static BigUInteger MargeSubtraction(BigUInteger destination,BigUInteger data) {
			return MargeSubtraction(destination,0,data,0,data.Value.Length);
		}

		/// <summary>
		/// 指定された 2 つのBigUIntegerの値をマージ減算します。注意：destination BigUIntegerの値を破壊的に変更します。
		/// </summary>
		/// <param name="destination">マージ減算先となるBigUInteger。</param>
		/// <param name="destinationPoint">マージ減算の開始場所になるインデックス。</param>
		/// <param name="data">マージ減算をするBigUInteger。</param>
		/// <returns>destinationにdataをマージ減算した値。</returns>
		public static BigUInteger MargeSubtraction(BigUInteger destination,int destinationPoint,BigUInteger data) {
			return MargeSubtraction(destination,destinationPoint,data,0,data.Value.Length);
		}

		/*
		/// <summary>
		/// 指定された 2 つのBigUIntegerの値をマージ減算します。注意：destination BigUIntegerの値を破壊的に変更します。
		/// </summary>
		/// <param name="destination">マージ減算先となるBigUInteger。</param>
		/// <param name="data">マージ減算をするBigUInteger。</param>
		/// <param name="dataPoint">マージ減算するデータの開始インデックス。</param>
		/// <param name="length">マージ減算するデータの長さ。</param>
		/// <returns>destinationにdataをマージ減算した値。</returns>
		public static BigUInteger MargeSubtraction(BigUInteger destination,BigUInteger data,int dataPoint,int length) {
			return MargeSubtraction(destination,0,data,dataPoint,length);
		}
		*/

		/// <summary>
		/// 指定された 2 つのBigUIntegerの値をマージ減算します。注意：destination BigUIntegerの値を破壊的に変更します。
		/// </summary>
		/// <param name="destination">マージ減算先となるBigUInteger。</param>
		/// <param name="destinationPoint">マージ減算の開始場所になるインデックス。</param>
		/// <param name="data">マージ減算をするBigUInteger。</param>
		/// <param name="dataPoint">マージ減算するデータの開始インデックス。</param>
		/// <param name="length">マージ減算するデータの長さ。</param>
		/// <returns>destinationにdataをマージ減算した値。</returns>
		public static BigUInteger MargeSubtraction(BigUInteger destination,int destinationPoint,BigUInteger data,int dataPoint,int length) {

			var loopEnd = System.Math.Min(System.Math.Min(destinationPoint+length,destination.Value.Length),destinationPoint+data.Value.Length);
			var overFlowFlgs = new bool[data.Value.Length];
			var overFlowMasterFlg = false;

			int dataCounter;
			int destinationCounter;
			int overFlowCounter;

			for(dataCounter=dataPoint, destinationCounter=destinationPoint;destinationCounter<loopEnd;dataCounter++, destinationCounter++) {
				if(destination.Value[destinationCounter]<data.Value[dataCounter]) {
					overFlowFlgs[dataCounter]=true;
					overFlowMasterFlg=true;
				} else {
					overFlowFlgs[dataCounter]=false;
				}
				unchecked {
					destination.Value[destinationCounter]-=data.Value[dataCounter];
				}
			}

			for(var shiftIndex = 1;overFlowMasterFlg;shiftIndex++) {
				overFlowMasterFlg=false;
				loopEnd=System.Math.Min(destination.Value.Length-destinationPoint+shiftIndex,overFlowFlgs.Length);
				for(overFlowCounter=0, dataCounter=destinationPoint+shiftIndex;overFlowCounter<loopEnd;overFlowCounter++, dataCounter++) {
					if(overFlowFlgs[overFlowCounter]) {
						if(0==destination.Value[dataCounter]) {
							overFlowFlgs[overFlowCounter]=true;
							overFlowMasterFlg=true;
						} else {
							overFlowFlgs[overFlowCounter]=false;
						}
						unchecked {
							destination.Value[dataCounter]--;
						}
					}
				}
			}

			return destination;

		}

#endif

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
			return (byte)value.Value[0];
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
			var temp = new byte[BigUInteger.ContainerItemSizeWithByte];
			var value = new byte[this.Value.Length*BigUInteger.ContainerItemSizeWithByte];

			for(int numeratorCounter = 0, containerCounter = 0;containerCounter<this.Value.Length;containerCounter++, numeratorCounter+=BigUInteger.ContainerItemSizeWithByte) {
				temp=BitConverter.GetBytes(this.Value[containerCounter]);
				Array.Copy(temp,0,value,numeratorCounter,BigUInteger.ContainerItemSizeWithByte);
			}

			return value;

#endif
		}

#if !DEBUG||DLLDEBUG
		public ContainerType[] ToContainerArray() {
			return this.Value;
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
			if(value>double.MaxValue) {
				return double.PositiveInfinity;
			}

			var result = 0d;

			for(var counter = value.Value.Length-1;counter>=0;counter--) {
				result*=(double)ContainerType.MaxValue+1d;
				result+=value.Value[counter];
			}

			return result;

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
			return (short)value.Value[0];
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
			return (int)value.Value[0];
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
			return (long)value.Value[0];
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

			return (sbyte)value.Value[0];
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

			var result = 0f;

			for(var counter = value.Value.Length-1;counter>=0;counter--) {
				result*=(float)ContainerType.MaxValue+1;
				result+=value.Value[counter];
			}

			return result;

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
			return new Formatter(format,provider).Format(this);
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
			//TODO:コンテナサイズを変える時に修正する事
			return (ushort)value.Value[0];
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
			return (uint)value.Value[0];
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
			return (ulong)value.Value[0];
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

			if(value>decimal.MaxValue) {
				throw new OverflowException();
			}

			var result = 0m;

			for(var counter = value.Value.Length-1;counter>=0;counter--) {
				result*=(decimal)ContainerType.MaxValue+1;
				result+=value.Value[counter];
			}

			return result;

#endif
		}

		/// <summary>
		/// 肥大化した内部表現をトリミングします
		/// </summary>
		/// <returns>トリミングしたBigUInteger値</returns>
		public BigUInteger Trim() {

#if !DEBUG||DLLDEBUG
			int counter;
			for(counter=this.Value.Length-1;counter>=0&&this.Value[counter]==0;counter--) {
			}
			if(counter==this.Value.Length-1) {
				return this;
			} else if(counter<0) {
				return BigUInteger.Zero;
			}
			counter++;
			var trimdValue = new ContainerType[counter];
			Array.Copy(this.Value,trimdValue,counter);

			this.Value=trimdValue;

#endif

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

			var smallerSize = System.Math.Min(left.Value.Length,right.Value.Length);
			var resultSize = System.Math.Max(left.Value.Length,right.Value.Length)+1;

			var overFlowFlgs = new bool[smallerSize];
			var overFlowMasterFlg = false;
			var result = new ContainerType[resultSize];

			int dataCounter;
			int overFlowCounter;

			int loopEnd;

			for(dataCounter=0;dataCounter<smallerSize;dataCounter++) {
				unchecked {
					result[dataCounter]=left.Value[dataCounter]+right.Value[dataCounter];
				}
				if(result[dataCounter]<left.Value[dataCounter]) {
					overFlowFlgs[dataCounter]=true;
					overFlowMasterFlg=true;
				} else {
					overFlowFlgs[dataCounter]=false;
				}
			}

			if(left.Value.Length>smallerSize) {
				Array.Copy(left.Value,smallerSize,result,smallerSize,left.Value.Length-smallerSize);
			} else if(right.Value.Length>smallerSize) {
				Array.Copy(right.Value,smallerSize,result,smallerSize,right.Value.Length-smallerSize);
			}

			for(var shiftIndex = 1;overFlowMasterFlg;shiftIndex++) {
				overFlowMasterFlg=false;
				loopEnd=System.Math.Min(overFlowFlgs.Length,resultSize-shiftIndex);
				for(overFlowCounter=0, dataCounter=shiftIndex;overFlowCounter<loopEnd;overFlowCounter++, dataCounter++) {
					if(overFlowFlgs[overFlowCounter]) {
						if(ContainerType.MaxValue==result[dataCounter]) {
							overFlowFlgs[overFlowCounter]=true;
							overFlowMasterFlg=true;
						} else {
							overFlowFlgs[overFlowCounter]=false;
						}
						unchecked {
							result[dataCounter]++;
						}
					}
				}
			}

			return new BigUInteger(result);

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
			var loopEnd = System.Math.Min(left.Value.Length,right.Value.Length);
			var result = new ContainerType[loopEnd];

			for(var counter = 0;counter<loopEnd;counter++) {
				result[counter]=left.Value[counter]&right.Value[counter];
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
			var loopEnd = System.Math.Min(left.Value.Length,right.Value.Length);
			var resultSize = System.Math.Max(left.Value.Length,right.Value.Length);

			var result = new ContainerType[resultSize];

			int counter;

			for(counter=0;counter<loopEnd;counter++) {
				result[counter]=left.Value[counter]|right.Value[counter];
			}

			if(resultSize==left.Value.Length) {
				Array.Copy(left.Value,counter,result,counter,left.Value.Length-counter);
			} else {
				Array.Copy(right.Value,counter,result,counter,right.Value.Length-counter);
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
			var compareEnd = System.Math.Min(left.Value.Length,right.Value.Length);
			int counter;

			for(counter=0;counter<compareEnd;counter++) {
				if(left.Value[counter]!=right.Value[counter]) {
					return false;
				}
			}

			for(;counter<left.Value.Length;counter++) {
				if(left.Value[counter]!=0) {
					return false;
				}
			}

			for(;counter<right.Value.Length;counter++) {
				if(right.Value[counter]!=0) {
					return false;
				}
			}

			return true;
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
			var loopEnd = System.Math.Min(left.Value.Length,right.Value.Length);
			var resultSize = System.Math.Max(left.Value.Length,right.Value.Length);

			var result = new ContainerType[resultSize];

			int counter;

			for(counter=0;counter<loopEnd;counter++) {
				result[counter]=left.Value[counter]^right.Value[counter];
			}

			if(resultSize==left.Value.Length) {
				Array.Copy(left.Value,counter,result,counter,left.Value.Length-counter);
			} else {
				Array.Copy(right.Value,counter,result,counter,right.Value.Length-counter);
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

			if(left.IsZero||right.IsZero) {
				return BigUInteger.Zero;
			} else if(left.IsOne) {
				return right;
			} else if(right.IsOne) {
				return left;
			}
			var (_, mathAreaSize)=BigUInteger.MathWorkAreaSize(left,right);
			var (z0, z2)=BigUInteger.MakeBaseZs(left,right,mathAreaSize);
			for(int inputSize = 1, processSize = 2;processSize<mathAreaSize;inputSize=processSize, processSize<<=1) {
				BigUInteger.MargeZs(left,right,z0,z2,processSize,inputSize);
			}

			return z0.Trim();

#endif
		}

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// 乗算の結果のデータコンテナ―のサイズと、乗算の計算に必要なワークエリアのサイズを算出します。
		/// </summary>
		/// <param name="left">乗算対象の最初の数。</param>
		/// <param name="right">乗算対象の 2 番目の数。</param>
		/// <returns>乗算の結果のデータコンテナ―のサイズ。乗算の計算に必要なワークエリアのサイズ。</returns>
		private static (int Result, int Math) MathWorkAreaSize(BigUInteger left,BigUInteger right) {
			var result = left.Value.Length+right.Value.Length;
			var mathArea = 1;
			//TODO:もうちょっとメモリ消費は減らしたい
			//var loopEnd = System.Math.Min(left.Length,right.Length);
			var loopEnd = System.Math.Max(left.Value.Length,right.Value.Length);
			for(;mathArea<loopEnd;mathArea<<=1) {
			}
			mathArea<<=1;
			return (result, mathArea);
		}

		/// <summary>
		/// カラツバ法を実行するために、Z0とZ2の集合を作成する。
		/// </summary>
		/// <param name="left">乗算対象の最初の数。</param>
		/// <param name="right">乗算対象の 2 番目の数。</param>
		/// <param name="mathAreaSize">乗算の計算に必要なワークエリアのサイズ。</param>
		/// <returns>カラツバ法のZ0とZ2。</returns>
		private static (BigUInteger Z0, BigUInteger Z2) MakeBaseZs(BigUInteger left,BigUInteger right,int mathAreaSize) {

			var z0 = new BigUInteger() {
				Value=new ContainerType[mathAreaSize]
			};
			var z2 = new BigUInteger() {
				Value=new ContainerType[mathAreaSize]
			};

			for(int lowerCounter = 0, upperCounter = 1, loopEnd = System.Math.Min(left.Value.Length,right.Value.Length);lowerCounter<loopEnd;lowerCounter+=2, upperCounter+=2) {

				BigUInteger.MakeBaseZs(left,right,lowerCounter,upperCounter,lowerCounter,z0);
				if(upperCounter<loopEnd) {
					BigUInteger.MakeBaseZs(left,right,upperCounter,upperCounter,lowerCounter,z2);
				}

			}

			return (z0, z2);

		}

		/// <summary>
		///  カラツバ法を実行するために、Z0、および、Z2を算出するメソッド。
		/// </summary>
		/// <param name="left">乗算対象の最初の数。</param>
		/// <param name="right">乗算対象の 2 番目の数。</param>
		/// <param name="inputIndex">入力するデータのインデックス。</param>
		/// <param name="upperCounter">上位要素の開始インデックス。</param>
		/// <param name="lowerCounter">下位要素の開始インデックス。</param>
		/// <param name="output">結果の出力先。</param>
		private static void MakeBaseZs(BigUInteger left,BigUInteger right,int inputIndex,int upperCounter,int lowerCounter,BigUInteger output) {

			var leftUp = left.Value[inputIndex]>>BigUInteger.LowerMaskShifter;
			var leftLow = left.Value[inputIndex]&BigUInteger.UpperMask;
			var rightUp = right.Value[inputIndex]>>BigUInteger.LowerMaskShifter;
			var rightLow = right.Value[inputIndex]&BigUInteger.UpperMask;

			output.Value[upperCounter]=leftUp*rightUp;
			output.Value[lowerCounter]=leftLow*rightLow;

			var z1_1 = new BigUInteger(output.Value[upperCounter])+new BigUInteger(output.Value[lowerCounter]);

			if(leftUp>leftLow) {
				if(rightUp>rightLow) {
					//z1=(leftUp-leftLow)*(rightUp-rightLow);
					//-
					var z1_2 = new BigUInteger((leftUp-leftLow)*(rightUp-rightLow));
					if(z1_1>z1_2) {
						BigUInteger.MargeSubtraction(z1_1,z1_2);
						z1_1=BigUInteger.LeftShift(z1_1,0,BigUInteger.LowerMaskShifter);
						BigUInteger.MargeAdd(output,lowerCounter,z1_1);
					} else {
						BigUInteger.MargeSubtraction(z1_2,z1_1);
						z1_2=BigUInteger.LeftShift(z1_2,0,BigUInteger.LowerMaskShifter);
						BigUInteger.MargeSubtraction(output,lowerCounter,z1_2);
					}
				} else {
					//z1=(leftUp-leftLow)*(rightLow-rightUp);
					//+
					var z1_2 = new BigUInteger((leftUp-leftLow)*(rightLow-rightUp));
					z1_1+=z1_2;
					z1_1=BigUInteger.LeftShift(z1_1,0,BigUInteger.LowerMaskShifter);
					BigUInteger.MargeAdd(output,lowerCounter,z1_1);
				}
			} else {
				if(rightUp>rightLow) {
					//z1=(leftLow-leftUp)*(rightUp-rightLow);
					//+
					var z1_2 = new BigUInteger((leftLow-leftUp)*(rightUp-rightLow));
					z1_1+=z1_2;
					z1_1=BigUInteger.LeftShift(z1_1,0,BigUInteger.LowerMaskShifter);
					BigUInteger.MargeAdd(output,lowerCounter,z1_1);
				} else {
					//z1=(leftLow-leftUp)*(rightLow-rightUp);
					//-
					var z1_2 = new BigUInteger((leftLow-leftUp)*(rightLow-rightUp));
					if(z1_1>z1_2) {
						BigUInteger.MargeSubtraction(z1_1,z1_2);
						z1_1=BigUInteger.LeftShift(z1_1,0,BigUInteger.LowerMaskShifter);
						BigUInteger.MargeAdd(output,lowerCounter,z1_1);
					} else {
						BigUInteger.MargeSubtraction(z1_2,z1_1);
						z1_2=BigUInteger.LeftShift(z1_2,0,BigUInteger.LowerMaskShifter);
						BigUInteger.MargeSubtraction(output,lowerCounter,z1_2);
					}
				}

			}

		}

		/// <summary>
		/// カラツバ法のZ0、および、Z2の要素をマージする。
		/// </summary>
		/// <param name="left">乗算対象の最初の数。</param>
		/// <param name="right">乗算対象の 2 番目の数。</param>
		/// <param name="z0">カラツバ法のZ0の集合。</param>
		/// <param name="z2">カラツバ法のZ2の集合。</param>
		/// <param name="processSize">Z0、Z2の要素サイズ。</param>
		/// <param name="inputSize">入力の要素サイズ。</param>
		private static void MargeZs(BigUInteger left,BigUInteger right,BigUInteger z0,BigUInteger z2,int processSize,int inputSize) {
			var tmp = new ContainerType[processSize];
			for(int lowerCounter = 0, upperCounter = processSize, loopEnd = z0.Value.Length;lowerCounter<loopEnd;lowerCounter+=processSize*2, upperCounter+=processSize*2) {
				Array.Copy(z0.Value,upperCounter,tmp,0,processSize);
				Array.Copy(z2.Value,lowerCounter,z0.Value,upperCounter,processSize);
				Array.Copy(tmp,0,z2.Value,lowerCounter,processSize);
				BigUInteger.MargeZs(left,right,lowerCounter,upperCounter,lowerCounter,z0,processSize,inputSize);
				BigUInteger.MargeZs(left,right,upperCounter,upperCounter,lowerCounter,z2,processSize,inputSize);
			}
		}

		/// <summary>
		/// カラツバ法のZ0、または、Z2の要素をマージする。
		/// </summary>
		/// <param name="left">乗算対象の最初の数。</param>
		/// <param name="right">乗算対象の 2 番目の数。</param>
		/// <param name="inputIndex">入力値の開始インデックス。</param>
		/// <param name="upperCounter">上位要素の開始インデックス。</param>
		/// <param name="lowerCounter">下要素の開始インデックス。</param>
		/// <param name="output">結果の出力先。</param>
		/// <param name="processSize">Z0、Z2の要素サイズ。</param>
		/// <param name="inputSize">入力の要素サイズ。</param>
		private static void MargeZs(BigUInteger left,BigUInteger right,int inputIndex,int upperCounter,int lowerCounter,BigUInteger output,int processSize,int inputSize) {

			var leftLow = ChunkExtract(left,inputIndex,inputSize);
			var rightLow = ChunkExtract(right,inputIndex,inputSize);
			var leftUp = ChunkExtract(left,inputIndex+inputSize,inputSize);
			var rightUp = ChunkExtract(right,inputIndex+inputSize,inputSize);
			var margePoint = lowerCounter+inputSize;

			var outputUpper = ChunkExtract(output,upperCounter,processSize);
			var outputLower = ChunkExtract(output,lowerCounter,processSize);
			var z1_1 = outputUpper+outputLower;

			if(leftUp>leftLow) {
				if(rightUp>rightLow) {
					//z1=(leftUp-leftLow)*(rightUp-rightLow);
					//-
					var z1_2 = BigUInteger.MargeSubtraction(leftUp,leftLow)*BigUInteger.MargeSubtraction(rightUp,rightLow);
					if(z1_1>z1_2) {
						BigUInteger.MargeSubtraction(z1_1,z1_2);
						BigUInteger.MargeAdd(output,margePoint,z1_1);
					} else {
						BigUInteger.MargeSubtraction(z1_2,z1_1);
						BigUInteger.MargeSubtraction(output,margePoint,z1_2);
					}
				} else {
					//z1=(leftUp-leftLow)*(rightLow-rightUp);
					//+
					var z1_2 = BigUInteger.MargeSubtraction(leftUp,leftLow)*BigUInteger.MargeSubtraction(rightLow,rightUp);
					z1_1+=z1_2;
					BigUInteger.MargeAdd(output,margePoint,z1_1);
				}
			} else {
				if(rightUp>rightLow) {
					//z1=(leftLow-leftUp)*(rightUp-rightLow);
					//+
					var z1_2 = BigUInteger.MargeSubtraction(leftLow,leftUp)*BigUInteger.MargeSubtraction(rightUp,rightLow);
					z1_1+=z1_2;
					BigUInteger.MargeAdd(output,margePoint,z1_1);
				} else {
					//z1=(leftLow-leftUp)*(rightLow-rightUp);
					//-
					var z1_2 = BigUInteger.MargeSubtraction(leftLow,leftUp)*BigUInteger.MargeSubtraction(rightLow,rightUp);
					if(z1_1>z1_2) {
						BigUInteger.MargeSubtraction(z1_1,z1_2);
						BigUInteger.MargeAdd(output,margePoint,z1_1);
					} else {
						BigUInteger.MargeSubtraction(z1_2,z1_1);
						BigUInteger.MargeSubtraction(output,margePoint,z1_2);
					}
				}

			}

		}

		/// <summary>
		/// カラツバ法のZ0、または、Z2の要素の入れ替え処理を行う。
		/// </summary>
		/// <param name="source">要素の入れ替え処理を行う対象のデータソース。</param>
		/// <param name="startIndex">入れ替えを行う要素の開始インデックス。</param>
		/// <param name="extractSize">入れ替えを行う要素のサイズ。</param>
		/// <returns></returns>
		private static BigUInteger ChunkExtract(BigUInteger source,int startIndex,int extractSize) {
			var result = new ContainerType[extractSize];
			if(source.Value.Length<=startIndex) {
				return new BigUInteger() {
					Value=result
				};
			}
			extractSize=System.Math.Min(source.Value.Length-startIndex,extractSize);
			Array.Copy(source.Value,startIndex,result,0,extractSize);
			return new BigUInteger() {
				Value=result
			};
		}

#endif

		/// <summary>
		/// BigUInteger 値のビットごとの 1 の補数を返します。
		/// </summary>
		/// <param name="value">1の補数を取得したい値。</param>
		/// <returns>value のビットごとの 1 の補数。</returns>
		public static BigUInteger operator ~(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
			return new BigUInteger(~value.Value);
#else
			var result = new ContainerType[value.Value.Length];
			for(var counter = 0;counter<value.Value.Length;counter++) {
				result[counter]=~value.Value[counter];
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

			var smallerSize = System.Math.Min(left.Value.Length,right.Value.Length);
			var resultSize = System.Math.Max(left.Value.Length,right.Value.Length)+1;

			var overFlowFlgs = new bool[smallerSize];
			var overFlowMasterFlg = false;
			var result = new ContainerType[resultSize];

			int dataCounter;
			int overFlowCounter;

			int loopEnd;

			for(dataCounter=0;dataCounter<smallerSize;dataCounter++) {
				if(left.Value[dataCounter]<right.Value[dataCounter]) {
					overFlowFlgs[dataCounter]=true;
					overFlowMasterFlg=true;
				} else {
					overFlowFlgs[dataCounter]=false;
				}

				unchecked {
					result[dataCounter]=left.Value[dataCounter]-right.Value[dataCounter];
				}
			}

			if(left.Value.Length>smallerSize) {
				Array.Copy(left.Value,smallerSize,result,smallerSize,left.Value.Length-smallerSize);
			} else if(right.Value.Length>smallerSize) {
				Array.Copy(left.Value,smallerSize,result,smallerSize,left.Value.Length-smallerSize);
			}

			for(var shiftIndex = 1;overFlowMasterFlg;shiftIndex++) {
				overFlowMasterFlg=false;
				loopEnd=System.Math.Min(overFlowFlgs.Length,resultSize-shiftIndex);
				for(overFlowCounter=0, dataCounter=shiftIndex;overFlowCounter<loopEnd;overFlowCounter++, dataCounter++) {
					if(overFlowFlgs[overFlowCounter]) {
						if(0==result[dataCounter]) {
							overFlowFlgs[overFlowCounter]=true;
							overFlowMasterFlg=true;
						} else {
							overFlowFlgs[overFlowCounter]=false;
						}
						unchecked {
							result[dataCounter]--;
						}
					}
				}
			}

			return new BigUInteger(result);

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

		/// <summary>
		/// コンテナ―アイテムの下半分をマスクするシフト値。
		/// </summary>
		private static int LowerMaskShifter {
			get;
		}

		/// <summary>
		/// コンテナ―アイテムの上半分をマスクするマスク値。
		/// </summary>
		private static ContainerType UpperMask {
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
		ContainerType[]
#endif
			Value {
			get;
			set;
		}

	}
}