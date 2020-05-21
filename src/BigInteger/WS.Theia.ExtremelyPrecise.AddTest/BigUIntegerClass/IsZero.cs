using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class IzZero:TestBase {

		[TestMethod]
		public void SimpleZero() {
			ExecTest(new ContainerType[] { 0 },true);
		}

		[TestMethod]
		public void NonZero() {
			ExecTest(new ContainerType[] { 1 },false);
		}

		[TestMethod]
		public void LongZero() {
			ExecTest(new ContainerType[] { 0,0,0 },true);
		}

		[TestMethod]
		public void LongNonZero() {
			ExecTest(new ContainerType[] { 0,0,ContainerType.MaxValue },false);
		}

		[TestMethod]
		public void BothLongNonZero() {
			ExecTest(new ContainerType[] { 0,0,ContainerType.MaxValue },false);
		}

		private void ExecTest(ContainerType[] value,bool result) {
			Assert.AreEqual<bool>(CreateObjectCT(value).IsZero,result);
			Assert.AreEqual<bool>(CreateObjectCT(value).IsZero,result);
		}

	}
}
