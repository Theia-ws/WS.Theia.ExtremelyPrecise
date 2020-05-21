using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class NotEquals:TestBase {

		[TestMethod]
		public void OpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })!=CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 }),false);
		}

		[TestMethod]
		public void OpLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })!=CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 2 }),true);
		}

		[TestMethod]
		public void OpUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })!=CreateObjectCT(false,new ContainerType[] { 1,1 },new ContainerType[] { 1 }),true);
		}

		[TestMethod]
		public void OpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })!=CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 }),false);
		}

		[TestMethod]
		public void OpSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 })!=CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 }),true);
		}

		[TestMethod]
		public void OpPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity!=Rational.PositiveInfinity,false);
		}

		[TestMethod]
		public void OpPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity!=Rational.One,true);
		}

		[TestMethod]
		public void OpNonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.One!=Rational.PositiveInfinity,true);
		}

		[TestMethod]
		public void OpPositiveInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity!=Rational.NegativeInfinity,true);
		}

		[TestMethod]
		public void OpNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity!=Rational.NegativeInfinity,false);
		}

		[TestMethod]
		public void OpNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity!=Rational.One,true);
		}

		[TestMethod]
		public void OpNonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.One!=Rational.NegativeInfinity,true);
		}

		[TestMethod]
		public void OpNaNNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NaN!=Rational.NegativeInfinity,true);
		}

		[TestMethod]
		public void OpNegativeInfinityNaN() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity!=Rational.NaN,true);
		}

		[TestMethod]
		public void OpZeroMinusZero() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 })!=new Rational(true,new byte[] { 0 },new byte[] { 1 }),true);
		}

	}
}
