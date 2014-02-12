using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using CryptSharp.Utility;

namespace SqrlNet.Crypto.CryptSharp
{
	/// <summary>
	/// Provides all the PBKDF functionality needed by the SQRL process, implemented with
	/// SCRYPT using the CryptSharp library.
	/// </summary>
	public class CryptSharpPbkdfHandler : IPbkdfHandler
	{
		#region IPbkdfHandler implementation

		/// <summary>
		///  Generates the password key. 
		/// </summary>
		/// <returns>
		///  The password key. 
		/// </returns>
		/// <param name='password'>
		///  The password. 
		/// </param>
		/// <param name='salt'>
		///  The salt. 
		/// </param>
		/// <param name='iterations'>
		///  The number of iterations. 
		/// </param>
		public byte[] GeneratePasswordKey(string password, byte[] salt, int iterations)
		{
			var key = new byte[32];
			var inputKey = Encoding.UTF8.GetBytes(password);
			var runningKey = new byte[32];

			// initialize the running key to all 0's
			for(int i = 0; i < 32; i++)
			{
				runningKey[i] = 0x00;
			}

			// run SCRYPT in a loop
			for(int i = 0; i < iterations; i++)
			{
				SCrypt.ComputeKey(
					inputKey,
					salt,
					256,
					512,
					1,
					null,
					key);

				runningKey = Utility.Xor(runningKey, key);
				inputKey = key;
			}

			return runningKey;
		}

		/// <summary>
		///  Verifies the password. 
		/// </summary>
		/// <returns>
		///  Returns true if the password given matches the partial hash given 
		/// </returns>
		/// <param name='password'>
		///  The password to be verified. 
		/// </param>
		/// <param name='salt'>
		///  The salt added to the password. 
		/// </param>
		/// <param name='partialHash'>
		///  The lower 128 bits of a hash of the output of the PBKDF (GeneratePasswordKey). 
		/// </param>
		public bool VerifyPassword(string password, byte[] salt, byte[] partialHash)
		{
			var passwordKey = GeneratePasswordKey(password, salt, 1);
			return partialHash.SequenceEqual(GetPartialHashFromPasswordKey(passwordKey));
		}

		/// <summary>
		///  Gets the partial hash used for password verification from the password key generated from the PBKDF. 
		/// </summary>
		/// <returns>
		///  The partial hash from password key. 
		/// </returns>
		/// <param name='passwordKey'>
		///  Password key. 
		/// </param>
		public byte[] GetPartialHashFromPasswordKey(byte[] passwordKey)
		{
			var sha256 = SHA256Managed.Create();
			var hash = sha256.ComputeHash(passwordKey);
			return new ArraySegment<byte>(hash, 0, 16).Array;
		}

		#endregion
	}
}