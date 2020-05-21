using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class RightShift:TestBase {

		[TestMethod]
		public void Plus() {
			ExecTest(Rational.RightShift(new Rational(false,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 1 }),32),false,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 0,0,0,0,1 },false);
		}

		[TestMethod]
		public void Nigate() {
			ExecTest(Rational.RightShift(new Rational(true,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 1 }),32),true,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 0,0,0,0,1 },false);
		}

		[TestMethod]
		public void OpPlus() {
			ExecTest(new Rational(false,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 1 })>>32,false,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 0,0,0,0,1 },false);
		}

		[TestMethod]
		public void OpNigate() {
			ExecTest(new Rational(true,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 1 })>>32,true,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 0,0,0,0,1 },false);
		}

	}
}
