using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt32;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {
	[TestClass]
	public class IsOne:TestBase {

		[TestMethod]
		public void IsOneEqualLength1() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).IsOne,true);
		}

		[TestMethod]
		public void IsOneEqualLength2() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 0 }).IsOne,false);
		}

		[TestMethod]
		public void IsOneNumuratorLong1() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1,0,0 }).IsOne,true);
		}

		[TestMethod]
		public void IsOneNumuratorLong2() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 0,0,0 }).IsOne,false);
		}

	}
}
