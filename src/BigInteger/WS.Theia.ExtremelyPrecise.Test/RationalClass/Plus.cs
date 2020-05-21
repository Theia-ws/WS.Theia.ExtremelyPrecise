using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class Plus:TestBase {

		[TestMethod]
		public void One() {
			ExecTest(Rational.Plus(Rational.One),false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void Zero() {
			ExecTest(Rational.Plus(Rational.Zero),false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void MinusOne() {
			ExecTest(Rational.Plus(Rational.MinusOne),true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpOne() {
			ExecTest(+Rational.One,false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpZero() {
			ExecTest(+Rational.Zero,false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpMinusOne() {
			ExecTest(+Rational.MinusOne,true,new byte[] { 1 },new byte[] { 1 },false);
		}

	}
}
