using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class Increment:TestBase {

		[TestMethod]
		public void Zero() {
			var value = Rational.Zero;
			value=Rational.Increment(value);
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void MinusZero() {
			var value = new Rational(true,new byte[] { 0 },new byte[] { 1 });
			value=Rational.Increment(value);
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void MinusOne() {
			var value = Rational.MinusOne;
			value=Rational.Increment(value);
			ExecTest(value,true,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void MinusTow() {
			var value = new Rational(true,new byte[] { 2 },new byte[] { 1 });
			value=Rational.Increment(value);
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void LargeDenominator() {
			var value = new Rational(true,new byte[] { 9 },new byte[] { 3 });
			value=Rational.Increment(value);
			ExecTest(value,true,new byte[] { 6 },new byte[] { 3 },false);
		}

		[TestMethod]
		public void NaN() {
			var value = Rational.NaN;
			value=Rational.Increment(value);
			ExecTest(value,false,new byte[] { 0 },new byte[] { 0 },false);
		}

		[TestMethod]
		public void PositiveInfinity() {
			var value = Rational.PositiveInfinity;
			value=Rational.Increment(value);
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void NegativeInfinity() {
			var value = Rational.NegativeInfinity;
			value=Rational.Increment(value);
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void OpZero() {
			var value = Rational.Zero;
			value++;
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpMinusZero() {
			var value = new Rational(true,new byte[] { 0 },new byte[] { 1 });
			value++;
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpMinusOne() {
			var value = Rational.MinusOne;
			value++;
			ExecTest(value,true,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpMinusTow() {
			var value = new Rational(true,new byte[] { 2 },new byte[] { 1 });
			value++;
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void OpLargeDenominator() {
			var value = new Rational(true,new byte[] { 9 },new byte[] { 3 });
			value++;
			ExecTest(value,true,new byte[] { 6 },new byte[] { 3 },false);
		}

		[TestMethod]
		public void OpNaN() {
			var value = Rational.NaN;
			value++;
			ExecTest(value,false,new byte[] { 0 },new byte[] { 0 },false);
		}

		[TestMethod]
		public void OpPositiveInfinity() {
			var value = Rational.PositiveInfinity;
			value++;
			ExecTest(value,false,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void OpNegativeInfinity() {
			var value = Rational.NegativeInfinity;
			value++;
			ExecTest(value,true,new byte[] { 1 },new byte[] { 1 },true);
		}

	}
}
