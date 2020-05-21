using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt32;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class Compare:TestBase {

		[TestMethod]
		public void PlusF1_1F1_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(false,new byte[] { 1 },new byte[] { 1 }),new Rational(false,new byte[] { 1 },new byte[] { 2 })),1);
		}

		[TestMethod]
		public void PlusF1_FF0_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(false,new byte[] { 1 },new byte[] { 1 }),new Rational(false,new byte[] { 0 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void PlusF0_1T1_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(false,new byte[] { 0 },new byte[] { 1 }),new Rational(true,new byte[] { 1 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void PlusT0_1T1_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(true,new byte[] { 0 },new byte[] { 1 }),new Rational(true,new byte[] { 1 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void PlusF0_1T0_2() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(false,new byte[] { 0 },new byte[] { 1 }),new Rational(true,new byte[] { 0 },new byte[] { 2 })),1);
		}

		[TestMethod]
		public void PlusT1_2_T1_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(true,new byte[] { 1 },new byte[] { 2 }),new Rational(true,new byte[] { 1 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void ZeroF1_1F2_2() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(false,new byte[] { 1 },new byte[] { 1 }),new Rational(false,new byte[] { 2 },new byte[] { 2 })),0);
		}

		[TestMethod]
		public void ZeroF0_2F0_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(false,new byte[] { 0 },new byte[] { 2 }),new Rational(false,new byte[] { 0 },new byte[] { 1 })),0);
		}

		[TestMethod]
		public void ZeroT0_1T0_2() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(true,new byte[] { 0 },new byte[] { 1 }),new Rational(true,new byte[] { 0 },new byte[] { 2 })),0);
		}

		[TestMethod]
		public void ZeroT2_2T1_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(true,new byte[] { 2 },new byte[] { 2 }),new Rational(true,new byte[] { 1 },new byte[] { 1 })),0);
		}

		[TestMethod]
		public void MinusF1_2F1_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(false,new byte[] { 1 },new byte[] { 2 }),new Rational(false,new byte[] { 1 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusF0_1F1_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(false,new byte[] { 0 },new byte[] { 1 }),new Rational(false,new byte[] { 1 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusT0_1F1_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(true,new byte[] { 0 },new byte[] { 1 }),new Rational(false,new byte[] { 1 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusT1_1T0_1() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(true,new byte[] { 1 },new byte[] { 1 }),new Rational(true,new byte[] { 0 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusT0_1F0_2() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(true,new byte[] { 0 },new byte[] { 1 }),new Rational(false,new byte[] { 0 },new byte[] { 2 })),-1);
		}

		[TestMethod]
		public void MinusT1_1T1_2() {
			Assert.AreEqual<int>(Rational.Compare(new Rational(true,new byte[] { 1 },new byte[] { 1 }),new Rational(true,new byte[] { 1 },new byte[] { 2 })),-1);
		}

		[TestMethod]
		public void LowAreaPlus() {
			Assert.AreEqual<int>(Rational.Compare(CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 })),1);
		}

		[TestMethod]
		public void LowAreaZero() {
			Assert.AreEqual<int>(Rational.Compare(CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 255,0 },new ContainerType[] { 1 })),0);
		}

		[TestMethod]
		public void LowAreaMinus() {
			Assert.AreEqual<int>(Rational.Compare(CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 0,1 },new ContainerType[] { 1 })),-1);
		}

		[TestMethod]
		public void UpperAreaPlus() {
			Assert.AreEqual<int>(Rational.Compare(CreateObjectCT(false,new ContainerType[] { 0,1 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 })),1);
		}

		[TestMethod]
		public void UpperAreaZero() {
			Assert.AreEqual<int>(Rational.Compare(CreateObjectCT(false,new ContainerType[] { 255,0 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 })),0);
		}

		[TestMethod]
		public void UpperAreaMinus() {
			Assert.AreEqual<int>(Rational.Compare(CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 })),-1);
		}

		[TestMethod]
		public void NaNNegativeInfinity() {
			Assert.AreEqual<int>(Rational.Compare(Rational.NaN,Rational.NegativeInfinity),-1);
		}

		[TestMethod]
		public void NegativeInfinityNaN() {
			Assert.AreEqual<int>(Rational.Compare(Rational.NegativeInfinity,Rational.NaN),1);
		}

		[TestMethod]
		public void NaNNaN() {
			Assert.AreEqual<int>(Rational.Compare(Rational.NaN,Rational.NaN),0);
		}

		[TestMethod]
		public void PositiveInfinityPositiveInfinity() {
			Assert.AreEqual<int>(Rational.Compare(Rational.PositiveInfinity,Rational.PositiveInfinity),0);
		}

		[TestMethod]
		public void PositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<int>(Rational.Compare(Rational.PositiveInfinity,Rational.One),1);
		}

		[TestMethod]
		public void NonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<int>(Rational.Compare(Rational.One,Rational.PositiveInfinity),-1);
		}

		[TestMethod]
		public void NegativeInfinityNegativeInfinity() {
			Assert.AreEqual<int>(Rational.Compare(Rational.NegativeInfinity,Rational.NegativeInfinity),0);
		}

		[TestMethod]
		public void NegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<int>(Rational.Compare(Rational.NegativeInfinity,Rational.One),-1);
		}

		[TestMethod]
		public void NonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<int>(Rational.Compare(Rational.One,Rational.NegativeInfinity),1);
		}

	}
}