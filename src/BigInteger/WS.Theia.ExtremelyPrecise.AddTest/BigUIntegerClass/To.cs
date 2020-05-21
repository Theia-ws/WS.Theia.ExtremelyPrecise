using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class To:TestBase {

		[TestMethod]
		public void ToByteMax() {
			ExecTest<byte>(BigUInteger.ToByte(new BigUInteger(byte.MaxValue)),byte.MaxValue);
		}

		[TestMethod]
		public void ToByteMin() {
			ExecTest<byte>(BigUInteger.ToByte(new BigUInteger(byte.MinValue)),byte.MinValue);
		}

		[TestMethod]
		public void ToByteMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToByte(new BigUInteger(byte.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToByteMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToByte(new BigUInteger(byte.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToByteFractional() {
			ExecTest<byte>(BigUInteger.ToByte(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToSbyteMax() {
			ExecTest<sbyte>(BigUInteger.ToSByte(new BigUInteger(sbyte.MaxValue)),sbyte.MaxValue);
		}

		[TestMethod]
		public void ToSbyteMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToSByte(sbyte.MinValue);
			});
		}

		[TestMethod]
		public void ToSbyteMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToSByte(new BigUInteger(sbyte.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToSbyteMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToSByte(new BigUInteger(sbyte.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToSbyteFractional() {
			ExecTest<sbyte>(BigUInteger.ToSByte(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToIntMax() {
			ExecTest<int>(BigUInteger.ToInt32(new BigUInteger(int.MaxValue)),int.MaxValue);
		}

		[TestMethod]
		public void ToIntMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToInt32(int.MinValue);
			});
		}

		[TestMethod]
		public void ToIntMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToInt32(new BigUInteger(int.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToIntMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToInt32(new BigUInteger(int.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToIntFractional() {
			ExecTest<int>(BigUInteger.ToInt32(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToUintMax() {
			ExecTest<uint>(BigUInteger.ToUInt32(new BigUInteger(uint.MaxValue)),uint.MaxValue);
		}

		[TestMethod]
		public void ToUintMin() {
			ExecTest<uint>(BigUInteger.ToUInt32(new BigUInteger(uint.MinValue)),uint.MinValue);
		}

		[TestMethod]
		public void ToUintMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToUInt32(new BigUInteger(uint.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUintMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToUInt32(new BigUInteger(uint.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUintFractional() {
			ExecTest<uint>(BigUInteger.ToUInt32(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToShortMax() {
			ExecTest<short>(BigUInteger.ToInt16(new BigUInteger(short.MaxValue)),short.MaxValue);
		}

		[TestMethod]
		public void ToShortMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToInt16(short.MinValue);
			});
		}

		[TestMethod]
		public void ToShortMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToInt16(new BigUInteger(short.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToShortMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToInt16(new BigUInteger(short.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToShortFractional() {
			ExecTest<short>(BigUInteger.ToInt16(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToUshortMax() {
			ExecTest<ushort>(BigUInteger.ToUInt16(new BigUInteger(ushort.MaxValue)),ushort.MaxValue);
		}

		[TestMethod]
		public void ToUshortMin() {
			ExecTest<ushort>(BigUInteger.ToUInt16(new BigUInteger(ushort.MinValue)),ushort.MinValue);
		}

		[TestMethod]
		public void ToUshortMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToUInt16(new BigUInteger(ushort.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUshortMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToUInt16(new BigUInteger(ushort.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUshortFractional() {
			ExecTest<ushort>(BigUInteger.ToUInt16(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToLongMax() {
			ExecTest<long>(BigUInteger.ToInt64(new BigUInteger(long.MaxValue)),long.MaxValue);
		}

		[TestMethod]
		public void ToLongMin() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToInt64(long.MinValue);
			});
		}

		[TestMethod]
		public void ToLongMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToInt64(new BigUInteger(long.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToLongMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToInt64(new BigUInteger(long.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToLongFractional() {
			ExecTest<long>(BigUInteger.ToInt64(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToUlongMax() {
			ExecTest<ulong>(BigUInteger.ToUInt64(new BigUInteger(ulong.MaxValue)),ulong.MaxValue);
		}

		[TestMethod]
		public void ToUlongMin() {
			ExecTest<ulong>(BigUInteger.ToUInt64(new BigUInteger(ulong.MinValue)),ulong.MinValue);
		}

		[TestMethod]
		public void ToUlongMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToUInt64(new BigUInteger(ulong.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUlongMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToUInt64(new BigUInteger(ulong.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUlongFractional() {
			ExecTest<ulong>(BigUInteger.ToUInt64(new BigUInteger(5)/2),2);
		}

		[TestMethod]
		public void ToFloatMaxValue() {
			ExecTest<float>(BigUInteger.ToSingle(new BigUInteger(float.MaxValue)),float.MaxValue);
		}

		[TestMethod]
		public void ToFloatMinValue() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToSingle(float.MinValue);
			});
		}

		[TestMethod]
		public void ToFloatMaxOver() {
			ExecTest<float>(BigUInteger.ToSingle(new BigUInteger(float.MaxValue)+1),float.PositiveInfinity);
		}

		[TestMethod]
		public void ToFloatMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToSingle(new BigUInteger(float.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToFloatEpsilon() {
			ExecTest<float>(BigUInteger.ToSingle(new BigUInteger(float.Epsilon)),0f);
		}

		[TestMethod]
		public void ToFloatEpsilonLower() {
			ExecTest<float>(BigUInteger.ToSingle(new BigUInteger(float.Epsilon)/2),0);
		}

		[TestMethod]
		public void ToFloatZero() {
			ExecTest<float>(BigUInteger.ToSingle(new BigUInteger(0f)),0f);
		}

		[TestMethod]
		public void ToFloatNaN() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToSingle(float.NaN);
			});
		}

		[TestMethod]
		public void ToFloatNegativeInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToSingle(float.NegativeInfinity);
			});
		}

		[TestMethod]
		public void ToFloatPositiveInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToSingle(float.PositiveInfinity);
			});
		}

		[TestMethod]
		public void ToDoubleMaxValue() {
			ExecTest<double>(BigUInteger.ToDouble(new BigUInteger(double.MaxValue)),double.MaxValue);
		}

		[TestMethod]
		public void ToDoubleMinValue() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToDouble(double.MinValue);
			});
		}

		[TestMethod]
		public void ToDoubleMaxOver() {
			ExecTest<double>(BigUInteger.ToDouble(new BigUInteger(double.MaxValue)+1),double.PositiveInfinity);
		}

		[TestMethod]
		public void ToDoubleMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToDouble(new BigUInteger(double.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToDoubleEpsilon() {
			ExecTest<double>(BigUInteger.ToDouble(new BigUInteger(double.Epsilon)),0d);
		}

		[TestMethod]
		public void ToDoubleEpsilonLower() {
			ExecTest<double>(BigUInteger.ToDouble(new BigUInteger(double.Epsilon)/2),0);
		}

		[TestMethod]
		public void ToDoubleZero() {
			ExecTest<double>(BigUInteger.ToDouble(new BigUInteger(0d)),0d);
		}

		[TestMethod]
		public void ToDecimalMaxValue() {
			ExecTest<decimal>(BigUInteger.ToDecimal(new BigUInteger(decimal.MaxValue)),decimal.MaxValue);
		}

		[TestMethod]
		public void ToDecimalMinValue() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToDouble(decimal.MinValue);
			});
		}

		[TestMethod]
		public void ToDoubleNaN() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToDouble(double.NaN);
			});
		}

		[TestMethod]
		public void ToDoubleNegativeInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToDouble(double.NegativeInfinity);
			});
		}

		[TestMethod]
		public void ToDoublePositiveInfinity() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToDouble(double.PositiveInfinity);
			});
		}


		[TestMethod]
		public void ToDecimalMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToDecimal(new BigUInteger(decimal.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToDecimalMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = BigUInteger.ToDecimal(new BigUInteger(decimal.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToDecimalZero() {
			this.ExecTest<decimal>(BigUInteger.ToDecimal(new BigUInteger(0m)),0m);
		}

		[TestMethod]
		public void ToDecimalEpsilon() {
			var value = 1m;
			for(var counter = 0;counter<28;counter++) {
				value/=10;
			}
			this.ExecTest<decimal>(BigUInteger.ToDecimal(new BigUInteger(value)),0m);
		}

		[TestMethod]
		public void ToByteArrayPlus() {
			var value = new byte[255];
			for(byte counter = 0;counter<value.Length;counter++) {
				value[counter]=counter;
			}
			ExecTest(new BigUInteger(value),value);
		}

		[TestMethod]
		public void ToByteArrayZero() {
			var value = new byte[255];
			ExecTest(new BigUInteger(value),value);
		}

	}
}
