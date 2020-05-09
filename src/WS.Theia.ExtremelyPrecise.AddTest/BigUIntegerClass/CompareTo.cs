using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class CompareTo:TestBase {
		//TODO:全面書き換え
		/*
		[TestMethod]
		public void DecimalPlusF1_1F0_5() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(0.5m),1);
		}

		[TestMethod]
		public void DecimalPlusF1_1F0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(0m),1);
		}

		[TestMethod]
		public void DecimalPlusF0_1T1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(-1m),1);
		}

		[TestMethod]
		public void DecimalPlusT0_1T1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(-1m),1);
		}

		[TestMethod]
		public void DecimalPlusT1_2T1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 },new byte[] { 2 }).CompareTo(-1m),1);
		}

		[TestMethod]
		public void DecimalZeroF1_1F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(1m),0);
		}

		[TestMethod]
		public void DecimalZeroF0_2F0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 },new byte[] { 2 }).CompareTo(0m),0);
		}

		[TestMethod]
		public void DecimalZeroF0_1T0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(-0m),0);
		}

		[TestMethod]
		public void DecimalZeroT2_2_T1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 2 },new byte[] { 2 }).CompareTo(-1m),0);
		}

		[TestMethod]
		public void DecimalMinusT0_1T0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(-0m),-1);
		}

		[TestMethod]
		public void DecimalMinusF1_2F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 },new byte[] { 2 }).CompareTo(1m),-1);
		}

		[TestMethod]
		public void DecimalMinusF0_1F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(1m),-1);
		}

		[TestMethod]
		public void DecimalMinusT0_1F1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(1m),-1);
		}

		[TestMethod]
		public void DecimalMinusT1_1T0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 }).CompareTo(-0m),-1);
		}

		[TestMethod]
		public void DecimalMinusT0_1F0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(0m),-1);
		}

		[TestMethod]
		public void DecimalMinusT1_1T0_5() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 }).CompareTo(-0.5m),-1);
		}

		[TestMethod]
		public void DoublePlusF1_1F0_5() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(0.5d),1);
		}

		[TestMethod]
		public void DoublePlusF1_1F0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(0d),1);
		}

		[TestMethod]
		public void DoublePlusF0_1T1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(-1d),1);
		}

		[TestMethod]
		public void DoublePlusT0_1T1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(-1d),1);
		}

		[TestMethod]
		public void DoublePlusT1_2T1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 },new byte[] { 2 }).CompareTo(-1d),1);
		}

		[TestMethod]
		public void DoubleZeroF1_1F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(1d),0);
		}

		[TestMethod]
		public void DoubleZeroF0_2F0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 },new byte[] { 2 }).CompareTo(0d),0);
		}

		[TestMethod]
		public void DoubleZeroF0_1T0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(-0d),0);
		}

		[TestMethod]
		public void DoubleZeroT2_2_T1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 2 },new byte[] { 2 }).CompareTo(-1d),0);
		}

		[TestMethod]
		public void DoubleMinusT0_1T0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(-0d),-1);
		}

		[TestMethod]
		public void DoubleMinusF1_2F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 },new byte[] { 2 }).CompareTo(1d),-1);
		}

		[TestMethod]
		public void DoubleMinusF0_1F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(1d),-1);
		}

		[TestMethod]
		public void DoubleMinusT0_1F1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(1d),-1);
		}

		[TestMethod]
		public void DoubleMinusT1_1T0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 }).CompareTo(-0d),-1);
		}

		[TestMethod]
		public void DoubleMinusT0_1F0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(0d),-1);
		}

		[TestMethod]
		public void DoubleMinusT1_1T0_5() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 }).CompareTo(-0.5d),-1);
		}

		[TestMethod]
		public void LongPlusF1_1F0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(0L),1);
		}

		[TestMethod]
		public void LongPlusF0_1T1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(-1L),1);
		}

		[TestMethod]
		public void LongPlusT0_1T1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(-1L),1);
		}

		[TestMethod]
		public void LongPlusT1_2T1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 },new byte[] { 2 }).CompareTo(-1L),1);
		}

		[TestMethod]
		public void LongZeroF1_1F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(1L),0);
		}

		[TestMethod]
		public void LongZeroF0_2F0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 },new byte[] { 2 }).CompareTo(0L),0);
		}

		[TestMethod]
		public void LongZeroF0_1T0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(-0L),0);
		}

		[TestMethod]
		public void LongZeroT2_2_T1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 2 },new byte[] { 2 }).CompareTo(-1L),0);
		}

		[TestMethod]
		public void LongMinusT0_1T0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(-0L),-1);
		}

		[TestMethod]
		public void LongMinusF1_2F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 },new byte[] { 2 }).CompareTo(1L),-1);
		}

		[TestMethod]
		public void LongMinusF0_1F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(1L),-1);
		}

		[TestMethod]
		public void LongMinusT0_1F1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(1L),-1);
		}

		[TestMethod]
		public void LongMinusT1_1T0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 }).CompareTo(-0L),-1);
		}

		[TestMethod]
		public void LongMinusT0_1F0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(0L),-1);
		}

		[TestMethod]
		public void ObjectException() {
			object value = "";
			Assert.ThrowsException<ArgumentException>(()=> {
				new BigUInteger(new byte[] { 1 }).CompareTo(value);
			});
		}

		[TestMethod]
		public void ObjectPlusF1_1F1_1() {
			object value = new BigUInteger(new byte[] { 1 },new byte[] { 2 });
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(value),1);
		}

		[TestMethod]
		public void ObjectPlusF1_FF0_1() {
			object value = new BigUInteger(new byte[] { 0 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(value),1);
		}

		[TestMethod]
		public void ObjectPlusF0_1T1_1() {
			object value = new BigUInteger(true,new byte[] { 1 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(value),1);
		}

		[TestMethod]
		public void ObjectPlusT0_1T1_1() {
			object value = new BigUInteger(true,new byte[] { 1 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(value),1);
		}

		[TestMethod]
		public void ObjectPlusF0_1T0_2() {
			object value = new BigUInteger(true,new byte[] { 0 },new byte[] { 2 });
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(value),1);
		}

		[TestMethod]
		public void ObjectPlusT1_2_T1_1() {
			object value = new BigUInteger(true,new byte[] { 1 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 },new byte[] { 2 }).CompareTo(value),1);
		}

		[TestMethod]
		public void ObjectZeroF1_1F2_2() {
			object value = new BigUInteger(new byte[] { 2 },new byte[] { 2 });
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(value),0);
		}

		[TestMethod]
		public void ObjectZeroF0_2F0_1() {
			object value = new BigUInteger(new byte[] { 0 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 },new byte[] { 2 }).CompareTo(value),0);
		}

		[TestMethod]
		public void ObjectZeroT0_1T0_2() {
			object value = new BigUInteger(true,new byte[] { 0 },new byte[] { 2 });
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(value),0);
		}

		[TestMethod]
		public void ObjectZeroT2_2T1_1() {
			object value = new BigUInteger(true,new byte[] { 1 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 2 },new byte[] { 2 }).CompareTo(value),0);
		}

		[TestMethod]
		public void ObjectMinusF1_2F1_1() {
			object value = new BigUInteger(new byte[] { 1 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 },new byte[] { 2 }).CompareTo(value),-1);
		}

		[TestMethod]
		public void ObjectMinusF0_1F1_1() {
			object value = new BigUInteger(new byte[] { 1 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(value),-1);
		}

		[TestMethod]
		public void ObjectMinusT0_1F1_1() {
			object value = new BigUInteger(new byte[] { 1 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(value),-1);
		}

		[TestMethod]
		public void ObjectMinusT1_1T0_1() {
			object value = new BigUInteger(true,new byte[] { 0 },new byte[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 }).CompareTo(value),-1);
		}

		[TestMethod]
		public void ObjectMinusT0_1F0_2() {
			object value = new BigUInteger(new byte[] { 0 },new byte[] { 2 });
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(value),-1);
		}

		[TestMethod]
		public void ObjectMinusT1_1T1_2() {
			object value = new BigUInteger(true,new byte[] { 1 },new byte[] { 2 });
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 }).CompareTo(value),-1);
		}

		[TestMethod]
		public void ObjectLowAreaPlus() {
			object value = new BigUInteger(new ContainerType[] { 1,0 },new ContainerType[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 }).CompareTo(value),1);
		}

		[TestMethod]
		public void ObjectLowAreaZero() {
			object value = new BigUInteger(new ContainerType[] { 255,0 },new ContainerType[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 }).CompareTo(value),0);
		}

		[TestMethod]
		public void ObjectLowAreaMinus() {
			object value = new BigUInteger(new ContainerType[] { 0,1 },new ContainerType[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 }).CompareTo(value),-1);
		}

		[TestMethod]
		public void ObjectUpperAreaPlus() {
			object value = new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 0,1 },new ContainerType[] { 1 }).CompareTo(value),1);
		}

		[TestMethod]
		public void ObjectUpperAreaZero() {
			object value = new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 255,0 },new ContainerType[] { 1 }).CompareTo(value),0);
		}

		[TestMethod]
		public void ObjectUpperAreaMinus() {
			object value = new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 });
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 1,0 },new ContainerType[] { 1 }).CompareTo(value),-1);
		}

		[TestMethod]
		public void ObjectNull() {
			object value = null;
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 1,0 },new ContainerType[] { 1 }).CompareTo(value),1);
		}

		[TestMethod]
		public void UlongPlusF1_1F0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(0UL),1);
		}

		[TestMethod]
		public void UlongZeroF1_1F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(1UL),0);
		}

		[TestMethod]
		public void UlongZeroF0_2F0() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 },new byte[] { 2 }).CompareTo(0UL),0);
		}

		[TestMethod]
		public void UlongMinusF1_2F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 },new byte[] { 2 }).CompareTo(1UL),-1);
		}

		[TestMethod]
		public void UlongMinusF0_1F1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(1UL),-1);
		}

		[TestMethod]
		public void UlongMinusT0_1F1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(1UL),-1);
		}

		[TestMethod]
		public void UlongMinusT0_1F0() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(0UL),-1);
		}

		[TestMethod]
		public void PlusF1_1F1_1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(new BigUInteger(new byte[] { 1 },new byte[] { 2 })),1);
		}

		[TestMethod]
		public void PlusF1_FF0_1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(new BigUInteger(new byte[] { 0 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void PlusF0_1T1_1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(new BigUInteger(true,new byte[] { 1 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void PlusT0_1T1_1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(new BigUInteger(true,new byte[] { 1 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void PlusF0_1T0_2() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(new BigUInteger(true,new byte[] { 0 },new byte[] { 2 })),1);
		}

		[TestMethod]
		public void PlusT1_2_T1_1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 },new byte[] { 2 }).CompareTo(new BigUInteger(true,new byte[] { 1 },new byte[] { 1 })),1);
		}

		[TestMethod]
		public void ZeroF1_1F2_2() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 }).CompareTo(new BigUInteger(new byte[] { 2 },new byte[] { 2 })),0);
		}

		[TestMethod]
		public void ZeroF0_2F0_1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 },new byte[] { 2 }).CompareTo(new BigUInteger(new byte[] { 0 },new byte[] { 1 })),0);
		}

		[TestMethod]
		public void ZeroT0_1T0_2() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(new BigUInteger(true,new byte[] { 0 },new byte[] { 2 })),0);
		}

		[TestMethod]
		public void ZeroT2_2T1_1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 2 },new byte[] { 2 }).CompareTo(new BigUInteger(true,new byte[] { 1 },new byte[] { 1 })),0);
		}

		[TestMethod]
		public void MinusF1_2F1_1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 1 },new byte[] { 2 }).CompareTo(new BigUInteger(new byte[] { 1 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusF0_1F1_1() {
			Assert.AreEqual<int>(new BigUInteger(new byte[] { 0 }).CompareTo(new BigUInteger(new byte[] { 1 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusT0_1F1_1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(new BigUInteger(new byte[] { 1 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusT1_1T0_1() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 }).CompareTo(new BigUInteger(true,new byte[] { 0 },new byte[] { 1 })),-1);
		}

		[TestMethod]
		public void MinusT0_1F0_2() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 0 }).CompareTo(new BigUInteger(new byte[] { 0 },new byte[] { 2 })),-1);
		}

		[TestMethod]
		public void MinusT1_1T1_2() {
			Assert.AreEqual<int>(new BigUInteger(true,new byte[] { 1 }).CompareTo(new BigUInteger(true,new byte[] { 1 },new byte[] { 2 })),-1);
		}

		[TestMethod]
		public void LowAreaPlus() {
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 }).CompareTo(new BigUInteger(new ContainerType[] { 1,0 },new ContainerType[] { 1 })),1);
		}

		[TestMethod]
		public void LowAreaZero() {
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 }).CompareTo(new BigUInteger(new ContainerType[] { 255,0 },new ContainerType[] { 1 })),0);
		}

		[TestMethod]
		public void LowAreaMinus() {
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 }).CompareTo(new BigUInteger(new ContainerType[] { 0,1 },new ContainerType[] { 1 })),-1);
		}

		[TestMethod]
		public void UpperAreaPlus() {
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 0,1 },new ContainerType[] { 1 }).CompareTo(new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 })),1);
		}

		[TestMethod]
		public void UpperAreaZero() {
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 255,0 },new ContainerType[] { 1 }).CompareTo(new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 })),0);
		}

		[TestMethod]
		public void UpperAreaMinus() {
			Assert.AreEqual<int>(new BigUInteger(new ContainerType[] { 1,0 },new ContainerType[] { 1 }).CompareTo(new BigUInteger(new ContainerType[] { 255 },new ContainerType[] { 1 })),-1);
		}

		[TestMethod]
		public void NaNNegativeInfinity() {
			Assert.AreEqual<int>(BigUInteger.NaN.CompareTo(BigUInteger.NegativeInfinity),-1);
		}

		[TestMethod]
		public void NegativeInfinityNaN() {
			Assert.AreEqual<int>(BigUInteger.NegativeInfinity.CompareTo(BigUInteger.NaN),1);
		}

		[TestMethod]
		public void NaNNaN() {
			Assert.AreEqual<int>(BigUInteger.NaN.CompareTo(BigUInteger.NaN),0);
		}

		[TestMethod]
		public void PositiveInfinityPositiveInfinity() {
			Assert.AreEqual<int>(BigUInteger.PositiveInfinity.CompareTo(BigUInteger.PositiveInfinity),0);
		}

		[TestMethod]
		public void PositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<int>(BigUInteger.PositiveInfinity.CompareTo(BigUInteger.One),1);
		}

		[TestMethod]
		public void NonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<int>(BigUInteger.One.CompareTo(BigUInteger.PositiveInfinity),-1);
		}

		[TestMethod]
		public void NegativeInfinityNegativeInfinity() {
			Assert.AreEqual<int>(BigUInteger.NegativeInfinity.CompareTo(BigUInteger.NegativeInfinity),0);
		}

		[TestMethod]
		public void NegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<int>(BigUInteger.NegativeInfinity.CompareTo(BigUInteger.One),-1);
		}

		[TestMethod]
		public void NonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<int>(BigUInteger.One.CompareTo(BigUInteger.NegativeInfinity),1);
		}
		*/
	}
}
