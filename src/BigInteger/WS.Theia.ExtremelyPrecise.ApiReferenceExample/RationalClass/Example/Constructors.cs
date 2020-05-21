using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example {
	[TestClass]
	public class Constructors {
		[TestMethod]
		public void Case1() {
			Rational number = new Rational(true);
			Console.WriteLine("The value of number is {0}.",number);
			// The example displays the following output:
			//    The value of number is 1.   
		}
		[TestMethod]
		public void Case2() {
			bool sign = false;
			byte[] numerator = { 5,4,3,2,1 };
			byte[] denominator = { 1 };
			Rational number = new Rational(sign,numerator,denominator);
			Console.WriteLine("The value of number is {0}.",number);
			// The example displays the following output:
			//    The value of number is 4328719365.  
		}
		[TestMethod]
		public void Case3() {
			bool sign = true;
			byte[] numerator = { 5,4,3,2,1 };
			byte[] denominator = { 1 };
			Rational number = new Rational(sign,numerator,denominator);
			Console.WriteLine("The value of number is {0}.",number);
			// The example displays the following output:
			//    The value of number is -4328719365.   
		}
		[TestMethod]
		public void Case4() {
			decimal[] decimalValues = { -1790.533m,-15.1514m,18903.79m,9180098.003m };
			foreach(decimal decimalValue in decimalValues) {
				Rational number = new Rational(decimalValue);
				Console.WriteLine("Instantiated Rational value {0} from the Decimal value {1}.",
								  number,decimalValue);
			}
			// The example displays the following output:
			//    Instantiated Rational value -1790.533 from the Decimal value -1790.533.
			//    Instantiated Rational value -15.1514. from the Decimal value -15.1514.
			//    Instantiated Rational value 18903.79 from the Decimal value 18903.79.
			//    Instantiated Rational value 9180098.003 from the Decimal value 9180098.003.
		}
		[TestMethod]
		public void Case5() {
			// Create a Rational from a large double value.
			double doubleValue = -6e20;
			Rational rationalValue = new Rational(doubleValue);
			Console.WriteLine("Original Double value: {0:N0}",doubleValue);
			Console.WriteLine("Original Rational value: {0:N0}",rationalValue);
			// Increment and then display both values.
			doubleValue++;
			rationalValue+=Rational.One;
			Console.WriteLine("Incremented Double value: {0:N0}",doubleValue);
			Console.WriteLine("Incremented Rational value: {0:N0}",rationalValue);
			// The example displays the following output:
			//    Original Double value: -600,000,000,000,000,000,000
			//    Original Rational value: -600,000,000,000,000,000,000
			//    Incremented Double value: -600,000,000,000,000,000,000
			//    Incremented Rational value: -599,999,999,999,999,999,999
		}
		[TestMethod]
		public void Case6() {
			int[] integers = { Int32.MinValue, -10534, -189, 0, 17, 113439,
				   Int32.MaxValue };
			Rational constructed, assigned;

			foreach(int number in integers) {
				constructed=new Rational(number);
				assigned=number;
				Console.WriteLine("{0} = {1}: {2}",constructed,assigned,
								  constructed.Equals(assigned));
			}
			// The example displays the following output:
			//       -2147483648 = -2147483648: True
			//       -10534 = -10534: True
			//       -189 = -189: True
			//       0 = 0: True
			//       17 = 17: True
			//       113439 = 113439: True
			//       2147483647 = 2147483647: True     
		}
		[TestMethod]
		public void Case7() {
			long[] longs = { Int64.MinValue, -10534, -189, 0, 17, 113439,
				 Int64.MaxValue };
			Rational constructed, assigned;

			foreach(long number in longs) {
				constructed=new Rational(number);
				assigned=number;
				Console.WriteLine("{0} = {1}: {2}",constructed,assigned,
								  constructed.Equals(assigned));
			}
			// The example displays the following output:
			//       - 9223372036854775808 = - 9223372036854775808: True
			//       -10534 = -10534: True
			//       -189 = -189: True
			//       0 = 0: True
			//       17 = 17: True
			//       113439 = 113439: True
			//       9223372036854775807 = 9223372036854775807: True    
		}
		[TestMethod]
		public void Case8() {
			// Create a BigInteger from a large negative Single value
			float negativeSingle = Single.MinValue;
			Rational negativeNumber = new Rational(negativeSingle);

			Console.WriteLine(negativeSingle.ToString("N0"));
			Console.WriteLine(negativeNumber.ToString("N0"));

			negativeSingle++;
			negativeNumber++;

			Console.WriteLine(negativeSingle.ToString("N0"));
			Console.WriteLine(negativeNumber.ToString("N0"));
			// The example displays the following output:
			//       -340,282,300,000,000,000,000,000,000,000,000,000,000
			//       -340,282,350,000,000,000,000,000,000,000,000,000,000
			//       -340,282,300,000,000,000,000,000,000,000,000,000,000
			//       -340,282,349,999,999,999,999,999,999,999,999,999,999
		}
	}
}
