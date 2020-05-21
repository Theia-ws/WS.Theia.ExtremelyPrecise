using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class LessThanOrEqual:TestBase {
		
		[TestMethod]
		public void PlusF1_1F1_1() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 1 },new byte[] { 1 })<=new Rational(false,new byte[] { 1 },new byte[] { 2 }),false);
		}

		[TestMethod]
		public void PlusF1_FF0_1() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 1 },new byte[] { 1 })<=new Rational(false,new byte[] { 0 },new byte[] { 1 }),false);
		}

		[TestMethod]
		public void PlusF0_1T1_1() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 })<=new Rational(true,new byte[] { 1 },new byte[] { 1 }),false);
		}

		[TestMethod]
		public void PlusT0_1T1_1() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 0 },new byte[] { 1 })<=new Rational(true,new byte[] { 1 },new byte[] { 1 }),false);
		}

		[TestMethod]
		public void PlusF0_1T0_2() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 })<=new Rational(true,new byte[] { 0 },new byte[] { 2 }),false);
		}

		[TestMethod]
		public void PlusT1_2_T1_1() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 1 },new byte[] { 2 })<=new Rational(true,new byte[] { 1 },new byte[] { 1 }),false);
		}

		[TestMethod]
		public void ZeroF1_1F2_2() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 1 },new byte[] { 1 })<=new Rational(false,new byte[] { 2 },new byte[] { 2 }),true);
		}

		[TestMethod]
		public void ZeroF0_2F0_1() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 2 })<=new Rational(false,new byte[] { 0 },new byte[] { 1 }),true);
		}

		[TestMethod]
		public void ZeroT0_1T0_2() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 0 },new byte[] { 1 })<=new Rational(true,new byte[] { 0 },new byte[] { 2 }),true);
		}

		[TestMethod]
		public void ZeroT2_2T1_1() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 2 },new byte[] { 2 })<=new Rational(true,new byte[] { 1 },new byte[] { 1 }),true);
		}

		[TestMethod]
		public void MinusF1_2F1_1() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 1 },new byte[] { 2 })<=new Rational(false,new byte[] { 1 },new byte[] { 1 }),true);
		}

		[TestMethod]
		public void MinusF0_1F1_1() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 })<=new Rational(false,new byte[] { 1 },new byte[] { 1 }),true);
		}

		[TestMethod]
		public void MinusT0_1F1_1() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 0 },new byte[] { 1 })<=new Rational(false,new byte[] { 1 },new byte[] { 1 }),true);
		}

		[TestMethod]
		public void MinusT1_1T0_1() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 1 },new byte[] { 1 })<=new Rational(true,new byte[] { 0 },new byte[] { 1 }),true);
		}

		[TestMethod]
		public void MinusT0_1F0_2() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 0 },new byte[] { 1 })<=new Rational(false,new byte[] { 0 },new byte[] { 2 }),true);
		}

		[TestMethod]
		public void MinusT1_1T1_2() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 1 },new byte[] { 1 })<=new Rational(true,new byte[] { 1 },new byte[] { 2 }),true);
		}

		[TestMethod]
		public void LowAreaPlus() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 })<=CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 }),false);
		}

		[TestMethod]
		public void LowAreaZero() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 })<=CreateObjectCT(false,new ContainerType[] { 255,0 },new ContainerType[] { 1 }),true);
		}

		[TestMethod]
		public void LowAreaMinus() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 })<=CreateObjectCT(false,new ContainerType[] { 0,1 },new ContainerType[] { 1 }),true);
		}

		[TestMethod]
		public void UpperAreaPlus() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 0,1 },new ContainerType[] { 1 })<=CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 }),false);
		}

		[TestMethod]
		public void UpperAreaZero() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 255,0 },new ContainerType[] { 1 })<=CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 }),true);
		}

		[TestMethod]
		public void UpperAreaMinus() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 })<=CreateObjectCT(false,new ContainerType[] { 255 },new ContainerType[] { 1 }),true);
		}

		[TestMethod]
		public void NaNNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NaN<=Rational.NegativeInfinity,false);
		}

		[TestMethod]
		public void NegativeInfinityNaN() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity<=Rational.NaN,false);
		}

		[TestMethod]
		public void NaNNaN() {
			Assert.AreEqual<bool>(Rational.NaN<=Rational.NaN,false);
		}

		[TestMethod]
		public void PositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity<=Rational.PositiveInfinity,true);
		}

		[TestMethod]
		public void PositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity<=Rational.One,false);
		}

		[TestMethod]
		public void NonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.One<=Rational.PositiveInfinity,true);
		}

		[TestMethod]
		public void NegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity<=Rational.NegativeInfinity,true);
		}

		[TestMethod]
		public void NegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity<=Rational.One,true);
		}

		[TestMethod]
		public void NonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.One<=Rational.NegativeInfinity,false);
		}

	}
}
