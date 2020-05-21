using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class GreaterThan {
		[TestMethod]
		public void Case1() {
			Rational number1 = 945834723;
			Rational number2 = 345145625;
			Rational number3 = 945834724;
			Console.WriteLine(number1>number2);              // Displays True
			Console.WriteLine(number1>number3);              // Displays False
		}
	}
}
