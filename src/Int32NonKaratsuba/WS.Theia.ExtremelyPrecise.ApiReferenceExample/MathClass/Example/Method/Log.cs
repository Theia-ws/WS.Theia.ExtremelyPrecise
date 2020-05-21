using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class Log {
		[TestMethod]
		public void Case1() {
			Console.WriteLine("  Evaluate this identity with selected values for X:");
			Console.WriteLine("                              ln(x) = 1 / log[X](B)");
			Console.WriteLine();

			double[] XArgs = { 1.2,4.9,9.9,0.1 };

			foreach(double argX in XArgs) {
				// Find natural log of argX.
				Console.WriteLine("                      Math.Log({0}) = {1:E16}",
								  argX,Math.Log(argX));

				// Evaluate 1 / log[X](e).
				Console.WriteLine("             1.0 / Math.Log(e, {0}) = {1:E16}",
								  argX,1.0/Math.Log(Math.E,argX));
				Console.WriteLine();
			}
			// This example displays the following output:
			//         Evaluate this identity with selected values for X:
			//                                     ln(x) = 1 / log[X](B)
			//       
			//                             Math.Log(1.2) = 1.8232155679395459E-001
			//                    1.0 / Math.Log(e, 1.2) = 1.8232155679395459E-001
			//       
			//                             Math.Log(4.9) = 1.5892352051165810E+000
			//                    1.0 / Math.Log(e, 4.9) = 1.5892352051165810E+000
			//       
			//                             Math.Log(9.9) = 2.2925347571405443E+000
			//                    1.0 / Math.Log(e, 9.9) = 2.2925347571405443E+000
			//       
			//                             Math.Log(0.1) = -2.3025850929940455E+000
			//                    1.0 / Math.Log(e, 0.1) = -2.3025850929940455E+000
		}
		[TestMethod]
		public void Case2() {
			Console.WriteLine(
	"This example of Math.Log( Rational ) and "+
	"Math.Log( Rational, Rational )\n"+
	"generates the following output.\n");
			Console.WriteLine(
				"Evaluate these identities with "+
				"selected values for X and B (base):");
			Console.WriteLine("   log(B)[X] == 1 / log(X)[B]");
			Console.WriteLine("   log(B)[X] == ln[X] / ln[B]");
			Console.WriteLine("   log(B)[X] == log(B)[e] * ln[X]");

			UseBaseAndArg(0.1,1.2);
			UseBaseAndArg(1.2,4.9);
			UseBaseAndArg(4.9,9.9);
			UseBaseAndArg(9.9,0.1);
		}
		// Evaluate logarithmic identities that are functions of two arguments.
		static void UseBaseAndArg(Rational argB,Rational argX) {
			// Evaluate log(B)[X] == 1 / log(X)[B].
			Console.WriteLine(
				"\n                   Math.Log({1}, {0}) == {2:E16}"+
				"\n             1.0 / Math.Log({0}, {1}) == {3:E16}",
				argB,argX,Math.Log(argX,argB),
				1.0/Math.Log(argB,argX));

			// Evaluate log(B)[X] == ln[X] / ln[B].
			Console.WriteLine(
				"        Math.Log({1}) / Math.Log({0}) == {2:E16}",
				argB,argX,Math.Log(argX)/Math.Log(argB));

			// Evaluate log(B)[X] == log(B)[e] * ln[X].
			Console.WriteLine(
				"Math.Log(Math.E, {0}) * Math.Log({1}) == {2:E16}",
				argB,argX,Math.Log(Math.E,argB)*Math.Log(argX));
			/*
This example of Math.Log( Rational ) and Math.Log( Rational, Rational )
generates the following output.
Evaluate these identities with selected values for X and B (base):
   log(B)[X] == 1 / log(X)[B]
   log(B)[X] == ln[X] / ln[B]
   log(B)[X] == log(B)[e] * ln[X]

				   Math.Log(1.2, 0.1) == -7.9181246047624818E-002
			 1.0 / Math.Log(0.1, 1.2) == -7.9181246047624818E-002
		Math.Log(1.2) / Math.Log(0.1) == -7.9181246047624818E-002
Math.Log(Math.E, 0.1) * Math.Log(1.2) == -7.9181246047624804E-002

				   Math.Log(4.9, 1.2) == 8.7166610085093179E+000
			 1.0 / Math.Log(1.2, 4.9) == 8.7166610085093161E+000
		Math.Log(4.9) / Math.Log(1.2) == 8.7166610085093179E+000
Math.Log(Math.E, 1.2) * Math.Log(4.9) == 8.7166610085093179E+000

				   Math.Log(9.9, 4.9) == 1.4425396251981288E+000
			 1.0 / Math.Log(4.9, 9.9) == 1.4425396251981288E+000
		Math.Log(9.9) / Math.Log(4.9) == 1.4425396251981288E+000
Math.Log(Math.E, 4.9) * Math.Log(9.9) == 1.4425396251981288E+000

				   Math.Log(0.1, 9.9) == -1.0043839404494075E+000
			 1.0 / Math.Log(9.9, 0.1) == -1.0043839404494075E+000
		Math.Log(0.1) / Math.Log(9.9) == -1.0043839404494075E+000
Math.Log(Math.E, 9.9) * Math.Log(0.1) == -1.0043839404494077E+000
*/
		}
	}
}
