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
    
    public partial class n_Checks
    {
        public n_Checks()
        {
            this.n_Purchases = new HashSet<n_Purchases>();
        }
    
        public int Id { get; set; }
        public int NeighbourId { get; set; }
        public int StoreId { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual n_Neighbours n_Neighbours { get; set; }
        public virtual n_Stores n_Stores { get; set; }
        public virtual ICollection<n_Purchases> n_Purchases { get; set; }
    }
}