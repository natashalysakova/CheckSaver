//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckSaver.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class n_Neighbours
    {
        public n_Neighbours()
        {
            this.n_Checks = new HashSet<n_Checks>();
            this.n_WhoWillUse = new HashSet<n_WhoWillUse>();
            this.n_Transactions = new HashSet<n_Transactions>();
            this.n_Transactions1 = new HashSet<n_Transactions>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
    
        public virtual ICollection<n_Checks> n_Checks { get; set; }
        public virtual ICollection<n_WhoWillUse> n_WhoWillUse { get; set; }
        public virtual ICollection<n_Transactions> n_Transactions { get; set; }
        public virtual ICollection<n_Transactions> n_Transactions1 { get; set; }
    }
}