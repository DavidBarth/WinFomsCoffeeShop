//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeShop
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblTransaction
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblTransaction()
        {
            this.tblTransactionItems = new HashSet<tblTransactionItem>();
        }
    
        public int TransactionID { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblTransactionItem> tblTransactionItems { get; set; }
    }
}