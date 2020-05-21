using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class NaN:TestBase {

		[TestMethod]
		public void Test() {
			ExecTest(Rational.NaN,false,new byte[] { 0 },new byte[] { 0 },false);
		}

	}
}
