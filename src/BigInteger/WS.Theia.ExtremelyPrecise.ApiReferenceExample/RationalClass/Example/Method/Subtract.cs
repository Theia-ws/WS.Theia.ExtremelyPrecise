using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Subtract {
		[TestMethod]
		public void Case1() {
			// The statement
			//    Rational number = Int64.MinValue - Int64.MaxValue;
			// produces compiler error CS0220: The operation overflows at compile time in checked mode.
			// The alternative:
			Rational number = Rational.Subtract(Int64.MinValue,Int64.MaxValue);
		}
	}
}
