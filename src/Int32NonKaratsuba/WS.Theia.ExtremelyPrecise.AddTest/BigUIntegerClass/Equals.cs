using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ContainerType = System.UInt32;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class Equals:TestBase {

		[TestMethod]
		public void DecimalLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(1m),true);
		}

		[TestMethod]
		public void DecimalLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(0.5m),false);
		}

		[TestMethod]
		public void DecimalUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals((decimal)ContainerType.MaxValue+2),false);
		}

		[TestMethod]
		public void DecimalUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(1m),true);
		}

		[TestMethod]
		public void DecimalZeroMinusZero() {
			Assert.AreEqual<bool>(new BigUInteger(new byte[] { 0 }).Equals(-0m),true);
		}

		[TestMethod]
		public void DecimalOpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==1m,true);
		}

		[TestMethod]
		public void DecimalOpLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==0.5m,false);
		}

		[TestMethod]
		public void DecimalOpUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==(decimal)ContainerType.MaxValue+2,false);
		}

		[TestMethod]
		public void DecimalOpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==1m,true);
		}

		[TestMethod]
		public void DecimalOpZeroMinusZero() {
			Assert.AreEqual<bool>(new BigUInteger(new byte[] { 0 })==-0m,true);
		}

		[TestMethod]
		public void DoubleLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(1d),true);
		}

		[TestMethod]
		public void DoubleLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(0.5d),false);
		}

		[TestMethod]
		public void DoubleUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals((double)ContainerType.MaxValue+2),false);
		}

		[TestMethod]
		public void DoubleUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(1d),true);
		}

		[TestMethod]
		public void DoubleZeroMinusZero() {
			Assert.AreEqual<bool>(new BigUInteger(new byte[] { 0 }).Equals(-0d),true);
		}

		[TestMethod]
		public void DoubleOpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==1d,true);
		}

		[TestMethod]
		public void DoubleOpLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==0.5d,false);
		}

		[TestMethod]
		public void DoubleOpUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==(double)ContainerType.MaxValue+2,false);
		}

		[TestMethod]
		public void DoubleOpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==1d,true);
		}
		
		[TestMethod]
		public void DoubleOpZeroMinusZero() {
			Assert.AreEqual<bool>(new BigUInteger(new byte[] { 0 })==-0d,true);
		}

		[TestMethod]
		public void LongLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(1L),true);
		}

		[TestMethod]
		public void LongUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(1L),true);
		}

		[TestMethod]
		public void LongZeroMinusZero() {
			Assert.AreEqual<bool>(new BigUInteger(new byte[] { 0 }).Equals(-0L),true);
		}

		[TestMethod]
		public void LongOpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==1L,true);
		}

		[TestMethod]
		public void LongOpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==1L,true);
		}

		[TestMethod]
		public void LongOpZeroMinusZero() {
			Assert.AreEqual<bool>(new BigUInteger(new byte[] { 0 })==-0L,true);
		}

		[TestMethod]
		public void ObjectException() {
			object value = "";
			Assert.AreEqual<bool>(new BigUInteger(new byte[] { 1 }).Equals(value),false);
		}

		[TestMethod]
		public void ObjectLowerTrue() {
			object value = CreateObjectCT(new ContainerType[] { 1,0 });
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(value),true);
		}

		[TestMethod]
		public void ObjectLowerFalse() {
			object value = CreateObjectCT(new ContainerType[] { 1,0 });
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 2 }).Equals(value),false);
		}

		[TestMethod]
		public void ObjectUpperFalse() {
			object value = CreateObjectCT(new ContainerType[] { 1,1 });
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(value),false);
		}

		[TestMethod]
		public void ObjectNull() {
			object value = null;
			Assert.AreEqual<bool>(new BigUInteger(new byte[] { 0 }).Equals(value),false);
		}

		[TestMethod]
		public void BigUIntegerLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(CreateObjectCT(new ContainerType[] { 1,0 })),true);
		}

		[TestMethod]
		public void BigUIntegerLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 2 }).Equals(CreateObjectCT(new ContainerType[] { 1,0 })),false);
		}

		[TestMethod]
		public void BigUIntegerUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(CreateObjectCT(new ContainerType[] { 1,1 })),false);
		}

		[TestMethod]
		public void UlongLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(1UL),true);
		}

		[TestMethod]
		public void UlongUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 }).Equals(1UL),true);
		}

		[TestMethod]
		public void UlongOpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==1UL,true);
		}

		[TestMethod]
		public void UlongOpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==1UL,true);
		}

		[TestMethod]
		public void LowerTrue() {
			Assert.AreEqual<bool>(BigUInteger.Equals(CreateObjectCT(new ContainerType[] { 1 }),CreateObjectCT(new ContainerType[] { 1,0 })),true);
		}

		[TestMethod]
		public void LowerFalse() {
			Assert.AreEqual<bool>(BigUInteger.Equals(CreateObjectCT(new ContainerType[] { 2 }),CreateObjectCT(new ContainerType[] { 1,0 })),false);
		}

		[TestMethod]
		public void OpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==CreateObjectCT(new ContainerType[] { 1,0 }),true);
		}

		[TestMethod]
		public void OpLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==CreateObjectCT(new ContainerType[] { 2,0 }),false);
		}

		[TestMethod]
		public void OpUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 1 })==CreateObjectCT(new ContainerType[] { 1,1 }),false);
		}

		[TestMethod]
		public void OpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(new ContainerType[] { 2 })==CreateObjectCT(new ContainerType[] { 2,0 }),true);
		}

	}
}
