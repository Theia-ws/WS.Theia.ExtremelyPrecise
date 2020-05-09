using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {
	[TestClass]
	public class Initialize:TestBase {

		[TestMethod]
		public void FromBoolTrue() {
			ExecTest(new BigUInteger(true),new byte[] { 1 });
		}

		[TestMethod]
		public void FromBoolFalse() {
			ExecTest(new BigUInteger(false),new byte[] { 0 });
		}

		[TestMethod]
		public void FromBytePlus() {
			var value = new byte[sizeof(ContainerType)+1];
			for(var counter = 0;counter<value.Length;counter++) {
				value[counter]=byte.MaxValue;
			}
			ExecTest(new BigUInteger(value),value);
		}

		[TestMethod]
		public void FromByteZero() {
			var value = new byte[] { 0 };
			ExecTest(new BigUInteger(value),value);
		}

		[TestMethod]
		public void FromDecimalMaxValue() {
			ExecTest(new BigUInteger(decimal.MaxValue),new byte[] { 255,255,255,255,255,255,255,255,255,255,255,255,0 });
		}

		[TestMethod]
		public void FromDecimalOne() {
			ExecTest(new BigUInteger(decimal.One),new byte[] { 1 });
		}

		[TestMethod]
		public void FromDecimalZero() {
			ExecTest(new BigUInteger(decimal.Zero),new byte[] { 0 });
		}

		[TestMethod]
		public void FromDoubleMaxValue() {
			ExecTest(new BigUInteger(double.MaxValue),new byte[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,80,158,98,6,116,170,166,243,153,139,163,51,86,86,168,135,141,73,56,189,207,34,246,216,224,92,104,60,144,199,77,15,141,25,29,39,36,80,22,253,64,133,18,146,117,231,15,81,130,196,118,233,156,239,76,174,53,185,38,185,72,215,98,211,204,214,127,217,46,178,184,249,223,185,122,85,243,17,38,181,91,113,38,107,172,247,255,255,255,255,255,255,0 });
		}

		[TestMethod]
		public void FromDoubleEpsilon() {
			ExecTest(new BigUInteger(double.Epsilon),new byte[] { 0 });
		}

		[TestMethod]
		public void FromDoubleZero() {
			ExecTest(new BigUInteger(0d),new byte[] { 0 });
		}

		[TestMethod]
		public void FromIntMaxValue() {
			ExecTest(new BigUInteger(int.MaxValue),new byte[] { byte.MaxValue,byte.MaxValue,byte.MaxValue,127 });
		}

		[TestMethod]
		public void FromIntZero() {
			ExecTest(new BigUInteger((int)0),new byte[] { 0 });
		}

		[TestMethod]
		public void FromLongMaxValue() {
			ExecTest(new BigUInteger(long.MaxValue),new byte[] { byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,127 });
		}

		[TestMethod]
		public void FromLongZero() {
			ExecTest(new BigUInteger((long)0),new byte[] { 0 });
		}

		[TestMethod]
		public void FromFloatMaxValue() {
			ExecTest(new BigUInteger(float.MaxValue),new byte[] { 0,0,0,128,135,208,74,249,190,193,127,109,42,255,255,255,0 });
		}

		[TestMethod]
		public void FromFloatEpsilon() {
			ExecTest(new BigUInteger(float.Epsilon),new byte[] { 0 });
		}

		[TestMethod]
		public void FromFloatZero() {
			ExecTest(new BigUInteger(0f),new byte[] { 0 });
		}
		
		[TestMethod]
		public void FromUintMaxValue() {
			ExecTest(new BigUInteger(uint.MaxValue),new byte[] { byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue });
		}

		[TestMethod]
		public void FromUintZero() {
			ExecTest(new BigUInteger(uint.MinValue),new byte[] { 0 });
		}

		[TestMethod]
		public void FromUlongMaxValue() {
			ExecTest(new BigUInteger(ulong.MaxValue),new byte[] { byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue });
		}

		[TestMethod]
		public void FromUlongZero() {
			ExecTest(new BigUInteger(ulong.MinValue),new byte[] { 0 });
		}

		[TestMethod]
		public void FromContainerTypePlus() {
			var value = new ContainerType[] { ContainerType.MaxValue,1 };

			var byteValue = new byte[sizeof(ContainerType)+1];
			for(var counter = 0;counter<sizeof(ContainerType);counter++) {
				byteValue[counter]=byte.MaxValue;
			}
			byteValue[sizeof(ContainerType)]=1;

			ExecTest(CreateObjectCT(value),byteValue);
		}

		[TestMethod]
		public void FromContainerTypeZero() {
			var value = new ContainerType[] { 0 };
			ExecTest(CreateObjectCT(value),new byte[] { 0 });
		}
		
	}
}