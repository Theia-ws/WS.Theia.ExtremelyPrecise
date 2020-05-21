using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.Test.RationalClass {

	[TestClass]
	public class GetTypeCode:TestBase {

		[TestMethod]
		public void Code() {
			Assert.AreEqual<TypeCode>(Rational.One.GetTypeCode(),TypeCode.Object);
		}

	}
}
