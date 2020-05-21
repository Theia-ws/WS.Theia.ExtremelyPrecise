using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class Negate:TestBase {

		[TestMethod]
		public void One() {
			ExecTest(Rational.Negate(Rational.One),true,new byte[]{ 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void Zero() {
			ExecTest(Rational.Negate(Rational.Zero),true,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void MinusOne() {
			ExecTest(Rational.Negate(Rational.MinusOne),false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpOne() {
			ExecTest(-Rational.One,true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpZero() {
			ExecTest(-Rational.Zero,true,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpMinusOne() {
			ExecTest(-Rational.MinusOne,false,new byte[] { 1 },new byte[] { 1 },false);
		}

	}
}