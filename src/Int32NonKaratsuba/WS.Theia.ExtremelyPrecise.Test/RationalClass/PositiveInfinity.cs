using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class PositiveInfinity:TestBase {

		[TestMethod]
		public void Test() {
			ExecTest(Rational.PositiveInfinity,false,new byte[] { 1 },new byte[] { 1 },true);
		}

	}
}
