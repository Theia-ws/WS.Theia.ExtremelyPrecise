using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {
	[TestClass]
	public class IsEven:TestBase {

		[TestMethod]
		public void IsEven1_1() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).IsEven,false);
		}

		[TestMethod]
		public void IsEven2_1() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 2 },new ContainerType[] { 1 }).IsEven,true);
		}

		[TestMethod]
		public void IsEven2_2() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 2 },new ContainerType[] { 2 }).IsEven,false);
		}

		[TestMethod]
		public void IsEven4_2() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 4 },new ContainerType[] { 2 }).IsEven,true);
		}

		[TestMethod]
		public void IsEven_2_2() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 2 },new ContainerType[] { 2 }).IsEven,false);
		}

		[TestMethod]
		public void IsEven_4_2() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 4 },new ContainerType[] { 2 }).IsEven,true);
		}

		[TestMethod]
		public void IsEven22_10() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 22 },new ContainerType[] { 10 }).IsEven,false);
		}

		[TestMethod]
		public void IsEven_22_10() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 22 },new ContainerType[] { 10 }).IsEven,false);
		}

		[TestMethod]
		public void PosisitiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.IsZero,false);
		}

		[TestMethod]
		public void NegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.IsZero,false);
		}

		[TestMethod]
		public void NaN() {
			Assert.AreEqual<bool>(Rational.NaN.IsZero,false);
		}

	}
}
