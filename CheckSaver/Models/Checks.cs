//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class Checks
    {
        public Checks()
        {
            this.Purchases = new HashSet<Purchases>();
            this.Transactions = new HashSet<Transactions>();
        }
    
        public int Id { get; set; }
        public int NeighbourId { get; set; }
        public int StoreId { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime CreationDate { get; set; }
    
        public virtual Neighbours Neighbours { get; set; }
        public virtual Stores Stores { get; set; }
        public virtual ICollection<Purchases> Purchases { get; set; }
        public virtual ICollection<Transactions> Transactions { get; set; }
    }
}
