//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTC.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhieuXuat
    {
        public string IDPhieuxuat { get; set; }
        public string IDhang { get; set; }
        public string TenHang { get; set; }
        public string Dvt { get; set; }
        public Nullable<int> Luongxuat { get; set; }
        public Nullable<int> Giaxuat { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual HangTon HangTon { get; set; }
    }
}
