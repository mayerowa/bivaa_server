namespace bivaa_server_main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("stock_item_dimension")]
    public partial class stock_item_dimension
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public stock_item_dimension()
        {
            stock_item = new HashSet<stock_item>();
        }

        public int id { get; set; }

        public double weight { get; set; }

        public double height { get; set; }

        public double width { get; set; }

        public double depth { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<stock_item> stock_item { get; set; }
    }
}
