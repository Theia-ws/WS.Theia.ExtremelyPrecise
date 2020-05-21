using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example {
	[TestClass]
	public class Class {
		[TestMethod]
		public void Case1() {
			Rational rationalFromDouble = new Rational(179032.6541);
			Console.WriteLine(rationalFromDouble);
			Rational rationalFromInt64 = new Rational(934157136952);
			Console.WriteLine(rationalFromInt64);
			// The example displays the following output:
			//   179032.6541
			//   934157136952
		}
		[TestMethod]
		public void Case2() {
			long longValue = 6315489358112;
			Rational assignedFromLong = longValue;
			Console.WriteLine(assignedFromLong);
			// The example displays the following output:
			//   6315489358112
		}
		[TestMethod]
		public void Case3() {
			Rational assignedFromDouble = 179032.6541;
			Console.WriteLine(assignedFromDouble);
			Rational assignedFromDecimal = 64312.65m;
			Console.WriteLine(assignedFromDecimal);
			// The example displays the following output:
			//   179032.6541
			//   64312.65
		}
		[TestMethod]
		public void Case4() {
			bool sign = false;
			byte[] numerator = { 10,9,8,7,6,5,4,3,2,1,0 };
			byte[] denominator = { 1 };
			Rational rational = new Rational(sign,numerator,denominator);
			Console.WriteLine("The value of Rational is {0}.",rational);
			// The example displays the following output:
			//   The value of Rational is 4759477275222530853130.
		}
		[TestMethod]
		public void Case5() {
			string positiveString = "91389681247993671255432112000000";
			string negativeString = "-90315837410896312071002088037140000";
			Rational posRational = 0;
			Rational negRational = 0;
			bool status = false;

			try {
				posRational=Rational.Parse(positiveString);
				Console.WriteLine(posRational);
			} catch(FormatException) {
				Console.WriteLine("Unable to convert the string '{0}' to a Rational value.",positiveString);
			}

			(status, negRational)=Rational.TryParse(negativeString);
			if(status)
				Console.WriteLine(negRational);
			else
				Console.WriteLine("Unable to convert the string '{0}' to a Rational value.",negativeString);

			// The example displays the following output:
			//   91389681247993671255432112000000
			//   -90315837410896312071002088037140000
		}
		[TestMethod]
		public void Case6() {
			Rational number = Math.Pow(UInt64.MaxValue,3);
			Console.WriteLine(number);
			// The example displays the following output:
			//    6277101735386680762814942322444851025767571854389858533375
		}
		[TestMethod]
		public void Case7() {
			Rational number = Rational.Multiply(Int64.MaxValue,3);
			number++;
			Console.WriteLine(number);
		}
		//TODO:大変重いのでコメントアウト
		/*[TestMethod]
		public void Case8() {
			bool SomeOperationSucceeds() {
				return true;
			}
			Rational number = Int64.MaxValue^5;
			int repetitions = 1000000;
			// Perform some repetitive operation 1 million times.
			for(int ctr = 0;ctr<=repetitions;ctr++) {
				// Perform some operation. If it fails, exit the loop.
				if(!SomeOperationSucceeds()) break;
				// The following code executes if the operation succeeds.
				number++;
			}
		}*/
		[TestMethod]
		public void Case9() {
			bool SomeOperationSucceeds() {
				return true;
			}
			Rational number = Int64.MaxValue^5;
			int repetitions = 1000000;
			int actualRepetitions = 0;
			// Perform some repetitive operation 1 million times.
			for(int ctr = 0;ctr<=repetitions;ctr++) {
				// Perform some operation. If it fails, exit the loop.
				if(!SomeOperationSucceeds()) break;
				// The following code executes if the operation succeeds.
				actualRepetitions++;
			}
			number+=actualRepetitions;
		}
		[TestMethod]
		public void Case10() {
			Rational number = Math.Pow(Int64.MaxValue,2);
			Console.WriteLine(number);

			// Write the BigInteger value to a byte array.
			var bytes = number.ToByteArray();

			// Display the byte array.
			foreach(byte byteValue in bytes.Numerator)
				Console.Write("0x{0:X2} ",byteValue);
			Console.WriteLine();

			// Restore the Rational value from a Byte array.
			Rational newNumber = new Rational(bytes.Sign,bytes.Numerator,bytes.Denominator);
			Console.WriteLine(newNumber);
			// The example displays the following output:
			//    85070591730234615847396907784232501249
			//    0x01 0x00 0x00 0x00 0x00 0x00 0x00 0x00 0xFF 0xFF 0xFF 0xFF 0xFF 0xFF 0xFF 0x3F
			//    
			//    85070591730234615847396907784232501249
		}
		[TestMethod]
		public void Case11() {
			short originalValue = 30000;
			Console.WriteLine(originalValue);

			// Convert the Int16 value to a byte array.
			byte[] bytes = BitConverter.GetBytes(originalValue);

			// Display the byte array.
			foreach(byte byteValue in bytes)
				Console.Write("0x{0} ",byteValue.ToString("X2"));
			Console.WriteLine();

			// Pass byte array to the Rational constructor.
			Rational number = new Rational(false,bytes,new byte[] { 1 });
			Console.WriteLine(number);
			// The example displays the following output:
			//       30000
			//       0x30 0x75
			//       30000

		}
		[TestMethod]
		public void Case12() {
			uint[] unsignedValues = { 0,16704,199365,UInt32.MaxValue };
			foreach(uint unsignedValue in unsignedValues) {
				Rational constructedNumber = new Rational(unsignedValue);
				Rational assignedNumber = unsignedValue;
				if(constructedNumber.Equals(assignedNumber))
					Console.WriteLine("Both methods create a Rational whose value is {0:N0}.",
									  constructedNumber);
				else
					Console.WriteLine("{0:N0} ≠ {1:N0}",constructedNumber,assignedNumber);

			}
			// The example displays the following output:
			//    Both methods create a Rational whose value is 0.
			//    Both methods create a Rational r whose value is 16,704.
			//    Both methods create a Rational whose value is 199,365.
			//    Both methods create a Rational whose value is 4,294,967,295.
		}
		[TestMethod]
		public void Case13() {
			ulong unsignedValue = UInt64.MaxValue;
			Rational number = new Rational(unsignedValue);
			Console.WriteLine(number.ToString("N0"));
			// The example displays the following output:
			//       18,446,744,073,709,551,615      
		}
	}
}
