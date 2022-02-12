namespace bivaa_server_main.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("vaa.items")]
    public partial class items
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(45)]
        public string name { get; set; }

        public float? price { get; set; }

        [StringLength(45)]
        public string company { get; set; }

        public float? discount { get; set; }
    }
}
