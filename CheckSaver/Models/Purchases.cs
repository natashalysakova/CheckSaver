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
    
    public partial class Purchases
    {
        public Purchases()
        {
            this.WhoWillUse = new HashSet<WhoWillUse>();
        }
    
        public int Id { get; set; }
        public int CheckId { get; set; }
        public int ProductId { get; set; }
        public decimal Cost { get; set; }
        public decimal CostPerPerson { get; set; }
        public decimal Count { get; set; }
        public decimal Summ { get; set; }
    
        public virtual Checks Checks { get; set; }
        public virtual Products Products { get; set; }
        public virtual ICollection<WhoWillUse> WhoWillUse { get; set; }
    }
}