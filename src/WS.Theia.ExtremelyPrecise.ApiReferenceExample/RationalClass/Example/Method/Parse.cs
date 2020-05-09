using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Parse {
		[TestMethod]
		public void Case1() {
			string stringToParse = String.Empty;
			try {
				// Parse two strings.
				string string1, string2;
				string1="12347534159895123";
				string2="987654321357159852";
				stringToParse=string1;
				Rational number1 = Rational.Parse(stringToParse);
				Console.WriteLine("Converted '{0}' to {1:N0}.",stringToParse,number1);
				stringToParse=string2;
				Rational number2 = Rational.Parse(stringToParse);
				Console.WriteLine("Converted '{0}' to {1:N0}.",stringToParse,number2);
				// Perform arithmetic operations on the two numbers.
				number1*=3;
				number2*=2;
				// Compare the numbers.
				int result = Rational.Compare(number1,number2);
				switch(result) {
					case -1:
						Console.WriteLine("{0} is greater than {1}.",number2,number1);
						break;
					case 0:
						Console.WriteLine("{0} is equal to {1}.",number1,number2);
						break;
					case 1:
						Console.WriteLine("{0} is greater than {1}.",number1,number2);
						break;
				}
			} catch(FormatException) {
				Console.WriteLine("Unable to parse {0}.",stringToParse);
			}
			// The example displays the following output:
			//    Converted '12347534159895123' to 12,347,534,159,895,123.
			//    Converted '987654321357159852' to 987,654,321,357,159,852.
			//    1975308642714319704 is greater than 37042602479685369.
		}
		[TestMethod]
		public void Case2() {
			Rational number;
			// Method should succeed (white space and sign allowed)
			number=Rational.Parse("   -68054   ",NumberStyles.Integer);
			Console.WriteLine(number);
			// Method should succeed (string interpreted as hexadecimal)
			number=Rational.Parse("68054",NumberStyles.AllowHexSpecifier);
			Console.WriteLine(number);
			// Method call should fail: sign not allowed
			try {
				number=Rational.Parse("   -68054  ",NumberStyles.AllowLeadingWhite|NumberStyles.AllowTrailingWhite);
				Console.WriteLine(number);
			} catch(FormatException e) {
				Console.WriteLine(e.Message);
			}
			// Method call should fail: white space not allowed
			try {
				number=Rational.Parse("   68054  ",NumberStyles.AllowLeadingSign);
				Console.WriteLine(number);
			} catch(FormatException e) {
				Console.WriteLine(e.Message);
			}
			//
			// The method produces the following output:
			//
			//     -68054
			//     Input string was not in a correct format.
			//     Input string was not in a correct format.
			//     Input string was not in a correct format. 
		}
		public class RationalFormatProvider:IFormatProvider {
			public object GetFormat(Type formatType) {
				if(formatType==typeof(NumberFormatInfo)) {
					NumberFormatInfo numberFormat = new NumberFormatInfo();
					numberFormat.NegativeSign="~";
					return numberFormat;
				} else {
					return null;
				}
			}
		}
		[TestMethod]
		public void Case3() {
			Rational number = Rational.Parse("~6354129876",new RationalFormatProvider());
			// Display value using same formatting information
			Console.WriteLine(number.ToString(new RationalFormatProvider()));
			// Display value using formatting of current culture
			Console.WriteLine(number);
		}
		[TestMethod]
		public void Case4() {
			NumberFormatInfo fmt = new NumberFormatInfo();
			fmt.NegativeSign="~";

			Rational number = Rational.Parse("~6354129876",fmt);
			// Display value using same formatting information
			Console.WriteLine(number.ToString(fmt));
			// Display value using formatting of current culture
			Console.WriteLine(number);
		}
		[TestMethod]
		public void Case5() {
			// Call parse with default values of style and provider
			Console.WriteLine(Rational.Parse("  -300   ",
							  NumberStyles.Integer,CultureInfo.CurrentCulture));
			// Call parse with default values of style and provider supporting tilde as negative sign
			Console.WriteLine(Rational.Parse("   ~300  ",
											   NumberStyles.Integer,new RationalFormatProvider()));
			// Call parse with only AllowLeadingWhite and AllowTrailingWhite
			// Exception thrown because of presence of negative sign
			try {
				Console.WriteLine(Rational.Parse("    ~300   ",
											 NumberStyles.AllowLeadingWhite|NumberStyles.AllowTrailingWhite,
											 new RationalFormatProvider()));
			} catch(FormatException e) {
				Console.WriteLine("{0}: \n   {1}",e.GetType().Name,e.Message);
			}
			// Call parse with only AllowHexSpecifier
			// Exception thrown because of presence of negative sign
			try {
				Console.WriteLine(Rational.Parse("-3af",NumberStyles.AllowHexSpecifier,
												   new RationalFormatProvider()));
			} catch(FormatException e) {
				Console.WriteLine("{0}: \n   {1}",e.GetType().Name,e.Message);
			}
			// Call parse with only NumberStyles.None
			// Exception thrown because of presence of white space and sign
			try {
				Console.WriteLine(Rational.Parse(" -300 ",NumberStyles.None,
												   new RationalFormatProvider()));
			} catch(FormatException e) {
				Console.WriteLine("{0}: \n   {1}",e.GetType().Name,e.Message);
			}
			// The example displays the followingoutput:
			//       -300
			//       -300
			//       FormatException:
			//          The value could not be parsed.
			//       FormatException:
			//          The value could not be parsed.
			//       FormatException:
			//          The value could not be parsed. 
		}

	}
}