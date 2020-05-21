using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt32;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {
	[TestClass]
	public class IsOne:TestBase {

		[TestMethod]
		public void IsOneEqualLength1() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { ContainerType.MaxValue,7,5 },new ContainerType[] { ContainerType.MaxValue,7,5 }).IsOne,true);
		}

		[TestMethod]
		public void IsOneEqualLength2() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { ContainerType.MaxValue,7,5 },new ContainerType[] { ContainerType.MaxValue-1,7,5 }).IsOne,false);
		}

		[TestMethod]
		public void IsOneEqualLegth_1() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { ContainerType.MaxValue,7,5 },new ContainerType[] { ContainerType.MaxValue,7,5 }).IsOne,false);
		}

		[TestMethod]
		public void IsOneEqualLength_2() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { ContainerType.MaxValue,7,5 },new ContainerType[] { ContainerType.MaxValue-1,7,5 }).IsOne,false);
		}

		[TestMethod]
		public void IsOneNumuratorLong1() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { ContainerType.MaxValue,7,5,0,0},new ContainerType[] { ContainerType.MaxValue,7,5 }).IsOne,true);
		}

		[TestMethod]
		public void IsOneNumuratorLong2() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { ContainerType.MaxValue,7,5,1,0 },new ContainerType[] { ContainerType.MaxValue,7,5 }).IsOne,false);
		}

		[TestMethod]
		public void IsOneNumuratorLong_1() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { ContainerType.MaxValue,7,5,0,0 },new ContainerType[] { ContainerType.MaxValue,7,5 }).IsOne,false);
		}

		[TestMethod]
		public void IsOneNumuratorLong_2() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { ContainerType.MaxValue,7,5,1,0 },new ContainerType[] { ContainerType.MaxValue,7,5 }).IsOne,false);
		}

		[TestMethod]
		public void IsOneDenominatorLong1() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { ContainerType.MaxValue,7,5 },new ContainerType[] { ContainerType.MaxValue,7,5,0,0 }).IsOne,true);
		}

		[TestMethod]
		public void IsOneDenominatorLong2() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { ContainerType.MaxValue,7,5 },new ContainerType[] { ContainerType.MaxValue,7,5,1,0 }).IsOne,false);
		}

		[TestMethod]
		public void IsOneDenominatorLong_1() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { ContainerType.MaxValue,7,5 },new ContainerType[] { ContainerType.MaxValue,7,5,0,0 }).IsOne,false);
		}

		[TestMethod]
		public void IsDenominatorLong_2() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { ContainerType.MaxValue,7,5 },new ContainerType[] { ContainerType.MaxValue,7,5,1,0 }).IsOne,false);
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
