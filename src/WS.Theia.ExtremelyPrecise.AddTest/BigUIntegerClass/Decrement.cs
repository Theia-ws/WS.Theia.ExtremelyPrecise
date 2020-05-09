using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class Decrement:TestBase {

		[TestMethod]
		public void Tow() {
			var value = new BigUInteger(new byte[] { 2 });
			value=BigUInteger.Decrement(value);
			ExecTest(value,new byte[] { 1 });
		}

		[TestMethod]
		public void One() {
			var value = BigUInteger.One;
			value=BigUInteger.Decrement(value);
			ExecTest(value,new byte[] { 0 });
		}

		[TestMethod]
		public void Zero() {
			Assert.ThrowsException<OverflowException>(()=> {
				var value = BigUInteger.Zero;
				value=BigUInteger.Decrement(value);
			});
		}


		[TestMethod]
		public void OpTow() {
			var value = new BigUInteger(new byte[] { 2 });
			value--;
			ExecTest(value,new byte[] { 1 });
		}

		[TestMethod]
		public void OpOne() {
			var value = BigUInteger.One;
			value--;
			ExecTest(value,new byte[] { 0 });
		}

		[TestMethod]
		public void OpZero() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero;
				value--;
			});
		}

	}
}
