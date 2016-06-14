//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CheckSaver
{
    using System;
    using System.Collections.Generic;
    
    public partial class Electricity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Electricity()
        {
            this.Invoice = new HashSet<Invoice>();
        }
    
        public int Id { get; set; }
        public decimal StartValue { get; set; }
        public decimal FinishValue { get; set; }
        public decimal ValueDifference { get; set; }
        public int TarifId { get; set; }
        public decimal TotalCost { get; set; }
    
        public virtual ElectricityTarif ElectricityTarif { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
