using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class RightShift:TestBase {

		[TestMethod]
		public void Plus() {
			ExecTest(BigUInteger.RightShift(new BigUInteger(new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 }),32),new byte[] { 255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 });
		}

		[TestMethod]
		public void OpPlus() {
			ExecTest(new BigUInteger(new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 })>>32,new byte[] { 255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 });
		}


	}
}
