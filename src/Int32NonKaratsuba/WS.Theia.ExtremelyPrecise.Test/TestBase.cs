using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ContainerType = System.UInt32;
using OuterInterfaceType = System.UInt64;

namespace WS.Theia.ExtremelyPrecise.Test {
	public class TestBase {

		protected Rational CreateObjectOIT(bool sign,OuterInterfaceType[] numerator,OuterInterfaceType[] denominator) {
			return new Rational(sign,ArrayConvertOIT(numerator),ArrayConvertOIT(denominator));
		}

		protected Rational CreateObjectCT(bool sign,ContainerType[] numerator,ContainerType[] denominator) {
			return new Rational(sign,ArrayConvertCT(numerator),ArrayConvertCT(denominator));
		}

		protected BigUInteger CreateObjectCT(ContainerType[] value) {
			return new BigUInteger(ArrayConvertCT(value));
		}

		private byte[] ArrayConvertOIT(OuterInterfaceType[] value) {
			var ContainerItemSizeWithByte = sizeof(OuterInterfaceType);

			var temp = new byte[ContainerItemSizeWithByte];
			var numerator = new byte[value.Length*ContainerItemSizeWithByte];

			for(int numeratorCounter = 0, containerCounter = 0;containerCounter<value.Length;containerCounter++, numeratorCounter+=ContainerItemSizeWithByte) {
				temp=BitConverter.GetBytes(value[containerCounter]);
				Array.Copy(temp,0,numerator,numeratorCounter,ContainerItemSizeWithByte);
			}
			return numerator;
		}

		private byte[] ArrayConvertCT(ContainerType[] value) {
			var ContainerItemSizeWithByte = sizeof(ContainerType);

			var temp = new byte[ContainerItemSizeWithByte];
			var numerator = new byte[value.Length*ContainerItemSizeWithByte];

			for(int numeratorCounter = 0, containerCounter = 0;containerCounter<value.Length;containerCounter++, numeratorCounter+=ContainerItemSizeWithByte) {
				temp=BitConverter.GetBytes(value[containerCounter]);
				Array.Copy(temp,0,numerator,numeratorCounter,ContainerItemSizeWithByte);
			}
			return numerator;
		}

		protected void ExecTest<T>(T target,T assertValue) {
			Assert.AreEqual<T>(target,assertValue);
		}

		protected void ExecTest(Rational target,Rational assertValue) {
			var (sign,numerator,denominator,infinity)=assertValue.ToByteArray();
			this.ExecTest(target,sign,numerator,denominator,infinity);
		}

		protected void ExecTest(Rational value,bool sign,byte[] numerator,byte[] denominator,bool infinity) {
			var (Sign, Numerator, Denominator, Infinity)=value.ToByteArray();
			Assert.AreEqual<bool>(Sign,sign);
			CompereArray(Numerator,numerator);
			CompereArray(Denominator,denominator);
			Assert.AreEqual<bool>(Infinity,infinity);
		}

		protected void ExecTest(bool Sign,byte[] Numerator,byte[] Denominator,bool Infinity,bool sign,byte[] numerator,byte[] denominator,bool infinity) {
			Assert.AreEqual<bool>(Sign,sign);
			CompereArray(Numerator,numerator);
			CompereArray(Denominator,denominator);
			Assert.AreEqual<bool>(Infinity,infinity);
		}

		protected void CompereArray(byte[] target,byte[] compereData) {
			var compereEnd = System.Math.Min(target.Length,compereData.Length);
			var counter = 0;
			for(;counter<compereEnd;counter++) {
				Assert.AreEqual<byte>(target[counter],compereData[counter]);
			}
			for(;counter<compereData.Length;counter++) {
				Assert.AreEqual<byte>(compereData[counter],0);
			}
			for(;counter<target.Length;counter++) {
				Assert.AreEqual<byte>(target[counter],0);
			}
		}

	}
}
