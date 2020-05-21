using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class GetHashCode:TestBase {

		[TestMethod]
		public void OneZero() {
			Assert.AreNotEqual<int>(Rational.One.GetHashCode(),Rational.Zero.GetHashCode());
		}

		[TestMethod]
		public void OneMinusOne() {
			Assert.AreNotEqual<int>(Rational.One.GetHashCode(),Rational.MinusOne.GetHashCode());
		}

		[TestMethod]
		public void OneNaN() {
			Assert.AreNotEqual<int>(Rational.One.GetHashCode(),Rational.NaN.GetHashCode());
		}

		[TestMethod]
		public void OnePositiveInfinity() {
			Assert.AreNotEqual<int>(Rational.One.GetHashCode(),Rational.PositiveInfinity.GetHashCode());
		}

		[TestMethod]
		public void OneNegativeInfinity() {
			Assert.AreNotEqual<int>(Rational.One.GetHashCode(),Rational.NegativeInfinity.GetHashCode());
		}

	}
}
