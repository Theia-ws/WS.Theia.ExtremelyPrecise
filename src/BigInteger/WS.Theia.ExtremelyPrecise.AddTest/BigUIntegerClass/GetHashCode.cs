using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class GetHashCode:TestBase {

		[TestMethod]
		public void OneZero() {
			Assert.AreNotEqual<int>(BigUInteger.One.GetHashCode(),BigUInteger.Zero.GetHashCode());
		}

	}
}
