using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Multiply {
		[TestMethod]
		public void Case1() {
			long number1 = 1234567890;
			long number2 = 9876543210;
			try {
				long product;
				product=checked(number1*number2);
			} catch(OverflowException) {
				Rational product;
				product=Rational.Multiply(number1,number2);
				Console.WriteLine(product.ToString());
			}
		}
	}
}
