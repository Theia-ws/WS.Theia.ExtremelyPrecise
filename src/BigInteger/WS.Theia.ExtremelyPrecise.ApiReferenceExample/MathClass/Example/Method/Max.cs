using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class Max {
		[TestMethod]
		public void Case1() {
			string str = "{0}: The greater of {1,3} and {2,3} is {3}.";
			string nl = Environment.NewLine;

			Rational xByte1 = -100, xByte2 = 51;

			Console.WriteLine("{0}Display the greater of two values:{0}",nl);
			Console.WriteLine(str,"Rational",xByte1,xByte2,Math.Max(xByte1,xByte2));
		}
	}
	/*
	This example produces the following results:

	Display the greater of two values:

	Rational: The greater of   -100 and  51 is 51.
	*/
}
