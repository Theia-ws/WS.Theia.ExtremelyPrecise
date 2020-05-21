using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt32;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class NotEquals:TestBase {

		[TestMethod]
		public void OpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })!=CreateObjectCT(new ContainerType[] { 1,0 }),false);
		}

		[TestMethod]
		public void OpLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })!=CreateObjectCT(new ContainerType[] { 2,0 }),true);
		}

		[TestMethod]
		public void OpUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })!=CreateObjectCT(new ContainerType[] { 1,1 }),true);
		}

		[TestMethod]
		public void OpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })!=CreateObjectCT(new ContainerType[] { 1,0 }),false);
		}

	}
}
