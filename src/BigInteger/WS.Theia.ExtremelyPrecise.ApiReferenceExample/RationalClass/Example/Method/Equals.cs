using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class Equals {
		[TestMethod]
		public void Case1() {
			Rational rationalValue;
			decimal decimalValue = 16.2m;
			rationalValue=new Rational(decimalValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  decimalValue.GetType().Name,decimalValue,
							  rationalValue.Equals(decimalValue));
			// The example displays the following output:
			//    Rational 16.2 = Decimal 16.2 : True
		}
		[TestMethod]
		public void Case2() {
			Rational rationalValue;

			float floatValue = 16.25f;
			rationalValue=new Rational(floatValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  floatValue.GetType().Name,floatValue,
							  rationalValue.Equals(floatValue));

			double doubleValue = 16.25d;
			rationalValue=new Rational(doubleValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  doubleValue.GetType().Name,doubleValue,
							  rationalValue.Equals(doubleValue));
			// The example displays the following output:
			//    Rational 16.25 = Single 16.25 : True
			//    Rational 16.25 = Double 16.25 : True
		}
		[TestMethod]
		public void Case3() {
			Rational rationalValue;

			byte byteValue = 16;
			rationalValue=new Rational(byteValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  byteValue.GetType().Name,byteValue,
							  rationalValue.Equals(byteValue));

			sbyte sbyteValue = -16;
			rationalValue=new Rational(sbyteValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  sbyteValue.GetType().Name,sbyteValue,
							  rationalValue.Equals(sbyteValue));

			short shortValue = 1233;
			rationalValue=new Rational(shortValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  shortValue.GetType().Name,shortValue,
							  rationalValue.Equals(shortValue));

			ushort ushortValue = 64000;
			rationalValue=new Rational(ushortValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  ushortValue.GetType().Name,ushortValue,
							  rationalValue.Equals(ushortValue));

			int intValue = -1603854;
			rationalValue=new Rational(intValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  intValue.GetType().Name,intValue,
							  rationalValue.Equals(intValue));

			uint uintValue = 1223300;
			rationalValue=new Rational(uintValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  uintValue.GetType().Name,uintValue,
							  rationalValue.Equals(uintValue));

			long longValue = -123822229012;
			rationalValue=new Rational(longValue);
			Console.WriteLine("{0} {1} = {2} {3} : {4}",
							  rationalValue.GetType().Name,rationalValue,
							  longValue.GetType().Name,longValue,
							  rationalValue.Equals(longValue));
			// The example displays the following output:
			//    Rational 16 = Byte 16 : True
			//    Rational -16 = SByte -16 : True
			//    Rational 1233 = Int16 1233 : True
			//    Rational 64000 = UInt16 64000 : True
			//    Rational -1603854 = Int32 -1603854 : True
			//    Rational 1223300 = UInt32 1223300 : True
			//    Rational -123822229012 = Int64 -123822229012 : True
		}
		[TestMethod]
		public void Case4() {
			object[] obj = { 0,10,100,new Rational(1000),-10 };
			Rational[] rt = { Rational.Zero, new Rational (10),
						  new Rational (100), new Rational (1000),
						  new Rational (-10) };
			for(int ctr = 0;ctr<rt.Length;ctr++)
				Console.WriteLine(rt[ctr].Equals(obj[ctr]));
			// The example displays the following output:
			//       False
			//       False
			//       False
			//       True
			//       False
		}
		[TestMethod]
		public void Case5() {
			const long LIGHT_YEAR = 5878625373183;

			Rational altairDistance = 17*LIGHT_YEAR;
			Rational epsilonIndiDistance = 12*LIGHT_YEAR;
			Rational ursaeMajoris47Distance = 46*LIGHT_YEAR;
			long tauCetiDistance = 12*LIGHT_YEAR;
			ulong procyon2Distance = 12*LIGHT_YEAR;
			object wolf424ABDistance = 14*LIGHT_YEAR;

			Console.WriteLine("Approx. equal distances from Epsilon Indi to:");
			Console.WriteLine("   Altair: {0}",
							  epsilonIndiDistance.Equals(altairDistance));
			Console.WriteLine("   Ursae Majoris 47: {0}",
							  epsilonIndiDistance.Equals(ursaeMajoris47Distance));
			Console.WriteLine("   TauCeti: {0}",
							  epsilonIndiDistance.Equals(tauCetiDistance));
			Console.WriteLine("   Procyon 2: {0}",
							  epsilonIndiDistance.Equals(procyon2Distance));
			Console.WriteLine("   Wolf 424 AB: {0}",
							  epsilonIndiDistance.Equals(wolf424ABDistance));
			// The example displays the following output:
			//    Approx. equal distances from Epsilon Indi to:
			//       Altair: False
			//       Ursae Majoris 47: False
			//       TauCeti: True
			//       Procyon 2: True
			//       Wolf 424 AB: False   
		}
		[TestMethod]
		public void Case6() {
			const long LIGHT_YEAR = 5878625373183;
			Rational altairDistance = 17*LIGHT_YEAR;
			Rational epsilonIndiDistance = 12*LIGHT_YEAR;
			Rational ursaeMajoris47Distance = 46*LIGHT_YEAR;
			long tauCetiDistance = 12*LIGHT_YEAR;
			ulong procyon2Distance = 12*LIGHT_YEAR;
			object wolf424ABDistance = 14*LIGHT_YEAR;

			Console.WriteLine("Approx. equal distances from Epsilon Indi to:");
			Console.WriteLine("   Altair: {0}",
							  epsilonIndiDistance.Equals(altairDistance));
			Console.WriteLine("   Ursae Majoris 47: {0}",
							  epsilonIndiDistance.Equals(ursaeMajoris47Distance));
			Console.WriteLine("   TauCeti: {0}",
							  epsilonIndiDistance.Equals(tauCetiDistance));
			Console.WriteLine("   Procyon 2: {0}",
							  epsilonIndiDistance.Equals(procyon2Distance));
			Console.WriteLine("   Wolf 424 AB: {0}",
							  epsilonIndiDistance.Equals(wolf424ABDistance));
			// The example displays the following output:
			//    Approx. equal distances from Epsilon Indi to:
			//       Altair: False
			//       Ursae Majoris 47: False
			//       TauCeti: True
			//       Procyon 2: True
			//       Wolf 424 AB: False  
		}
		[TestMethod]
		public void Case7() {
			// The statement:
			//    bool comp = Int64.MaxValue == Int32.MaxValue;
			// produces compiler error CS0220: The operation overflows at compile time in checked mode.
			// The alternative:
			bool comp = Rational.Equals(Int64.MaxValue,Int32.MaxValue);
		}
	}
}
