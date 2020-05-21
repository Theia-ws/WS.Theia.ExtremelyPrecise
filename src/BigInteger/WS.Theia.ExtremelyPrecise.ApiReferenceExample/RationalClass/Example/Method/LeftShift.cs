using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class LeftShift {
		[TestMethod]
		public void Case1() {
			Rational number = Rational.Parse("-9047321678449816249999312055");
			Console.WriteLine("Shifting {0} left by:",number);
			for(int ctr = 0;ctr<=16;ctr++) {
				Rational newNumber = Rational.LeftShift(number,ctr);
				Console.WriteLine(" {0,2} bits: {1,35}",ctr,newNumber);
			}
			// The example displays the following output:
			//    Shifting -9047321678449816249999312055 left by:
			//      0 bits:       -9047321678449816249999312055
			//      1 bits:      -18094643356899632499998624110
			//      2 bits:      -36189286713799264999997248220
			//      3 bits:      -72378573427598529999994496440
			//      4 bits: -1.4475714685519705999998899288E+29
			//      5 bits: -2.8951429371039411999997798576E+29
			//      6 bits: -5.7902858742078823999995597152E+29
			//      7 bits:  -1.158057174841576479999911943E+30
			//      8 bits: -2.3161143496831529599998238861E+30
			//      9 bits: -4.6322286993663059199996477722E+30
			//     10 bits: -9.2644573987326118399992955443E+30
			//     11 bits: -1.8528914797465223679998591089E+31
			//     12 bits: -3.7057829594930447359997182177E+31
			//     13 bits: -7.4115659189860894719994364355E+31
			//     14 bits: -1.4823131837972178943998872871E+32
			//     15 bits: -2.9646263675944357887997745742E+32
			//     16 bits: -5.9292527351888715775995491484E+32

		}
	}
}
