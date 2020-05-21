using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class ExclusiveOr {
		[TestMethod]
		public void Case1() {
			Rational number1 = Math.Pow(2,127);
			Rational number2 = Rational.Multiply(163,124);
			Rational result = number1^number2;
		}
	}
}
