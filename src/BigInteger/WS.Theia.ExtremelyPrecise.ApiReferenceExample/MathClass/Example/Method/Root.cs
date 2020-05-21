#if !DEBUG||DLLDEBUG

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class Root {
		[TestMethod]
		public void Case1() {
			// Create an array containing the area of some squares.
			Tuple<string,Rational>[] areas =
						   { Tuple.Create("Sitka, Alaska", (Rational)2870.3),
					   Tuple.Create("New York City", (Rational)302.6),
					   Tuple.Create("Los Angeles", (Rational)468.7),
					   Tuple.Create("Detroit", (Rational)138.8),
					   Tuple.Create("Chicago", (Rational)227.1),
					   Tuple.Create("San Diego", (Rational)325.2) };

			Console.WriteLine("{0,-18} {1,14:N1} {2,30}\n","City","Area (mi.)",
							"Equivalent to a square with:");

			foreach(var area in areas)
				Console.WriteLine("{0,-18} {1,14:N1} {2,14:N2} miles per side",
								  area.Item1,area.Item2,Math.Round(Math.Root(area.Item2,2),2));
			// The example displays the following output:
			//    City                   Area (mi.)   Equivalent to a square with:
			//    
			//    Sitka, Alaska             2,870.3          53.58 miles per side
			//    New York City               302.6          17.40 miles per side
			//    Los Angeles                 468.7          21.65 miles per side
			//    Detroit                     138.8          11.78 miles per side
			//    Chicago                     227.1          15.07 miles per side
			//    San Diego                   325.2          18.03 miles per side
		}
	}
}

#endif