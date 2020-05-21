using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class ToUInt32 {
		[TestMethod]
		public void Case1() {
			Rational[] values = { 123m, new decimal(123000, 0, 0, false, 3),
				123.999m, 4294967295m, 4294967295.001m,
			  4294967296m, 2147483647m, 2147483647.001m,
			   -0.999m, -1m, -2147483648m, -2147483648.001m };
			foreach(var value in values) {
				try {
					uint number = Rational.ToUInt32(value);
					Console.WriteLine("{0} --> {1}",value,number);
				} catch(OverflowException e) {
					Console.WriteLine("{0}: {1}",e.GetType().Name,value);
				}
			}
		}
		// The example displays the following output:
		//      123 --> 123
		//      123.000 --> 123
		//      123.999 --> 123
		//      4294967295 --> 4294967295
		//      OverflowException: 4294967295.001
		//      OverflowException: 4294967296
		//      2147483647 --> 2147483647
		//      2147483647.001 --> 2147483647
		//      OverflowException: -0.999
		//      OverflowException: -1
		//      OverflowException: -2147483648
		//      OverflowException: -2147483648.001
	}
}
