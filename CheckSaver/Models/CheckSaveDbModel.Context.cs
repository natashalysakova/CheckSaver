﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckSaver.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CheckSaveEntities : DbContext
    {
        public CheckSaveEntities()
            : base("name=CheckSaveEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Check> Check { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Neighbor> Neighbor { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Purchase> Purchase { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<WhoWillUse> WhoWillUse { get; set; }
    }
}
