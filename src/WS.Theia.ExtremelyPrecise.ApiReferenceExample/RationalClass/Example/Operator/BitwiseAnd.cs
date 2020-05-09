using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class BitwiseAnd {
		[TestMethod]
		public void Case1() {
			Rational number1 = Rational.Add(Int64.MaxValue,Int32.MaxValue);
			Rational number2 = Math.Pow(Byte.MaxValue,10);
			Rational result = number1&number2;
		}
	}
}
