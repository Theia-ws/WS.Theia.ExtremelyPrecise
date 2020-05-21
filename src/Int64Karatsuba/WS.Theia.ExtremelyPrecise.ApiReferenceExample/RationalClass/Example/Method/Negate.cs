using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Negate {
		[TestMethod]
		public void Case1() {
			// The statement
			//    Rational number = -Int64.MinValue;
			// produces compiler error CS0220: The operation overflows at compile time in checked mode.
			// The alternative:
			Rational number = Rational.Negate(Int64.MinValue);
		}
	}
}
