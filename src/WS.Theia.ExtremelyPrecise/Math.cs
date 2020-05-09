using System;
using OuterInterfaceType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise {

	/// <summary>
	/// 三角関数や対数関数などの一般的な数値関数の定数と静的メソッドを提供します。
	/// </summary>
	public static partial class Math {

		/// <summary>
		///  Rational 数値の絶対値を返します。
		/// </summary>
		/// <param name="value">Ratioan型の数値。</param>
		/// <returns>valueの絶対値。</returns>
		public static Rational Abs(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Abs(value.Numerator);
#else
			if(Rational.IsInfinity(value)) {
				return Rational.PositiveInfinity;
			}
			return new Rational(false,value.Numerator,value.Denominator);
#endif
		}

		/// <summary>
		/// コサインが指定数となる角度を返します。
		/// </summary>
		/// <param name="cos">コサインを表す数で、cos が -1 以上 1 以下である必要があります。</param>
		/// <returns>0 ≤θ≤π の、ラジアンで表した角度 θ。 または cos < -1 または cos > 1、あるいは cos が NaN と等しい場合は、NaN。</returns>
		public static Rational Acos(Rational cos) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Acos(cos.Numerator);
#else
			return Math.PI/Rational.Tow-Math.Asin(cos);
#endif
		}

		/// <summary>
		/// サインが指定数となる角度を返します。
		/// </summary>
		/// <param name="sin">サインを表す数で、sin が -1 以上 1 以下である必要があります。</param>
		/// <returns>-π/2 ≤θ≤π/2 の、ラジアンで表した角度 θ。 または sin < -1 または sin > 1、あるいは sin が NaN と等しい場合は、NaN。</returns>
		public static Rational Asin(Rational sin) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Asin(sin.Numerator);
#else
			if(sin<-1||sin>1||Rational.IsNaN(sin)) {
				return Rational.NaN;
			}

			var result = Rational.Zero;
			var loopEnd = new Rational(false,BigUInteger.One,Rational.RoundInternalInfrator);
			Rational resultAdder;
			var towSection = Rational.Zero;
			var towSectionPlusOne = Rational.One;
			var sinPow = sin;
			var four = new Rational(4);
			var fourPow = Rational.One;

			var binomialCoefficientsNumurator = Rational.One;
			var binomialCoefficientsDenominator = Rational.One;

			//TODO:無理数演算なので打切り誤差許容演算に切り替えた方が良いかもしれない
			for(var section = Rational.Zero;true;towSectionPlusOne+=Rational.Tow, sinPow*=sin*sin, fourPow*=four) {
				resultAdder=binomialCoefficientsNumurator/binomialCoefficientsDenominator;
				resultAdder*=sinPow/(fourPow*towSectionPlusOne);
				result+=resultAdder;
				//TODO:Math.Abs(resultAdder)が重いので絶対値比較メソッドを作った方が良い
				if(Math.Abs(resultAdder)<=loopEnd) {
					break;
				}
				towSection+=Rational.One;
				binomialCoefficientsNumurator*=towSection;
				towSection+=Rational.One;
				binomialCoefficientsNumurator*=towSection;
				section++;
				binomialCoefficientsDenominator*=section*section;
			}
			return result;
#endif
		}

		/// <summary>
		/// タンジェントが指定数となる角度を返します。
		/// </summary>
		/// <param name="tan">タンジェントを表す数。</param>
		/// <returns>-π/2 ≤θ≤π/2 の、ラジアンで表した角度 θ。
		/// tanがNaNの場合、NaN、tanがNegativeInfinityの場合、-PI/2、tanがPositiveInfinityの場合、PI/2になります。</returns>
		public static Rational Atan(Rational tan) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Atan(tan.Numerator);
#else
			if(Rational.IsNaN(tan)) {
				return Rational.NaN;
			}
			if(Rational.IsInfinity(tan)) {
				return tan.Sign ? -Math.PI/Rational.Tow : Math.PI/Rational.Tow;
			}

			//TODO:無理数演算なので打切り誤差許容演算に切り替えた方が良いかもしれない
			var tanPowTow = Math.Pow(tan,Rational.Tow);
			var tanPowTowPlusOne = tanPowTow+Rational.One;
			var towTanPowTowPlusOne = tanPowTowPlusOne*Rational.Tow;
			var result = tan/(Rational.One+tanPowTow);
			var summation = Rational.Zero;
			var infiniteProduct = Rational.PositiveInfinity;
			var loopEnd = new Rational(false,BigUInteger.One,Rational.RoundInternalInfrator);
			for(var summationSection = Rational.Zero;Math.Abs(infiniteProduct)>loopEnd;summationSection++) {
				infiniteProduct=Rational.One;
				var towInfiniteProductSection = Rational.Tow;
				var towInfiniteProductSectionPlusOne = new Rational(3)*tanPowTowPlusOne;
				//TODO:Math.Abs(infiniteProduct)が重いので絶対値比較メソッドを作った方が良い
				for(var infiniteProductSection = Rational.One;infiniteProductSection<=summationSection;infiniteProductSection++, towInfiniteProductSection+=Rational.Tow, towInfiniteProductSectionPlusOne+=towTanPowTowPlusOne) {
					infiniteProduct*=towInfiniteProductSection*tanPowTow/(towInfiniteProductSectionPlusOne);
				}
				summation+=infiniteProduct;
			}
			return result*summation;
#endif
		}

		/// <summary>
		/// タンジェントが 2 つの指定された数の商である角度を返します。
		/// </summary>
		/// <param name="yCoordinates">点の y 座標。</param>
		/// <param name="xCoordinates">点の x 座標。</param>
		/// <returns>-π≤θ≤π および tan(θ) = y / x の、ラジアンで示した角度 θ。(x, y) は、デカルト座標の点を示します。 次の点に注意してください。 - クワドラント 1 の (x, y) の場合は、0 < θ < π/2。 
		///- クワドラント 2 の(x,y) の場合は、π/2 < θ≤π。 
		///- クワドラント 3 の(x,y) の場合は、-π<θ< -π/2。 
		///- クワドラント 4 の (x, y) の場合は、-π/2 < θ< 0。 
		///クワドラント間の境界上にある点の場合は、次の戻り値になります。 - y が 0 で x が負数でない場合は、θ = 0。 
		///- y が 0 で x が負の場合は、θ = π。 
		///- y が正で x が 0 の場合は、θ = π/2。 
		///- y が負数で x が 0 の場合は、θ = -π/2。 
		///- y が 0 かつ x が 0 の場合は、θ = 0。 
		///x または y が NaN であるか、x または y が PositiveInfinity または NegativeInfinity のいずれである場合、メソッドは NaN を返します。</returns>
		public static Rational Atan2(Rational yCoordinates,Rational xCoordinates) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Atan2(yCoordinates.Numerator,xCoordinates.Numerator);
#else
			return Math.Atan(yCoordinates/xCoordinates);
#endif
		}

		/// <summary>
		/// 指定した Rational 以上の数のうち、最小の整数値を返します。
		/// </summary>
		/// <param name="value">Rational</param>
		/// <returns>value 以上の最小の整数値。このメソッドは、整数型ではなく Rational を返します。value が NaN、NegativeInfinity、PositiveInfinity のいずれかに等しい場合は、その値が返されます。 </returns>
		public static Rational Ceiling(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Ceiling(value.Numerator);
#else
			if(value==Rational.NaN||Rational.IsInfinity(value)) {
				return value;
			}

			var ceiling = new Rational(value.Sign,value.Numerator/value.Denominator,BigUInteger.One);
			if(!value.Sign) {

				if(value!=ceiling) {
					ceiling.Numerator++;
				}

			} else {
				var ceilingMinus1 = ceiling-1;
				ceiling=value==ceilingMinus1 ? ceilingMinus1 : ceiling;
			}

			return ceiling;

#endif
		}

		/// <summary>
		/// 指定された角度のコサインを返します。
		/// </summary>
		/// <param name="radian">ラジアンで表した角度。</param>
		/// <returns>radian のコサイン。 radian が NaN、NegativeInfinity、PositiveInfinity のいずれかに等しい場合、このメソッドは NaN を返します。</returns>
		public static Rational Cos(Rational radian) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Cos(radian.Numerator);
#else
			radian%=Math.PI;
			var nFactrial = BigUInteger.Tow;
			var towCoefficient = BigUInteger.Tow;
			var radRad = radian*radian;
			var radianFactrial = radRad;

			var result = Rational.One;

			var resultAdder = new Rational(false,BigUInteger.One,nFactrial)*radianFactrial;
			result-=resultAdder;

			//TODO:Math.Abs(resultAdder)が重いので絶対値比較メソッドを作った方が良い
			//TODO:無理数演算なので打切り誤差許容演算に切り替えた方が良いかもしれない
			for(var loopEnd = new Rational(false,BigUInteger.One,Rational.RoundInternalInfrator);Math.Abs(resultAdder)>loopEnd;) {

				towCoefficient++;
				nFactrial*=towCoefficient;
				towCoefficient++;
				nFactrial*=towCoefficient;
				radianFactrial*=radRad;
				result+=new Rational(false,radianFactrial.Numerator,nFactrial*radianFactrial.Denominator);

				towCoefficient++;
				nFactrial*=towCoefficient;
				towCoefficient++;
				nFactrial*=towCoefficient;
				radianFactrial*=radRad;
				resultAdder=new Rational(false,radianFactrial.Numerator,nFactrial*radianFactrial.Denominator);
				result-=resultAdder;
			}
			return result;
#endif
		}

		/// <summary>
		/// 指定された角度のハイパーボリック コサインを返します。
		/// </summary>
		/// <param name="radian">ラジアンで表した角度。</param>
		/// <returns>value のハイパーボリック コサイン。 value が NegativeInfinity または PositiveInfinity に等しい場合は、PositiveInfinity が返されます。 value が NaN に等しい場合は、NaN が返されます。</returns>
		public static Rational Cosh(Rational radian) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Cosh(radian.Numerator);
#else
			return (Math.Pow(Math.E,radian)+Math.Pow(Math.E,-radian))/Rational.Tow;
#endif
		}

		/// <summary>
		/// 2 つの数値の商を計算し、出力パラメーターの剰余を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>指定した数値の商。剰余。</returns>
		public static (Rational Quotient, Rational Remainder) DivRem(Rational dividend,Rational divisor) {
#if DEBUG&&!DLLDEBUG
			var quotient=System.Math.Round(dividend.Numerator/divisor.Numerator,0);
			var remainder=dividend.Numerator-quotient*divisor.Numerator;
			return (quotient,remainder);
#else
			if(Rational.IsNaN(dividend)||Rational.IsNaN(divisor)||Rational.IsInfinity(divisor)) {
				return (Rational.NaN, Rational.NaN);
			} else if(Rational.IsInfinity(dividend)) {
				if(dividend.Sign==divisor.Sign) {
					return (Rational.PositiveInfinity, Rational.NegativeInfinity);
				}
				return (Rational.NegativeInfinity, Rational.NegativeInfinity);
			}
			var quotientNumerator = dividend.Numerator*divisor.Denominator;
			var denominator = dividend.Denominator*divisor.Numerator;
			var remainderNumerator = quotientNumerator%denominator;
			return (new Rational(dividend.Sign^divisor.Sign,quotientNumerator,denominator).Trim(), new Rational(dividend.Sign,remainderNumerator,dividend.Denominator));
#endif
		}

		/// <summary>
		/// 指定した値で e を累乗した値を返します。
		/// </summary>
		/// <param name="value">累乗を指定する数値。</param>
		/// <returns>数値 e を value で累乗した値。 value が NaN または PositiveInfinity のいずれかに等しい場合は、その値が返されます。 value が NegativeInfinity に等しい場合は、0 が返されます。</returns>
		public static Rational Exp(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Exp(value.Numerator);
#else
			return Pow(E,value);
#endif
		}

		/// <summary>
		///  指定した Rational 以下の数のうち、最大の整数値を返します。
		/// </summary>
		/// <param name="value">Ratioan型の数値。</param>
		/// <returns>value以下の最大の整数値。このメソッドは整数型ではなくRational型で結果を返します。value が NaN、NegativeInfinity、PositiveInfinity のいずれかに等しい場合は、その値が返されます。</returns>
		public static Rational Floor(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Floor(value.Numerator);
#else
			if(value==Rational.NaN||Rational.IsInfinity(value)) {
				return value;
			}

			if(!value.Sign) {
				return new Rational(false,value.Numerator/value.Denominator,BigUInteger.One);
			} else {
				return new Rational(true,(value.Numerator/value.Denominator)+BigUInteger.One,BigUInteger.One);
			}
#endif
		}

		/// <summary>
		/// 指定した数を別の指定数で除算した結果の剰余を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>dividend - (divisor Q) に等しい数値。Q は dividend / divisor の商を丸めた近似整数を示します。dividend / divisor が 2 つの整数の中間に位置する場合は、偶数の整数が返されます。 
		///dividend - (divisor Q) がゼロのとき、dividend が正である場合は値 +0、dividend が負である場合は -0 が返されます。 
		///divisor = 0 の場合は、NaN が返されます。</returns>
		public static Rational IEEERemainder(Rational dividend,Rational divisor) {
#if DEBUG&&!DLLDEBUG
			return System.Math.IEEERemainder(dividend.Numerator,divisor.Numerator);
#else
			return dividend-(Round(dividend%divisor)*divisor);
#endif
		}

		/// <summary>
		/// 指定した数の自然 (底 e) 対数を返します。
		/// </summary>
		/// <param name="value">対数を求める対象の数値。</param>
		/// <returns>次の表に示した値のいずれか 
		///value パラメーター
		///戻り値
		///正
		///value の自然対数。つまり、ln value または log e value
		///0 
		///NegativeInfinity
		///負
		///NaN
		///NaN と等価です。
		///NaN
		///PositiveInfinity と等価です。
		///PositiveInfinity</returns>
		public static Rational Log(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Log(value.Numerator);
#else

			if(value.IsZero) {
				return Rational.NegativeInfinity;
			} else if(value.Sign||Rational.IsNaN(value)) {
				return Rational.NaN;
			} else if(Rational.IsInfinity(value)) {
				return value;
			}

			return InternalLog(value,E);

#endif
		}

		/// <summary>
		/// 指定した数値の指定した底での対数を返します。
		/// </summary>
		/// <param name="value">対数を求める対象の数値。</param>
		/// <param name="newBase">対数の底。</param>
		/// <returns>次の表に示した値のいずれか (+Infinity は PositiveInfinity、-Infinity は NegativeInfinity、NaN は NaN をそれぞれ示しています。) 
		///value
		///newBase
		///戻り値
		///value> 0 
		///(0 <newBase< 1) - または -(newBase> 1) 
		///lognewBase(a)
		///value< 0 
		///(任意の値)
		///NaN
		///(任意の値)
		///newBase< 0 
		///NaN
		///value != 1 
		///newBase = 0 
		///NaN
		///value != 1 
		///newBase = +Infinity
		///NaN
		///value = NaN
		///(任意の値)
		///NaN
		///(任意の値)
		///newBase = NaN
		///NaN
		///(任意の値)
		///newBase = 1 
		///NaN
		///value = 0
		///0 <newBase< 1 
		///+Infinity
		///value = 0 
		///newBase> 1 
		///-Infinity
		///value = +無限大
		///0 <newBase< 1 
		///-Infinity
		///value = +無限大
		///newBase> 1 
		///+Infinity
		///value = 1
		///newBase = 0 
		///0 
		///value = 1 
		///newBase = +Infinity 
		///0</returns>
		public static Rational Log(Rational value,Rational newBase) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Log(value.Numerator,newBase.Numerator);
#else

			if(Rational.IsNaN(value)||Rational.IsNaN(newBase)||value.Sign) {
				return Rational.NaN;
			}

			var isValOne = value.IsOne;

			if(!isValOne&&(newBase.IsZero||Rational.IsPositiveInfinity(newBase))) {
				return Rational.NaN;
			}
			if(newBase.Sign||newBase.IsOne) {
				return Rational.NaN;
			}

			if(isValOne) {
				return Rational.Zero;
			}

			if(value.IsZero) {
				if(newBase<1) {
					return Rational.PositiveInfinity;
				} else {
					return Rational.NegativeInfinity;
				}
			}
			if(Rational.IsPositiveInfinity(value)) {
				if(newBase<1) {
					return Rational.NegativeInfinity;
				} else {
					return Rational.PositiveInfinity;
				}
			}

			return InternalLog(value,newBase);

#endif
		}

#if !DEBUG||DLLDEBUG

		private static Rational InternalLog(Rational value,Rational newBase) {

			var result = Rational.Zero;
			for(;value>=newBase;result++) {
				value/=newBase;
			}

			if(value!=0) {
				var fractionalPartResult = Math.Log(value.Numerator)-Math.Log(value.Denominator);
				if(newBase!=Rational.Tow) {
					fractionalPartResult/=(Math.Log(newBase.Numerator)-Math.Log(newBase.Denominator));
				}
				result+=fractionalPartResult;
			}

			return result;

		}

		private static Rational Log(BigUInteger value) {

			var result = Rational.Zero;
			var rationalValue = new Rational(false,value,BigUInteger.One);

			for(;rationalValue>=Rational.Tow;result++) {
				rationalValue/=Rational.Tow;
			}

			var denominator = new Rational(false,BigUInteger.One,BigUInteger.Tow);
			for(var counter = (int)System.Math.Ceiling(Rational.Accuracy*3.322);counter>0&&!rationalValue.IsOne;counter--, denominator/=Rational.Tow) {
				rationalValue*=rationalValue;
				if(rationalValue>=Rational.Tow) {
					rationalValue/=Rational.Tow;
					result+=denominator;
				}

				counter--;

			}

			return result;

		}

#endif

		/// <summary>
		/// 指定した数の底 10 の対数を返します。
		/// </summary>
		/// <param name="value">対数を求める対象の数値。</param>
		/// <returns>次の表に示した値のいずれか 
		///value パラメーター
		///戻り値
		///正
		///value の底 10 の log。つまり、log 10value。 
		///0 
		///NegativeInfinity
		///負
		///NaN
		///NaN と等価です。
		///NaN
		///PositiveInfinity と等価です。
		///PositiveInfinity</returns>
		public static Rational Log10(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Log10(value.Numerator);
#else

			if(value.IsZero) {
				return Rational.NegativeInfinity;
			} else if(value.Sign||Rational.IsNaN(value)) {
				return Rational.NaN;
			} else if(Rational.IsInfinity(value)) {
				return value;
			}

			return InternalLog(value,new Rational(false,BigUInteger.Ten,BigUInteger.One));

#endif
		}

		/// <summary>
		/// 2 つの Rational のうち、大きな方を返します。
		/// </summary>
		/// <param name="val1">比較する最初の数値。</param>
		/// <param name="val2">比較する2 番目の数値。</param>
		/// <returns>パラメーター val1 または val2 のいずれか大きい方。</returns>
		public static Rational Max(Rational val1,Rational val2) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Max(val1.Numerator,val2.Numerator);
#else
			return val1>val2 ? val1 : val2;
#endif
		}

		/// <summary>
		/// 2 つの Rational のうち、小さい方を返します。
		/// </summary>
		/// <param name="val1">比較する最初の数値。</param>
		/// <param name="val2">比較する 2 番目の数値。</param>
		/// <returns>パラメーター val1 または val2 のいずれか小さい方。</returns>
		public static Rational Min(Rational val1,Rational val2) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Min(val1.Numerator,val2.Numerator);
#else
			return val1<val2 ? val1 : val2;
#endif
		}

		/// <summary>
		/// 指定の数値を指定した値で累乗した値を返します。
		/// </summary>
		/// <param name="ebase">累乗対象の Rational。</param>
		/// <param name="exponent">累乗を指定する Rational。</param>
		/// <returns>数値 ebase を exponent で累乗した値。</returns>
		public static Rational Pow(Rational ebase,Rational exponent) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Pow(ebase.Numerator,exponent.Numerator);
#else

			if(ebase.IsOne||exponent.IsOne) {
				//x=1; 1
				return ebase;
			}

			//x or y=NaN.NaN
			if(Rational.IsNaN(ebase)||Rational.IsNaN(exponent)) {
				return Rational.NaN;
			} else if(exponent==0) {
				return Rational.One;
			}

			if(Rational.IsNegativeInfinity(ebase)) {
				if(exponent<0) {
					//x=NegativeInfinity; y<0.    0
					return Rational.Zero;
				} else if(exponent.IsEven) {
					//x = NegativeInfinity; y is positive but not an odd integer.	PositiveInfinity
					return Rational.PositiveInfinity;
				}
				return Rational.NegativeInfinity;
				//x=NegativeInfinity; y is a positive odd integer.	NegativeInfinity
			}

			if(Rational.IsInfinity(exponent)) {
				if(ebase==-1) {
					//x = -1; y=NegativeInfinity or PositiveInfinity.	NaN
					return Rational.NaN;
				} else if(-1<ebase&&ebase<1) {
					//-1<x<1; y=NegativeInfinity.PositiveInfinity
					//-1<x<1; y=PositiveInfinity.   0
					return exponent.Sign ? Rational.PositiveInfinity : Rational.Zero;
				} else {
					//x<-1 or x >1; y=NegativeInfinity.  0
					//x<-1 or x >1; y=PositiveInfinity.PositiveInfinity
					return exponent.Sign ? Rational.Zero : Rational.PositiveInfinity;
				}
			}

			if(ebase.IsZero) {
				//x=0; y<0.PositiveInfinity
				//x=0; y>0.   0
				return exponent<0 ? Rational.PositiveInfinity : Rational.Zero;
			}

			if(Rational.IsPositiveInfinity(ebase)) {
				//x=PositiveInfinity; y<0.    0
				//x=PositiveInfinity; y>0.PositiveInfinity
				return exponent<0 ? Rational.Zero : Rational.PositiveInfinity;
			}

			if(exponent.IsZero) {
				return Rational.One;
			}

			exponent.Trim();

			Rational index;
			BigUInteger powExponent;

			index=new Rational(false,exponent.Denominator,BigUInteger.One);
			powExponent=exponent.Numerator;


			if(exponent.Sign) {
				if(!index.IsOne) {
					ebase=InternalRoot(ebase,index).Trim();
				}
				var tmpebase = Math.Pow(ebase,powExponent);
				ebase=new Rational(tmpebase.Sign,tmpebase.Denominator,tmpebase.Numerator);
			} else {
				ebase=Math.Pow(ebase,powExponent);
				if(!index.IsOne) {
					ebase=InternalRoot(ebase,index).Trim();
				}
			}

			return ebase;
#endif
		}

#if !DEBUG||DLLDEBUG

		/// <summary>
		/// 指定された値を指数として Rational 値を累乗します。
		/// </summary>
		/// <param name="ebase">累乗対象の Rational。</param>
		/// <param name="exponent">累乗の指数を指定する Rational。</param>
		private static Rational Pow(Rational ebase,BigUInteger exponent) {

			if(exponent.IsZero) {
				return Rational.One;
			} else if(exponent.IsOne) {
				return ebase;
			}

			var resultBase = Rational.One;
			while(exponent>BigUInteger.One) {
				if(!exponent.IsEven) {
					resultBase*=ebase;
				}
				ebase*=ebase;
				exponent=BigUInteger.RightShift(exponent,0,1);

			}

			return resultBase*ebase;

		}

#endif

		/// <summary>
		/// Rational の値は指定した小数部の桁数に丸められ、中間値には指定した丸め処理が使用されます。
		/// </summary>
		/// <param name="value">丸め対象の Rational。</param>
		/// <param name="digits">戻り値の小数部の桁数。</param>
		/// <param name="mode">value が 2つの整数の中間にある場合に丸める方法を指定します。</param>
		/// <returns>digits に等しい小数部の桁数を格納する value に最も近い数値。 value の小数部の桁数が digits よりも少ない場合、value がそのまま返されます。</returns>
		public static Rational Round(Rational value,int digits,MidpointRounding mode) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Round(value.Numerator,digits,mode);
#else
			if(mode!=MidpointRounding.AwayFromZero&&mode!=MidpointRounding.ToEven) {
				//TODO:メッセージ何とかする
				throw new ArgumentException("",nameof(digits));
			}
			if(Rational.IsInfinity(value)||Rational.IsNaN(value)) {
				return value;
			}
			if(digits<0) {

				BigUInteger RoundInternalInfrator;
				BigUInteger RoundInfrator;
				if(digits==Rational.Accuracy) {
					RoundInternalInfrator=Rational.RoundInternalInfrator;
					RoundInfrator=Rational.RoundInfrator;
				} else {
					RoundInternalInfrator=Math.Pow(BigUInteger.Ten,System.Math.Abs(digits)-1);
					RoundInfrator=RoundInternalInfrator*BigUInteger.Ten;
				}

				var newNumrator = value.Numerator/value.Denominator/RoundInternalInfrator;
				BigUInteger reminder;
				//TODO:%とDivremどちらが速いか考える必要がある
				(newNumrator, reminder)=Math.DivRem(newNumrator,BigUInteger.Ten);

				if(reminder.Value[0]==5) {
					if(mode==MidpointRounding.AwayFromZero||!newNumrator.IsEven) {
						newNumrator++;
					}
				} else if(reminder.Value[0]>5) {
					newNumrator++;
				}

				newNumrator*=RoundInfrator;

				return new Rational(value.Sign,newNumrator,BigUInteger.One);

			} else {

				BigUInteger RoundInternalInfrator;
				BigUInteger RoundInfrator;
				if(digits==Rational.Accuracy) {
					RoundInternalInfrator=Rational.RoundInternalInfrator;
					RoundInfrator=Rational.RoundInfrator;
				} else {
					RoundInfrator=Math.Pow(BigUInteger.Ten,digits);
					RoundInternalInfrator=RoundInfrator*BigUInteger.Ten;
				}
				var neuNumerator = value.Numerator*RoundInternalInfrator;
				var newNumrator = neuNumerator/value.Denominator;
				BigUInteger reminder;
				//TODO:%とDivremどちらが速いか考える必要がある
				(newNumrator, reminder)=Math.DivRem(newNumrator,BigUInteger.Ten);

				if(reminder.Value[0]==5) {
					if(mode==MidpointRounding.AwayFromZero||!newNumrator.IsEven) {
						newNumrator++;
					}
				} else if(reminder.Value[0]>5) {
					newNumrator++;
				}

				return new Rational(value.Sign,newNumrator,RoundInfrator);

			}

#endif
		}

		/// <summary>
		/// Rational の値は最も近い整数に丸められ、中間値には指定した丸め処理が使用されます。
		/// </summary>
		/// <param name="value">丸め対象の Rational。</param>
		/// <param name="mode">value が 2 つの数値の中間にある場合に丸める方法を指定します。</param>
		/// <returns>value に最も近い整数。 value が 2 つの整数 (一方が偶数でもう一方が奇数) の中間にある場合、mode によって 2 つの数値のどちらが返されるかが決まります。 このメソッドは、整数型ではなく Rational を返します。</returns>
		public static Rational Round(Rational value,MidpointRounding mode) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Round(value.Numerator,mode);
#else
			return Round(value,0,mode);
#endif
		}

		/// <summary>
		/// Rational の値は指定した小数部の桁数に丸められ、中間値は最も近い偶数値に丸められます。
		/// </summary>
		/// <param name="value">丸め対象の Rational</param>
		/// <param name="digits">戻り値の小数部の桁数。</param>
		/// <returns>digits に等しい小数部の桁数を格納する value に最も近い数値。 value の小数部の桁数が digits よりも少ない場合、value がそのまま返されます。</returns>
		public static Rational Round(Rational value,int digits) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Round(value.Numerator,digits);
#else
			return Round(value,digits,MidpointRounding.ToEven);
#endif
		}

		/// <summary>
		/// Rational の値は最も近い整数値に丸められ、中間値は最も近い偶数値に丸められます。
		/// </summary>
		/// <param name="value">丸め対象の Rational。</param>
		/// <returns>value パラメーターに最も近い整数。 value の小数部が 2 つの整数 (一方が偶数で、もう一方が奇数) の中間にある場合は、偶数が返されます。 このメソッドは、整数型ではなく Rational を返します。</returns>
		public static Rational Round(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Round(value.Numerator);
#else
			return Round(value,MidpointRounding.ToEven);
#endif
		}

		/// <summary>
		/// Rational の符号を示す整数を返します。
		/// </summary>
		/// <param name="value">符号を取得したいRational値。</param>
		/// <returns>value の符号を示す数値 (次の表を参照)。 
		///戻り値
		///説明 
		///-1 
		///value が 0 未満です。 
		///0 
		///value が 0 です。 
		///1 
		///value が 0 より大きい値です。</returns>
		public static int Sign(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Sign(value.Numerator);
#else
			if(Rational.IsNaN(value)) {
				throw new ArithmeticException();
			}
			return value.IsZero ? 0 : value.Sign ? -1 : 1;
#endif
		}

		/// <summary>
		/// 指定された角度のサインを返します。
		/// </summary>
		/// <param name="radian">ラジアンで表した角度。</param>
		/// <returns>radian のサイン。 radian が NaN、NegativeInfinity、PositiveInfinity のいずれかに等しい場合、このメソッドは NaN を返します。</returns>
		public static Rational Sin(Rational radian) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Sin(radian.Numerator);
#else

			radian-=Math.PI/2;
			return Math.Cos(radian);

#endif
		}

		/// <summary>
		/// 指定された角度のハイパーボリック サインを返します。
		/// </summary>
		/// <param name="value">ラジアンで表した角度。</param>
		/// <returns>value のハイパーボリック サイン。 value が NegativeInfinity、PositiveInfinity、または NaN のいずれかに等しい場合、このメソッドは value に等しい Rational を返します。</returns>
		public static Rational Sinh(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Sinh(value.Numerator);
#else
			return (Math.Pow(Math.E,value)-Math.Pow(Math.E,-value))/Rational.Tow;
#endif
		}

		/// <summary>
		/// 指定された数値の平方根を返します。
		/// </summary>
		/// <param name="value">平方根を求める対象の数値。</param>
		/// <returns>次の表に示したいずれかの値。
		///戻り値 
		///0 または正
		///d の正の平方根。 
		///負
		///NaN
		///NaN と等しい
		///NaN
		///PositiveInfinity と等しい
		///PositiveInfinity</returns>
		public static Rational Sqrt(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Sqrt(value.Numerator);
#else
			return Root(value,Rational.Tow);
#endif
		}

#if !DEBUG||DLLDEBUG
		/// <summary>
		/// 指定された数値の冪根を返します。
		/// </summary>
		/// <param name="value">冪根を求める対象の数値。</param>
		/// <param name="index">冪根の次元数。</param>
		/// <returns>次の表に示したいずれかの値。
		///戻り値 
		///0 または正
		///d の正の冪根。 
		///負
		///NaN
		///NaN と等しい
		///NaN
		///PositiveInfinity と等しい
		///PositiveInfinity</returns>
		public static Rational Root(Rational value,Rational index) {

			//TODO:ニュートン法では小さな数の収束特性が悪い事を何とかしたい

			Rational rootIndex;
			BigUInteger exponent;

			index=index.Trim();
			if(Rational.IsNaN(value)||Rational.IsNaN(index)||value.Sign) {
				return Rational.NaN;
			}
			if(Rational.IsInfinity(value)) {
				return Rational.PositiveInfinity;
			}

			if(index.Sign) {
				if(Rational.IsInfinity(index)) {
					return 0;
				}
				rootIndex=new Rational(false,index.Numerator,BigUInteger.One);
				exponent=index.Denominator;
				if(!rootIndex.IsOne) {
					value=InternalRoot(value,rootIndex).Trim();
				}
				value=Math.Pow(value,exponent);
				value=new Rational(value.Sign,value.Denominator,value.Numerator);
			} else {
				if(Rational.IsInfinity(index)) {
					return Rational.PositiveInfinity;
				}
				rootIndex=new Rational(false,index.Numerator,BigUInteger.One);
				exponent=index.Denominator;
				value=Math.Pow(value,exponent);
				if(!rootIndex.IsOne) {
					value=InternalRoot(value,rootIndex).Trim();
				}
			}




			return value;

		}
		private static Rational InternalRoot(Rational value,Rational index) {
			//TODO:虚数どうする
			//TODO:無理数演算なので打切り誤差許容演算に切り替えた方が良いかもしれない
			if(value.Sign) {
				return Rational.NaN;
			}
			if(Rational.IsInfinity(value)) {
				return value;
			}
			if(value.IsZero) {
				return value;
			}
			var seed = value/index;
			Rational roundedValue;
			var beforeLoopVal = Rational.NaN;
			while(true) {
				var tmp = Pow(seed,index-1);
				seed-=((tmp*seed-value)/index/tmp);
				//TODO:Math.Round(seed,Rational.Accuracy,MidpointRounding.AwayFromZero)が重いので絶対値比較メソッドを作った方が良い
				roundedValue=Round(seed,Rational.Accuracy,MidpointRounding.AwayFromZero);
				if(beforeLoopVal!=Rational.NaN&&beforeLoopVal==roundedValue) {
					break;
				}
				beforeLoopVal=roundedValue;
			}
			return roundedValue;
		}
#endif

		/// <summary>
		/// 指定された角度のタンジェントを返します。
		/// </summary>
		/// <param name="radian">ラジアンで表した角度。</param>
		/// <returns>radian のタンジェント。 radian が NaN、NegativeInfinity、PositiveInfinity のいずれかに等しい場合、このメソッドは NaN を返します。</returns>
		public static Rational Tan(Rational radian) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Tan(radian.Numerator);
#else
			//TODO:級数でといたほうが良い？
			return Sin(radian)/Cos(radian);
#endif
		}

		/// <summary>
		/// 指定された角度のハイパーボリック タンジェントを返します。
		/// </summary>
		/// <param name="value">ラジアンで表した角度。</param>
		/// <returns>value のハイパーボリック タンジェント。 value が NegativeInfinity に等しい場合、このメソッドは -1 を返します。 値が PositiveInfinity に等しい場合、このメソッドは 1 を返します。 value が NaN に等しい場合、このメソッドは NaN を返します。</returns>
		public static Rational Tanh(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Tanh(value.Numerator);
#else
			var ePowPlus = Math.Pow(Math.E,value);
			var ePowMinus = Math.Pow(Math.E,-value);
			return (ePowPlus-ePowMinus)/(ePowPlus+ePowMinus);
#endif
		}

		/// <summary>
		/// 指定した Rational の小数部を切り捨て整数部のみを取得します。
		/// </summary>
		/// <param name="value">切り捨て対象の数値。</param>
		/// <returns>value の整数部。つまり、小数部の桁を破棄した後に残る数値 (次の表にリストされている値のいずれか)。 
		///value
		///戻り値
		///NaN
		///NaN
		///NegativeInfinity
		///NegativeInfinity
		///PositiveInfinity
		///PositiveInfinity</returns>
		public static Rational Truncate(Rational value) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Truncate(value.Numerator);
#else
			if(value==Rational.NaN||Rational.IsInfinity(value)) {
				return value;
			}
			return new Rational(value.Sign,value.Numerator/value.Denominator,BigUInteger.One);
#endif
		}

		/// <summary>
		/// 定数 e によって示される、自然対数の底を表します。
		/// </summary>
		public static Rational E {
			get;
#if !DEBUG||DLLDEBUG
			internal set;
#endif
		}
#if DEBUG&&!DLLDEBUG
		= System.Math.E;
#else
		= new Rational(false,new OuterInterfaceType[] { 11112081522460778609,12223872147168481568,2349204798556998512,15075965923520682115,6887441615138062995,16309656837341375539,15064719163981543696,436705491625477095,11275827193362881332,15930449447352606409,8814516956436756203,213469946252225446,17562829733530253787,14685142554401801162,10351630597096059351,452030552307843178,12599217341095742962,2150777662294472601,11499401292121181421,8828688546087268080,16191199285910339946,15770895216363381547,17633379988082445019,16704824943256566957,12255840167792647034,8279445735501666837,2530739752452782553,1693782449153324445,4155824472764305402,14358519708806461023,4903780485095121483,9347590489047703887,1958446007764881222,6531651879552988218,15649430498495902736,7613245310431531018,793943541887726625,1004293353036657041,7337288758135811398,431463988243667989,17453742838326951816,2256437538173063000,2660446382605963837,14382269670486137780,4798424585720096754,7194630212491286601,99512005679176744,2054799005336719489,13553580103264336877,9393714883535875344,18174942134337062630,7372620103999754507,15056141441115942554,6754460909229411584,6331245426262248588,7923726199501894234,11184045854551627809,13070217822446833558,6666072499354230909,15850611238786390259,3048204098084820008,4067670636400948253,7913757632156332343,7295907229686254588,3849440940615226411,4221219137182235511,7084223018734302582,15736078036340550647,10251328865834139110,8906823785276001073,14993799659556386430,18334078650339763292,2805765462496244131,18378152089937372556,11790280088711245491,2276329919093175217,1872117539742771406,5967353071964319586,12889519068655821673,2296224586721385768,12650679533278433856,3184148113448350236,15195256336862610029,8097092320013756544,10152403260130441434,15503575014075809436,12225374424217571765,13748093702327203358,17014245115582638092,798751765585054151,17776823734816789806,8210281211539409519,17251814680187409502,7078204809885115256,6590124051544841,17559931859724509310,2230291125442839817,5795942081045101168,3321724121590418916,6472710117087663526,9782788851935817896,7297295139863409973,4122672914247583184,14624876118683671022,13754303546347112410,13686577128844205601,6060182598560055388,12389203812566167919,4826076389690044141,5816141681266077639,2265322750886355281,3901794835390592928,545580882736255193,11916138651007142571,18434383702858684706,11610789126479418140,9113865753238336222,4183896499924045798,4414060733937643271,12987407211764938010,559229627008951509,8213855697952964525,11047438559786942838,11757622600449504139,5925799840384012140,15234251397139017281,8239258678432087158,1250349209514499279,1073746128382456474,12418762238200040722,9406843206413542618,8210182014410105935,9653739482014099784,199 },new OuterInterfaceType[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,3967874561105461248,14284242002196731726,13322254600904042372,7944033880010061581,4671440264857437103,5369142438583458699,2400235289494845672,621111831471436509,14661231094253878991,7042532484530460203,16681427188693992463,3926753641863524167,3774392872879799123,16822334524500706051,2896587044809508760,10381247759178370079,4657900060113243492,5227527421033534055,9922296926877053277,10868779514569299442,10937773765101902164,17023563356658127838,12377503285251962024,15973609183575998876,6475827679182016162,7531751943905297557,7472415492522769205,1474985947548927577,10711025492205138285,17804092881383411642,5035630429697251448,8228673272090484134,14208275076464762396,17253226738114335653,18110109365169847640,14506490383025787933,1925285583409131602,14027821037648210529,774688916479964539,13806766806718611928,5865066826976418913,12244328648700828605,12720103583736606879,14728708945233485542,13172344563374440581,12269314361076334095,9056756766391501895,7296954599317013545,16871857417716883088,8870691804955030497,15221992980621604397,16501352041587121571,4060397757058995276,17847777641723265545,12049675405387922806,15276629289308876868,13822438629009494257,16283193002100020690,10758545924476260111,4816395860105534608,2860355481890394779,12661179600257263100,7108744313661958463,18413581773135044980,9989015231167940970,10066780426640502586,10871939851118765103,763863292365646951,1166509331135313328,16062070524362358667,8499605186464622423,12205503302905543510,6468185563245783100,1996010707542846764,2355612580878034617,12532289058302232139,6394246235432309058,5791324406976732076,11747068664638728320,2289038621429848501,7001286766311104688,15159222755854607044,13699399407026534155,17846368479752222158,15123776195820223006,6874621273027156361,3044591339759264764,15849719121298607729,17671461075239167381,16537101015016477473,196326303396643922,11076638506865273478,5754850088041038924,10054541640931312515,13590671191974889721,16595542496944487773,9617730863981927311,5364383830578866494,5938795631234958492,4205338063829584978,13224853819338740083,170783031045077726,2419563932019775723,2884130817297411308,7089068175206913411,15788313108694782151,14055278848292386329,17219351755801934216,10077166536152491842,12317314078209959836,6881527827195664224,8601060221333840356,8605662901215331726,3938978220774928321,16896712866140370219,7660682457705441943,17656259118583882153,7388497257568937794,73 });
#endif

		/// <summary>
		/// 定数 (π) を指定して、円の直径に対する円周の割合を表します。
		/// </summary>
		public static Rational PI {
			get;
		}
#if DEBUG&&!DLLDEBUG
		= System.Math.PI;
#else
		= new Rational(false,new OuterInterfaceType[] { 16496468009935315123,10832621970412584439,9674472321896724842,13947051636708304168,2550531909354371600,16972689635924487089,9622228904471823903,4048356304456027083,4610769094172139593,3664019429699551413,6496459945603362234,154097013387706173,1013311654631510030,8049975346367250242,7899088214859260039,8349867045960302172,11412816556253056616,788754250820977202,1499234216273666184,10222877767628116441,466361759095081721,1482159951499186869,10838285284798424144,10599643281522205171,12044265699516724026,15818284048676252889,15390296349458018674,9900803837993163293,8109505787959507486,4297460655642410370,1955868195642369305,2642248927496000603,5724489181333613433,8281294871604102675,16245386674674079909,7814355449697699390,2848581407866474636,3365786518393427289,17825844542327876323,6076723823655799324,11893971071846223113,3592581882009103061,12136817490141622255,14163142778142205164,16665436098397882810,10275434360854146086,775956007012574527,14993048153699533907,14322932581725859611,7739185853900556036,14238037420304475569,43073883568831634 },new OuterInterfaceType[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,14231914957577912320,3324593729678259774,7501031365974025287,14396362770004323718,12452882010019383101,11660825074448301611,12670112802503344198,10361088455039662369,9938632175832712308,15891758513768934493,11404169402197911406,14232518055403774503,796334716151636780,1844863941729562135,18027089849460446086,14929308618853042833,470901862175387347,532487777391571195,1501447268273094100,7459274532137030355,15342903960146140782,1377293616532374764,8868278097960682939,8838766528254903273,10954941421871493167,9758844335201040220,12993476319710686803,1229722549801656059,4386728077885512386,2713566799601874469,17877534876448462120,14613074067824746683,2428628286549635352,14425605582926340782,3036306186508062550,14836254561284728254,13710842976288648 });
#endif

	}
}