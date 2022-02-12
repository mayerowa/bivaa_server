namespace bivaa_server_main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("brand")]
    public partial class brand
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public brand()
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

        public int default_tax_rate_id { get; set; }

        public virtual tax_rate tax_rate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sales_order> sales_order { get; set; }
    }
}
