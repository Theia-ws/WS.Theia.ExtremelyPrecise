using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class Multiply {
		[TestMethod]
		public void Case1() {
			Rational num1 = 1000456321;
			Rational num2 = 90329434;
			Rational result = num1*num2;
		}
	}
}
