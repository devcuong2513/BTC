﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhamMinhDuc_BTC_17Entities : DbContext
    {
        public PhamMinhDuc_BTC_17Entities()
            : base("name=PhamMinhDuc_BTC_17Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<HangTon> HangTons { get; set; }
        public virtual DbSet<NCC> NCCs { get; set; }
        public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }
        public virtual DbSet<PhieuXuat> PhieuXuats { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}
