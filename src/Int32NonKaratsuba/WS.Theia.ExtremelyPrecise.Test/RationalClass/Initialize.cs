using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContainerType = System.UInt32;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {
	[TestClass]
	public class Initialize:TestBase {

		[TestMethod]
		public void FromBoolTrue() {
			ExecTest(new Rational(true),false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromBoolFalse() {
			ExecTest(new Rational(false),false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromBytePlus() {
			var numurator = new byte[sizeof(ContainerType)+1];
			for(var counter = 0;counter<numurator.Length;counter++) {
				numurator[counter]=byte.MaxValue;
			}
			var denominator = new byte[sizeof(ContainerType)+1];
			for(var counter = 1;counter<denominator.Length;counter++) {
				denominator[counter]=byte.MaxValue;
			}
			ExecTest(new Rational(false,numurator,denominator),false,numurator,denominator,false);
		}

		[TestMethod]
		public void FromByteMinus() {
			var numurator = new byte[sizeof(ContainerType)+1];
			for(var counter = 0;counter<numurator.Length;counter++) {
				numurator[counter]=byte.MaxValue;
			}
			var denominator = new byte[sizeof(ContainerType)+1];
			for(var counter = 1;counter<denominator.Length;counter++) {
				denominator[counter]=byte.MaxValue;
			}
			ExecTest(new Rational(true,numurator,denominator),true,numurator,denominator,false);
		}

		[TestMethod]
		public void FromByteZero() {
			var numurator = new byte[] { 0 };
			var denominator = new byte[] { 1 };
			ExecTest(new Rational(true,numurator,denominator),true,numurator,denominator,false);
		}

		[TestMethod]
		public void FromDecimalMaxValue() {
			ExecTest(new Rational(decimal.MaxValue),false,new byte[] { 255,255,255,255,255,255,255,255,255,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDecimalMinValue() {
			ExecTest(new Rational(decimal.MinValue),true,new byte[] { 255,255,255,255,255,255,255,255,255,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDecimalMinusOne() {
			ExecTest(new Rational(decimal.MinusOne),true,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDecimalOne() {
			ExecTest(new Rational(decimal.One),false,new byte[] { 1 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDecimalZero() {
			ExecTest(new Rational(decimal.Zero),false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDoubleMaxValue() {
			ExecTest(new Rational(double.MaxValue),false,new byte[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,80,158,98,6,116,170,166,243,153,139,163,51,86,86,168,135,141,73,56,189,207,34,246,216,224,92,104,60,144,199,77,15,141,25,29,39,36,80,22,253,64,133,18,146,117,231,15,81,130,196,118,233,156,239,76,174,53,185,38,185,72,215,98,211,204,214,127,217,46,178,184,249,223,185,122,85,243,17,38,181,91,113,38,107,172,247,255,255,255,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDoubleMinValue() {
			ExecTest(new Rational(double.MinValue),true,new byte[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,80,158,98,6,116,170,166,243,153,139,163,51,86,86,168,135,141,73,56,189,207,34,246,216,224,92,104,60,144,199,77,15,141,25,29,39,36,80,22,253,64,133,18,146,117,231,15,81,130,196,118,233,156,239,76,174,53,185,38,185,72,215,98,211,204,214,127,217,46,178,184,249,223,185,122,85,243,17,38,181,91,113,38,107,172,247,255,255,255,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromDoubleEpsilon() {
			ExecTest(new Rational(double.Epsilon),false,new byte[] { 119,248,205,29,129,195,87 },new byte[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,136,9,116,27,61,99,207,20,11,122,133,159,164,249,103,211,210,187,209,17,95,82,193,45,81,230,23,57,136,154,63,162,78,95,220,9,97,84,39,25,166,228,214,25,79,94,93,127,86,59,153,16,38,23,153,230,9,31,218,72,127,56,155,108,174,221,194,75,10,161,126,13,102,35,252,110,28,115,233,195,131,180,139,104,1,13,255,248,90,31,215,213,220,225,55,119,4,14,95,1 },false);
		}

		[TestMethod]
		public void FromDoubleZero() {
			ExecTest(new Rational(0d),false,new byte[] { 0 },new byte[] { 1 },false);
		}


		[TestMethod]
		public void FromDoubleNaN() {
			ExecTest(new Rational(double.NaN),false,new byte[] { 0 },new byte[] { 0 },false);
		}

		[TestMethod]
		public void FromDoubleNegativeInfinity() {
			ExecTest(new Rational(double.NegativeInfinity),true,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void FromDoublePositiveInfinity() {
			ExecTest(new Rational(double.PositiveInfinity),false,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void FromIntMaxValue() {
			ExecTest(new Rational(int.MaxValue),false,new byte[] { byte.MaxValue,byte.MaxValue,byte.MaxValue,127 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromIntMinValue() {
			ExecTest(new Rational(int.MinValue),true,new byte[] { 0,0,0,128 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromIntZero() {
			ExecTest(new Rational((int)0),false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromLongMaxValue() {
			ExecTest(new Rational(long.MaxValue),false,new byte[] { byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,127 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromLongMinValue() {
			ExecTest(new Rational(long.MinValue),true,new byte[] { 0,0,0,0,0,0,0,128 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromLongZero() {
			ExecTest(new Rational((long)0),false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromFloatMaxValue() {
			ExecTest(new Rational(float.MaxValue),false,new byte[] { 0,0,0,128,135,208,74,249,190,193,127,109,42,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromFloatMinValue() {
			ExecTest(new Rational(float.MinValue),true,new byte[] { 0,0,0,128,135,208,74,249,190,193,127,109,42,255,255,255,0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromFloatEpsilon() {
			ExecTest(new Rational(float.Epsilon),false,new byte[] { 165,195,42 },new byte[] { 0,0,0,0,0,0,208,43,210,35,104,80,119,156,2,112,127,183,157,116,88,5 },false);
		}

		[TestMethod]
		public void FromFloatZero() {
			ExecTest(new Rational(0f),false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromFloatNaN() {
			ExecTest(new Rational(float.NaN),false,new byte[] { 0 },new byte[] { 0 },false);
		}

		[TestMethod]
		public void FromFloatNegativeInfinity() {
			ExecTest(new Rational(float.NegativeInfinity),true,new byte[] { 1 },new byte[] { 1 },true);
		}

		[TestMethod]
		public void FromFloatPositiveInfinity() {
			ExecTest(new Rational(float.PositiveInfinity),false,new byte[] { 1 },new byte[] { 1 },true);
		}


		[TestMethod]
		public void FromUintMaxValue() {
			ExecTest(new Rational(uint.MaxValue),false,new byte[] { byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromUintZero() {
			ExecTest(new Rational(uint.MinValue),false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromUlongMaxValue() {
			ExecTest(new Rational(ulong.MaxValue),false,new byte[] { byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue,byte.MaxValue },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromUlongZero() {
			ExecTest(new Rational(ulong.MinValue),false,new byte[] { 0 },new byte[] { 1 },false);
		}

		[TestMethod]
		public void FromContainerTypePlus() {
			var numurator = new ContainerType[] { ContainerType.MaxValue,1 };
			var denominator = new ContainerType[] { 0,2 };

			var byteNumurator = new byte[sizeof(ContainerType)+1];
			for(var counter = 0;counter<sizeof(ContainerType);counter++) {
				byteNumurator[counter]=byte.MaxValue;
			}
			byteNumurator[sizeof(ContainerType)]=1;
			var byteDenominator = new byte[sizeof(ContainerType)+1];
			for(var counter = 0;counter<sizeof(ContainerType);counter++) {
				byteDenominator[counter]=0;
			}
			byteDenominator[sizeof(ContainerType)]=2;

			ExecTest(CreateObjectCT(false,numurator,denominator),false,byteNumurator,byteDenominator,false);
		}

		[TestMethod]
		public void FromContainerTypeMinus() {
			var numurator = new ContainerType[] { ContainerType.MaxValue,1 };
			var denominator = new ContainerType[] { 0,2 };

			var byteNumurator = new byte[sizeof(ContainerType)+1];
			for(var counter = 0;counter<sizeof(ContainerType);counter++) {
				byteNumurator[counter]=byte.MaxValue;
			}
			byteNumurator[sizeof(ContainerType)]=1;
			var byteDenominator = new byte[sizeof(ContainerType)+1];
			for(var counter = 0;counter<sizeof(ContainerType);counter++) {
				byteDenominator[counter]=0;
			}
			byteDenominator[sizeof(ContainerType)]=2;

			ExecTest(CreateObjectCT(true,numurator,denominator),true,byteNumurator,byteDenominator,false);
		}

		[TestMethod]
		public void FromContainerTypeZero() {
			var numurator = new ContainerType[] { 0 };
			var denominator = new ContainerType[] { 1 };
			ExecTest(CreateObjectCT(true,numurator,denominator),true,new byte[] { 0 },new byte[] { 1 },false);
		}
		
	}
}