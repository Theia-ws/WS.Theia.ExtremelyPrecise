using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.AddTest {
	public class TestBase:WS.Theia.ExtremelyPrecise.Test.TestBase {

		protected void ExecTest(BigUInteger target,BigUInteger assertValue) {
			this.ExecTest(target,assertValue.ToByteArray());
		}


		protected void ExecTest(BigUInteger value,byte[] assertValue) {
			CompereArray(value.ToByteArray(),assertValue);
		}

	}
}
