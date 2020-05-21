using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class IsNegativeInfinity:TestBase {

		[TestMethod]
		public void One() {
			Assert.AreEqual<bool>(Rational.IsNegativeInfinity(Rational.One),false);
		}

		[TestMethod]
		public void Zero() {
			Assert.AreEqual<bool>(Rational.IsNegativeInfinity(Rational.Zero),false);
		}

		[TestMethod]
		public void MinusZero() {
			Assert.AreEqual<bool>(Rational.IsNegativeInfinity(new Rational(true,new byte[] { 0 },new byte[] { 1 })),false);
		}

		[TestMethod]
		public void MinusOne() {
			Assert.AreEqual<bool>(Rational.IsNegativeInfinity(Rational.MinusOne),false);
		}

		[TestMethod]
		public void NaN() {
			Assert.AreEqual<bool>(Rational.IsNegativeInfinity(Rational.NaN),false);
		}

		[TestMethod]
		public void PositiveInfinity() {
			Assert.AreEqual<bool>(Rational.IsNegativeInfinity(Rational.PositiveInfinity),false);
		}

		[TestMethod]
		public void NegativeInfinity() {
			Assert.AreEqual<bool>(Rational.IsNegativeInfinity(Rational.NegativeInfinity),true);
		}

	}
}
