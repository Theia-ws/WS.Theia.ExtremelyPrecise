using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class Compare:TestBase {
		//TODO:全面書き換え
		/*
		[TestMethod]
		public void PlusF1_1F1_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new byte[] { 1 },new byte[] { 1 }),new BigUInteger(false,new byte[] { 1 },new byte[] { 2 })),1);
		}

		[TestMethod]
		public void PlusF1_FF0_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new byte[] { 1 },new byte[] { 1 }),new BigUInteger(false,new byte[] { 0 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void PlusF0_1T1_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new byte[] { 0 },new byte[] { 1 }),new BigUInteger(true,new byte[] { 1 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void PlusT0_1T1_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(true,new byte[] { 0 },new byte[] { 1 }),new BigUInteger(true,new byte[] { 1 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void PlusF0_1T0_2() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new byte[] { 0 },new byte[] { 1 }),new BigUInteger(true,new byte[] { 0 },new byte[] { 2 })),1);
		}

		[TestMethod]
		public void PlusT1_2_T1_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(true,new byte[] { 1 },new byte[] { 2 }),new BigUInteger(true,new byte[] { 1 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void ZeroF1_1F2_2() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new byte[] { 1 },new byte[] { 1 }),new BigUInteger(false,new byte[] { 2 },new byte[] { 2 })),0);
		}

		[TestMethod]
		public void ZeroF0_2F0_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new byte[] { 0 },new byte[] { 2 }),new BigUInteger(false,new byte[] { 0 },new byte[] { 1 })),0);
		}

		[TestMethod]
		public void ZeroT0_1T0_2() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(true,new byte[] { 0 },new byte[] { 1 }),new BigUInteger(true,new byte[] { 0 },new byte[] { 2 })),0);
		}

		[TestMethod]
		public void ZeroT2_2T1_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(true,new byte[] { 2 },new byte[] { 2 }),new BigUInteger(true,new byte[] { 1 },new byte[] { 1 })),0);
		}

		[TestMethod]
		public void MinusF1_2F1_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new byte[] { 1 },new byte[] { 2 }),new BigUInteger(false,new byte[] { 1 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusF0_1F1_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new byte[] { 0 },new byte[] { 1 }),new BigUInteger(false,new byte[] { 1 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusT0_1F1_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(true,new byte[] { 0 },new byte[] { 1 }),new BigUInteger(false,new byte[] { 1 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusT1_1T0_1() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(true,new byte[] { 1 },new byte[] { 1 }),new BigUInteger(true,new byte[] { 0 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusT0_1F0_2() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(true,new byte[] { 0 },new byte[] { 1 }),new BigUInteger(false,new byte[] { 0 },new byte[] { 2 })),-1);
		}

		[TestMethod]
		public void MinusT1_1T1_2() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(true,new byte[] { 1 },new byte[] { 1 }),new BigUInteger(true,new byte[] { 1 },new byte[] { 2 })),-1);
		}

		[TestMethod]
		public void LowAreaPlus() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new ContainerType[] { 255 },new ContainerType[] { 1 }),new BigUInteger(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 })),1);
		}

		[TestMethod]
		public void LowAreaZero() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new ContainerType[] { 255 },new ContainerType[] { 1 }),new BigUInteger(false,new ContainerType[] { 255,0 },new ContainerType[] { 1 })),0);
		}

		[TestMethod]
		public void LowAreaMinus() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new ContainerType[] { 255 },new ContainerType[] { 1 }),new BigUInteger(false,new ContainerType[] { 0,1 },new ContainerType[] { 1 })),-1);
		}

		[TestMethod]
		public void UpperAreaPlus() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new ContainerType[] { 0,1 },new ContainerType[] { 1 }),new BigUInteger(false,new ContainerType[] { 255 },new ContainerType[] { 1 })),1);
		}

		[TestMethod]
		public void UpperAreaZero() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new ContainerType[] { 255,0 },new ContainerType[] { 1 }),new BigUInteger(false,new ContainerType[] { 255 },new ContainerType[] { 1 })),0);
		}

		[TestMethod]
		public void UpperAreaMinus() {
			Assert.AreEqual<int>(BigUInteger.Compare(new BigUInteger(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 }),new BigUInteger(false,new ContainerType[] { 255 },new ContainerType[] { 1 })),-1);
		}

		[TestMethod]
		public void NaNNegativeInfinity() {
			Assert.AreEqual<int>(BigUInteger.Compare(BigUInteger.NaN,BigUInteger.NegativeInfinity),-1);
		}

		[TestMethod]
		public void NegativeInfinityNaN() {
			Assert.AreEqual<int>(BigUInteger.Compare(BigUInteger.NegativeInfinity,BigUInteger.NaN),1);
		}

		[TestMethod]
		public void NaNNaN() {
			Assert.AreEqual<int>(BigUInteger.Compare(BigUInteger.NaN,BigUInteger.NaN),0);
		}

		[TestMethod]
		public void PositiveInfinityPositiveInfinity() {
			Assert.AreEqual<int>(BigUInteger.Compare(BigUInteger.PositiveInfinity,BigUInteger.PositiveInfinity),0);
		}

		[TestMethod]
		public void PositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<int>(BigUInteger.Compare(BigUInteger.PositiveInfinity,BigUInteger.One),1);
		}

		[TestMethod]
		public void NonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<int>(BigUInteger.Compare(BigUInteger.One,BigUInteger.PositiveInfinity),-1);
		}

		[TestMethod]
		public void NegativeInfinityNegativeInfinity() {
			Assert.AreEqual<int>(BigUInteger.Compare(BigUInteger.NegativeInfinity,BigUInteger.NegativeInfinity),0);
		}

		[TestMethod]
		public void NegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<int>(BigUInteger.Compare(BigUInteger.NegativeInfinity,BigUInteger.One),-1);
		}

		[TestMethod]
		public void NonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<int>(BigUInteger.Compare(BigUInteger.One,BigUInteger.NegativeInfinity),1);
		}
		*/
	}
}