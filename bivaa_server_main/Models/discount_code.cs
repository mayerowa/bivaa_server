namespace bivaa_server_main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("discount_code")]
    public partial class discount_code
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public discount_code()
        {
            sales_order = new HashSet<sales_order>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string code { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public double discount_percentage { get; set; }

        public double discount_amount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_order> sales_order { get; set; }
    }
}
