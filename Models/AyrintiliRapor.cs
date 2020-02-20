using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YeldaSert.Models
{
    public class AyrintiliRapor
    {
        public int Id { get; set; }
        public string evrakAd { get; set; }
        public int userId { get; set; }
        public DateTime tarih { get; set; }
        public string Durum { get; set; }
        public string Dosya { get; set; }



    }
}