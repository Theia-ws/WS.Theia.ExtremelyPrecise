using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class Explicit {
		[TestMethod]
		public void Case1() {
			// Rational to Byte conversion.
			Rational goodByte = Rational.One;
			Rational badByte = 256;

			byte byteFromRational;

			// Successful conversion using cast operator.
			byteFromRational=(byte)goodByte;
			Console.WriteLine(byteFromRational);

			// Handle conversion that should result in overflow.
			try {
				byteFromRational=(byte)badByte;
				Console.WriteLine(byteFromRational);
			} catch(OverflowException e) {
				Console.WriteLine("Unable to convert {0}:\n   {1}",
								  badByte,e.Message);
			}
			Console.WriteLine();
		}
		[TestMethod]
		public void Case2() {
			// Rational to Byte conversion.
			Rational goodByte = Rational.One;
			Rational badByte = 256;

			byte byteFromRational;

			// Successful conversion using cast operator.
			byteFromRational=(byte)goodByte;
			Console.WriteLine(byteFromRational);

			// Handle conversion that should result in overflow.
			try {
				byteFromRational=(byte)badByte;
				Console.WriteLine(byteFromRational);
			} catch(OverflowException e) {
				Console.WriteLine("Unable to convert {0}:\n   {1}",
								  badByte,e.Message);
			}
			Console.WriteLine();
		}
		[TestMethod]
		public void Case3() {
			//Rational to Int32 conversion.
			Rational goodInteger = 200000;
			Rational badInteger = 65000000000;

			int integerFromRatioanl;

			// Successful conversion using cast operator. 
			integerFromRatioanl=(int)goodInteger;
			Console.WriteLine(integerFromRatioanl);

			// Handle conversion that should result in overflow.
			try {
				integerFromRatioanl=(int)badInteger;
				Console.WriteLine(integerFromRatioanl);
			} catch(OverflowException e) {
				Console.WriteLine("Unable to convert {0}:\n   {1}",
								  badInteger,e.Message);
			}
			Console.WriteLine();
		}
		[TestMethod]
		public void Case4() {
			// Rational to UInt32 conversion.
			Rational goodUInteger = 200000;
			Rational badUInteger = 65000000000;

			uint uIntegerFromRational;

			// Successful conversion using cast operator. 
			uIntegerFromRational=(uint)goodUInteger;
			Console.WriteLine(uIntegerFromRational);

			// Handle conversion that should result in overflow.
			try {
				uIntegerFromRational=(uint)badUInteger;
				Console.WriteLine(uIntegerFromRational);
			} catch(OverflowException e) {
				Console.WriteLine("Unable to convert {0}:\n   {1}",
								  badUInteger,e.Message);
			}
			Console.WriteLine();
		}
		[TestMethod]
		public void Case5() {
			// Rational to Int16 conversion.
			Rational goodShort = 20000;
			Rational badShort = 33000;

			short shortFromRational;

			// Successful conversion using cast operator. 
			shortFromRational=(short)goodShort;
			Console.WriteLine(shortFromRational);

			// Handle conversion that should result in overflow.
			try {
				shortFromRational=(short)badShort;
				Console.WriteLine(shortFromRational);
			} catch(OverflowException e) {
				Console.WriteLine("Unable to convert {0}:\n   {1}",
								  badShort,e.Message);
			}
			Console.WriteLine();
		}
		[TestMethod]
		public void Case6() {
			// Rational to UInt16 conversion.
			Rational goodUShort = 20000;
			Rational badUShort = 66000;

			ushort uShortFromRational;

			// Successful conversion using cast operator. 
			uShortFromRational=(ushort)goodUShort;
			Console.WriteLine(uShortFromRational);

			// Handle conversion that should result in overflow.
			try {
				uShortFromRational=(ushort)badUShort;
				Console.WriteLine(uShortFromRational);
			} catch(OverflowException e) {
				Console.WriteLine("Unable to convert {0}:\n   {1}",
								  badUShort,e.Message);
			}
			Console.WriteLine();
		}
		[TestMethod]
		public void Case7() {
			// Rational to Int64 conversion.
			Rational goodLong = 2000000000;
			Rational badLong = Math.Pow(goodLong,3);

			long longFromRational;

			// Successful conversion using cast operator. 
			longFromRational=(long)goodLong;
			Console.WriteLine(longFromRational);

			// Handle conversion that should result in overflow.
			try {
				longFromRational=(long)badLong;
				Console.WriteLine(longFromRational);
			} catch(OverflowException e) {
				Console.WriteLine("Unable to convert {0}:\n   {1}",
								  badLong,e.Message);
			}
			Console.WriteLine();
		}
		[TestMethod]
		public void Case8() {
			// Rational to UInt64 conversion.
			Rational goodULong = 2000000000;
			Rational badULong = Math.Pow(goodULong,3);

			ulong uLongFromRational;

			// Successful conversion using cast operator. 
			uLongFromRational=(ulong)goodULong;
			Console.WriteLine(uLongFromRational);

			// Handle conversion that should result in overflow.
			try {
				uLongFromRational=(ulong)badULong;
				Console.WriteLine(uLongFromRational);
			} catch(OverflowException e) {
				Console.WriteLine("Unable to convert {0}:\n   {1}",
								  badULong,e.Message);
			}
			Console.WriteLine();
		}
		[TestMethod]
		public void Case9() {
			// Rational to Single conversion.
			Rational goodSingle = 102.43e22F;
			Rational badSingle = float.MaxValue;
			badSingle=badSingle*2;

			float singleFromRational;

			// Successful conversion using cast operator. 
			singleFromRational=(float)goodSingle;
			Console.WriteLine(singleFromRational);

			// Convert an out-of-bounds Rational value to a Single.
			singleFromRational=(float)badSingle;
			Console.WriteLine(singleFromRational);
		}
		[TestMethod]
		public void Case10() {
			// Rational to Double conversion.
			Rational goodDouble = 102.43e22;
			Rational badDouble = Double.MaxValue;
			badDouble=badDouble*2;

			double doubleFromRational;

			// successful conversion using cast operator.
			doubleFromRational=(double)goodDouble;
			Console.WriteLine(doubleFromRational);

			// Convert an out-of-bounds Rational value to a Double.
			doubleFromRational=(double)badDouble;
			Console.WriteLine(doubleFromRational);
		}
		[TestMethod]
		public void Case11() {
			// Rational to Boolean conversion.
			Rational trueBoolean = 102.43e22;
			Rational falseBoolean = 0;

			bool booleanFromRational;

			// successful conversion using cast operator in value of true.
			booleanFromRational=(bool)trueBoolean;
			Console.WriteLine(booleanFromRational);

			// successful conversion using cast operator in value of false.
			booleanFromRational=(bool)falseBoolean;
			Console.WriteLine(booleanFromRational);
		}
		[TestMethod]
		public void Case12() {
			// Rational to Decimal conversion.
			Rational goodDecimal = 761652543;
			Rational badDecimal = Decimal.MaxValue;
			badDecimal+=Rational.One;

			Decimal decimalFromRational;

			// Successful conversion using cast operator.
			decimalFromRational=(decimal)goodDecimal;
			Console.WriteLine(decimalFromRational);

			// Handle conversion that should result in overflow.
			try {
				decimalFromRational=(decimal)badDecimal;
				Console.WriteLine(decimalFromRational);
			} catch(OverflowException e) {
				Console.WriteLine("Unable to convert {0}:\n   {1}",
								  badDecimal,e.Message);
			}
			Console.WriteLine();
		}
	}
}
