using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Property {
	[TestClass]
	public class NaN {
		[TestMethod]
		public void Case1() {
			Rational zero = 0.0;
			Console.WriteLine("{0} / {1} = {2}",zero,zero,zero/zero);
			// The example displays the following output:
			//         0 / 0 = NaN     
		}
		[TestMethod]
		public void Case2() {
			Rational nan1 = Rational.NaN;

			Console.WriteLine("{0} + {1} = {2}",3,nan1,3+nan1);
			Console.WriteLine("Abs({0}) = {1}",nan1,WS.Theia.ExtremelyPrecise.Math.Abs(nan1));
			// The example displays the following output:
			//       3 + NaN = NaN
			//       Abs(NaN) = NaN
		}
		[TestMethod]
		public void Case3() {
			Console.WriteLine("NaN == NaN: {0}",Rational.NaN==Rational.NaN);
			Console.WriteLine("NaN != NaN: {0}",Rational.NaN!=Rational.NaN);
			Console.WriteLine("NaN.Equals(NaN): {0}",Rational.NaN.Equals(Rational.NaN));
			Console.WriteLine("! NaN.Equals(NaN): {0}",!Rational.NaN.Equals(Rational.NaN));
			Console.WriteLine("IsNaN: {0}",Rational.IsNaN(Rational.NaN));

			Console.WriteLine("\nNaN > NaN: {0}",Rational.NaN>Rational.NaN);
			Console.WriteLine("NaN >= NaN: {0}",Rational.NaN>=Rational.NaN);
			Console.WriteLine("NaN < NaN: {0}",Rational.NaN<Rational.NaN);
			Console.WriteLine("NaN < 100.0: {0}",Rational.NaN<100.0);
			Console.WriteLine("NaN <= 100.0: {0}",Rational.NaN<=100.0);
			Console.WriteLine("NaN >= 100.0: {0}",Rational.NaN>100.0);
			Console.WriteLine("NaN.CompareTo(NaN): {0}",Rational.NaN.CompareTo(Rational.NaN));
			Console.WriteLine("NaN.CompareTo(100.0): {0}",Rational.NaN.CompareTo(100.0));
			Console.WriteLine("(100.0).CompareTo(Rational.NaN): {0}",new Rational(100.0).CompareTo(Rational.NaN));
			// The example displays the following output:
			//       NaN == NaN: False
			//       NaN != NaN: True
			//       NaN.Equals(NaN): True
			//       ! NaN.Equals(NaN): False
			//       IsNaN: True
			//       
			//       NaN > NaN: False
			//       NaN >= NaN: False
			//       NaN < NaN: False
			//       NaN < 100.0: False
			//       NaN <= 100.0: False
			//       NaN >= 100.0: False
			//       NaN.CompareTo(NaN): 0
			//       NaN.CompareTo(100.0): -1
			//       (100.0).CompareTo(Rational.NaN): 1

		}
	}
}