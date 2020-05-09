using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class Cast:TestBase {

		[TestMethod]
		public void ToByteMax() {
			ExecTest<byte>((byte)(new BigUInteger(byte.MaxValue)),byte.MaxValue);
		}

		[TestMethod]
		public void ToByteMin() {
			ExecTest<byte>((byte)(new BigUInteger(byte.MinValue)),byte.MinValue);
		}

		[TestMethod]
		public void ToByteMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (byte)(new BigUInteger(byte.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToByteMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (byte)(new BigUInteger(byte.MinValue)-1);
			});
		}
		
		[TestMethod]
		public void ToByteFractional() {
			ExecTest<byte>((byte)(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToSbyteMax() {
			ExecTest<sbyte>((sbyte)(new BigUInteger(sbyte.MaxValue)),sbyte.MaxValue);
		}

		[TestMethod]
		public void ToSbyteMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (sbyte)(new BigUInteger(sbyte.MinValue));
			});
		}

		[TestMethod]
		public void ToSbyteMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (sbyte)(new BigUInteger(sbyte.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToSbyteMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (sbyte)(new BigUInteger(sbyte.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToSbyteFractional() {
			ExecTest<sbyte>((sbyte)(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToIntMax() {
			ExecTest<int>((int)(new BigUInteger(int.MaxValue)),int.MaxValue);
		}

		[TestMethod]
		public void ToIntMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (int)(new BigUInteger(int.MinValue));
			});
		}

		[TestMethod]
		public void ToIntMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (int)(new BigUInteger(int.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToIntMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (int)(new BigUInteger(int.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToIntFractional() {
			ExecTest<int>((int)(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToUintMax() {
			ExecTest<uint>((uint)(new BigUInteger(uint.MaxValue)),uint.MaxValue);
		}

		[TestMethod]
		public void ToUintMin() {
			ExecTest<uint>((uint)(new BigUInteger(uint.MinValue)),uint.MinValue);
		}

		[TestMethod]
		public void ToUintMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (uint)(new BigUInteger(uint.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUintMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (uint)(new BigUInteger(uint.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUintFractional() {
			ExecTest<uint>((uint)(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToShortMax() {
			ExecTest<short>((short)(new BigUInteger(short.MaxValue)),short.MaxValue);
		}

		[TestMethod]
		public void ToShortMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (short)(new BigUInteger(short.MinValue));
			});
		}

		[TestMethod]
		public void ToShortMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (short)(new BigUInteger(short.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToShortMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (short)(new BigUInteger(short.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToShortFractional() {
			ExecTest<short>((short)(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToUshortMax() {
			ExecTest<ushort>((ushort)(new BigUInteger(ushort.MaxValue)),ushort.MaxValue);
		}

		[TestMethod]
		public void ToUshortMin() {
			ExecTest<ushort>((ushort)(new BigUInteger(ushort.MinValue)),ushort.MinValue);
		}

		[TestMethod]
		public void ToUshortMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (ushort)(new BigUInteger(ushort.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUshortMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (ushort)(new BigUInteger(ushort.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUshortFractional() {
			ExecTest<ushort>((ushort)(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToLongMax() {
			ExecTest<long>((long)(new BigUInteger(long.MaxValue)),long.MaxValue);
		}

		[TestMethod]
		public void ToLongMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (long)(new BigUInteger(long.MinValue));
			});
		}

		[TestMethod]
		public void ToLongMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (long)(new BigUInteger(long.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToLongMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (long)(new BigUInteger(long.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToLongFractional() {
			ExecTest<long>((long)(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToUlongMax() {
			ExecTest<ulong>((ulong)(new BigUInteger(ulong.MaxValue)),ulong.MaxValue);
		}

		[TestMethod]
		public void ToUlongMin() {
			ExecTest<ulong>((ulong)(new BigUInteger(ulong.MinValue)),ulong.MinValue);
		}

		[TestMethod]
		public void ToUlongMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (ulong)(new BigUInteger(ulong.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUlongMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (ulong)(new BigUInteger(ulong.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUlongFractional() {
			ExecTest<ulong>((ulong)(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToFloatMaxValue() {
			ExecTest<float>((float)(new BigUInteger(float.MaxValue)),float.MaxValue);
		}

		[TestMethod]
		public void ToFloatMinValue() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (float)(new BigUInteger(float.MinValue));
			});
		}

		[TestMethod]
		public void ToFloatMaxOver() {
			ExecTest<float>((float)(new BigUInteger(float.MaxValue)+1),float.PositiveInfinity);
		}

		[TestMethod]
		public void ToFloatMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (float)(new BigUInteger(float.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToFloatEpsilon() {
			ExecTest<float>((float)(new BigUInteger(float.Epsilon)),0f);
		}

		[TestMethod]
		public void ToFloatEpsilonLower() {
			ExecTest<float>((float)(new BigUInteger(float.Epsilon)/2),0f);
		}

		[TestMethod]
		public void ToFloatZero() {
			ExecTest<float>((float)(new BigUInteger(0f)),0f);
		}

		[TestMethod]
		public void ToFloatNaN() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (float)(new BigUInteger(float.NaN));
			});
		}

		[TestMethod]
		public void ToFloatNegativeInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (float)(new BigUInteger(float.NegativeInfinity));
			});
		}

		[TestMethod]
		public void ToFloatPositiveInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (float)(new BigUInteger(float.PositiveInfinity));
			});
		}

		[TestMethod]
		public void ToDoubleMaxValue() {
			ExecTest<double>((double)(new BigUInteger(double.MaxValue)),double.MaxValue);
		}

		[TestMethod]
		public void ToDoubleMinValue() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (double)(new BigUInteger(double.MinValue));
			});
		}

		[TestMethod]
		public void ToDoubleMaxOver() {
			ExecTest<double>((double)(new BigUInteger(double.MaxValue)+1),double.PositiveInfinity);
		}

		[TestMethod]
		public void ToDoubleMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (double)(new BigUInteger(double.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToDoubleEpsilon() {
			ExecTest<double>((double)(new BigUInteger(double.Epsilon)),0d);
		}

		[TestMethod]
		public void ToDoubleEpsilonLower() {
			ExecTest<double>((double)(new BigUInteger(double.Epsilon)/2),0d);
		}

		[TestMethod]
		public void ToDoubleZero() {
			ExecTest<double>((double)(new BigUInteger(0d)),0d);
		}


		[TestMethod]
		public void ToDoubleNaN() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (double)(new BigUInteger(double.NaN));
			});
		}

		[TestMethod]
		public void ToDoubleNegativeInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (double)(new BigUInteger(double.NegativeInfinity));
			});
		}

		[TestMethod]
		public void ToDoublePositiveInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (double)(new BigUInteger(double.PositiveInfinity));
			});
		}

		[TestMethod]
		public void ToBoolOne() {
			ExecTest<bool>((bool)BigUInteger.One,true);
		}

		[TestMethod]
		public void ToBoolZero() {
			ExecTest<bool>((bool)BigUInteger.Zero,false);
		}

		[TestMethod]
		public void ToBoolFractional() {
			ExecTest<bool>((bool)(BigUInteger.One/2),false);
		}

		[TestMethod]
		public void ToDecimalMaxValue() {
			ExecTest<decimal>((decimal)(new BigUInteger(decimal.MaxValue)),decimal.MaxValue);
		}

		[TestMethod]
		public void ToDecimalMinValue() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (decimal)(new BigUInteger(decimal.MinValue));
			});
		}

		[TestMethod]
		public void ToDecimalMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (decimal)(new BigUInteger(decimal.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToDecimalMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (decimal)(new BigUInteger(decimal.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToDecimalZero() {
			this.ExecTest<decimal>((decimal)new BigUInteger(0m),0m);
		}

		[TestMethod]
		public void ToDecimalEpsilon() {
			var value = 1m;
			for(var counter = 0;counter<28;counter++) {
				value/=10;
			}
			this.ExecTest<decimal>((decimal)new BigUInteger(value),decimal.Zero);
		}

		[TestMethod]
		public void FromByteMax() {
			ExecTest(BigUInteger.Zero+byte.MaxValue,new byte[] { 255 });
		}

		[TestMethod]
		public void FromByteMin() {
			ExecTest(BigUInteger.Zero+byte.MinValue,new byte[] { 0 });
		}

		[TestMethod]
		public void FromSbyteMax() {
			ExecTest(BigUInteger.Zero+sbyte.MaxValue,new byte[] { 127 });
		}

		[TestMethod]
		public void FromSbyteZero() {
			ExecTest(BigUInteger.Zero+(sbyte)0,new byte[] { 0 });
		}

		[TestMethod]
		public void FromSbyteMin() {
			Assert.ThrowsException<OverflowException>(()=> {
				var value=BigUInteger.Zero+sbyte.MinValue;
			});
		}

		[TestMethod]
		public void FromIntMax() {
			ExecTest(BigUInteger.Zero+int.MaxValue,new byte[] { 0xff,0xff,0xff,0x7f });
		}

		[TestMethod]
		public void FromIntZero() {
			ExecTest(BigUInteger.Zero+(int)0,new byte[] { 0,0,0,0 });
		}

		[TestMethod]
		public void FromIntMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+int.MinValue;
			});
		}

		[TestMethod]
		public void FromUintMax() {
			ExecTest(BigUInteger.Zero+uint.MaxValue,new byte[] { 0xff,0xff,0xff,0xff });
		}

		[TestMethod]
		public void FromUintMin() {
			ExecTest(BigUInteger.Zero+uint.MinValue,new byte[] { 0,0,0,0 });
		}

		[TestMethod]
		public void FromShortMax() {
			ExecTest(BigUInteger.Zero+short.MaxValue,new byte[] { 0xff,0x7f });
		}

		[TestMethod]
		public void FromShortZero() {
			ExecTest(BigUInteger.Zero+(short)0,new byte[] { 0,0 });
		}

		[TestMethod]
		public void FromShortMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+short.MinValue;
			});
		}

		[TestMethod]
		public void FromUshortMax() {
			ExecTest(BigUInteger.Zero+ushort.MaxValue,new byte[] { 0xff,0xff });
		}

		[TestMethod]
		public void FromUshortMin() {
			ExecTest(BigUInteger.Zero+ushort.MinValue,new byte[] { 0,0 });
		}

		[TestMethod]
		public void FromLongMax() {
			ExecTest(BigUInteger.Zero+long.MaxValue,new byte[] { 0xff,0xff,0xff,0xff,0xff,0xff,0xff,0x7f });
		}

		[TestMethod]
		public void FromLongZero() {
			ExecTest(BigUInteger.Zero+(long)0,new byte[] { 0,0,0,0,0,0,0,0 });
		}

		[TestMethod]
		public void FromLongMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+long.MinValue;
			});
		}

		[TestMethod]
		public void FromUlongMax() {
			ExecTest(BigUInteger.Zero+ulong.MaxValue,new byte[] { 0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff });
		}

		[TestMethod]
		public void FromUlongMin() {
			ExecTest(BigUInteger.Zero+ulong.MinValue,new byte[] { 0,0,0,0,0,0,0,0 });
		}

		[TestMethod]
		public void FromFloatMaxValue() {
			ExecTest(BigUInteger.Zero+float.MaxValue,new byte[] { 0,0,0,128,135,208,74,249,190,193,127,109,42,255,255,255,0 });
		}

		[TestMethod]
		public void FromFloatMinValue() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+float.MinValue;
			});
		}

		[TestMethod]
		public void FromFloatEpsilon() {
			ExecTest(BigUInteger.Zero+float.Epsilon,new byte[] { 0 });
		}

		[TestMethod]
		public void FromFloatZero() {
			ExecTest(BigUInteger.Zero+0f,new byte[] { 0 });
		}

		[TestMethod]
		public void FromFloatNaN() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+float.NaN;
			});
		}

		[TestMethod]
		public void FromFloatNegativeInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+float.NegativeInfinity;
			});
		}

		[TestMethod]
		public void FromFloatPositiveInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+float.PositiveInfinity;
			});
		}

		[TestMethod]
		public void FromDoubleMaxValue() {
			ExecTest(BigUInteger.Zero+double.MaxValue,new byte[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,80,158,98,6,116,170,166,243,153,139,163,51,86,86,168,135,141,73,56,189,207,34,246,216,224,92,104,60,144,199,77,15,141,25,29,39,36,80,22,253,64,133,18,146,117,231,15,81,130,196,118,233,156,239,76,174,53,185,38,185,72,215,98,211,204,214,127,217,46,178,184,249,223,185,122,85,243,17,38,181,91,113,38,107,172,247,255,255,255,255,255,255,0 });
		}

		[TestMethod]
		public void FromDoubleMinValue() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+double.MinValue;
			});
		}

		[TestMethod]
		public void FromDoubleEpsilon() {
			ExecTest(BigUInteger.Zero+double.Epsilon,new byte[] { 0 });
		}

		[TestMethod]
		public void FromDoubleZero() {
			ExecTest(BigUInteger.Zero+0d,new byte[] { 0 });
		}


		[TestMethod]
		public void FromDoubleNaN() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+double.NaN;
			});
		}

		[TestMethod]
		public void FromDoubleNegativeInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+double.NegativeInfinity;
			});
		}

		[TestMethod]
		public void FromDoublePositiveInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+double.PositiveInfinity;
			});
		}

		[TestMethod]
		public void FromBoolTrue() {
			ExecTest(BigUInteger.Zero+true,new byte[] { 1 });
		}

		[TestMethod]
		public void FromBoolFalse() {
			ExecTest(BigUInteger.Zero+false,new byte[] { 0 });
		}

		[TestMethod]
		public void FromDecimalMaxValue() {
			ExecTest(BigUInteger.Zero+decimal.MaxValue,new byte[] { 255,255,255,255,255,255,255,255,255,255,255,255,0 });
		}

		[TestMethod]
		public void FromDecimalMinValue() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+decimal.MinValue;
			});
		}

		[TestMethod]
		public void FromDecimalMinusOne() {
			Assert.ThrowsException<OverflowException>(() => {
				var value = BigUInteger.Zero+decimal.MinusOne;
			});
		}

		[TestMethod]
		public void FromDecimalOne() {
			ExecTest(BigUInteger.Zero+decimal.One,new byte[] { 1 });
		}

		[TestMethod]
		public void FromDecimalZero() {
			ExecTest(BigUInteger.Zero+decimal.Zero,new byte[] { 0 });
		}

	}
}
