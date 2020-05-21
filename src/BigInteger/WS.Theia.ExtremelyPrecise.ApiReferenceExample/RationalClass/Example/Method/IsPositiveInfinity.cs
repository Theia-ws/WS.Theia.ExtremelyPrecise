using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class IsPositiveInfinity {
		[TestMethod]
		public void Case1() {
			// This will return "true".
			Console.WriteLine("IsPositiveInfinity(4.0 / 0) == {0}.",Rational.IsPositiveInfinity(4.0/Rational.Zero) ? "true" : "false");
		}
	}
}
