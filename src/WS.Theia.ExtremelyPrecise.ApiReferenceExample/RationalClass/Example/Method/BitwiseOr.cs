using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class BitwiseOr {
		[TestMethod]
		public void Case1() {
			Rational number1 = Rational.Parse("10343901200000000000");
			Rational number2 = Byte.MaxValue;
			Rational result = Rational.BitwiseOr(number1,number2);
		}
	}
}
