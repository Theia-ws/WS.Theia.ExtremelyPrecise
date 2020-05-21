using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class Increment {
		[TestMethod]
		public void Case1() {
			Rational number = 93843112;
			Console.WriteLine(++number);               // Displays 93843113
		}
	}
}
