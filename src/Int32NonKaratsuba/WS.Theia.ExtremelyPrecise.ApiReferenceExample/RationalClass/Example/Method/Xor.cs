using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Xor {
		[TestMethod]
		public void Case1() {
			Rational number1 = Math.Pow(2,127);
			Rational number2 = Rational.Multiply(163,124);
			Rational result = Rational.Xor(number1,number2);
		}
	}
}
