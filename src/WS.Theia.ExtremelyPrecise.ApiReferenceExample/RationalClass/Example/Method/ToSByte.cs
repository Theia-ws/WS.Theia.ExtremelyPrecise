using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class ToSByte {
		[TestMethod]
		public void Case1() {
			Rational[] values = { 123m, new Decimal(78000, 0, 0, false, 3),
						   78.999m, 255m, 255.001m,
						   127m, 127.001m, -0.999m,
						   -1m,  -128m, -128.001m };

			foreach(var value in values) {
				try {
					sbyte number = Rational.ToSByte(value);
					Console.WriteLine("{0} --> {1}",value,number);
				} catch(OverflowException e) {
					Console.WriteLine("{0}: {1}",e.GetType().Name,value);
				}
			}
		}
	}
	// The example displays the following output:
	//     78 --> 78
	//     78.000 --> 78
	//     78.999 --> 78
	//     OverflowException: 255
	//     OverflowException: 255.001
	//     127 --> 127
	//     OverflowException: 127.001
	//     -0.999 --> 0
	//     -1 --> -1
	//     -128 --> -128
	//     OverflowException: -128.001
}
