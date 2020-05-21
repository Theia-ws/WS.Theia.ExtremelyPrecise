using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class Clone:TestBase {

		[TestMethod]
		public void NormalValue() {
			var value = new byte[] { 0,200,45,89,12,17,253,43,162,239 };
			ExecTest(new BigUInteger(value).Clone(),value);
		}

	}
}
