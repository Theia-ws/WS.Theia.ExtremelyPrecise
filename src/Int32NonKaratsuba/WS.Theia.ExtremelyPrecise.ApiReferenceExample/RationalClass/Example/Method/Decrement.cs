using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Decrement {
		[TestMethod]
		public void Case1() {
			Rational number = 93843112;
			number=Rational.Decrement(number);               // Displays 93843111
		}
	}
}
