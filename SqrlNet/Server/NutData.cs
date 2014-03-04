using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;

namespace SqrlNet.Server
{
	/// <summary>
	/// Data for the SQRL nonce, otherwise known as the 'nut' (Get it?  Squirrel?  Nut?  Hilarious!).
	/// </summary>
	/// <remarks>
	/// This class includes a constructor that initializes from a <see cref="SqrlNet.Server.NutStruct"/>,
	/// as well as a method to return a <see cref="SqrlNet.Server.NutStruct"/> representation of itself.
	/// </remarks>
	public class NutData
	{
		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="SqrlNet.Server.NutData"/> class.
		/// </summary>
		public NutData()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="SqrlNet.Server.NutData"/> class.
		/// </summary>
		/// <param name='nutStruct'>
		/// Nut struct.
		/// </param>
		public NutData(NutStruct nutStruct)
		{
			// convert the IP address
			Address = new IPAddress(nutStruct.Address);

			// convert the timestamp
			Timestamp = new DateTime(1970, 1, 1, 0, 0, 0, 0);
			Timestamp = Timestamp.AddSeconds(nutStruct.Timestamp).ToLocalTime();

			Counter = nutStruct.Counter;
			Entropy = BitConverter.GetBytes(nutStruct.Entropy);
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// Gets or sets the address.
		/// </summary>
		/// <value>
		/// The IP address of the request to the login page.
		/// </value>
		public IPAddress Address { get; set; }

		/// <summary>
		/// Gets or sets the timestamp.
		/// </summary>
		/// <value>
		/// The timestamp.
		/// </value>
		public DateTime Timestamp { get; set; }

		/// <summary>
		/// Gets or sets the counter.
		/// </summary>
		/// <value>
		/// A rolling up-counter to encrypt into the nut.
		/// </value>
		public UInt32 Counter { get; set; }

		/// <summary>
		/// Gets or sets the entropy.
		/// </summary>
		/// <value>
		/// Pseudo-random noise to encrypt into the nut.
		/// </value>
		public byte[] Entropy { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Gets the nut struct.
		/// </summary>
		/// <returns>
		/// The nut struct.
		/// </returns>
		public NutStruct GetNutStruct()
		{
			var nutStruct = new NutStruct();

			// test for IPv4 or IPv6
			if(Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
			{
				nutStruct.Address = BitConverter.ToUInt32(Address.GetAddressBytes(), 0);
			}
			else if(Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
			{
				var sha = SHA256Managed.Create();

				// TODO: I may have to think about how to salt this hash
				var hash = sha.ComputeHash(Address.GetAddressBytes());
				nutStruct.Address = BitConverter.ToUInt32(new ArraySegment<byte>(hash, 0, 8).Array, 0);
			}
			else
			{
				throw new Exception("Unknown IP Address Family");
			}

			nutStruct.Timestamp = (UInt32) (Timestamp - new DateTime(1970, 1, 1).ToLocalTime()).TotalSeconds;
			nutStruct.Counter = Counter;
			nutStruct.Entropy = BitConverter.ToUInt32(Entropy, 0);

			return nutStruct;
		}

		#endregion
	}
}