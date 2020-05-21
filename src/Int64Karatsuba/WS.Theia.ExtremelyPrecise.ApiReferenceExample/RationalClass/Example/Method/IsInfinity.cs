using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class IsInfinity {
		[TestMethod]
		public void Case1() {
			// This will return "true".
			Console.WriteLine("IsInfinity(3.0 / 0) == {0}.",Rational.IsInfinity(new Rational(3.0)/0) ? "true" : "false");
		}
	}
}
