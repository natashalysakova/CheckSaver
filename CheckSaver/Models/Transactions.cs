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
    
    public partial class Transactions
    {
        public int Id { get; set; }
        public int WhoPay { get; set; }
        public int ForWhom { get; set; }
        public decimal Summa { get; set; }
        public string Caption { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsDebitOff { get; set; }
        public Nullable<int> CheckId { get; set; }
    
        public virtual Checks Checks { get; set; }
        public virtual Neighbours WhoPayNP { get; set; }
        public virtual Neighbours ForWhomNP { get; set; }
    }
}