using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class Implicit {
		[TestMethod]
		public void Case1() {
			byte byteValue = 254;
			Rational number = byteValue;
			number=Rational.Add(number,byteValue);
			Console.WriteLine(number>byteValue);            // Displays True   
		}
		[TestMethod]
		public void Case2() {
			sbyte sByteValue = -12;
			Rational number = Math.Pow(sByteValue,3);
			Console.WriteLine(number<sByteValue);            // Displays True    
		}
		[TestMethod]
		public void Case3() {
			int intValue = 65000;
			Rational number = intValue;
			number=Rational.Multiply(number,intValue);
			Console.WriteLine(number==intValue);            // Displays False  
		}
		[TestMethod]
		public void Case4() {
			uint uIntValue = 65000;
			Rational number = uIntValue;
			number=Rational.Multiply(number,uIntValue);
			Console.WriteLine(number==uIntValue);           // Displays False
		}
		[TestMethod]
		public void Case5() {
			short shortValue = 25064;
			Rational number = shortValue;
			number+=shortValue;
			Console.WriteLine(number<shortValue);           // Displays False
		}
		[TestMethod]
		public void Case6() {
			ushort uShortValue = 25064;
			Rational number = uShortValue;
			number+=uShortValue;
			Console.WriteLine(number<uShortValue);           // Displays False
		}
		[TestMethod]
		public void Case7() {
			long longValue = 1358754982;
			Rational number = longValue;
			number=number+(longValue/2);
			Console.WriteLine(number*longValue/longValue); // Displays 2038132473
		}
		[TestMethod]
		public void Case8() {
			ulong uLongValue = 1358754982;
			Rational number = uLongValue;
			number=number*2-uLongValue;
			Console.WriteLine(number*uLongValue/uLongValue); // Displays 1358754982
		}
		[TestMethod]
		public void Case9() {
			//TODO:FLOAT,DOUBLE系初期化問題？
			float floatValue = 135875498.25f;
			Rational number = floatValue;
			number=number*2-floatValue;
			Console.WriteLine(number*floatValue/floatValue); // Displays 135875498.25
		}
		[TestMethod]
		public void Case10() {
			double doubleValue = 135875498.25;
			Rational number = doubleValue;
			number=number*2-doubleValue;
			Console.WriteLine(number*doubleValue/doubleValue); // Displays 135875498.25
		}
		[TestMethod]
		public void Case11() {
			bool boolValue = true;
			Rational number = boolValue;
			number=number*2-boolValue;
			Console.WriteLine(number*boolValue/boolValue); // Displays 1
		}
		[TestMethod]
		public void Case12() {
			decimal decimalValue = 135875498.2m;
			Rational number = decimalValue;
			number=number*2-decimalValue;
			Console.WriteLine(number*decimalValue/decimalValue); // Displays 135875498.2
		}
	}
}
