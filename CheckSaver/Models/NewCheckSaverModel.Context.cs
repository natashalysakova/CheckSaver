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
    
    public partial class CheckSaver : DbContext
    {
        public CheckSaver()
            : base("name=CheckSaver")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Checks> Checks { get; set; }
        public virtual DbSet<Neighbours> Neighbours { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Purchases> Purchases { get; set; }
        public virtual DbSet<Stores> Stores { get; set; }
        public virtual DbSet<WhoWillUse> WhoWillUse { get; set; }
        public virtual DbSet<Transactions> Transactions { get; set; }
    }
}
