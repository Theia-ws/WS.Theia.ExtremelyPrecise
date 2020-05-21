using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class Plus:TestBase {

		[TestMethod]
		public void One() {
			ExecTest(BigUInteger.Plus(BigUInteger.One),new byte[] { 1 });
		}

		[TestMethod]
		public void Zero() {
			ExecTest(BigUInteger.Plus(BigUInteger.Zero),new byte[] { 0 });
		}

		[TestMethod]
		public void OpOne() {
			ExecTest(+BigUInteger.One,new byte[] { 1 });
		}

		[TestMethod]
		public void OpZero() {
			ExecTest(+BigUInteger.Zero,new byte[] { 0 });
		}

	}
}
