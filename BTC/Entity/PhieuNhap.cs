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
    
    public partial class PhieuNhap
    {
        public string IDPhieuNhap { get; set; }
        public string IDHang { get; set; }
        public string IDncc { get; set; }
        public string TenHang { get; set; }
        public string Dvt { get; set; }
        public Nullable<int> LuongNhap { get; set; }
        public Nullable<int> Gianhap { get; set; }
        public Nullable<int> ThanhTien { get; set; }
    
        public virtual HangTon HangTon { get; set; }
        public virtual NCC NCC { get; set; }
    }
}
