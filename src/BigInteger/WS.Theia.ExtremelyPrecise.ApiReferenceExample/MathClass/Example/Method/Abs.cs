using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.MathClass.Example.Method {
	[TestClass]
	public class Abs {
		[Serializable]
		public struct SignAndMagnitude {
			public int Sign;
			public byte[] Bytes;
		}
		[TestMethod]
		public void Case1() {
			FileStream fs;
			BinaryFormatter formatter = new BinaryFormatter();
			Rational number = Math.Pow(Int32.MaxValue,20)*Rational.MinusOne;
			Console.WriteLine("The original value is {0}.",number);
			SignAndMagnitude sm = new SignAndMagnitude();
			sm.Sign=Math.Sign(number);
			sm.Bytes=Math.Abs(number).ToByteArray().Numerator;

			// Serialize SignAndMagnitude value.
			fs=new FileStream(@".\data.bin",FileMode.Create);
			formatter.Serialize(fs,sm);
			fs.Close();

			// Deserialize SignAndMagnitude value.
			fs=new FileStream(@".\data.bin",FileMode.Open);
			SignAndMagnitude smRestored = (SignAndMagnitude)formatter.Deserialize(fs);
			fs.Close();
			Rational restoredNumber = new Rational(false,smRestored.Bytes,new byte[] { 1 });
			restoredNumber*=sm.Sign;
			Console.WriteLine("The deserialized value is {0}.",restoredNumber);
		}
		// The example displays the following output:
		//    The original value is -4.3510823966323432743748744058E+186.
		//    The deserialized value is -4.3510823966323432743748744058E+186.
		//TODO:結果を上手く指数表現にしたい
	}
}
