using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class ToInt16 {
		[TestMethod]
		public void Case1() {
			Rational[] values = { 123m, new Decimal(123000, 0, 0, false, 3),
						   123.999m, 65535m, 65535.001m,
						   32767m, 32767.001m, -0.999m,
						   -1m,  -32768m, -32768.001m };

			foreach(var value in values) {
				try {
					short number = Rational.ToInt16(value);
					Console.WriteLine("{0} --> {1}",value,number);
				} catch(OverflowException e) {
					Console.WriteLine("{0}: {1}",e.GetType().Name,value);
				}
			}
			// The example displays the following output:
			//   123 --> 123
			//   123 --> 123
			//   123.999 --> 123
			//   OverflowException: 65535
			//   OverflowException: 65535.001
			//   32767 --> 32767
			//   OverflowException: 32767.001
			//   -0.999 --> 0
			//   -1 --> -1
			//   -32768 --> -32768
			//   OverflowException: -32768.001
		}
	}
}
