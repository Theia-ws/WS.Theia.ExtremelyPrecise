using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class Pow {
		[TestMethod]
		public void Case1() {
			Rational value = 2;
			for(int power = 0;power<=32;power++)
				Console.WriteLine("{0}^{1} = {2:N0} ",
								  value,power,Math.Pow(value,power));
		}
	}
	// The example displays the following output:
	//     2^0 = 1
	//     2^1 = 2
	//     2^2 = 4
	//     2^3 = 8
	//     2^4 = 16
	//     2^5 = 32
	//     2^6 = 64
	//     2^7 = 128
	//     2^8 = 256
	//     2^9 = 512
	//     2^10 = 1,024
	//     2^11 = 2,048
	//     2^12 = 4,096
	//     2^13 = 8,192
	//     2^14 = 16,384
	//     2^15 = 32,768
	//     2^16 = 65,536
	//     2^17 = 131,072
	//     2^18 = 262,144
	//     2^19 = 524,288
	//     2^20 = 1,048,576
	//     2^21 = 2,097,152
	//     2^22 = 4,194,304
	//     2^23 = 8,388,608
	//     2^24 = 16,777,216
	//     2^25 = 33,554,432
	//     2^26 = 67,108,864
	//     2^27 = 134,217,728
	//     2^28 = 268,435,456
	//     2^29 = 536,870,912
	//     2^30 = 1,073,741,824
	//     2^31 = 2,147,483,648
	//     2^32 = 4,294,967,296
}
