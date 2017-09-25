using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using PublicPrivateKeyLib;

namespace PublicPrivateKeyLibTest {

	class Program {

		void RunTestPrime() {
			PublicPrivateKey ppk = new PublicPrivateKey();
			long prime = 1000000000000000000;
			while(!ppk.isPrime(prime)) {
				prime--;
			}
			Debug.WriteLine($"{prime} is prime");
		}
		void Run() {
			PublicPrivateKey ppl = new PublicPrivateKey();
			ppl.p = 3;
			ppl.q = 11;
			ppl.e = 17;
			ppl.d = 13;

			var enc = ppl.Encrypt(9);
			Debug.WriteLine($"9 encrypted is {enc}");
			var dec = ppl.Decrypt(15);
			Debug.WriteLine($"15 decrypted is {dec}");
		}
		static void Main(string[] args) {
			new Program().RunTestPrime();
		}
	}
}
