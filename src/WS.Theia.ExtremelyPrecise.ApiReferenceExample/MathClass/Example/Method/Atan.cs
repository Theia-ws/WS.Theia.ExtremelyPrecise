using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class Atan {
		[TestMethod]
		public void Case1() {
			Rational x = 1.0;
			Rational y = 2.0;
			Rational angle;
			Rational radians;
			Rational result;

			// Calculate the tangent of 30 degrees.
			angle=30;
			radians=angle*(Math.PI/180);
			result=Math.Tan(radians);
			Console.WriteLine("The tangent of 30 degrees is {0}.",result);

			// Calculate the arctangent of the previous tangent.
			radians=Math.Atan(result);
			angle=radians*(180/Math.PI);
			Console.WriteLine("The previous tangent is equivalent to {0} degrees.",angle);

			// Calculate the arctangent of an angle.
			String line1 = "{0}The arctangent of the angle formed by the x-axis and ";
			String line2 = "a vector to point ({0},{1}) is {2}, ";
			String line3 = "which is equivalent to {0} degrees.";

			radians=Math.Atan2(y,x);
			angle=radians*(180/Math.PI);

			Console.WriteLine(line1,Environment.NewLine);
			Console.WriteLine(line2,x,y,radians);
			Console.WriteLine(line3,angle);
		}
	}
	/*
	This example produces the following results:

	The tangent of 30 degrees is 0.577350269189626.
	The previous tangent is equivalent to 30 degrees.

	The arctangent of the angle formed by the x-axis and
	a vector to point (1,2) is 1.10714871779409,
	which is equivalent to 63.434948822922 degrees.
	*/


}

