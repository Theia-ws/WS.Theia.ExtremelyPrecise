using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class UnaryNegation {
		[TestMethod]
		public void Case1() {
			Rational number = 12645002;
			Console.WriteLine(Rational.Negate(number));      // Displays -12645002
			Console.WriteLine(-number);                     // Displays -12645002
			Console.WriteLine(number*Rational.MinusOne);   // Displays -12645002
		}
	}
}
