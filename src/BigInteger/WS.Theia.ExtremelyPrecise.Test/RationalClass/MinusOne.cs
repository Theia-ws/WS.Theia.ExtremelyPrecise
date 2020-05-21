using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class MinusOne:TestBase {

		[TestMethod]
		public void Test() {
			ExecTest(Rational.MinusOne,true,new byte[] { 1 },new byte[] { 1 },false);
		}

	}
}