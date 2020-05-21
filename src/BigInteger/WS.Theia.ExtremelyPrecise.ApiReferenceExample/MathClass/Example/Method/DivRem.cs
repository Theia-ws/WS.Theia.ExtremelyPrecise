using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class DivRem {
		//TODO:余りの出し方が少し微妙
		[TestMethod]
		public void Case1() {
			// Define several positive and negative dividends.
			Rational[] dividends = { Int32.MaxValue, 13952, 0, -14032,
									 Int32.MinValue };
			// Define one positive and one negative divisor.
			Rational[] divisors = { 2000,-2000 };

			foreach(Rational divisor in divisors) {
				foreach(Rational dividend in dividends) {
					Rational remainder;
					Rational quotient;
					(quotient, remainder)=Math.DivRem(dividend,divisor);
					Console.WriteLine(@"{0:N0} \ {1:N0} = {2:N0}, remainder {3:N0}",
									  dividend,divisor,quotient,remainder);
				}
			}
		}
		// The example displays the following output:
		//       2,147,483,647 \ 2,000 = 1,073,741, remainder 1,647
		//       13,952 \ 2,000 = 6, remainder 1,952
		//       0 \ 2,000 = 0, remainder 0
		//       -14,032 \ 2,000 = -7, remainder -32
		//       -2,147,483,648 \ 2,000 = -1,073,741, remainder -1,648
		//       2,147,483,647 \ -2,000 = -1,073,741, remainder 1,647
		//       13,952 \ -2,000 = -6, remainder 1,952
		//       0 \ -2,000 = 0, remainder 0
		//       -14,032 \ -2,000 = 7, remainder -32
		//       -2,147,483,648 \ -2,000 = 1,073,741, remainder -1,648

	}
}
