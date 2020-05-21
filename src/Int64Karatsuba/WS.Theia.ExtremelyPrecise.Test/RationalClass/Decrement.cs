using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class Decrement:TestBase {

		[TestMethod]
		public void Tow() {
			var value = new Rational(false,new byte[] { 2 },new byte[] { 1 });
			value=Rational.Decrement(value);
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void One() {
			var value = Rational.One;
			value=Rational.Decrement(value);
			ExecTest(value,false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void Zero() {
			var value = Rational.Zero;
			value=Rational.Decrement(value);
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void MinusZero() {
			var value = new Rational(true,new byte[] { 0 },new byte[] { 1 });
			value=Rational.Decrement(value);
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void LargeDenominator() {
			var value = new Rational(true,new byte[] { 9 },new byte[] { 3 });
			value=Rational.Decrement(value);
			ExecTest(value,true,new byte[] { 12 },new byte[] { 3 },false);
		}

		[TestMethod]
		public void NaN() {
			var value = Rational.NaN;
			value=Rational.Decrement(value);
			ExecTest(value,false,new byte[] { 0 },new byte[] { 0 },false);
		}

		[TestMethod]
		public void PositiveInfinity() {
			var value = Rational.PositiveInfinity;
			value=Rational.Decrement(value);
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void NegativeInfinity() {
			var value = Rational.NegativeInfinity;
			value=Rational.Decrement(value);
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void OpTow() {
			var value = new Rational(false,new byte[] { 2 },new byte[] { 1 });
			value--;
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpOne() {
			var value = Rational.One;
			value--;
			ExecTest(value,false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpZero() {
			var value = Rational.Zero;
			value--;
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpMinusZero() {
			var value = new Rational(true,new byte[] { 0 },new byte[] { 1 });
			value--;
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpLargeDenominator() {
			var value = new Rational(true,new byte[] { 9 },new byte[] { 3 });
			value--;
			ExecTest(value,true,new byte[] { 12 },new byte[] { 3 },false);
		}

		[TestMethod]
		public void OpNaN() {
			var value = Rational.NaN;
			value--;
			ExecTest(value,false,new byte[] { 0 },new byte[] { 0 },false);
		}

		[TestMethod]
		public void OpPositiveInfinity() {
			var value = Rational.PositiveInfinity;
			value--;
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void OpNegativeInfinity() {
			var value = Rational.NegativeInfinity;
			value--;
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },true);
		}

	}
}
