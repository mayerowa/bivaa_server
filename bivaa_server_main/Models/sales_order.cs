namespace bivaa_server_main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sales_order")]
    public partial class sales_order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sales_order()
        {
            sales_order_item = new HashSet<sales_order_item>();
            discount_code = new HashSet<discount_code>();
        }

        public int id { get; set; }

        public int customer_id { get; set; }

        public int brand_id { get; set; }

        [Required]
        [StringLength(128)]
        public string type { get; set; }

        public double total_price { get; set; }

        public double total_net { get; set; }

        public double total_vat { get; set; }

        public virtual brand brand { get; set; }

        public virtual customer customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_order_item> sales_order_item { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<discount_code> discount_code { get; set; }
    }
}
