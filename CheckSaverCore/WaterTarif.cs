//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckSaverCore
{ 
    using System;
    using System.Collections.Generic;
    
    public partial class WaterTarif
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public WaterTarif()
        {
            this.Water = new HashSet<Water>();
        }
    
        public int Id { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public decimal Price { get; set; }
        public string WaterType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Water> Water { get; set; }
    }
}
