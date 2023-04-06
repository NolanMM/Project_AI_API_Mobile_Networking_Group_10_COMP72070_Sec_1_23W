using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AIClient.Models
{
    public class DataPacket
    {
        // 1 byte for Source 1 byte for Destination 4 byte for dataLength()
        public string Destination = "Server";
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
            source = UserId;
            // Assign the length of data
            int datacount = data.Count();         // +1 because Count() from 0    
            DataLength = datacount.ToString();  //fixed 4 bytes for int
            // Assign the Destination of the data packet
        }
        // When receive to extract data
        public DataPacket(string overload)
        {
            string[] Items = overload.Split('>');
            //Swap source with destination set destination to server
            Destination = Items[0];
            source = Items[1];
            DataLength = Items[2];
        }

        public string DataPacketToString()
        {
            return source + ">" + Destination + ">" + DataLength;
        }

    }
}
