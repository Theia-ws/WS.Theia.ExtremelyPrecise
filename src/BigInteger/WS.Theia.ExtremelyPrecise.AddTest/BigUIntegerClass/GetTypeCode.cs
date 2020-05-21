using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.AddTest.BigUIntegerClass {

	[TestClass]
	public class GetTypeCode:TestBase {

		[TestMethod]
		public void Code() {
			Assert.AreEqual<TypeCode>(BigUInteger.One.GetTypeCode(),TypeCode.Object);
		}

	}
}
