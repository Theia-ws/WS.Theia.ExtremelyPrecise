using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class ToString {
		[TestMethod]
		public void Case1() {
			// Initialize a Rational value.
			Rational value = Rational.Add(UInt64.MaxValue,1024);

			// Display value using the default ToString method.
			Console.WriteLine(value.ToString());
			// Display value using some standard format specifiers.
			Console.WriteLine(value.ToString("G"));
			Console.WriteLine(value.ToString("C"));
			Console.WriteLine(value.ToString("D"));
			Console.WriteLine(value.ToString("F"));
			Console.WriteLine(value.ToString("N"));
			// The example displays the following output on a system whose current 
			// culture is en-US:
			//       18446744073709552639
			//       18446744073709552639
			//       $18,446,744,073,709,552,639.00
			//       18446744073709552639
			//       18446744073709552639.00
			//       18,446,744,073,709,552,639.00 

		}
		[TestMethod]
		public void Case2() {
			Rational number = 9867857831128;
			number=Math.Pow(number,3)*Rational.MinusOne;

			NumberFormatInfo bigIntegerProvider = new NumberFormatInfo();
			bigIntegerProvider.NegativeSign="~";

			Console.WriteLine(number.ToString(bigIntegerProvider));
		}
		[TestMethod]
		public void Case3() {
			Rational value = Rational.Parse("-903145792771643190182");
			string[] specifiers = { "C", "D", "D25", "E", "E4", "e8", "F0",
						"G", "N0", "P", "R", "0,0.000",
						"#,#.00#;(#,#.00#)" };

			foreach(string specifier in specifiers)
				Console.WriteLine("{0}: {1}",specifier,value.ToString(specifier));

			// The example displays the following output:
			//       C: ($903,145,792,771,643,190,182.00)
			//       D: -903145792771643190182
			//       D25: -0000903145792771643190182
			//       E: -9.031457E+020
			//       E4: -9.0314E+020
			//       e8: -9.03145792e+020
			//       F0: -903145792771643190182
			//       G: -903145792771643190182
			//       N0: -903,145,792,771,643,190,182
			//       P: -90,314,579,277,164,319,018,200.00 %
			//       R: -903145792771643190182
			//       0,0.000: -903,145,792,771,643,190,182.000
			//       #,#.00#;(#,#.00#): (903,145,792,771,643,190,182.00)
		}
		[TestMethod]
		public void Case4() {
			// Redefine the negative sign as the tilde for the invariant culture.
			NumberFormatInfo bigIntegerFormatter = new NumberFormatInfo();
			bigIntegerFormatter.NegativeSign="~";

			Rational value = Rational.Parse("-903145792771643190182");
			string[] specifiers = { "C", "D", "D25", "E", "E4", "e8", "F0",
						"G", "N0", "P", "R", "0,0.000",
						"#,#.00#;(#,#.00#)" };

			foreach(string specifier in specifiers)
				Console.WriteLine("{0}: {1}",specifier,value.ToString(specifier,
								  bigIntegerFormatter));

			// The example displays the following output:
			//    C: (☼903,145,792,771,643,190,182.00)
			//    D: ~903145792771643190182
			//    D25: ~0000903145792771643190182
			//    E: ~9.031457E+020
			//    E4: ~9.0314E+020
			//    e8: ~9.03145792e+020
			//    F0: ~903145792771643190182
			//    G: ~903145792771643190182
			//    N0: ~903,145,792,771,643,190,182
			//    P: ~90,314,579,277,164,319,018,200.00 %
			//    R: ~903145792771643190182
			//    0,0.000: ~903,145,792,771,643,190,182.000
			//    #,#.00#;(#,#.00#): (903,145,792,771,643,190,182.00)

		}
	}
}
