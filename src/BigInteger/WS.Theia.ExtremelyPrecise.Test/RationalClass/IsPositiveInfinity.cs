using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class IsPositiveInfinity:TestBase {

		[TestMethod]
		public void One() {
			Assert.AreEqual<bool>(Rational.IsPositiveInfinity(Rational.One),false);
		}

		[TestMethod]
		public void Zero() {
			Assert.AreEqual<bool>(Rational.IsPositiveInfinity(Rational.Zero),false);
		}

		[TestMethod]
		public void MinusZero() {
			Assert.AreEqual<bool>(Rational.IsPositiveInfinity(new Rational(true,new byte[] { 0 },new byte[] { 1 })),false);
		}

		[TestMethod]
		public void MinusOne() {
			Assert.AreEqual<bool>(Rational.IsPositiveInfinity(Rational.MinusOne),false);
		}

		[TestMethod]
		public void NaN() {
			Assert.AreEqual<bool>(Rational.IsPositiveInfinity(Rational.NaN),false);
		}

		[TestMethod]
		public void PositiveInfinity() {
			Assert.AreEqual<bool>(Rational.IsPositiveInfinity(Rational.PositiveInfinity),true);
		}

		[TestMethod]
		public void NegativeInfinity() {
			Assert.AreEqual<bool>(Rational.IsPositiveInfinity(Rational.NegativeInfinity),false);
		}

	}
}
