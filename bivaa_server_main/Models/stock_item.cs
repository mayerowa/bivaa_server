namespace bivaa_server_main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock_item")]
    public partial class stock_item
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public stock_item()
        {
            sales_order_item = new HashSet<sales_order_item>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string code { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public double sell_price { get; set; }

        public int stock_item_dimension_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_order_item> sales_order_item { get; set; }

        public virtual stock_item_dimension stock_item_dimension { get; set; }
    }
}
