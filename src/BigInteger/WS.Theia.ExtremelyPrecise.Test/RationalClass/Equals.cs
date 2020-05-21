using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class Equals:TestBase {

		[TestMethod]
		public void DecimalLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1m),true);
		}

		[TestMethod]
		public void DecimalLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(0.5m),false);
		}

		[TestMethod]
		public void DecimalUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals((decimal)ContainerType.MaxValue+2),false);
		}

		[TestMethod]
		public void DecimalUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1m),true);
		}

		[TestMethod]
		public void DecimalSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1m),false);
		}

		[TestMethod]
		public void DecimalPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(1m),false);
		}

		[TestMethod]
		public void DecimalNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(1m),false);
		}

		[TestMethod]
		public void DecimalZeroMinusZero() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 }).Equals(-0m),true);
		}

		[TestMethod]
		public void DecimalOpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==1m,true);
		}

		[TestMethod]
		public void DecimalOpLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==0.5m,false);
		}

		[TestMethod]
		public void DecimalOpUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==(decimal)ContainerType.MaxValue+2,false);
		}

		[TestMethod]
		public void DecimalOpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==1m,true);
		}

		[TestMethod]
		public void DecimalOpSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 })==1m,false);
		}

		[TestMethod]
		public void DecimalOpPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity==1m,false);
		}

		[TestMethod]
		public void DecimalOpNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity==1m,false);
		}

		[TestMethod]
		public void DecimalOpZeroMinusZero() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 })==-0m,true);
		}

		[TestMethod]
		public void DoubleLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1d),true);
		}

		[TestMethod]
		public void DoubleLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(0.5d),false);
		}

		[TestMethod]
		public void DoubleUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals((double)ContainerType.MaxValue+2),false);
		}

		[TestMethod]
		public void DoubleUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1d),true);
		}

		[TestMethod]
		public void DoubleSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1d),false);
		}

		[TestMethod]
		public void DoublePositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(double.PositiveInfinity),true);
		}

		[TestMethod]
		public void DoublePositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(1d),false);
		}

		[TestMethod]
		public void DoubleNonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.One.Equals(double.PositiveInfinity),false);
		}

		[TestMethod]
		public void DoublePositiveInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(double.NegativeInfinity),false);
		}

		[TestMethod]
		public void DoubleNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(double.NegativeInfinity),true);
		}

		[TestMethod]
		public void DoubleNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(1d),false);
		}

		[TestMethod]
		public void DoubleNonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.One.Equals(double.NegativeInfinity),false);
		}

		[TestMethod]
		public void DoubleNaNNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NaN.Equals(double.NegativeInfinity),false);
		}

		[TestMethod]
		public void DoubleNegativeInfinityNaN() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(double.NaN),false);
		}

		[TestMethod]
		public void DoubleZeroMinusZero() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 }).Equals(-0d),true);
		}

		[TestMethod]
		public void DoubleOpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==1d,true);
		}

		[TestMethod]
		public void DoubleOpLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==0.5d,false);
		}

		[TestMethod]
		public void DoubleOpUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==(double)ContainerType.MaxValue+2,false);
		}

		[TestMethod]
		public void DoubleOpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==1d,true);
		}

		[TestMethod]
		public void DoubleOpSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 })==1d,false);
		}

		[TestMethod]
		public void DoubleOpPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity==double.PositiveInfinity,true);
		}

		[TestMethod]
		public void DoubleOpPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity==1d,false);
		}

		[TestMethod]
		public void DoubleOpNonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.One==double.PositiveInfinity,false);
		}

		[TestMethod]
		public void DoubleOpPositiveInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity==double.NegativeInfinity,false);
		}

		[TestMethod]
		public void DoubleOpNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity==double.NegativeInfinity,true);
		}

		[TestMethod]
		public void DoubleOpNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity==1d,false);
		}

		[TestMethod]
		public void DoubleOpNonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.One==double.NegativeInfinity,false);
		}

		[TestMethod]
		public void DoubleOpNaNNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NaN==double.NegativeInfinity,false);
		}

		[TestMethod]
		public void DoubleOpNegativeInfinityNaN() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity==double.NaN,false);
		}

		[TestMethod]
		public void DoubleOpZeroMinusZero() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 })==-0d,true);
		}

		[TestMethod]
		public void LongLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1L),true);
		}

		[TestMethod]
		public void LongUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1L),true);
		}

		[TestMethod]
		public void LongSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1L),false);
		}

		[TestMethod]
		public void LongPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(1L),false);
		}

		[TestMethod]
		public void LongNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(1L),false);
		}

		[TestMethod]
		public void LongZeroMinusZero() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 }).Equals(-0L),true);
		}

		[TestMethod]
		public void LongOpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==1L,true);
		}

		[TestMethod]
		public void LongOpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==1L,true);
		}

		[TestMethod]
		public void LongOpSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 })==1L,false);
		}

		[TestMethod]
		public void LongOpPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity==1L,false);
		}

		[TestMethod]
		public void LongOpNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity==1L,false);
		}

		[TestMethod]
		public void LongOpZeroMinusZero() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 })==-0L,true);
		}

		[TestMethod]
		public void ObjectException() {
			object value = "";
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 1 },new byte[] { 1 }).Equals(value),false);
		}

		[TestMethod]
		public void ObjectLowerTrue() {
			object value = CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 });
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(value),true);
		}

		[TestMethod]
		public void ObjectLowerFalse() {
			object value = CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 2 });
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(value),false);
		}

		[TestMethod]
		public void ObjectUpperFalse() {
			object value = CreateObjectCT(false,new ContainerType[] { 1,1 },new ContainerType[] { 1 });
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(value),false);
		}

		[TestMethod]
		public void ObjectUpperTrue() {
			object value = CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 });
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(value),true);
		}

		[TestMethod]
		public void ObjectSignFalse() {
			object value = CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 });
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(value),false);
		}

		[TestMethod]
		public void ObjectPositiveInfinityPositiveInfinity() {
			object value = Rational.PositiveInfinity;
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(value),true);
		}

		[TestMethod]
		public void ObjectPositiveInfinityNonPositiveInfinity() {
			object value = Rational.One;
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(value),false);
		}

		[TestMethod]
		public void ObjectNonPositiveInfinityPositiveInfinity() {
			object value = Rational.PositiveInfinity;
			Assert.AreEqual<bool>(Rational.One.Equals(value),false);
		}

		[TestMethod]
		public void ObjectPositiveInfinityNegativeInfinity() {
			object value = Rational.NegativeInfinity;
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(value),false);
		}

		[TestMethod]
		public void ObjectNegativeInfinityNegativeInfinity() {
			object value = Rational.NegativeInfinity;
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(value),true);
		}

		[TestMethod]
		public void ObjectNegativeInfinityNonNegativeInfinity() {
			object value = Rational.One;
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(value),false);
		}

		[TestMethod]
		public void ObjectNonNegativeInfinityNegativeInfinity() {
			object value = Rational.NegativeInfinity;
			Assert.AreEqual<bool>(Rational.One.Equals(value),false);
		}

		[TestMethod]
		public void ObjectNaNNegativeInfinity() {
			object value = Rational.NegativeInfinity;
			Assert.AreEqual<bool>(Rational.NaN.Equals(value),false);
		}

		[TestMethod]
		public void ObjectNegativeInfinityNaN() {
			object value = Rational.NaN;
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(value),false);
		}

		[TestMethod]
		public void ObjectZeroMinusZero() {
			object value = new Rational(true,new byte[] { 0 },new byte[] { 1 });
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 }).Equals(value),false);
		}

		[TestMethod]
		public void ObjectNull() {
			object value = null;
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 }).Equals(value),false);
		}

		[TestMethod]
		public void RationalLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 })),true);
		}

		[TestMethod]
		public void RationalLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 2 })),false);
		}

		[TestMethod]
		public void RationalUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(CreateObjectCT(false,new ContainerType[] { 1,1 },new ContainerType[] { 1 })),false);
		}

		[TestMethod]
		public void RationalUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 })),true);
		}

		[TestMethod]
		public void RationalSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 })),false);
		}

		[TestMethod]
		public void RationalPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(Rational.PositiveInfinity),true);
		}

		[TestMethod]
		public void RationalPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(Rational.One),false);
		}

		[TestMethod]
		public void RationalNonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.One.Equals(Rational.PositiveInfinity),false);
		}

		[TestMethod]
		public void RationalPositiveInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(Rational.NegativeInfinity),false);
		}

		[TestMethod]
		public void RationalNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(Rational.NegativeInfinity),true);
		}

		[TestMethod]
		public void RationalNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(Rational.One),false);
		}

		[TestMethod]
		public void RationalNonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.One.Equals(Rational.NegativeInfinity),false);
		}

		[TestMethod]
		public void RationalNaNNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NaN.Equals(Rational.NegativeInfinity),false);
		}

		[TestMethod]
		public void RationalNegativeInfinityNaN() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(Rational.NaN),false);
		}

		[TestMethod]
		public void RationalZeroMinusZero() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[]{1 }).Equals(new Rational(true,new byte[] { 0 },new byte[] { 1 })),false);
		}

		[TestMethod]
		public void UlongLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1UL),true);
		}

		[TestMethod]
		public void UlongUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1UL),true);
		}

		[TestMethod]
		public void UlongSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 }).Equals(1UL),false);
		}

		[TestMethod]
		public void UlongPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity.Equals(1UL),false);
		}

		[TestMethod]
		public void UlongNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity.Equals(1UL),false);
		}

		[TestMethod]
		public void UlongOpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==1UL,true);
		}

		[TestMethod]
		public void UlongOpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==1UL,true);
		}

		[TestMethod]
		public void UlongOpSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 })==1UL,false);
		}

		[TestMethod]
		public void UlongOpPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity==1UL,false);
		}

		[TestMethod]
		public void UlongOpNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity==1UL,false);
		}

		[TestMethod]
		public void LowerTrue() {
			Assert.AreEqual<bool>(Rational.Equals(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 })),true);
		}

		[TestMethod]
		public void LowerFalse() {
			Assert.AreEqual<bool>(Rational.Equals(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 2 })),false);
		}

		[TestMethod]
		public void UpperFalse() {
			Assert.AreEqual<bool>(Rational.Equals(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 1,1 },new ContainerType[] { 1 })),false);
		}

		[TestMethod]
		public void UpperTrue() {
			Assert.AreEqual<bool>(Rational.Equals(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 })),true);
		}

		[TestMethod]
		public void SignFalse() {
			Assert.AreEqual<bool>(Rational.Equals(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 }),CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 })),false);
		}

		[TestMethod]
		public void PositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.PositiveInfinity,Rational.PositiveInfinity),true);
		}

		[TestMethod]
		public void PositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.PositiveInfinity,Rational.One),false);
		}

		[TestMethod]
		public void NonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.One,Rational.PositiveInfinity),false);
		}

		[TestMethod]
		public void PositiveInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.PositiveInfinity,Rational.NegativeInfinity),false);
		}

		[TestMethod]
		public void NegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.NegativeInfinity,Rational.NegativeInfinity),true);
		}

		[TestMethod]
		public void NegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.NegativeInfinity,Rational.One),false);
		}

		[TestMethod]
		public void NonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.One,Rational.NegativeInfinity),false);
		}

		[TestMethod]
		public void NaNNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.NaN,Rational.NegativeInfinity),false);
		}

		[TestMethod]
		public void NaNNaN() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.NaN,Rational.NaN),true);
		}

		[TestMethod]
		public void NegativeInfinityNaN() {
			Assert.AreEqual<bool>(Rational.Equals(Rational.NegativeInfinity,Rational.NaN),false);
		}

		[TestMethod]
		public void ZeroMinusZero() {
			Assert.AreEqual<bool>(Rational.Equals(new Rational(false,new byte[] { 0 },new byte[]{1 }),new Rational(true,new byte[] { 0 },new byte[] { 1 })),false);
		}

		[TestMethod]
		public void OpLowerTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 1 }),true);
		}

		[TestMethod]
		public void OpLowerFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==CreateObjectCT(false,new ContainerType[] { 1,0 },new ContainerType[] { 2 }),false);
		}

		[TestMethod]
		public void OpUpperFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==CreateObjectCT(false,new ContainerType[] { 1,1 },new ContainerType[] { 1 }),false);
		}

		[TestMethod]
		public void OpUpperTrue() {
			Assert.AreEqual<bool>(CreateObjectCT(false,new ContainerType[] { 1 },new ContainerType[] { 1 })==CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 }),true);
		}

		[TestMethod]
		public void OpSignFalse() {
			Assert.AreEqual<bool>(CreateObjectCT(true,new ContainerType[] { 1 },new ContainerType[] { 1 })==CreateObjectCT(false,new ContainerType[] { 2,0 },new ContainerType[] { 2 }),false);
		}

		[TestMethod]
		public void OpPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity==Rational.PositiveInfinity,true);
		}

		[TestMethod]
		public void OpPositiveInfinityNonPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity==Rational.One,false);
		}

		[TestMethod]
		public void OpNonPositiveInfinityPositiveInfinity() {
			Assert.AreEqual<bool>(Rational.One==Rational.PositiveInfinity,false);
		}

		[TestMethod]
		public void OpPositiveInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.PositiveInfinity==Rational.NegativeInfinity,false);
		}

		[TestMethod]
		public void OpNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity==Rational.NegativeInfinity,true);
		}

		[TestMethod]
		public void OpNegativeInfinityNonNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity==Rational.One,false);
		}

		[TestMethod]
		public void OpNonNegativeInfinityNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.One==Rational.NegativeInfinity,false);
		}

		[TestMethod]
		public void OpNaNNegativeInfinity() {
			Assert.AreEqual<bool>(Rational.NaN==Rational.NegativeInfinity,false);
		}

		[TestMethod]
		public void OpNegativeInfinityNaN() {
			Assert.AreEqual<bool>(Rational.NegativeInfinity==Rational.NaN,false);
		}

		[TestMethod]
		public void OpNaNNaN() {
			Assert.AreEqual<bool>(Rational.NaN==Rational.NaN,false);
		}

		[TestMethod]
		public void OpZeroMinusZero() {
			Assert.AreEqual<bool>(new Rational(false,new byte[] { 0 },new byte[] { 1 })==new Rational(true,new byte[] { 0 },new byte[] { 1 }),false);
		}

	}
}
