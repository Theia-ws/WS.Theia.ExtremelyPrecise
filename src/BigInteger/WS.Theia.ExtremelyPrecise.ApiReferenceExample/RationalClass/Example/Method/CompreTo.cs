using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace WS.Theia.ExtremelyPrecise.ApiReferenceExample.RationalClass.Example.Method {
	[TestClass]
	public class CompreTo {
		[TestMethod]
		public void Case1() {
			Rational rationalValue = Rational.Parse("3221123045552");

			byte byteValue = 16;
			sbyte sbyteValue = -16;
			short shortValue = 1233;
			ushort ushortValue = 1233;
			int intValue = -12233;
			uint uintValue = 12233;
			long longValue = 12382222;
			ulong ulongValue = 1238222;

			Console.WriteLine("Comparing {0} with {1}: {2}",
							  rationalValue,byteValue,
							  rationalValue.CompareTo(byteValue));
			Console.WriteLine("Comparing {0} with {1}: {2}",
							  rationalValue,sbyteValue,
							  rationalValue.CompareTo(sbyteValue));
			Console.WriteLine("Comparing {0} with {1}: {2}",
							  rationalValue,shortValue,
							  rationalValue.CompareTo(shortValue));
			Console.WriteLine("Comparing {0} with {1}: {2}",
							  rationalValue,ushortValue,
							  rationalValue.CompareTo(ushortValue));
			Console.WriteLine("Comparing {0} with {1}: {2}",
							  rationalValue,intValue,
							  rationalValue.CompareTo(intValue));
			Console.WriteLine("Comparing {0} with {1}: {2}",
							  rationalValue,uintValue,
							  rationalValue.CompareTo(uintValue));
			Console.WriteLine("Comparing {0} with {1}: {2}",
							  rationalValue,longValue,
							  rationalValue.CompareTo(longValue));
			Console.WriteLine("Comparing {0} with {1}: {2}",
							  rationalValue,ulongValue,
							  rationalValue.CompareTo(ulongValue));
			// The example displays the following output:
			//       Comparing 3221123045552 with 16: 1
			//       Comparing 3221123045552 with -16: 1
			//       Comparing 3221123045552 with 1233: 1
			//       Comparing 3221123045552 with 1233: 1
			//       Comparing 3221123045552 with -12233: 1
			//       Comparing 3221123045552 with 12233: 1
			//       Comparing 3221123045552 with 12382222: 1
			//       Comparing 3221123045552 with 1238222: 1

		}
		[TestMethod]
		public void Case2() {
			object[] values = { Math.Pow(Int64.MaxValue, 10), null,
					12.534, Int64.MaxValue, Rational.One };
			Rational number = UInt64.MaxValue;

			foreach(object value in values) {
				try {
					Console.WriteLine("Comparing {0} with '{1}': {2}",number,value,
									  number.CompareTo(value));
				} catch(ArgumentException) {
					Console.WriteLine("Unable to compare the {0} value {1} with a Rational.",
									  value.GetType().Name,value);
				}
			}
			// The example displays the following output:
			//    Comparing 18446744073709551615 with '4.4555084156466750133735972424E+189': -1
			//    Comparing 18446744073709551615 with '': 1
			//    Unable to compare the Double value 12.534 with a Rational.
			//    Unable to compare the Int64 value 9223372036854775807 with a Rational.
			//    Comparing 18446744073709551615 with '1': 1
			//TODO:指数表記で出力できる例に変更したい
		}
		public struct StarInfo:IComparable<StarInfo> {
			// Define constructors.
			public StarInfo(string name,double lightYears) {
				this.Name=name;

				// Calculate distance in miles from light years.
				this.Distance=(Rational)Math.Round(lightYears*5.88e12);
			}

			public StarInfo(string name,Rational distance) {
				this.Name=name;
				this.Distance=distance;
			}

			// Define public fields.
			public string Name;
			public Rational Distance;

			// Display name of star and its distance in parentheses.
			public override string ToString() {
				return String.Format("{0,-10} ({1:N0})",this.Name,this.Distance);
			}

			// Compare StarInfo objects by their distance from Earth.
			public int CompareTo(StarInfo other) {
				return this.Distance.CompareTo(other.Distance);
			}
		}
		[TestMethod]
		public void Case3() {
			StarInfo star;
			List<StarInfo> stars = new List<StarInfo>();

			star=new StarInfo("Sirius",8.6d);
			stars.Add(star);
			star=new StarInfo("Rigel",1400d);
			stars.Add(star);
			star=new StarInfo("Castor",49d);
			stars.Add(star);
			star=new StarInfo("Antares",520d);
			stars.Add(star);

			stars.Sort();

			foreach(StarInfo sortedStar in stars)
				Console.WriteLine(sortedStar);
			// The example displays the following output:
			//       Sirius     (50,568,000,000,000)
			//       Castor     (288,120,000,000,000)
			//       Antares    (3,057,600,000,000,000)
			//       Rigel      (8,232,000,000,000,000)
		}
	}
}
