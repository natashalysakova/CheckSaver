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
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=uh357966_db2Entities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Electricity> Electricity { get; set; }
        public virtual DbSet<ElectricityTarif> ElectricityTarif { get; set; }
        public virtual DbSet<FixedPays> FixedPays { get; set; }
        public virtual DbSet<Gas> Gas { get; set; }
        public virtual DbSet<GasTarif> GasTarif { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Water> Water { get; set; }
        public virtual DbSet<WaterTarif> WaterTarif { get; set; }
    }
}
