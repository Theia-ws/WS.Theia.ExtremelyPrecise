using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class One:TestBase {

		[TestMethod]
		public void Test() {
			ExecTest(Rational.One,false,new byte[] { 1 },new byte[] { 1 },false);
		}

	}
}