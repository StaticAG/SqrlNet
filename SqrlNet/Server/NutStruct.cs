using System;
using System.Runtime.InteropServices;

namespace SqrlNet.Server
{
	/// <summary>
	/// This is the nut data in struct form, but with explicit layout and an overlayed
	/// byte array.  This makes it trivial to encode data into the nut, so it isn't just
	/// random, and can be used for anti-phishing purposes.
	/// </summary>
	/// <remarks>
	/// This struct operates much like a C-style union data type, in that the bytes that
	/// make up the struct can be directly set or retrieved, or the individual fields
	/// can be manipulated.  So remember, changing the data one way affects it the other.
	/// </remarks>
	[StructLayout(LayoutKind.Explicit)]
	public unsafe struct NutStruct
	{
		/// <summary>
		/// The address.
		/// </summary>
		[FieldOffset(0)]
		public UInt32 Address;

		/// <summary>
		/// The timestamp.
		/// </summary>
		[FieldOffset(4)]
		public UInt32 Timestamp;

		/// <summary>
		/// The counter.
		/// </summary>
		[FieldOffset(8)]
		public UInt32 Counter;

		/// <summary>
		/// The entropy.
		/// </summary>
		[FieldOffset(12)]
		public UInt32 Entropy;

		/// <summary>
		/// The bytes.
		/// </summary>
		[FieldOffset(0)]
		private fixed byte ByteArray[16];

		#region Methods

		/// <summary>
		/// Gets the bytes of the struct.
		/// </summary>
		/// <returns>
		/// The bytes.
		/// </returns>
		public byte[] GetBytes()
		{
			var data = new byte[16];
			fixed(byte* ptr = ByteArray)
			{
				for (int i = 0; i < 16; i++)
				{
					data[i] = ptr[i];
				}
			}

			return data;
		}

		/// <summary>
		/// Sets the bytes of the struct.
		/// </summary>
		/// <param name='bytes'>
		/// The bytes.
		/// </param>
		public void SetBytes(byte[] bytes)
		{
			fixed(byte* ptr = ByteArray)
			{
				for (int i = 0; i < 16; i++)
				{
					ptr[i] = bytes[i];
				}
			}
		}

		#endregion
	}
}