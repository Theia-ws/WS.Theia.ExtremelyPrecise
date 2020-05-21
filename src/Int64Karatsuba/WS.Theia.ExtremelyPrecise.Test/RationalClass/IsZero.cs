using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class IzZero:TestBase {

		[TestMethod]
		public void SimpleZero() {
			ExecTest(new ContainerType[] { 0 },new ContainerType[] { 1 },true);
		}

		[TestMethod]
		public void SimpleNonZero() {
			ExecTest(new ContainerType[] { 1 },new ContainerType[] { 1 },false);
		}

		[TestMethod]
		public void NamuratorLongZero() {
			ExecTest(new ContainerType[] { 0,0,0 },new ContainerType[] { 1 },true);
		}

		[TestMethod]
		public void NamuratorLongNonZero() {
			ExecTest(new ContainerType[] { 0,0,ContainerType.MaxValue },new ContainerType[] { 1 },false);
		}

		[TestMethod]
		public void DenominatorLongZero() {
			ExecTest(new ContainerType[] { 0 },new ContainerType[] { 0,0,0,ContainerType.MaxValue },true);
		}

		[TestMethod]
		public void DenominatorLongNonZero() {
			ExecTest(new ContainerType[] { 1 },new ContainerType[] { 0,0,0,ContainerType.MaxValue },false);
		}

		[TestMethod]
		public void BothLongZero() {
			ExecTest(new ContainerType[] { 0,0,0 },new ContainerType[] { 0,0,0,ContainerType.MaxValue },true);
		}

		[TestMethod]
		public void BothLongNonZero() {
			ExecTest(new ContainerType[] { 0,0,ContainerType.MaxValue },new ContainerType[] { 0,0,0,ContainerType.MaxValue },false);
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

		private void ExecTest(ContainerType[] numurator,ContainerType[] denominator,bool result) {
			Assert.AreEqual<bool>(CreateObjectCT(false,numurator,denominator).IsZero,result);
			Assert.AreEqual<bool>(CreateObjectCT(true,numurator,denominator).IsZero,result);
		}

	}
}
