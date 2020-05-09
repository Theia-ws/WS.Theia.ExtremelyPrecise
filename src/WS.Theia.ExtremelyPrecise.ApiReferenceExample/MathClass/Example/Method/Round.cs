using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class Round {
		[TestMethod]
		public void Case1() {
			Rational result;
			Rational posValue = 3.45m;
			Rational negValue = -3.45m;

			// By default, round a positive and a negative value to the nearest even number. 
			// The precision of the result is 1 decimal place.

			result=Math.Round(posValue,1);
			Console.WriteLine("{0,4} = Math.Round({1,5}, 1)",result,posValue);
			result=Math.Round(negValue,1);
			Console.WriteLine("{0,4} = Math.Round({1,5}, 1)",result,negValue);
			Console.WriteLine();

			// Round a positive value to the nearest even number, then to the nearest number away from zero. 
			// The precision of the result is 1 decimal place.

			result=Math.Round(posValue,1,MidpointRounding.ToEven);
			Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)",result,posValue);
			result=Math.Round(posValue,1,MidpointRounding.AwayFromZero);
			Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)",result,posValue);
			Console.WriteLine();

			// Round a negative value to the nearest even number, then to the nearest number away from zero. 
			// The precision of the result is 1 decimal place.

			result=Math.Round(negValue,1,MidpointRounding.ToEven);
			Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.ToEven)",result,negValue);
			result=Math.Round(negValue,1,MidpointRounding.AwayFromZero);
			Console.WriteLine("{0,4} = Math.Round({1,5}, 1, MidpointRounding.AwayFromZero)",result,negValue);
			Console.WriteLine();
			/*
This code example produces the following results:

 3.4 = Math.Round( 3.45, 1)
-3.4 = Math.Round(-3.45, 1)

 3.4 = Math.Round( 3.45, 1, MidpointRounding.ToEven)
 3.5 = Math.Round( 3.45, 1, MidpointRounding.AwayFromZero)

-3.4 = Math.Round(-3.45, 1, MidpointRounding.ToEven)
-3.5 = Math.Round(-3.45, 1, MidpointRounding.AwayFromZero)

*/
		}
		[TestMethod]
		public void Case2() {
			//TODO:ラウンドトリップ形式が無い事による例外が発生する
			Rational[] values = { 12.0, 12.1, 12.2, 12.3, 12.4, 12.5, 12.6,
						  12.7, 12.8, 12.9, 13.0 };
			Console.WriteLine("{0,-10} {1,-10} {2,-10} {3,-15}","Value","Default",
							  "ToEven","AwayFromZero");
			foreach(var value in values)
				Console.WriteLine("{0,-10:R} {1,-10} {2,-10} {3,-15}",
								  value,Math.Round(value),
								  Math.Round(value,MidpointRounding.ToEven),
								  Math.Round(value,MidpointRounding.AwayFromZero));
			// The example displays the following output:
			//       Value      Default    ToEven     AwayFromZero
			//       12         12         12         12
			//       12.1       12         12         12
			//       12.2       12         12         12
			//       12.3       12         12         12
			//       12.4       12         12         12
			//       12.5       12         12         13
			//       12.6       13         13         13
			//       12.7       13         13         13
			//       12.8       13         13         13
			//       12.9       13         13         13
			//       13.0       13         13         13
		}
		[TestMethod]
		public void Case3() {
			Math.Round(3.44,1); //Returns 3.4.
			Math.Round(3.45,1); //Returns 3.4.
			Math.Round(3.46,1); //Returns 3.5.

			Math.Round(4.34,1); // Returns 4.3
			Math.Round(4.35,1); // Returns 4.4
			Math.Round(4.36,1); // Returns 4.4
		}
		[TestMethod]
		public void Case4() {
			Console.WriteLine("Classic Math.Round in CSharp");
			Console.WriteLine(Math.Round(4.4m)); // 4
			Console.WriteLine(Math.Round(4.5m)); // 4
			Console.WriteLine(Math.Round(4.6m)); // 5
			Console.WriteLine(Math.Round(5.5m)); // 6
		}
	}
}
