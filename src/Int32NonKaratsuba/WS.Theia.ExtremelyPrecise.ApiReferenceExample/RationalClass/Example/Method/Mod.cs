using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Mod {
		[TestMethod]
		public void Case1() {
			Rational num1 = 100045632194;
			Rational num2 = 90329434;
			Rational remainder = num1%num2;
			Console.WriteLine(remainder);           // Displays 50948756
		}
	}
}
