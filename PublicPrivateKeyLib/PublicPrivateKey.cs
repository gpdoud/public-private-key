using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace PublicPrivateKeyLib {

	public class PublicPrivateKey {

		public long p { get; set; }
		public long q { get; set; }
		public long n { get { return p * q; } }
		public long totientn { get { return (p - 1) * (q - 1); } }
		public long mmie {
			get {
				var i = 0;
				long x = -1;
				while (x != 0) {
					i++;
					x = (e * i - 1) % totientn;
				}
				return i;
			}
		}
		public long e { get; set; }
		public long d { get; set; }

		public long Encrypt(long m) {
			return Power(m, e) % n;
		}

		public long Decrypt(long m) {
			return Power(m, d) % n;
		}

		private long Power(long b, long e) {
			//return BigInteger.Pow(b, e);
			long ans = 1;
			for (var idx = 0; idx < e; idx++) {
				ans *= b;
			}
			return ans;
		}

		private long CalcModularMultiplicativeInverseOfE(long e, long totientn) {
			long x = -1;
			long i = 0;
			while(x != 0) {
				x = (e * i++ - 1) % totientn;
			}
			return x;
		}

		public bool isPrime(long number) {

			if (number == 1) return false;
			if (number == 2) return true;

			for (int i = 2; i <= Math.Ceiling(Math.Sqrt(number)); ++i) {
				if (number % i == 0) return false;
			}

			return true;

		}
	}
}
