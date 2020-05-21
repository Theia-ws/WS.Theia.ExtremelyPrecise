using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class One:TestBase {

		[TestMethod]
		public void Test() {
			ExecTest(BigUInteger.One,new byte[] { 1 });
		}

	}
}