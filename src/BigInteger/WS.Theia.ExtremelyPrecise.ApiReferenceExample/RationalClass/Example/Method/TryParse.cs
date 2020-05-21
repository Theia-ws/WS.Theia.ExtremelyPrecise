using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class TryParse {
		[TestMethod]
		public void Case1() {
			Rational number1, number2;
			bool succeeded1, succeeded2;
			(succeeded1, number1)=Rational.TryParse("-12347534159895123");
			(succeeded2, number2)=Rational.TryParse("987654321357159852");
			if(succeeded1&&succeeded2) {
				number1*=3;
				number2*=2;
				switch(Rational.Compare(number1,number2)) {
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
			} else {
				if(!succeeded1)
					Console.WriteLine("Unable to initialize the first Rational value.");
				if(!succeeded2)
					Console.WriteLine("Unable to initialize the second Rational value.");
			}
			// The example displays the following output:
			//      1975308642714319704 is greater than -37042602479685369.
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
		//TODO:想定と違う挙動している部分がある
		[TestMethod]
		public void Case2() {
			string numericString;
			Rational number = Rational.Zero;
			bool status = false;

			// Call TryParse with default values of style and provider.
			numericString="  -300   ";
			(status, number)=Rational.TryParse(numericString,NumberStyles.Integer,
								   null);
			if(status)
				Console.WriteLine("'{0}' was converted to {1}.",
								  numericString,number);
			else
				Console.WriteLine("Conversion of '{0}' to a Rational failed.",
								  numericString);

			// Call TryParse with the default value of style and 
			// a provider supporting the tilde as negative sign.
			numericString="  -300   ";
			(status, number)=Rational.TryParse(numericString,NumberStyles.Integer,
								   new RationalFormatProvider());
			if(status)
				Console.WriteLine("'{0}' was converted to {1}.",
								  numericString,number);
			else
				Console.WriteLine("Conversion of '{0}' to a Rational failed.",
								  numericString);

			// Call TryParse with only AllowLeadingWhite and AllowTrailingWhite.
			// Method returns false because of presence of negative sign.
			numericString="  -500   ";
			(status, number)=Rational.TryParse(numericString,
									NumberStyles.AllowLeadingWhite|NumberStyles.AllowTrailingWhite,
									new RationalFormatProvider());
			if(status)
				Console.WriteLine("'{0}' was converted to {1}.",
								  numericString,number);
			else
				Console.WriteLine("Conversion of '{0}' to a Rational failed.",
								  numericString);

			// Call TryParse with AllowHexSpecifier and a hex value.
			numericString="F14237FFAAC086455192";
			(status, number)=Rational.TryParse(numericString,
									NumberStyles.AllowHexSpecifier,
									null);
			if(status)
				Console.WriteLine("'{0}' was converted to {1} (0x{1:x}).",
								  numericString,number);
			else
				Console.WriteLine("Conversion of '{0}' to a Rational failed.",
								  numericString);

			// Call TryParse with AllowHexSpecifier and a negative hex value.
			// Conversion fails because of presence of negative sign.
			numericString="-3af";
			(status, number)=Rational.TryParse(numericString,NumberStyles.AllowHexSpecifier,new RationalFormatProvider());
			if(status)
				Console.WriteLine("'{0}' was converted to {1}.",
								  numericString,number);
			else
				Console.WriteLine("Conversion of '{0}' to a Rational failed.",
								  numericString);

			// Call TryParse with only NumberStyles.None.
			// Conversion fails because of presence of white space and sign.
			numericString=" -300 ";
			(status, number)=Rational.TryParse(numericString,NumberStyles.None,
								   new RationalFormatProvider());
			if(status)
				Console.WriteLine("'{0}' was converted to {1}.",
								  numericString,number);
			else
				Console.WriteLine("Conversion of '{0}' to a Rational failed.",
								  numericString);

			// Call TryParse with NumberStyles.Any and a provider for the fr-FR culture.
			// Conversion fails because the string is formatted for the en-US culture.
			numericString="9,031,425,666,123,546.00";
			(status, number)=Rational.TryParse(numericString,NumberStyles.Any,
								   new CultureInfo("fr-FR"));
			if(status)
				Console.WriteLine("'{0}' was converted to {1}.",
								  numericString,number);
			else
				Console.WriteLine("Conversion of '{0}' to a Rational failed.",
								  numericString);

			// Call TryParse with NumberStyles.Any and a provider for the fr-FR culture.
			// Conversion succeeds because the string is properly formatted 
			// For the fr-FR culture.
			numericString="9 031 425 666 123 546,00";
			(status, number)=Rational.TryParse(numericString,NumberStyles.Any,
								   new CultureInfo("fr-FR"));
			if(status)
				Console.WriteLine("'{0}' was converted to {1}.",
								  numericString,number);
			else
				Console.WriteLine("Conversion of '{0}' to a Rational failed.",
								  numericString);
			// The example displays the following output:
			//    '  -300   ' was converted to -300.
			//    Conversion of '  -300   ' to a Rational failed.
			//    Conversion of '  -500   ' to a Rational failed.
			//    'F14237FFAAC086455192' was converted to -69613977002644837412462 (0xf14237ffaac086455192).
			//    Conversion of '-3af' to a Rational failed.
			//    Conversion of ' -300 ' to a Rational failed.
			//    Conversion of '9,031,425,666,123,546.00' to a Rational failed.
			//    '9 031 425 666 123 546,00' was converted to 9031425666123546.      

		}
	}
}
