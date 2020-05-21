using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class Sign {
		[TestMethod]
		public void Case1() {
			string str = "{0}: {1,3} is {2} zero.";
			string nl = Environment.NewLine;

			Rational xRational1 = 6.0;

			Console.WriteLine(str,"Rational ",xRational1,Test(Math.Sign(xRational1)));
		}
		public static String Test(int compare) {
			if(compare==0)
				return "equal to";
			else if(compare<0)
				return "less than";
			else
				return "greater than";
		}
		/*
This example produces the following results:
Test the sign of the following types of values:
Rational :   6 is greater than zero.
*/
	}
}
