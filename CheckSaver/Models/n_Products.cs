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
    
    public partial class n_Products
    {
        public n_Products()
        {
            this.n_Price = new HashSet<n_Price>();
            this.n_Purchases = new HashSet<n_Purchases>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
    
        public virtual ICollection<n_Price> n_Price { get; set; }
        public virtual ICollection<n_Purchases> n_Purchases { get; set; }
    }
}
