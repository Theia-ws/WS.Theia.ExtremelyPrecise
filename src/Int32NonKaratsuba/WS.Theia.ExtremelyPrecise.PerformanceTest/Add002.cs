using Microsoft.VisualStudio.TestTools.UnitTesting;
using WS.Theia.ExtremelyPrecise.Test;

namespace WS.Theia.ExtremelyPrecise.PerformanceTest.Add {
	[TestClass]
	public class Add002:TestBase {

		[TestMethod]
		public void Add16_0(){
			var ans=new BigUInteger(new byte[]{40,35,238,5,148,172,212,246,171,30,152,20,213,128,95,144,0})+new BigUInteger(new byte[]{144,73,172,124,50,238,222,83,150,109,37,96,182,56,127,168,0});
		}

		[TestMethod]
		public void Add16_1(){
			var ans=new BigUInteger(new byte[]{162,23,194,92,156,28,232,165,24,193,241,101,203,189,74,7,0})+new BigUInteger(new byte[]{20,5,163,100,240,242,252,85,40,224,65,46,249,45,88,169,0});
		}

		[TestMethod]
		public void Add16_2(){
			var ans=new BigUInteger(new byte[]{150,2,135,236,102,74,77,70,143,213,27,234,91,33,206,105,0})+new BigUInteger(new byte[]{220,52,190,178,184,105,210,39,237,117,148,116,101,164,35,1,0});
		}

		[TestMethod]
		public void Add16_3(){
			var ans=new BigUInteger(new byte[]{224,2,56,223,87,18,208,100,29,224,243,245,63,217,24,73,0})+new BigUInteger(new byte[]{9,221,164,119,158,229,231,26,184,170,111,145,154,164,108,210,0});
		}

		[TestMethod]
		public void Add16_4(){
			var ans=new BigUInteger(new byte[]{248,134,234,182,149,101,154,14,6,171,236,177,239,116,21,213,0})+new BigUInteger(new byte[]{84,253,22,240,1,179,211,215,224,102,92,247,131,50,45,217,0});
		}

		[TestMethod]
		public void Add16_5(){
			var ans=new BigUInteger(new byte[]{153,75,24,12,2,248,149,75,153,244,230,192,116,180,54,125,0})+new BigUInteger(new byte[]{9,40,118,189,229,254,108,204,143,232,194,92,67,142,56,203,0});
		}

		[TestMethod]
		public void Add16_6(){
			var ans=new BigUInteger(new byte[]{148,131,119,2,181,214,20,111,211,151,169,217,170,96,123,191,0})+new BigUInteger(new byte[]{225,189,29,181,158,84,152,5,54,210,238,242,192,196,118,211,0});
		}

		[TestMethod]
		public void Add16_7(){
			var ans=new BigUInteger(new byte[]{217,108,191,192,44,89,98,48,228,142,219,111,246,28,153,61,0})+new BigUInteger(new byte[]{101,51,104,179,248,249,164,44,132,156,160,218,104,200,218,143,0});
		}

		[TestMethod]
		public void Add16_8(){
			var ans=new BigUInteger(new byte[]{64,200,184,217,75,124,13,40,41,195,225,128,148,140,18,61,0})+new BigUInteger(new byte[]{24,251,37,207,16,153,128,77,245,72,114,65,129,212,109,6,0});
		}

		[TestMethod]
		public void Add16_9(){
			var ans=new BigUInteger(new byte[]{149,138,62,69,161,165,96,138,138,154,3,188,193,205,130,228,0})+new BigUInteger(new byte[]{105,151,36,178,189,95,2,37,157,188,195,132,96,13,16,149,0});
		}

		[TestMethod]
		public void Add16_10(){
			var ans=new BigUInteger(new byte[]{176,65,184,140,20,57,41,63,201,159,3,241,65,94,120,86,0})+new BigUInteger(new byte[]{37,142,155,102,151,239,66,210,97,158,154,149,227,54,68,39,0});
		}

		[TestMethod]
		public void Add16_11(){
			var ans=new BigUInteger(new byte[]{213,249,229,150,61,164,67,56,79,28,218,100,53,31,197,195,0})+new BigUInteger(new byte[]{161,59,178,45,211,122,184,159,228,47,88,77,21,76,20,149,0});
		}

		[TestMethod]
		public void Add16_12(){
			var ans=new BigUInteger(new byte[]{65,55,41,72,10,176,221,25,89,222,176,182,35,52,136,216,0})+new BigUInteger(new byte[]{78,194,46,41,173,21,250,0,106,199,6,174,220,188,193,254,0});
		}

		[TestMethod]
		public void Add16_13(){
			var ans=new BigUInteger(new byte[]{151,71,83,19,233,187,9,116,217,146,167,231,197,220,125,244,0})+new BigUInteger(new byte[]{183,11,33,159,61,228,245,226,150,251,100,231,245,86,215,107,0});
		}

		[TestMethod]
		public void Add16_14(){
			var ans=new BigUInteger(new byte[]{86,250,62,243,146,43,217,242,244,33,17,60,187,225,234,160,0})+new BigUInteger(new byte[]{189,111,151,39,57,108,11,42,54,167,17,218,56,61,116,245,0});
		}

		[TestMethod]
		public void Add16_15(){
			var ans=new BigUInteger(new byte[]{64,60,112,125,50,174,128,3,169,141,139,19,249,59,182,15,0})+new BigUInteger(new byte[]{82,33,140,243,159,163,169,205,119,164,211,184,116,113,102,212,0});
		}

		[TestMethod]
		public void Add16_16(){
			var ans=new BigUInteger(new byte[]{91,103,233,249,246,162,97,238,123,54,88,219,102,143,220,226,0})+new BigUInteger(new byte[]{163,13,34,6,121,86,76,91,190,71,148,129,72,241,224,111,0});
		}

		[TestMethod]
		public void Add16_17(){
			var ans=new BigUInteger(new byte[]{153,8,221,18,226,163,76,105,225,45,47,84,247,252,148,75,0})+new BigUInteger(new byte[]{134,18,107,105,84,190,212,71,243,106,198,153,96,66,14,161,0});
		}

		[TestMethod]
		public void Add16_18(){
			var ans=new BigUInteger(new byte[]{175,142,189,75,227,56,115,201,46,216,229,36,9,81,165,182,0})+new BigUInteger(new byte[]{37,136,188,102,4,148,236,79,214,50,149,108,194,88,215,70,0});
		}

		[TestMethod]
		public void Add16_19(){
			var ans=new BigUInteger(new byte[]{7,191,70,243,231,236,176,68,73,181,28,137,27,47,172,99,0})+new BigUInteger(new byte[]{214,64,158,209,54,212,91,40,46,106,92,192,191,143,186,88,0});
		}

		[TestMethod]
		public void Add16_20(){
			var ans=new BigUInteger(new byte[]{3,159,42,233,89,137,111,120,4,239,237,6,208,31,121,25,0})+new BigUInteger(new byte[]{58,81,97,118,178,234,30,215,127,55,74,169,62,115,180,124,0});
		}

		[TestMethod]
		public void Add16_21(){
			var ans=new BigUInteger(new byte[]{229,197,242,166,159,205,28,119,137,36,243,225,82,245,1,96,0})+new BigUInteger(new byte[]{15,35,175,144,152,209,59,11,36,219,248,127,243,74,245,42,0});
		}

		[TestMethod]
		public void Add16_22(){
			var ans=new BigUInteger(new byte[]{242,108,223,77,107,77,20,244,27,178,157,87,157,13,98,150,0})+new BigUInteger(new byte[]{30,74,134,30,99,205,68,160,60,125,142,86,61,248,231,130,0});
		}

		[TestMethod]
		public void Add16_23(){
			var ans=new BigUInteger(new byte[]{187,78,58,123,113,28,53,92,112,66,39,133,247,164,214,22,0})+new BigUInteger(new byte[]{229,100,93,101,158,222,225,248,201,167,120,120,113,219,132,211,0});
		}

		[TestMethod]
		public void Add16_24(){
			var ans=new BigUInteger(new byte[]{11,205,22,92,146,36,162,191,23,187,51,112,63,162,56,223,0})+new BigUInteger(new byte[]{204,61,222,37,222,150,38,250,106,131,93,118,164,78,119,12,0});
		}

		[TestMethod]
		public void Add16_25(){
			var ans=new BigUInteger(new byte[]{83,194,185,67,138,242,123,151,129,223,127,19,34,142,248,74,0})+new BigUInteger(new byte[]{200,0,174,212,110,46,97,211,171,200,127,229,212,130,252,223,0});
		}

		[TestMethod]
		public void Add16_26(){
			var ans=new BigUInteger(new byte[]{9,47,223,67,107,165,98,1,205,254,53,17,27,135,55,20,0})+new BigUInteger(new byte[]{63,48,23,227,104,222,27,159,81,123,44,79,124,184,155,88,0});
		}

		[TestMethod]
		public void Add16_27(){
			var ans=new BigUInteger(new byte[]{63,130,36,62,78,194,43,39,26,27,88,83,102,177,103,121,0})+new BigUInteger(new byte[]{251,134,130,0,43,226,205,249,171,169,51,203,61,205,29,150,0});
		}

		[TestMethod]
		public void Add16_28(){
			var ans=new BigUInteger(new byte[]{2,109,169,185,155,14,113,250,126,184,1,182,205,52,161,188,0})+new BigUInteger(new byte[]{118,206,143,91,142,22,110,227,76,93,73,25,162,5,183,123,0});
		}

		[TestMethod]
		public void Add16_29(){
			var ans=new BigUInteger(new byte[]{105,179,137,251,163,45,72,232,30,206,178,174,149,183,227,58,0})+new BigUInteger(new byte[]{17,8,191,133,0,165,184,126,39,247,126,18,18,51,186,63,0});
		}

		[TestMethod]
		public void Add16_30(){
			var ans=new BigUInteger(new byte[]{132,167,235,52,228,28,204,94,176,89,234,87,129,74,237,34,0})+new BigUInteger(new byte[]{173,105,116,24,6,124,180,195,141,101,104,238,144,164,204,45,0});
		}

		[TestMethod]
		public void Add16_31(){
			var ans=new BigUInteger(new byte[]{236,245,8,150,220,93,114,90,173,25,78,137,47,237,220,169,0})+new BigUInteger(new byte[]{63,11,131,43,238,193,172,224,95,56,109,151,134,197,70,118,0});
		}

		[TestMethod]
		public void Add16_32(){
			var ans=new BigUInteger(new byte[]{23,177,210,207,70,207,95,100,136,85,48,190,239,51,203,160,0})+new BigUInteger(new byte[]{31,123,99,106,220,228,3,224,240,93,169,148,141,161,140,144,0});
		}

		[TestMethod]
		public void Add16_33(){
			var ans=new BigUInteger(new byte[]{144,228,144,40,126,109,133,68,241,17,106,90,2,242,132,159,0})+new BigUInteger(new byte[]{96,132,204,130,5,234,104,171,153,162,223,132,144,160,130,88,0});
		}

		[TestMethod]
		public void Add16_34(){
			var ans=new BigUInteger(new byte[]{92,159,201,176,182,175,158,82,171,171,47,79,20,112,200,166,0})+new BigUInteger(new byte[]{249,193,125,70,116,94,54,157,72,149,71,185,109,11,72,203,0});
		}

		[TestMethod]
		public void Add16_35(){
			var ans=new BigUInteger(new byte[]{80,158,143,105,135,214,156,108,248,117,54,3,71,40,117,163,0})+new BigUInteger(new byte[]{95,122,148,219,45,182,35,229,34,217,33,158,158,90,29,29,0});
		}

		[TestMethod]
		public void Add16_36(){
			var ans=new BigUInteger(new byte[]{216,227,208,74,242,95,99,193,31,121,33,254,7,215,254,130,0})+new BigUInteger(new byte[]{101,135,240,136,94,83,52,99,1,102,111,183,134,88,19,210,0});
		}

		[TestMethod]
		public void Add16_37(){
			var ans=new BigUInteger(new byte[]{9,74,140,206,64,238,50,37,81,98,126,220,140,3,89,212,0})+new BigUInteger(new byte[]{174,78,229,142,85,63,105,38,3,70,169,100,244,128,32,7,0});
		}

		[TestMethod]
		public void Add16_38(){
			var ans=new BigUInteger(new byte[]{136,109,175,80,1,186,15,243,187,139,158,221,147,37,24,107,0})+new BigUInteger(new byte[]{99,125,166,137,105,130,154,31,132,179,254,135,233,137,251,48,0});
		}

		[TestMethod]
		public void Add16_39(){
			var ans=new BigUInteger(new byte[]{52,164,222,24,7,227,57,27,61,151,65,222,108,61,5,67,0})+new BigUInteger(new byte[]{214,92,26,137,10,191,140,74,132,7,117,65,195,234,73,39,0});
		}

		[TestMethod]
		public void Add16_40(){
			var ans=new BigUInteger(new byte[]{170,45,69,5,47,123,10,8,253,188,150,95,1,122,59,96,0})+new BigUInteger(new byte[]{108,88,207,109,58,46,209,78,76,185,40,177,17,12,7,211,0});
		}

		[TestMethod]
		public void Add16_41(){
			var ans=new BigUInteger(new byte[]{76,145,182,139,230,87,57,187,122,136,108,222,191,179,190,29,0})+new BigUInteger(new byte[]{56,169,17,166,66,54,21,176,114,46,13,18,175,171,111,124,0});
		}

		[TestMethod]
		public void Add16_42(){
			var ans=new BigUInteger(new byte[]{231,99,98,153,43,50,237,55,108,2,155,38,179,45,171,174,0})+new BigUInteger(new byte[]{140,23,124,81,218,206,54,191,210,113,4,224,197,136,210,169,0});
		}

		[TestMethod]
		public void Add16_43(){
			var ans=new BigUInteger(new byte[]{133,21,115,88,56,152,114,195,131,204,205,5,52,153,31,186,0})+new BigUInteger(new byte[]{215,18,185,67,53,210,230,92,128,115,231,198,43,156,232,171,0});
		}

		[TestMethod]
		public void Add16_44(){
			var ans=new BigUInteger(new byte[]{97,80,244,237,152,157,151,208,4,35,170,134,246,36,122,195,0})+new BigUInteger(new byte[]{105,122,169,52,166,107,231,207,144,126,105,101,82,160,157,219,0});
		}

		[TestMethod]
		public void Add16_45(){
			var ans=new BigUInteger(new byte[]{240,136,127,163,51,212,100,30,135,124,107,179,54,125,5,32,0})+new BigUInteger(new byte[]{236,39,187,167,93,175,34,221,23,211,237,235,55,29,63,136,0});
		}

		[TestMethod]
		public void Add16_46(){
			var ans=new BigUInteger(new byte[]{235,171,253,127,2,142,136,66,157,36,30,150,2,165,25,235,0})+new BigUInteger(new byte[]{108,48,216,174,253,250,32,91,70,25,160,50,160,36,246,155,0});
		}

		[TestMethod]
		public void Add16_47(){
			var ans=new BigUInteger(new byte[]{75,19,219,38,222,230,215,212,203,182,121,58,139,1,140,5,0})+new BigUInteger(new byte[]{106,200,105,173,200,169,68,92,242,162,166,16,91,51,230,59,0});
		}

		[TestMethod]
		public void Add16_48(){
			var ans=new BigUInteger(new byte[]{20,190,200,254,10,170,144,226,232,35,155,197,71,89,94,84,0})+new BigUInteger(new byte[]{114,231,236,212,209,90,136,57,236,245,249,129,51,82,137,247,0});
		}

		[TestMethod]
		public void Add16_49(){
			var ans=new BigUInteger(new byte[]{165,135,245,36,119,119,214,159,122,218,122,230,20,7,107,192,0})+new BigUInteger(new byte[]{121,184,8,107,193,115,239,72,203,205,106,200,105,80,83,93,0});
		}

		[TestMethod]
		public void Add16_50(){
			var ans=new BigUInteger(new byte[]{108,144,24,8,41,46,182,235,153,102,120,190,154,171,207,44,0})+new BigUInteger(new byte[]{146,137,168,186,98,235,80,102,18,99,198,199,238,226,65,214,0});
		}

		[TestMethod]
		public void Add16_51(){
			var ans=new BigUInteger(new byte[]{84,147,98,42,73,147,109,143,147,66,137,198,236,119,177,246,0})+new BigUInteger(new byte[]{119,130,109,17,236,58,248,106,175,127,33,168,181,112,222,91,0});
		}

		[TestMethod]
		public void Add16_52(){
			var ans=new BigUInteger(new byte[]{17,244,131,33,249,206,7,140,18,199,150,4,48,8,207,177,0})+new BigUInteger(new byte[]{36,119,34,55,5,211,84,176,52,131,43,126,146,219,29,230,0});
		}

		[TestMethod]
		public void Add16_53(){
			var ans=new BigUInteger(new byte[]{32,118,45,16,66,88,195,26,224,234,141,101,9,210,146,189,0})+new BigUInteger(new byte[]{5,32,242,107,208,245,91,140,166,48,92,65,178,239,99,105,0});
		}

		[TestMethod]
		public void Add16_54(){
			var ans=new BigUInteger(new byte[]{160,19,61,205,239,130,45,163,172,34,220,136,52,17,165,142,0})+new BigUInteger(new byte[]{144,181,173,227,114,227,212,90,34,202,181,59,32,170,65,221,0});
		}

		[TestMethod]
		public void Add16_55(){
			var ans=new BigUInteger(new byte[]{235,57,57,239,233,41,247,229,3,241,104,215,181,5,85,221,0})+new BigUInteger(new byte[]{24,103,117,252,166,118,246,156,101,221,134,171,61,186,154,184,0});
		}

		[TestMethod]
		public void Add16_56(){
			var ans=new BigUInteger(new byte[]{222,38,15,89,133,61,165,69,153,155,171,4,205,105,159,251,0})+new BigUInteger(new byte[]{76,147,34,179,117,46,250,86,68,197,92,6,98,2,17,105,0});
		}

		[TestMethod]
		public void Add16_57(){
			var ans=new BigUInteger(new byte[]{222,232,136,120,155,240,17,26,150,21,170,26,201,214,196,249,0})+new BigUInteger(new byte[]{40,192,80,81,205,106,227,113,206,121,154,88,156,81,68,251,0});
		}

		[TestMethod]
		public void Add16_58(){
			var ans=new BigUInteger(new byte[]{68,112,45,141,177,233,92,21,81,159,101,226,181,63,250,34,0})+new BigUInteger(new byte[]{146,10,209,174,207,46,189,207,99,219,16,113,55,254,138,104,0});
		}

		[TestMethod]
		public void Add16_59(){
			var ans=new BigUInteger(new byte[]{75,14,133,84,199,32,174,114,210,253,197,164,125,21,23,52,0})+new BigUInteger(new byte[]{120,242,226,130,140,207,107,23,227,143,147,163,151,12,206,182,0});
		}

		[TestMethod]
		public void Add16_60(){
			var ans=new BigUInteger(new byte[]{172,165,85,246,251,107,185,23,20,121,195,119,24,179,20,188,0})+new BigUInteger(new byte[]{64,81,63,147,13,53,92,40,43,241,70,195,148,128,232,200,0});
		}

		[TestMethod]
		public void Add16_61(){
			var ans=new BigUInteger(new byte[]{34,43,151,58,176,49,129,46,117,171,13,37,49,153,73,148,0})+new BigUInteger(new byte[]{133,55,49,102,59,49,2,230,133,194,222,175,60,76,74,179,0});
		}

		[TestMethod]
		public void Add16_62(){
			var ans=new BigUInteger(new byte[]{75,161,221,190,89,199,202,152,120,106,212,191,122,102,52,185,0})+new BigUInteger(new byte[]{180,107,81,112,38,169,225,106,110,167,11,140,171,225,27,19,0});
		}

		[TestMethod]
		public void Add16_63(){
			var ans=new BigUInteger(new byte[]{7,96,111,128,150,35,84,92,114,81,203,127,2,50,52,60,0})+new BigUInteger(new byte[]{81,152,28,92,187,90,121,45,10,107,117,247,165,79,9,123,0});
		}

		[TestMethod]
		public void Add16_64(){
			var ans=new BigUInteger(new byte[]{24,140,4,237,141,231,212,132,240,74,88,167,94,146,17,41,0})+new BigUInteger(new byte[]{74,59,175,40,190,102,161,251,47,228,102,22,111,219,1,10,0});
		}

		[TestMethod]
		public void Add16_65(){
			var ans=new BigUInteger(new byte[]{210,97,241,28,195,237,64,241,34,231,141,27,198,155,160,53,0})+new BigUInteger(new byte[]{190,135,132,63,109,107,165,192,120,98,58,120,205,206,3,8,0});
		}

		[TestMethod]
		public void Add16_66(){
			var ans=new BigUInteger(new byte[]{121,105,241,231,49,123,160,134,253,114,40,205,215,132,47,243,0})+new BigUInteger(new byte[]{214,51,63,5,149,33,117,233,93,26,108,129,220,13,158,62,0});
		}

		[TestMethod]
		public void Add16_67(){
			var ans=new BigUInteger(new byte[]{219,240,252,144,16,193,88,159,39,235,82,99,69,111,3,147,0})+new BigUInteger(new byte[]{177,136,130,138,242,17,173,192,68,207,200,216,98,169,141,163,0});
		}

		[TestMethod]
		public void Add16_68(){
			var ans=new BigUInteger(new byte[]{98,247,175,0,220,54,102,174,179,67,81,178,143,182,55,3,0})+new BigUInteger(new byte[]{21,206,117,46,118,131,251,245,6,248,178,56,246,54,24,104,0});
		}

		[TestMethod]
		public void Add16_69(){
			var ans=new BigUInteger(new byte[]{198,196,157,107,100,6,220,253,23,36,41,74,249,202,91,25,0})+new BigUInteger(new byte[]{78,119,231,20,35,151,180,115,179,157,61,230,113,55,228,162,0});
		}

		[TestMethod]
		public void Add16_70(){
			var ans=new BigUInteger(new byte[]{169,43,31,99,36,40,10,50,38,145,134,117,184,160,150,150,0})+new BigUInteger(new byte[]{160,89,58,58,179,231,201,227,113,128,130,175,70,153,248,64,0});
		}

		[TestMethod]
		public void Add16_71(){
			var ans=new BigUInteger(new byte[]{218,232,179,164,13,120,194,170,43,220,166,247,158,85,10,147,0})+new BigUInteger(new byte[]{79,68,34,86,48,123,27,243,171,92,95,20,164,69,82,0,0});
		}

		[TestMethod]
		public void Add16_72(){
			var ans=new BigUInteger(new byte[]{127,103,156,181,6,123,48,194,118,166,246,50,155,229,95,107,0})+new BigUInteger(new byte[]{4,110,215,142,17,25,135,121,178,106,210,104,190,159,68,95,0});
		}

		[TestMethod]
		public void Add16_73(){
			var ans=new BigUInteger(new byte[]{143,92,177,83,247,96,223,39,190,46,182,50,121,51,110,242,0})+new BigUInteger(new byte[]{250,157,225,46,145,31,153,219,187,85,98,129,188,144,28,80,0});
		}

		[TestMethod]
		public void Add16_74(){
			var ans=new BigUInteger(new byte[]{16,188,115,106,47,49,104,163,20,18,124,58,169,88,179,133,0})+new BigUInteger(new byte[]{93,96,56,58,149,41,123,142,80,92,183,23,36,231,203,31,0});
		}

		[TestMethod]
		public void Add16_75(){
			var ans=new BigUInteger(new byte[]{220,107,56,74,39,106,126,167,196,64,25,59,101,194,135,239,0})+new BigUInteger(new byte[]{235,117,210,187,11,159,249,158,210,140,51,10,56,229,0,22,0});
		}

		[TestMethod]
		public void Add16_76(){
			var ans=new BigUInteger(new byte[]{53,2,7,204,241,135,116,167,30,244,46,206,176,173,73,236,0})+new BigUInteger(new byte[]{181,16,6,171,249,246,42,83,48,84,240,46,40,152,249,188,0});
		}

		[TestMethod]
		public void Add16_77(){
			var ans=new BigUInteger(new byte[]{71,62,163,215,60,5,1,29,59,190,41,189,148,62,121,5,0})+new BigUInteger(new byte[]{233,170,201,82,213,247,145,108,86,87,80,0,56,62,180,43,0});
		}

		[TestMethod]
		public void Add16_78(){
			var ans=new BigUInteger(new byte[]{32,196,4,150,140,186,100,150,117,36,226,43,121,107,109,220,0})+new BigUInteger(new byte[]{104,9,172,23,234,9,102,239,58,158,110,185,157,181,195,183,0});
		}

		[TestMethod]
		public void Add16_79(){
			var ans=new BigUInteger(new byte[]{214,110,186,12,214,199,166,248,60,38,66,228,151,157,75,21,0})+new BigUInteger(new byte[]{143,101,56,121,49,209,24,204,22,166,6,100,178,121,26,228,0});
		}

		[TestMethod]
		public void Add16_80(){
			var ans=new BigUInteger(new byte[]{78,184,219,22,234,158,42,171,133,248,102,15,192,138,40,66,0})+new BigUInteger(new byte[]{223,24,56,222,114,190,16,166,175,233,122,251,254,124,198,23,0});
		}

		[TestMethod]
		public void Add16_81(){
			var ans=new BigUInteger(new byte[]{9,76,241,51,51,83,9,63,5,215,32,191,159,53,245,42,0})+new BigUInteger(new byte[]{83,186,102,31,142,72,98,238,32,186,220,230,102,194,235,9,0});
		}

		[TestMethod]
		public void Add16_82(){
			var ans=new BigUInteger(new byte[]{59,148,9,102,158,157,143,236,115,240,64,169,4,254,191,141,0})+new BigUInteger(new byte[]{226,196,106,242,52,121,163,188,204,50,48,219,146,250,165,207,0});
		}

		[TestMethod]
		public void Add16_83(){
			var ans=new BigUInteger(new byte[]{179,26,218,165,213,129,73,90,142,42,104,48,112,151,223,145,0})+new BigUInteger(new byte[]{153,224,88,53,245,122,170,6,83,38,39,108,19,50,6,42,0});
		}

		[TestMethod]
		public void Add16_84(){
			var ans=new BigUInteger(new byte[]{4,95,108,245,168,161,99,147,164,50,14,86,122,82,181,186,0})+new BigUInteger(new byte[]{27,126,48,141,170,242,40,141,12,105,20,150,1,22,221,247,0});
		}

		[TestMethod]
		public void Add16_85(){
			var ans=new BigUInteger(new byte[]{76,58,221,92,240,112,139,28,143,50,177,182,100,141,112,18,0})+new BigUInteger(new byte[]{207,64,178,132,228,202,240,152,163,248,71,134,76,72,14,207,0});
		}

		[TestMethod]
		public void Add16_86(){
			var ans=new BigUInteger(new byte[]{190,53,149,119,71,121,187,71,29,176,149,16,190,64,223,167,0})+new BigUInteger(new byte[]{254,86,253,196,41,59,3,254,114,176,226,190,138,0,220,155,0});
		}

		[TestMethod]
		public void Add16_87(){
			var ans=new BigUInteger(new byte[]{136,243,53,18,179,242,130,87,103,249,188,77,243,192,95,93,0})+new BigUInteger(new byte[]{3,112,139,116,112,61,235,80,190,79,80,181,118,214,140,178,0});
		}

		[TestMethod]
		public void Add16_88(){
			var ans=new BigUInteger(new byte[]{113,164,44,166,93,196,250,139,141,194,250,222,118,219,25,229,0})+new BigUInteger(new byte[]{181,38,201,53,134,4,193,158,13,29,92,134,153,74,39,194,0});
		}

		[TestMethod]
		public void Add16_89(){
			var ans=new BigUInteger(new byte[]{9,116,234,22,204,127,50,158,104,226,15,152,146,45,86,74,0})+new BigUInteger(new byte[]{217,31,162,93,109,38,156,71,82,248,34,46,170,252,85,241,0});
		}

		[TestMethod]
		public void Add16_90(){
			var ans=new BigUInteger(new byte[]{140,94,180,89,19,4,188,161,85,152,73,46,68,231,233,9,0})+new BigUInteger(new byte[]{41,192,217,138,191,156,144,92,125,141,23,189,172,37,71,214,0});
		}

		[TestMethod]
		public void Add16_91(){
			var ans=new BigUInteger(new byte[]{90,177,78,58,198,88,90,133,138,189,183,221,110,243,253,91,0})+new BigUInteger(new byte[]{140,78,208,154,181,169,134,18,149,63,166,183,173,233,10,44,0});
		}

		[TestMethod]
		public void Add16_92(){
			var ans=new BigUInteger(new byte[]{71,240,116,168,179,59,233,243,203,140,94,88,215,220,120,11,0})+new BigUInteger(new byte[]{81,178,190,6,147,106,227,245,94,65,107,91,144,90,109,69,0});
		}

		[TestMethod]
		public void Add16_93(){
			var ans=new BigUInteger(new byte[]{101,198,160,157,83,80,105,123,151,179,108,245,32,131,248,92,0})+new BigUInteger(new byte[]{81,17,39,179,147,150,198,56,4,44,136,72,28,43,215,210,0});
		}

		[TestMethod]
		public void Add16_94(){
			var ans=new BigUInteger(new byte[]{48,108,36,109,25,40,85,209,140,233,66,33,218,161,28,237,0})+new BigUInteger(new byte[]{193,22,215,156,224,136,185,33,83,224,128,219,25,38,149,83,0});
		}

		[TestMethod]
		public void Add16_95(){
			var ans=new BigUInteger(new byte[]{12,70,241,157,176,183,24,123,195,150,174,155,11,160,228,230,0})+new BigUInteger(new byte[]{34,123,180,152,176,97,108,187,211,241,97,52,114,32,14,169,0});
		}

		[TestMethod]
		public void Add16_96(){
			var ans=new BigUInteger(new byte[]{78,143,181,222,30,216,62,31,126,220,44,112,142,153,175,234,0})+new BigUInteger(new byte[]{189,210,87,85,11,101,147,238,130,120,16,157,193,93,66,190,0});
		}

		[TestMethod]
		public void Add16_97(){
			var ans=new BigUInteger(new byte[]{11,15,234,252,22,148,20,75,155,72,73,28,28,128,61,65,0})+new BigUInteger(new byte[]{28,243,11,10,64,163,180,128,21,95,130,90,22,217,84,39,0});
		}

		[TestMethod]
		public void Add16_98(){
			var ans=new BigUInteger(new byte[]{72,89,185,121,118,124,250,121,130,4,95,32,22,73,25,58,0})+new BigUInteger(new byte[]{250,8,109,93,171,33,20,36,161,112,203,115,237,123,173,219,0});
		}

		[TestMethod]
		public void Add16_99(){
			var ans=new BigUInteger(new byte[]{241,157,65,91,55,72,200,128,218,106,218,173,3,242,249,149,0})+new BigUInteger(new byte[]{152,6,115,215,35,224,254,79,145,190,105,65,69,192,15,61,0});
		}

	}
}