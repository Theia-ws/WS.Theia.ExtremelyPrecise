using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class IsNaN {
		[TestMethod]
		public void Case1() {
			// This will return true.
			if(Rational.IsNaN(0/Rational.Zero))
				Console.WriteLine("Double.IsNan() can determine whether a value is not-a-number.");
		}
	}
}
