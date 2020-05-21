using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class ModPow {
		[TestMethod]
		public void Case1() {
			Rational number = 10;
			int exponent = 3;
			Rational modulus = 30;
			Console.WriteLine("({0}^{1}) Mod {2} = {3}",
							  number,exponent,modulus,
							  Rational.ModPow(number,exponent,modulus));
			// The example displays the following output:
			//      (10^3) Mod 30 = 10
		}
	}
}
