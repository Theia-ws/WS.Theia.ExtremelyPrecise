using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class Addition {
		[TestMethod]
		public void Case1() {
			Rational num1 = 1000456321;
			Rational num2 = 90329434;
			Rational sum = num1+num2;
		}
	}
}
