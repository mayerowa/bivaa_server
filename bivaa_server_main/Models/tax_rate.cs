namespace bivaa_server_main
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tax_rate")]
    public partial class tax_rate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tax_rate()
        {
            brand = new HashSet<brand>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(128)]
        public string code { get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }

        public double rate { get; set; }

        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<brand> brand { get; set; }
    }
}
