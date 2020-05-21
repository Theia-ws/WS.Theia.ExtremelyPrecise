using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class IsNegativeInfinity {
		[TestMethod]
		public void Case1() {
			// This will return "true".
			Console.WriteLine("IsNegativeInfinity(-5.0 / 0) == {0}.",Rational.IsNegativeInfinity(-5.0/Rational.Zero) ? "true" : "false");
			// This will equal Infinity.
			Console.WriteLine("10.0 minus NegativeInfinity equals {0}.",(10.0-Rational.NegativeInfinity).ToString());
		}
	}
}
