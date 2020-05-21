using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class IsPowerOfTwo:TestBase {

		[TestMethod]
		public void IsPowerOfTwoF8_3() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 8 },new byte[] { 3 }).IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoT8_3() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 8 },new byte[] { 3 }).IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoF24_3() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 24 },new byte[] { 3 }).IsPowerOfTwo,true);
		}

		[TestMethod]
		public void IsPowerOfTwoT24_3() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 24 },new byte[] { 3 }).IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoF18446744073709551616_1() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0,0,0,0,0,0,0,0,1 },new byte[] { 1 }).IsPowerOfTwo,true);
		}

		[TestMethod]
		public void IsPowerOfTwoT18446744073709551616_1() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 0,0,0,0,0,0,0,0,1 },new byte[] { 1 }).IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoF18446744073709551616_2() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0,0,0,0,0,0,0,0,1 },new byte[] { 2 }).IsPowerOfTwo,true);
		}

		[TestMethod]
		public void IsPowerOfTwoT18446744073709551616_2() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 0,0,0,0,0,0,0,0,1 },new byte[] { 2 }).IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoF1_1() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 1 },new byte[] { 1 }).IsPowerOfTwo,true);
		}

		[TestMethod]
		public void IsPowerOfTwoT1_1() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 1 },new byte[] { 1 }).IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoF0_1() {
			Assert.AreEqual<bool>(Rational.Zero.IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoF0_2() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 2 }).IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoT0_1() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 0 },new byte[] { 1 }).IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoT0_2() {
			Assert.AreEqual<bool>(new Rational(true,new byte[] { 0 },new byte[] { 2 }).IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoNaN() {
			Assert.AreEqual<bool>(Rational.NaN.IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.IsPowerOfTwo,false);
		}

		[TestMethod]
		public void IsPowerOfTwoNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.IsPowerOfTwo,false);
		}

	}
}