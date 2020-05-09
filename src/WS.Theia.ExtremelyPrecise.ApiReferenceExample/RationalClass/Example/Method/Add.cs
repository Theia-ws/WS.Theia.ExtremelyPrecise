using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Add {
		[TestMethod]
		public void Case1() {
			// The statement:
			//    Rational number = Int64.MaxValue + Int32.MaxValue;
			// produces compiler error CS0220: The operation overflows at compile time in checked mode.
			// The alternative:
			Rational number = Rational.Add(Int64.MaxValue,Int32.MaxValue);
		}
	}
}
