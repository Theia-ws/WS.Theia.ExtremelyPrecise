using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Compre {
		[TestMethod]
		public void Case1() {
			Rational number1 = Math.Pow(Int64.MaxValue,100);
			Rational number2 = number1+1;
			string relation = "";
			switch(Rational.Compare(number1,number2)) {
				case -1:
					relation="<";
					break;
				case 0:
					relation="=";
					break;
				case 1:
					relation=">";
					break;
			}
			Console.WriteLine("{0} {1} {2}",number1,relation,number2);
			// The example displays the following output:
			//    3.0829940252776347122742186219E+1896 < 3.0829940252776347122742186219E+1896
			//TODO:指数表記で出力できる例に変更したい
		}
	}
}
