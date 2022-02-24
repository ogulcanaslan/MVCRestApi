using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models
{
    public class MvcCalisanlarModel
    {
        public int CalisanID { get; set; }

        [Required(ErrorMessage = "Ad Soyad Girmesi Zorunludur!!!")]
        public string AdSoyad { get; set; }

        public string Pozisyon { get; set; }

        public int Yas { get; set; }
        public int? Maas { get; set; }
    }
}