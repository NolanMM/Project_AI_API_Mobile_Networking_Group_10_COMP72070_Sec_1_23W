using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace server
{
    public class DataPacket
    {
        // 1 byte for Source 1 byte for Destination 4 byte for dataLength()
        public byte[] Source;
        public byte[] Destination;
        public byte[] DataLength;
        public string source = "Server";

        /// <summary>
        /// Data Packet for Server side to attract header in respond
        /// </summary>
        /// <param string="data"> This passing into the respond data after be encrypted</param>
        /// <param int="UserId">This is the UserID (public key only (int , 4 bytes)) to set the destination of data packet and send the public key to the client side</param>
        public DataPacket(string data, int UserId)
        {
            // Assign the Source to bitArray
            Source = Encoding.ASCII.GetBytes(source); // Fixed 6 bytes Corressponding to S e r v e r
            // Assign the length of data
            int datacount = data.Count() + 1;         // +1 because Count() from 0    
            DataLength = Encoding.ASCII.GetBytes(datacount.ToString());  //fixed 4 bytes for int
            // Assign the Destination of the data packet
            byte[] bytes = BitConverter.GetBytes(UserId);
            Destination = bytes;
        }
    }
}
