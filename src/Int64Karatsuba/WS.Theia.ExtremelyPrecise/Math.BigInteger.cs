using System;
using ContainerType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise {

	/// <summary>
	/// 三角関数や対数関数などの一般的な数値関数の定数と静的メソッドを提供します。
	/// </summary>
	public static partial class Math {
		
		/// <summary>
		/// 2 つの数値の商を計算し、出力パラメーターの剰余を返します。
		/// </summary>
		/// <param name="dividend">被除数。</param>
		/// <param name="divisor">除数。</param>
		/// <returns>指定した数値の商。剰余。</returns>
		public static (BigUInteger Quotient, BigUInteger Remainder) DivRem(BigUInteger dividend,BigUInteger divisor) {
#if DEBUG&&!DLLDEBUG
			return (dividend.Value/divisor.Value, dividend.Value%divisor.Value);
#else
			if(divisor.IsZero) {
				throw new DivideByZeroException();
			}

			if(divisor.IsOne) {
				return (dividend, BigUInteger.Zero);
			}

			//TODO:最適化未了
			var comp = BigUInteger.Compare(dividend,divisor);
			if(comp<0) {
				return (BigUInteger.Zero, dividend);
			} else if(comp==0) {
				return (BigUInteger.One, BigUInteger.Zero);
			}

			var arrayShifter = dividend.Value.Length-divisor.Value.Length;
			var innerShifter = 0;

			divisor=BigUInteger.LeftShift(divisor,arrayShifter,innerShifter);

			while(dividend>divisor) {
				divisor<<=1;
				innerShifter++;
				if(innerShifter>=BigUInteger.ContainerItemSizeWithBit) {
					innerShifter=0;
					arrayShifter++;
				}
			}

			while(dividend<divisor) {
				divisor>>=1;
				innerShifter--;
				if(innerShifter<0) {
					innerShifter=BigUInteger.ContainerItemSizeWithBit-1;
					arrayShifter--;
				}
			}

			var quotientLength = arrayShifter+1;
			var quotient = new ContainerType[quotientLength<1 ? 1 : quotientLength];

			while(arrayShifter>=0) {
				if(dividend>=divisor) {
					dividend-=divisor;
					quotient[arrayShifter]|=(ContainerType)1<<innerShifter;
				}
				divisor>>=1;
				innerShifter--;
				if(innerShifter<0) {
					innerShifter=BigUInteger.ContainerItemSizeWithBit-1;
					arrayShifter--;
				}
			}

			return (new BigUInteger(quotient), dividend);
#endif
		}

		/// <summary>
		/// 2 つの BigUInteger のうち、大きな方を返します。
		/// </summary>
		/// <param name="val1">比較する最初の数値。</param>
		/// <param name="val2">比較する2 番目の数値。</param>
		/// <returns>パラメーター val1 または val2 のいずれか大きい方。</returns>
		public static BigUInteger Max(BigUInteger val1,BigUInteger val2) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Max(val1.Value,val2.Value);
#else
			return val1>val2 ? val1 : val2;
#endif
		}

		/// <summary>
		/// 2 つの BigUInteger のうち、小さい方を返します。
		/// </summary>
		/// <param name="val1">比較する最初の数値。</param>
		/// <param name="val2">比較する 2 番目の数値。</param>
		/// <returns>パラメーター val1 または val2 のいずれか小さい方。</returns>
		public static BigUInteger Min(BigUInteger val1,BigUInteger val2) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Min(val1.Value,val2.Value);
#else
			return val1<val2 ? val1 : val2;
#endif
		}
		
		/// <summary>
		/// 指定の数値を指定した値で累乗した値を返します。
		/// </summary>
		/// <param name="ebase">累乗対象の BigUInteger。</param>
		/// <param name="exponent">累乗を指定する BigUInteger。</param>
		/// <returns>数値 ebase を exponent で累乗した値。</returns>
		public static BigUInteger Pow(BigUInteger ebase,BigUInteger exponent) {
#if DEBUG&&!DLLDEBUG
			return System.Math.Pow(ebase.Value,exponent.Value);
#else

			if(ebase.IsOne||exponent.IsOne) {
				//x=1; 1
				return ebase;
			}

			if(exponent==0) {
				return BigUInteger.One;
			}

			if(ebase.IsZero) {
				//x=0; y>0.   0
				return BigUInteger.Zero;
			}

			if(exponent.IsZero) {
				return BigUInteger.One;
			}

			if(exponent.IsZero) {
				return BigUInteger.One;
			} else if(exponent.IsOne) {
				return ebase;
			}

			var resultBase = BigUInteger.One;
			while(exponent>BigUInteger.One) {
				if(!exponent.IsEven) {
					resultBase*=ebase;
				}
				ebase*=ebase;
				exponent=BigUInteger.RightShift(exponent,0,1);

			}

			return resultBase*ebase;
#endif
		}

	}
}