using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class Cast:TestBase {

		[TestMethod]
		public void ToByteMax() {
			ExecTest<byte>((byte)(new Rational(byte.MaxValue)),byte.MaxValue);
		}

		[TestMethod]
		public void ToByteMin() {
			ExecTest<byte>((byte)(new Rational(byte.MinValue)),byte.MinValue);
		}

		[TestMethod]
		public void ToByteMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (byte)(new Rational(byte.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToByteMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (byte)(new Rational(byte.MinValue)-1);
			});
		}
		
		[TestMethod]
		public void ToByteFractional() {
			ExecTest<byte>((byte)(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToSbyteMax() {
			ExecTest<sbyte>((sbyte)(new Rational(sbyte.MaxValue)),sbyte.MaxValue);
		}

		[TestMethod]
		public void ToSbyteMin() {
			ExecTest<sbyte>((sbyte)(new Rational(sbyte.MinValue)),sbyte.MinValue);
		}

		[TestMethod]
		public void ToSbyteMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (sbyte)(new Rational(sbyte.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToSbyteMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (sbyte)(new Rational(sbyte.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToSbyteFractional() {
			ExecTest<sbyte>((sbyte)(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToIntMax() {
			ExecTest<int>((int)(new Rational(int.MaxValue)),int.MaxValue);
		}

		[TestMethod]
		public void ToIntMin() {
			ExecTest<int>((int)(new Rational(int.MinValue)),int.MinValue);
		}

		[TestMethod]
		public void ToIntMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (int)(new Rational(int.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToIntMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (int)(new Rational(int.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToIntFractional() {
			ExecTest<int>((int)(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToUintMax() {
			ExecTest<uint>((uint)(new Rational(uint.MaxValue)),uint.MaxValue);
		}

		[TestMethod]
		public void ToUintMin() {
			ExecTest<uint>((uint)(new Rational(uint.MinValue)),uint.MinValue);
		}

		[TestMethod]
		public void ToUintMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (uint)(new Rational(uint.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUintMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (uint)(new Rational(uint.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUintFractional() {
			ExecTest<uint>((uint)(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToShortMax() {
			ExecTest<short>((short)(new Rational(short.MaxValue)),short.MaxValue);
		}

		[TestMethod]
		public void ToShortMin() {
			ExecTest<short>((short)(new Rational(short.MinValue)),short.MinValue);
		}

		[TestMethod]
		public void ToShortMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (short)(new Rational(short.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToShortMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (short)(new Rational(short.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToShortFractional() {
			ExecTest<short>((short)(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToUshortMax() {
			ExecTest<ushort>((ushort)(new Rational(ushort.MaxValue)),ushort.MaxValue);
		}

		[TestMethod]
		public void ToUshortMin() {
			ExecTest<ushort>((ushort)(new Rational(ushort.MinValue)),ushort.MinValue);
		}

		[TestMethod]
		public void ToUshortMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (ushort)(new Rational(ushort.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUshortMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (ushort)(new Rational(ushort.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUshortFractional() {
			ExecTest<ushort>((ushort)(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToLongMax() {
			ExecTest<long>((long)(new Rational(long.MaxValue)),long.MaxValue);
		}

		[TestMethod]
		public void ToLongMin() {
			ExecTest<long>((long)(new Rational(long.MinValue)),long.MinValue);
		}

		[TestMethod]
		public void ToLongMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (long)(new Rational(long.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToLongMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (long)(new Rational(long.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToLongFractional() {
			ExecTest<long>((long)(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToUlongMax() {
			ExecTest<ulong>((ulong)(new Rational(ulong.MaxValue)),ulong.MaxValue);
		}

		[TestMethod]
		public void ToUlongMin() {
			ExecTest<ulong>((ulong)(new Rational(ulong.MinValue)),ulong.MinValue);
		}

		[TestMethod]
		public void ToUlongMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (ulong)(new Rational(ulong.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUlongMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (ulong)(new Rational(ulong.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUlongFractional() {
			ExecTest<ulong>((ulong)(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToFloatMaxValue() {
			ExecTest<float>((float)(new Rational(float.MaxValue)),float.MaxValue);
		}

		[TestMethod]
		public void ToFloatMinValue() {
			ExecTest<float>((float)(new Rational(float.MinValue)),float.MinValue);
		}

		[TestMethod]
		public void ToFloatMaxOver() {
			ExecTest<float>((float)(new Rational(float.MaxValue)+1),float.PositiveInfinity);
		}

		[TestMethod]
		public void ToFloatMinOver() {
			ExecTest<float>((float)(new Rational(float.MinValue)-1),float.NegativeInfinity);
		}

		[TestMethod]
		public void ToFloatEpsilon() {
			ExecTest<float>((float)(new Rational(float.Epsilon)),float.Epsilon);
		}

		[TestMethod]
		public void ToFloatEpsilonLower() {
			ExecTest<float>((float)(new Rational(float.Epsilon)/2),0);
		}

		[TestMethod]
		public void ToFloatZero() {
			ExecTest<float>((float)(new Rational(0f)),0f);
		}

		[TestMethod]
		public void ToFloatNaN() {
			ExecTest<float>((float)(new Rational(float.NaN)),float.NaN);
		}

		[TestMethod]
		public void ToFloatNegativeInfinity() {
			ExecTest<float>((float)(new Rational(float.NegativeInfinity)),float.NegativeInfinity);
		}

		[TestMethod]
		public void ToFloatPositiveInfinity() {
			ExecTest<float>((float)(new Rational(float.PositiveInfinity)),float.PositiveInfinity);
		}

		[TestMethod]
		public void ToDoubleMaxValue() {
			ExecTest<double>((double)(new Rational(double.MaxValue)),double.MaxValue);
		}

		[TestMethod]
		public void ToDoubleMinValue() {
			ExecTest<double>((double)(new Rational(double.MinValue)),double.MinValue);
		}

		[TestMethod]
		public void ToDoubleMaxOver() {
			ExecTest<double>((double)(new Rational(double.MaxValue)+1),double.PositiveInfinity);
		}

		[TestMethod]
		public void ToDoubleMinOver() {
			ExecTest<double>((double)(new Rational(double.MinValue)-1),double.NegativeInfinity);
		}

		[TestMethod]
		public void ToDoubleEpsilon() {
			ExecTest<double>((double)(new Rational(double.Epsilon)),double.Epsilon);
		}

		[TestMethod]
		public void ToDoubleEpsilonLower() {
			ExecTest<double>((double)(new Rational(double.Epsilon)/2),0);
		}

		[TestMethod]
		public void ToDoubleZero() {
			ExecTest<double>((double)(new Rational(0d)),0d);
		}


		[TestMethod]
		public void ToDoubleNaN() {
			ExecTest<double>((double)(new Rational(double.NaN)),double.NaN);
		}

		[TestMethod]
		public void ToDoubleNegativeInfinity() {
			ExecTest<double>((double)(new Rational(double.NegativeInfinity)),double.NegativeInfinity);
		}

		[TestMethod]
		public void ToDoublePositiveInfinity() {
			ExecTest<double>((double)(new Rational(double.PositiveInfinity)),double.PositiveInfinity);
		}

		[TestMethod]
		public void ToBoolOne() {
			ExecTest<bool>((bool)Rational.One,true);
		}

		[TestMethod]
		public void ToBoolZero() {
			ExecTest<bool>((bool)Rational.Zero,false);
		}

		[TestMethod]
		public void ToBoolMinusOne() {
			ExecTest<bool>((bool)Rational.MinusOne,true);
		}

		[TestMethod]
		public void ToBoolFractional() {
			ExecTest<bool>((bool)(Rational.One/2),true);
		}

		[TestMethod]
		public void ToDecimalMaxValue() {
			ExecTest<decimal>((decimal)(new Rational(decimal.MaxValue)),decimal.MaxValue);
		}

		[TestMethod]
		public void ToDecimalMinValue() {
			ExecTest<decimal>((decimal)(new Rational(decimal.MinValue)),decimal.MinValue);
		}

		[TestMethod]
		public void ToDecimalMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (decimal)(new Rational(decimal.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToDecimalMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = (decimal)(new Rational(decimal.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToDecimalZero() {
			this.ExecTest<decimal>((decimal)new Rational(0m),0m);
		}

		[TestMethod]
		public void ToDecimalEpsilon() {
			var value = 1m;
			for(var counter = 0;counter<28;counter++) {
				value/=10;
			}
			this.ExecTest<decimal>((decimal)new Rational(value),value);
		}

		[TestMethod]
		public void FromByteMax() {
			ExecTest(Rational.Zero+byte.MaxValue,false,new byte[] { 255 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromByteMin() {
			ExecTest(Rational.Zero+byte.MinValue,false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromSbyteMax() {
			ExecTest(Rational.Zero+sbyte.MaxValue,false,new byte[] { 127 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromSbyteZero() {
			ExecTest(Rational.Zero+(sbyte)0,false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromSbyteMin() {
			ExecTest(Rational.Zero+sbyte.MinValue,true,new byte[] { 128 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromIntMax() {
			ExecTest(Rational.Zero+int.MaxValue,false,new byte[] { 0xff,0xff,0xff,0x7f },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromIntZero() {
			ExecTest(Rational.Zero+(int)0,false,new byte[] { 0,0,0,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromIntMin() {
			ExecTest(Rational.Zero+int.MinValue,true,new byte[] { 0,0,0,0x80 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromUintMax() {
			ExecTest(Rational.Zero+uint.MaxValue,false,new byte[] { 0xff,0xff,0xff,0xff },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromUintMin() {
			ExecTest(Rational.Zero+uint.MinValue,false,new byte[] { 0,0,0,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromShortMax() {
			ExecTest(Rational.Zero+short.MaxValue,false,new byte[] { 0xff,0x7f },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromShortZero() {
			ExecTest(Rational.Zero+(short)0,false,new byte[] { 0,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromShortMin() {
			ExecTest(Rational.Zero+short.MinValue,true,new byte[] { 0,0x80 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromUshortMax() {
			ExecTest(Rational.Zero+ushort.MaxValue,false,new byte[] { 0xff,0xff },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromUshortMin() {
			ExecTest(Rational.Zero+ushort.MinValue,false,new byte[] { 0,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromLongMax() {
			ExecTest(Rational.Zero+long.MaxValue,false,new byte[] { 0xff,0xff,0xff,0xff,0xff,0xff,0xff,0x7f },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromLongZero() {
			ExecTest(Rational.Zero+(long)0,false,new byte[] { 0,0,0,0,0,0,0,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromLongMin() {
			ExecTest(Rational.Zero+long.MinValue,true,new byte[] { 0,0,0,0,0,0,0,0x80 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromUlongMax() {
			ExecTest(Rational.Zero+ulong.MaxValue,false,new byte[] { 0xff,0xff,0xff,0xff,0xff,0xff,0xff,0xff },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromUlongMin() {
			ExecTest(Rational.Zero+ulong.MinValue,false,new byte[] { 0,0,0,0,0,0,0,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromFloatMaxValue() {
			ExecTest(Rational.Zero+float.MaxValue,false,new byte[] { 0,0,0,128,135,208,74,249,190,193,127,109,42,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromFloatMinValue() {
			ExecTest(Rational.Zero+float.MinValue,true,new byte[] { 0,0,0,128,135,208,74,249,190,193,127,109,42,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromFloatEpsilon() {
			ExecTest(Rational.Zero+float.Epsilon,false,new byte[] { 165,195,42 },new byte[] { 0,0,0,0,0,0,208,43,210,35,104,80,119,156,2,112,127,183,157,116,88,5 },false);
		}

		[TestMethod]
		public void FromFloatZero() {
			ExecTest(Rational.Zero+0f,false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromFloatNaN() {
			ExecTest(Rational.Zero+float.NaN,false,new byte[] { 0 },new byte[] { 0 },false);
		}

		[TestMethod]
		public void FromFloatNegativeInfinity() {
			ExecTest(Rational.Zero+float.NegativeInfinity,true,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void FromFloatPositiveInfinity() {
			ExecTest(Rational.Zero+float.PositiveInfinity,false,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void FromDoubleMaxValue() {
			ExecTest(Rational.Zero+double.MaxValue,false,new byte[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,80,158,98,6,116,170,166,243,153,139,163,51,86,86,168,135,141,73,56,189,207,34,246,216,224,92,104,60,144,199,77,15,141,25,29,39,36,80,22,253,64,133,18,146,117,231,15,81,130,196,118,233,156,239,76,174,53,185,38,185,72,215,98,211,204,214,127,217,46,178,184,249,223,185,122,85,243,17,38,181,91,113,38,107,172,247,255,255,255,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDoubleMinValue() {
			ExecTest(Rational.Zero+double.MinValue,true,new byte[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,80,158,98,6,116,170,166,243,153,139,163,51,86,86,168,135,141,73,56,189,207,34,246,216,224,92,104,60,144,199,77,15,141,25,29,39,36,80,22,253,64,133,18,146,117,231,15,81,130,196,118,233,156,239,76,174,53,185,38,185,72,215,98,211,204,214,127,217,46,178,184,249,223,185,122,85,243,17,38,181,91,113,38,107,172,247,255,255,255,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDoubleEpsilon() {
			ExecTest(Rational.Zero+double.Epsilon,false,new byte[] { 119,248,205,29,129,195,87 },new byte[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,136,9,116,27,61,99,207,20,11,122,133,159,164,249,103,211,210,187,209,17,95,82,193,45,81,230,23,57,136,154,63,162,78,95,220,9,97,84,39,25,166,228,214,25,79,94,93,127,86,59,153,16,38,23,153,230,9,31,218,72,127,56,155,108,174,221,194,75,10,161,126,13,102,35,252,110,28,115,233,195,131,180,139,104,1,13,255,248,90,31,215,213,220,225,55,119,4,14,95,1 },false);
		}

		[TestMethod]
		public void FromDoubleZero() {
			ExecTest(Rational.Zero+0d,false,new byte[] { 0 },new byte[] { 1 },false);
		}


		[TestMethod]
		public void FromDoubleNaN() {
			ExecTest(Rational.Zero+double.NaN,false,new byte[] { 0 },new byte[] { 0 },false);
		}

		[TestMethod]
		public void FromDoubleNegativeInfinity() {
			ExecTest(Rational.Zero+double.NegativeInfinity,true,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void FromDoublePositiveInfinity() {
			ExecTest(Rational.Zero+double.PositiveInfinity,false,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void FromBoolTrue() {
			ExecTest(Rational.Zero+true,false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromBoolFalse() {
			ExecTest(Rational.Zero+false,false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDecimalMaxValue() {
			ExecTest(Rational.Zero+decimal.MaxValue,false,new byte[] { 255,255,255,255,255,255,255,255,255,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDecimalMinValue() {
			ExecTest(Rational.Zero+decimal.MinValue,true,new byte[] { 255,255,255,255,255,255,255,255,255,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDecimalMinusOne() {
			ExecTest(Rational.Zero+decimal.MinusOne,true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDecimalOne() {
			ExecTest(Rational.Zero+decimal.One,false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDecimalZero() {
			ExecTest(Rational.Zero+decimal.Zero,false,new byte[] { 0 },new byte[] { 1 },false);
		}

	}
}
