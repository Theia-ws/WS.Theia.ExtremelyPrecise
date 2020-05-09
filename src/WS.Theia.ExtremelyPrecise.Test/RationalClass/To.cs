using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class To:TestBase {

		[TestMethod]
		public void ToByteMax() {
			ExecTest<byte>(Rational.ToByte(new Rational(byte.MaxValue)),byte.MaxValue);
		}

		[TestMethod]
		public void ToByteMin() {
			ExecTest<byte>(Rational.ToByte(new Rational(byte.MinValue)),byte.MinValue);
		}

		[TestMethod]
		public void ToByteMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToByte(new Rational(byte.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToByteMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToByte(new Rational(byte.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToByteFractional() {
			ExecTest<byte>(Rational.ToByte(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToSbyteMax() {
			ExecTest<sbyte>(Rational.ToSByte(new Rational(sbyte.MaxValue)),sbyte.MaxValue);
		}

		[TestMethod]
		public void ToSbyteMin() {
			ExecTest<sbyte>(Rational.ToSByte(new Rational(sbyte.MinValue)),sbyte.MinValue);
		}

		[TestMethod]
		public void ToSbyteMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToSByte(new Rational(sbyte.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToSbyteMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToSByte(new Rational(sbyte.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToSbyteFractional() {
			ExecTest<sbyte>(Rational.ToSByte(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToIntMax() {
			ExecTest<int>(Rational.ToInt32(new Rational(int.MaxValue)),int.MaxValue);
		}

		[TestMethod]
		public void ToIntMin() {
			ExecTest<int>(Rational.ToInt32(new Rational(int.MinValue)),int.MinValue);
		}

		[TestMethod]
		public void ToIntMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToInt32(new Rational(int.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToIntMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToInt32(new Rational(int.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToIntFractional() {
			ExecTest<int>(Rational.ToInt32(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToUintMax() {
			ExecTest<uint>(Rational.ToUInt32(new Rational(uint.MaxValue)),uint.MaxValue);
		}

		[TestMethod]
		public void ToUintMin() {
			ExecTest<uint>(Rational.ToUInt32(new Rational(uint.MinValue)),uint.MinValue);
		}

		[TestMethod]
		public void ToUintMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToUInt32(new Rational(uint.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUintMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToUInt32(new Rational(uint.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUintFractional() {
			ExecTest<uint>(Rational.ToUInt32(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToShortMax() {
			ExecTest<short>(Rational.ToInt16(new Rational(short.MaxValue)),short.MaxValue);
		}

		[TestMethod]
		public void ToShortMin() {
			ExecTest<short>(Rational.ToInt16(new Rational(short.MinValue)),short.MinValue);
		}

		[TestMethod]
		public void ToShortMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToInt16(new Rational(short.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToShortMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToInt16(new Rational(short.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToShortFractional() {
			ExecTest<short>(Rational.ToInt16(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToUshortMax() {
			ExecTest<ushort>(Rational.ToUInt16(new Rational(ushort.MaxValue)),ushort.MaxValue);
		}

		[TestMethod]
		public void ToUshortMin() {
			ExecTest<ushort>(Rational.ToUInt16(new Rational(ushort.MinValue)),ushort.MinValue);
		}

		[TestMethod]
		public void ToUshortMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToUInt16(new Rational(ushort.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUshortMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToUInt16(new Rational(ushort.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUshortFractional() {
			ExecTest<ushort>(Rational.ToUInt16(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToLongMax() {
			ExecTest<long>(Rational.ToInt64(new Rational(long.MaxValue)),long.MaxValue);
		}

		[TestMethod]
		public void ToLongMin() {
			ExecTest<long>(Rational.ToInt64(new Rational(long.MinValue)),long.MinValue);
		}

		[TestMethod]
		public void ToLongMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToInt64(new Rational(long.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToLongMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToInt64(new Rational(long.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToLongFractional() {
			ExecTest<long>(Rational.ToInt64(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToUlongMax() {
			ExecTest<ulong>(Rational.ToUInt64(new Rational(ulong.MaxValue)),ulong.MaxValue);
		}

		[TestMethod]
		public void ToUlongMin() {
			ExecTest<ulong>(Rational.ToUInt64(new Rational(ulong.MinValue)),ulong.MinValue);
		}

		[TestMethod]
		public void ToUlongMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToUInt64(new Rational(ulong.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToUlongMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToUInt64(new Rational(ulong.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToUlongFractional() {
			ExecTest<ulong>(Rational.ToUInt64(new Rational(5)/2),2);
		}

		[TestMethod]
		public void ToFloatMaxValue() {
			ExecTest<float>(Rational.ToSingle(new Rational(float.MaxValue)),float.MaxValue);
		}

		[TestMethod]
		public void ToFloatMinValue() {
			ExecTest<float>(Rational.ToSingle(new Rational(float.MinValue)),float.MinValue);
		}

		[TestMethod]
		public void ToFloatMaxOver() {
			ExecTest<float>(Rational.ToSingle(new Rational(float.MaxValue)+1),float.PositiveInfinity);
		}

		[TestMethod]
		public void ToFloatMinOver() {
			ExecTest<float>(Rational.ToSingle(new Rational(float.MinValue)-1),float.NegativeInfinity);
		}

		[TestMethod]
		public void ToFloatEpsilon() {
			ExecTest<float>(Rational.ToSingle(new Rational(float.Epsilon)),float.Epsilon);
		}

		[TestMethod]
		public void ToFloatEpsilonLower() {
			ExecTest<float>(Rational.ToSingle(new Rational(float.Epsilon)/2),0);
		}

		[TestMethod]
		public void ToFloatZero() {
			ExecTest<float>(Rational.ToSingle(new Rational(0f)),0f);
		}

		[TestMethod]
		public void ToFloatNaN() {
			ExecTest<float>(Rational.ToSingle(new Rational(float.NaN)),float.NaN);
		}

		[TestMethod]
		public void ToFloatNegativeInfinity() {
			ExecTest<float>(Rational.ToSingle(new Rational(float.NegativeInfinity)),float.NegativeInfinity);
		}

		[TestMethod]
		public void ToFloatPositiveInfinity() {
			ExecTest<float>(Rational.ToSingle(new Rational(float.PositiveInfinity)),float.PositiveInfinity);
		}

		[TestMethod]
		public void ToDoubleMaxValue() {
			ExecTest<double>(Rational.ToDouble(new Rational(double.MaxValue)),double.MaxValue);
		}

		[TestMethod]
		public void ToDoubleMinValue() {
			ExecTest<double>(Rational.ToDouble(new Rational(double.MinValue)),double.MinValue);
		}

		[TestMethod]
		public void ToDoubleMaxOver() {
			ExecTest<double>(Rational.ToDouble(new Rational(double.MaxValue)+1),double.PositiveInfinity);
		}

		[TestMethod]
		public void ToDoubleMinOver() {
			ExecTest<double>(Rational.ToDouble(new Rational(double.MinValue)-1),double.NegativeInfinity);
		}

		[TestMethod]
		public void ToDoubleEpsilon() {
			ExecTest<double>(Rational.ToDouble(new Rational(double.Epsilon)),double.Epsilon);
		}

		[TestMethod]
		public void ToDoubleEpsilonLower() {
			ExecTest<double>(Rational.ToDouble(new Rational(double.Epsilon)/2),0);
		}

		[TestMethod]
		public void ToDoubleZero() {
			ExecTest<double>(Rational.ToDouble(new Rational(0d)),0d);
		}


		[TestMethod]
		public void ToDoubleNaN() {
			ExecTest<double>(Rational.ToDouble(new Rational(double.NaN)),double.NaN);
		}

		[TestMethod]
		public void ToDoubleNegativeInfinity() {
			ExecTest<double>(Rational.ToDouble(new Rational(double.NegativeInfinity)),double.NegativeInfinity);
		}

		[TestMethod]
		public void ToDoublePositiveInfinity() {
			ExecTest<double>(Rational.ToDouble(new Rational(double.PositiveInfinity)),double.PositiveInfinity);
		}

		[TestMethod]
		public void ToDecimalMaxValue() {
			ExecTest<decimal>(Rational.ToDecimal(new Rational(decimal.MaxValue)),decimal.MaxValue);
		}

		[TestMethod]
		public void ToDecimalMinValue() {
			ExecTest<decimal>(Rational.ToDecimal(new Rational(decimal.MinValue)),decimal.MinValue);
		}

		[TestMethod]
		public void ToDecimalMaxOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToDecimal(new Rational(decimal.MaxValue)+1);
			});
		}

		[TestMethod]
		public void ToDecimalMinOver() {
			Assert.ThrowsException<OverflowException>(() => {
				var castedVal = Rational.ToDecimal(new Rational(decimal.MinValue)-1);
			});
		}

		[TestMethod]
		public void ToDecimalZero() {
			this.ExecTest<decimal>(Rational.ToDecimal(new Rational(0m)),0m);
		}

		[TestMethod]
		public void ToDecimalEpsilon() {
			var value = 1m;
			for(var counter = 0;counter<28;counter++) {
				value/=10;
			}
			this.ExecTest<decimal>(Rational.ToDecimal(new Rational(value)),value);
		}

		[TestMethod]
		public void ToByteArrayPlus() {
			var sign = false;
			var numerator = new byte[255];
			var denominator = new byte[255];
			for(byte counter = 0;counter<numerator.Length;counter++) {
				numerator[counter]=counter;
			}
			for(byte counter = (byte)(denominator.Length-1);counter!=byte.MaxValue;counter--) {
				denominator[counter]=counter;
			}
			var infinity = false;
			var (Sign, Numerator, Denominator, Infinity)=new Rational(sign,numerator,denominator).ToByteArray();
			ExecTest(Sign,Numerator,Denominator,Infinity,sign,numerator,denominator,infinity);
		}

		[TestMethod]
		public void ToByteArrayZero() {
			var sign = false;
			var numerator = new byte[255];
			var denominator = new byte[255];
			denominator[10]=1;
			var infinity = false;
			var (Sign, Numerator, Denominator, Infinity)=new Rational(sign,numerator,denominator).ToByteArray();
			ExecTest(Sign,Numerator,Denominator,Infinity,sign,numerator,denominator,infinity);
		}

		[TestMethod]
		public void ToByteArrayMinus() {
			var sign = true;
			var numerator = new byte[255];
			var denominator = new byte[255];
			for(byte counter = 0;counter<numerator.Length;counter++) {
				numerator[counter]=counter;
			}
			for(byte counter = (byte)(denominator.Length-1);counter!=byte.MaxValue;counter--) {
				denominator[counter]=counter;
			}
			var infinity = false;
			var (Sign, Numerator, Denominator, Infinity)=new Rational(sign,numerator,denominator).ToByteArray();
			ExecTest(Sign,Numerator,Denominator,Infinity,sign,numerator,denominator,infinity);
		}

		[TestMethod]
		public void ToByteArrayNegativeInfinity() {
			var sign = true;
			var numerator = new byte[] { 1 };
			var denominator = new byte[] { 1 };
			var infinity = true;
			var (Sign, Numerator, Denominator, Infinity)=Rational.NegativeInfinity.ToByteArray();
			ExecTest(Sign,Numerator,Denominator,Infinity,sign,numerator,denominator,infinity);
		}

		[TestMethod]
		public void ToByteArrayPositiveInfinity() {
			var sign = false;
			var numerator = new byte[] { 1 };
			var denominator = new byte[] { 1 };
			var infinity = true;
			var (Sign, Numerator, Denominator, Infinity)=Rational.PositiveInfinity.ToByteArray();
			ExecTest(Sign,Numerator,Denominator,Infinity,sign,numerator,denominator,infinity);
		}

		[TestMethod]
		public void ToByteArrayNaN() {
			var sign = false;
			var numerator = new byte[] { 0 };
			var denominator = new byte[] { 0 };
			var infinity = false;
			var (Sign, Numerator, Denominator, Infinity)=Rational.NaN.ToByteArray();
			ExecTest(Sign,Numerator,Denominator,Infinity,sign,numerator,denominator,infinity);
		}

	}
}
