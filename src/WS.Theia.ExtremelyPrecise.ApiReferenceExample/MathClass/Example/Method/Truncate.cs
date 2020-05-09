using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class Truncate {
		[TestMethod]
		public void Case1() {
			Rational floatNumber;

			floatNumber=32.7865;
			// Displays 32      
			Console.WriteLine(Math.Truncate(floatNumber));

			floatNumber=-32.9012;
			// Displays -32       
			Console.WriteLine(Math.Truncate(floatNumber));
		}
	}
}
