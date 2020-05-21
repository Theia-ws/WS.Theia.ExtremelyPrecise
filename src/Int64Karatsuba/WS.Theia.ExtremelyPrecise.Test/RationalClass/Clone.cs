using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class Clone:TestBase {

		[TestMethod]
		public void NormalValue() {
			var numerator = new byte[] { 0,200,45,89,12,17,253,43,162,239 };
			var denominator = new byte[] { 1,35,26,32,157,215,122,107,211 };
			var sign = true;
			var infinity = false;
			ExecTest(new Rational(sign,numerator,denominator).Clone(),sign,numerator,denominator,infinity);
		}

		[TestMethod]
		public void Nan() {
			var numerator = new byte[] { 0 };
			var denominator = new byte[] { 0 };
			var sign = false;
			var infinity = false;
			ExecTest(Rational.NaN.Clone(),sign,numerator,denominator,infinity);
		}

		[TestMethod]
		public void PositiveInfinity() {
			var numerator = new byte[] { 1 };
			var denominator = new byte[] { 1 };
			var sign = false;
			var infinity = true;
			ExecTest(Rational.PositiveInfinity.Clone(),sign,numerator,denominator,infinity);
		}

		[TestMethod]
		public void NegativeInfinity() {
			var numerator = new byte[] { 1 };
			var denominator = new byte[] { 1 };
			var sign = true;
			var infinity = true;
			ExecTest(Rational.NegativeInfinity.Clone(),sign,numerator,denominator,infinity);
		}

	}
}
