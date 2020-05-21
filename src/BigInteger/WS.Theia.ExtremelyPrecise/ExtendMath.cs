#if DLLDEBUG
namespace WS.Theia.ExtremelyPrecise {

	public static class ExtendMath {

		/// <summary>
		/// 指定した項のベルヌーイ数を算出します。
		/// </summary>
		/// <param name="section">算出するベルヌーイ数の項。</param>
		/// <returns>指定した項のベルヌーイ数。</returns>
		public static Rational BernoulliNumber(BigUInteger section) {
#if DEBUG&&!DLLDEBUG
#else
			if(section.IsZero) {
				return 1;
			}
			if(section.IsOne) {
				return -0.5;
			}
			if(!section.IsEven) {
				return 0;
			}

			var sectionPlusOne = section+BigUInteger.One;
			var result = Rational.MinusOne/sectionPlusOne;
			var summation = Rational.Zero;
			if(section>1) {



				summation+=1*BinomialCoefficients(sectionPlusOne,BigUInteger.Zero);
				summation+=-0.5*BinomialCoefficients(sectionPlusOne,BigUInteger.One);

				var binomialCoefficientsNumerator = Factorial(sectionPlusOne);
				var binomialCoefficientsDenominator1 = Rational.One;
				var binomialCoefficientsDenominator2 = (Rational)Factorial(sectionPlusOne-BigUInteger.Tow);

				for(var k = BigUInteger.Tow;k<section;k+=BigUInteger.Tow) {
					//TODO:一度算出したベルヌーイ数を保管しておいて再使用する方法を考えないといけない。
					binomialCoefficientsDenominator1*=k-1;
					binomialCoefficientsDenominator1*=k;

					summation+=BernoulliNumber(k)*binomialCoefficientsNumerator/(binomialCoefficientsDenominator1*binomialCoefficientsDenominator2);

					binomialCoefficientsDenominator2/=sectionPlusOne-k;
					binomialCoefficientsDenominator2/=sectionPlusOne-k-1;
				}
			} else {
				summation=1;
			}
			return result*summation;
#endif
		}

		/// <summary>
		/// 二項係数を算出します。
		/// </summary>
		/// <param name="firstCoefficients">1つ目の項。</param>
		/// <param name="secondCoefficients">2つ目の項。</param>
		/// <returns>二項係数を計算した結果。</returns>
		public static Rational BinomialCoefficients(BigUInteger firstCoefficients,BigUInteger secondCoefficients) {
#if DEBUG&&!DLLDEBUG
#else
			return Factorial(firstCoefficients)/(Rational)(Factorial(secondCoefficients)*Factorial(firstCoefficients-secondCoefficients));
#endif
		}

		/// <summary>
		/// 指定した項のオイラー数を算出します。
		/// </summary>
		/// <param name="section">算出するオイラー数の項。</param>
		/// <returns>指定した項のオイラー数。</returns>
		public static BigUInteger EulerNumber(BigUInteger section) {
#if DEBUG&&!DLLDEBUG
#else
			if(((section>>1)&0x1)>0) {
				return SecantNumber(section)*-1;
			}
			return SecantNumber(section);
#endif
		}

		/// <summary>
		/// 指定した項のセカント数・タンジェント数を算出します。
		/// </summary>
		/// <param name="section">算出するセカント数・タンジェント数の項。</param>
		/// <returns>指定した項のセカント数・タンジェント数。</returns>
		private static BigUInteger ETExplore(BigUInteger section) {
#if DEBUG&&!DLLDEBUG
#else
			section+=2;
			var oldMaster = new BigUInteger[] { 1 };
			for(var masterLength = 2;masterLength<section;masterLength++) {
				var newMaster = new BigUInteger[masterLength];
				var adder = BigUInteger.Zero;
				var newMasterCounter = 0;
				newMaster[newMasterCounter]=BigUInteger.Zero;
				newMasterCounter++;
				for(var oldMasterCounter = oldMaster.Length-1;oldMasterCounter>=0;oldMasterCounter--, newMasterCounter++) {
					adder+=oldMaster[oldMasterCounter];
					newMaster[newMasterCounter]=adder;
				}
				oldMaster=newMaster;
			}
			return oldMaster[^1];
#endif
		}

		/// <summary>
		/// 階乗を計算します。
		/// </summary>
		/// <param name="value">階乗の終了値。</param>
		/// <returns>階乗を計算した結果。</returns>
		public static BigUInteger Factorial(BigUInteger value) {
#if DEBUG&&!DLLDEBUG
#else
			var result = BigUInteger.One;
			for(var counter = BigUInteger.One;counter<=value;counter++) {
				result*=counter;
			}
			return result;
#endif
		}

		/// <summary>
		/// 指定した項のセカント数を算出します。
		/// </summary>
		/// <param name="section">算出するセカント数の項。</param>
		/// <returns>指定した項のセカント数。</returns>
		public static BigUInteger SecantNumber(BigUInteger section) {
#if DEBUG&&!DLLDEBUG
#else
			if(section==0) {
				return 1;
			}
			if(!section.IsEven) {
				return 0;
			}

			return ETExplore(section);
#endif
		}

		/// <summary>
		/// 指定した項のタンジェント数を算出します。
		/// </summary>
		/// <param name="section">算出するタンジェント数の項。</param>
		/// <returns>指定した項のタンジェント数。</returns>
		public static BigUInteger TangentNumber(BigUInteger section) {
#if DEBUG&&!DLLDEBUG
#else
			if(section==0) {
				return 1;
			}
			if(section.IsEven) {
				return 0;
			}
			return ETExplore(section);
#endif
		}

	}
}
#endif