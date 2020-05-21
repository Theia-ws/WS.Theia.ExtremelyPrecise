using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class OnesComplement {
		[TestMethod]
		public void Case1() {
			Rational value, complement;

			value=Rational.Multiply(Rational.One,9);
			complement=Rational.OnesComplement(value);

			Console.WriteLine("{0,5} -- {1,-32}",value,DisplayInBinary(value));
			Console.WriteLine("{0,5} -- {1,-32}\n",complement,
	  DisplayInBinary(complement));

			value=Rational.MinusOne*SByte.MaxValue;
			complement=Rational.OnesComplement(value);

			Console.WriteLine("{0,5} -- {1,-32}",value,DisplayInBinary(value));
			Console.WriteLine("{0,5} -- {1,-32}\n",complement,DisplayInBinary(complement));
			// The example displays the following output:
			//           9 – 00001001
			//         -10 – 11110110
			//       
			//        -127 – 10000001
			//         126 -- 01111110
		}

		private static string DisplayInBinary(Rational number) {
			(_,byte[] bytes,_,_) = number.ToByteArray();
			string binaryString = string.Empty;
			foreach(byte byteValue in bytes) {
				string byteString = Convert.ToString(byteValue,2).Trim();
				binaryString+=byteString.Insert(0,new string('0',8-byteString.Length));
			}
			return binaryString;
		}
	}
}
