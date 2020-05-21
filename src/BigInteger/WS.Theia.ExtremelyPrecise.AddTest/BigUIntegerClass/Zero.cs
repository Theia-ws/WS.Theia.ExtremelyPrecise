using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class Zero:TestBase {

		[TestMethod]
		public void Test() {
			ExecTest(BigUInteger.Zero,new byte[] { 0 });
		}

	}
}
