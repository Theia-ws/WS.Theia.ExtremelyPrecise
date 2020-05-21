using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class ToSingle {
		// Example of the Rational.ToSingle and Rational.ToDouble methods.
		string formatter = "{0,30}{1,17}{2,23}";
		// Convert the decimal argument; no exceptions are thrown.
		public void RationalToSgl_Dbl(Rational argument) {
			object SingleValue;
			object DoubleValue;

			// Convert the argument to a float value.
			SingleValue=Rational.ToSingle(argument);

			// Convert the argument to a double value.
			DoubleValue=Rational.ToDouble(argument);

			Console.WriteLine(formatter,argument,
				SingleValue,DoubleValue);
		}

		[TestMethod]
		public void Case1() {
			Console.WriteLine("This example of the \n"+
				"  Rational.ToSingle( Rational ) and \n"+
				"  Rational.ToDouble( Rational ) \nmethods "+
				"generates the following output. It \ndisplays "+
				"several converted decimal values.\n");
			Console.WriteLine(formatter,"decimal argument",
				"float","double");
			Console.WriteLine(formatter,"----------------",
				"-----","------");

			// Convert decimal values and display the results.
			RationalToSgl_Dbl(0.0000000000000000000000000001M);
			RationalToSgl_Dbl(0.0000000000123456789123456789M);
			RationalToSgl_Dbl(123M);
			RationalToSgl_Dbl(new decimal(123000000,0,0,false,6));
			RationalToSgl_Dbl(123456789.123456789M);
			RationalToSgl_Dbl(123456789123456789123456789M);
			RationalToSgl_Dbl(decimal.MinValue);
			RationalToSgl_Dbl(decimal.MaxValue);
		}

		/*
		This example of the
		  Rational.ToSingle( Rational ) and
		  Rational.ToDouble( Rational )
		methods generates the following output. It
		displays several converted decimal values.

					  decimal argument            float                 double
					  ----------------            -----                 ------
		0.0000000000000000000000000001            1E-28                  1E-28
		0.0000000000123456789123456789     1.234568E-11   1.23456789123457E-11
								   123              123                    123
							123.000000              123                    123
				   123456789.123456789     1.234568E+08       123456789.123457
		   123456789123456789123456789     1.234568E+26   1.23456789123457E+26
		-79228162514264337593543950335    -7.922816E+28  -7.92281625142643E+28
		 79228162514264337593543950335     7.922816E+28   7.92281625142643E+28
		*/

	}
}
