using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class GetTypeCode {
		[TestMethod]
		public void Case1() {
			// Example of the Rational.GetTypeCode method. 
			Console.WriteLine("This example of the "+
				"Rational.GetTypeCode( ) \nmethod "+
				"generates the following output.\n");

			// Create a decimal object and get its type code.
			Rational aRational = new Rational(1.0);
			TypeCode typCode = aRational.GetTypeCode();

			Console.WriteLine("Type Code:      \"{0}\"",typCode);
			Console.WriteLine("Numeric value:  {0}",(int)typCode);
			/*
			This example of the Rational.GetTypeCode( )
			method generates the following output.

			Type Code:      "Object"
			Numeric value:  1
			*/

		}
	}
}