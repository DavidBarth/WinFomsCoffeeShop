namespace CoffeeShop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransactionItem")]
    public partial class TransactionItem
    {
        public int TransactionItemID { get; set; }

        public int? TransactionID { get; set; }

        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }

        public virtual Transaction Transaction { get; set; }
    }
}
