using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class LeftSihft:TestBase {

		[TestMethod]
		public void Plus() {
			ExecTest(Rational.LeftShift(new Rational(false,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 1 }),32),false,new byte[] { 0,0,0,0,0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void Nigate() {
			ExecTest(Rational.LeftShift(new Rational(true,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 1 }),32),true,new byte[] { 0,0,0,0,0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpPlus() {
			ExecTest(new Rational(false,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 1 })<<32,false,new byte[] { 0,0,0,0,0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpNigate() {
			ExecTest(new Rational(true,new byte[] { 0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255,0,0,0,0 },new byte[] { 1 })<<32,true,new byte[] { 0,0,0,0,0,0,0,0,255,255,255,255,255,255,255,255,255,255,255,255 },new byte[] { 1 },false);
		}

	}
}
