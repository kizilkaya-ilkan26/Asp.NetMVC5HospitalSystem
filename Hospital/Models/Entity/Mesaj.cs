//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mesaj
    {
        public int ID { get; set; }
        public string HASTA { get; set; }
        public string GÖNDEREN { get; set; }
        public string ALICI { get; set; }
        public string KONU { get; set; }
        public Nullable<System.DateTime> TARIH { get; set; }
        public string MESAJ1 { get; set; }
        public string ISLEM { get; set; }
        public string Sonuc { get; set; }
    }
}
