using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt32;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {
	[TestClass]
	public class IsEven:TestBase {

		[TestMethod]
		public void IsEven1() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).IsEven,false);
		}

		[TestMethod]
		public void IsEven2() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 2 }).IsEven,true);
		}

		[TestMethod]
		public void IsEven4() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 4 }).IsEven,true);
		}

		[TestMethod]
		public void TopIsEven() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1,4,0 }).IsEven,false);
		}

		[TestMethod]
		public void LowIsEven() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 2,5,0 }).IsEven,true);
		}

		[TestMethod]
		public void MothIsEven() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 2,4,0 }).IsEven,true);
		}

	}
}
