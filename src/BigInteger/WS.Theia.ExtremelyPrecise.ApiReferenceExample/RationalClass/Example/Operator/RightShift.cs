using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Operator {
	[TestClass]
	public class RightShift {
		[TestMethod]
		public void Case1() {
			var number = Rational.Parse("-9047321678449816249999312055");
			Console.WriteLine("Shifting {0} right by:",number);
			for(int ctr = 0;ctr<=16;ctr++) {
				Rational newNumber = number>>ctr;
				Console.WriteLine(" {0,2} bits: {1,35}",ctr,newNumber);
			}
			// The example displays the following output:
			//    Shifting -9047321678449816249999312055 right by:
			//      0 bits:       -9047321678449816249999312055
			//      1 bits:       -4523660839224908124999656028
			//      2 bits:       -2261830419612454062499828014
			//      3 bits:       -1130915209806227031249914007
			//      4 bits:        -565457604903113515624957004
			//      5 bits:        -282728802451556757812478502
			//      6 bits:        -141364401225778378906239251
			//      7 bits:         -70682200612889189453119626
			//      8 bits:         -35341100306444594726559813
			//      9 bits:         -17670550153222297363279907
			//     10 bits:          -8835275076611148681639954
			//     11 bits:          -4417637538305574340819977
			//     12 bits:          -2208818769152787170409989
			//     13 bits:          -1104409384576393585204995
			//     14 bits:           -552204692288196792602498
			//     15 bits:           -276102346144098396301249
			//     16 bits:           -138051173072049198150625
		}
	}
}
