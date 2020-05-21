#if !DEBUG||DLLDEBUG

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.Sundbox {
	[TestClass]
	public class UnitTest1 {
		[TestMethod]
		public void Case1() {
			Rational.Accuracy=10;
			var counter = 60;
			var radian = counter*System.Math.PI/180;
			System.Console.WriteLine(System.Math.Tan(radian));
		}
		[TestMethod]
		public void Case2() {
			Rational.Accuracy=10;
			var counter = 60;
			var radian = counter*System.Math.PI/180;
			System.Console.WriteLine(Math.Tan(radian));
		}
#if DLLDEBUG
		[TestMethod]
		public void Case2_2() {
			Rational.Accuracy=10;
			var counter = 60;
			var radian = counter*System.Math.PI/180;
			System.Console.WriteLine(TriangleFunctionTest.Cos(radian-Math.PI/2)/TriangleFunctionTest.Cos(radian));
		}
#endif
		[TestMethod]
		public void Case3() {
			System.Console.WriteLine(Math.Root(2,2));
		}

	}
}

#endif