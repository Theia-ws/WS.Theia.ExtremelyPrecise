using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class OACurrency:TestBase {

		[TestMethod]
		public void From0() {
			long input = 0;
			Rational result = 0;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From1() {
			long input = 1;
			Rational result = 0.0001m;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From100000() {
			long input = 100000;
			Rational result = 10;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From100000000000() {
			long input = 100000000000;
			Rational result = 10000000;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From1000000000000000000() {
			long input = 1000000000000000000;
			Rational result = 100000000000000;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From1000000000000000001() {
			long input = 1000000000000000001;
			Rational result = 100000000000000.0001m;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From9223372036854775807() {
			long input = 9223372036854775807;
			Rational result = 922337203685477.5807m;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From_9223372036854775808() {
			long input = -9223372036854775808;
			Rational result = -922337203685477.5808m;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From123456789() {
			long input = 123456789;
			Rational result = 12345.6789m;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From1234567890000() {
			long input = 1234567890000;
			Rational result = 123456789;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From1234567890987654321() {
			long input = 1234567890987654321;
			Rational result = 123456789098765.4321m;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void From4294967295() {
			long input = 4294967295;
			Rational result = 429496.7295m;
			ExecTest<Rational>(Rational.FromOACurrency(input),result);
		}

		[TestMethod]
		public void To0() {
			Rational input = 0;
			var result = 0;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To1() {
			Rational input = 1;
			var result = 10000;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To1_0000000000000000000000000000() {
			Rational input = 1.0000000000000000000000000000m;
			var result = 10000;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To100000000000000() {
			Rational input = 100000000000000;
			var result = 1000000000000000000;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To100000000000000_00000000000000() {
			Rational input = 100000000000000.00000000000000m;
			var result = 1000000000000000000;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To10000000000000000000000000000() {
			Rational input = Rational.Parse("10000000000000000000000000000");
			Assert.ThrowsException<OverflowException>(() => {
				Rational.ToOACurrency(input);
			});
		}

		[TestMethod]
		public void To0_000000000123456789() {
			Rational input = 0.000000000123456789m;
			var result = 0;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To0_123456789() {
			Rational input = 0.123456789m;
			var result = 1235;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To123456789() {
			Rational input = 123456789;
			var result = 1234567890000;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To123456789000000000() {
			Rational input = Rational.Parse("123456789000000000");
			Assert.ThrowsException<OverflowException>(() => {
				Rational.ToOACurrency(input);
			});
		}

		[TestMethod]
		public void To4294967295() {
			Rational input = 4294967295;
			var result = 42949672950000;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To18446744073709551615() {
			Rational input = Rational.Parse("18446744073709551615");
			Assert.ThrowsException<OverflowException>(() => {
				Rational.ToOACurrency(input);
			});
		}

		[TestMethod]
		public void To_79_228162514264337593543950335() {
			Rational input = -79.228162514264337593543950335m;
			var result = -792282;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

		[TestMethod]
		public void To_79228162514264_337593543950335() {
			Rational input = -79228162514264.337593543950335m;
			var result = -792281625142643376;
			ExecTest<long>(Rational.ToOACurrency(input),result);
		}

	}
}