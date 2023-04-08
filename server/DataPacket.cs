using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiServer
{
	public class DataPacket
	{
		// 1 byte for Source 1 byte for Destination 4 byte for dataLength()
		public string Destination;
		public string DataLength;
		public string source;

		/// <summary>
		/// Data Packet for Server side to attract header in respond
		/// </summary>
		/// <param string="data"> This passing into the respond data after be encrypted</param>
		/// <param int="UserId">This is the UserID (public key only (int , 4 bytes)) to set the destination of data packet and send the public key to the client side</param>
		/// 
		// When create Data Packet to send
		public DataPacket(string data, string UserId)
		{
			Destination = UserId;
			source = "Server";
			// Assign the length of data
			int datacount = data.Count();
			DataLength = datacount.ToString();  //fixed 4 bytes for int
												// Assign the Destination of the data packet
		}
		// When receive to extract data
		public DataPacket(string overload)
		{
			string[] Items = overload.Split('>');
			// Public key is the source here
			// Destiantion variable here is "Server"
			source = Items[0];
			Destination = Items[1];
			DataLength = Items[2];
		}

		public string DataPacketToString()
		{
			return source + ">" + Destination + ">" + DataLength;
		}

	}
}