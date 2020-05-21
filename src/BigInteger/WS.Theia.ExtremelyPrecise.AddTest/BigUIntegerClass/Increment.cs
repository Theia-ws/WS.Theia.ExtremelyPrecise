using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class Increment:TestBase {

		[TestMethod]
		public void Zero() {
			var value = BigUInteger.Zero;
			value=BigUInteger.Increment(value);
			ExecTest(value,new byte[] { 1 });
		}

		public void OpZero() {
			var value = BigUInteger.Zero;
			value++;
			ExecTest(value,new byte[] { 1 });
		}

	}
}
