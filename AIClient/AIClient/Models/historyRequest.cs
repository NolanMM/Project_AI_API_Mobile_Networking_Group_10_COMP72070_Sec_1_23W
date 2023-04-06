using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AIClient.Models
{
    public class historyRequest
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [Indexed]
        public string contentRequest { get; set; }
        public string respondFromServer { get; set; }
        public string typeRequest { get; set; }
        public string timeOccured { get; set; }
        public string Image_Res { get; set; }
    }
}
