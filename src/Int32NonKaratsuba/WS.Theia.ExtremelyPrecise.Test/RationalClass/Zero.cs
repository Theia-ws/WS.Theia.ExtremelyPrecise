using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class Zero:TestBase {

		[TestMethod]
		public void Test() {
			ExecTest(Rational.Zero,false,new byte[] { 0 },new byte[] { 1 },false);
		}

	}
}
