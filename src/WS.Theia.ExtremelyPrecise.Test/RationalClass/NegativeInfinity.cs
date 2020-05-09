using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class NegativeInfinity:TestBase {

		[TestMethod]
		public void Test() {
			ExecTest(Rational.NegativeInfinity,true,new byte[] { 1 },new byte[] { 1 },true);
		}

	}
}
