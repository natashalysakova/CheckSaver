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
    
    public partial class n_Price
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int StoreId { get; set; }
        public decimal Cost { get; set; }
        public System.DateTime Date { get; set; }
    
        public virtual n_Products n_Products { get; set; }
        public virtual n_Stores n_Stores { get; set; }
    }
}