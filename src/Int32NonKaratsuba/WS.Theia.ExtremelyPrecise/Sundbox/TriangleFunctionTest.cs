#if DLLDEBUG

namespace WS.Theia.ExtremelyPrecise.Sundbox {
	public class TriangleFunctionTest {

		public static Rational Cos(Rational radian) {
			radian%=Math.PI;
			var nFactrial = BigUInteger.Tow;
			var towCoefficient = BigUInteger.Tow;
			var radRad = radian*radian;
			var radianFactrial = radRad;

			var result = Rational.One;

			var resultAdder = new Rational(false,BigUInteger.One,nFactrial)*radianFactrial;
			result-=resultAdder;

			//TODO:無理数演算なので打切り誤差許容演算に切り替えた方が良いかもしれない
			var targetOder = GetOrder(Rational.RoundInternalInfrator);
			for(var loopEnd = -targetOder;GetOrder(resultAdder)>loopEnd;) {

				towCoefficient++;
				nFactrial*=towCoefficient;
				towCoefficient++;
				nFactrial*=towCoefficient;
				radianFactrial*=radRad;
				radianFactrial=UnderflowTrimer(radianFactrial,targetOder);
				result+=new Rational(false,radianFactrial.Numerator,nFactrial*radianFactrial.Denominator);

				towCoefficient++;
				nFactrial*=towCoefficient;
				towCoefficient++;
				nFactrial*=towCoefficient;
				radianFactrial*=radRad;
				radianFactrial=UnderflowTrimer(radianFactrial,targetOder);
				resultAdder=new Rational(false,radianFactrial.Numerator,nFactrial*radianFactrial.Denominator);
				result-=resultAdder;
			}
			return result;
		}

		private static Rational UnderflowTrimer(Rational value,Rational targetOder) {
			var nowOder = GetOrder(value.Denominator)-targetOder;
			if(nowOder>0) {
				var (arrayShift, innerShift)=Math.DivRem(nowOder,BigUInteger.ContainerItemSizeWithBit);
				value.Numerator=BigUInteger.RightShift(value.Numerator,(int)arrayShift,(int)innerShift);
				value.Denominator=BigUInteger.RightShift(value.Denominator,(int)arrayShift,(int)innerShift);
			}
			return value;
		}

		internal static Rational GetOrder(BigUInteger value) {
			var result = (value.Value.Length-Rational.One)*new Rational(BigUInteger.ContainerItemSizeWithBit);

			for(var topPart = value.Value[^1];topPart!=0;topPart>>=1) {
				result++;
			}
			return result;
		}

		internal static Rational GetOrder(Rational value) {
			var result = new Rational(value.Numerator.Value.Length-value.Denominator.Value.Length)*new Rational(BigUInteger.ContainerItemSizeWithBit);

			for(var topPart = value.Numerator.Value[^1];topPart!=0;topPart>>=1) {
				result++;
			}
			for(var topPart = value.Denominator.Value[^1];topPart!=0;topPart>>=1) {
				result--;
			}
			return result;
		}


		public static Rational Cot(Rational radian) {
			var result = Math.Tan(radian);
			var tmp = result.Denominator;
			result.Denominator=result.Numerator;
			result.Numerator=tmp;
			return result;
		}

		public static Rational Acot(Rational cot) {
			return Math.PI/Rational.Tow-Math.Atan(cot);
		}

		public static Rational Crd(Rational radian) {
			var versin = TriangleFunctionTest.Versin(radian);
			var sin = Math.Sin(radian);
			//TODO:小さな値の冪根はニュートン法との相性が悪い為、できれば冪根を使いたくない。
			return Math.Sqrt(versin*versin+sin*sin);
		}

		public static Rational Csc(Rational radian) {
			var result = Math.Sin(radian);
			var tmp = result.Denominator;
			result.Denominator=result.Numerator;
			result.Numerator=tmp;
			return result;
		}

		public static Rational Acsc(Rational csc) {
			return Math.Asin(new Rational(csc.Sign,csc.Denominator,csc.Numerator));
		}

		public static Rational Cvs(Rational radian) {
			var result = Math.Sin(radian);
			result.Numerator=result.Denominator-result.Numerator;
			return result;
		}

		public static Rational Excsc(Rational radian) {
			var result = TriangleFunctionTest.Csc(radian);
			result.Numerator=BigUInteger.MargeSubtraction(result.Numerator,result.Denominator);
			return result;
		}

		public static Rational Exsec(Rational radian) {
			var result = TriangleFunctionTest.Sec(radian);
			result.Numerator=BigUInteger.MargeSubtraction(result.Numerator,result.Denominator);
			return result;
		}

		public static Rational Sec(Rational radian) {
			var result = Math.Cos(radian);
			var tmp = result.Denominator;
			result.Denominator=result.Numerator;
			result.Numerator=tmp;
			return result;
		}

		public static Rational Asec(Rational sec) {
			return Math.Acos(new Rational(sec.Sign,sec.Denominator,sec.Numerator));
		}

		public static Rational Versin(Rational radian) {
			var result = Math.Cos(radian);
			result.Numerator=result.Denominator-result.Numerator;
			return result;
		}

	}
}
#endif