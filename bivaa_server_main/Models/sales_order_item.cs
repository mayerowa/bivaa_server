namespace bivaa_server_main
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("sales_order_item")]
    public partial class sales_order_item
    {
        public int id { get; set; }

        public int sales_order_id { get; set; }

        public int stock_item_id { get; set; }

        public double total_price { get; set; }

        public double total_gross { get; set; }

        public double total_net { get; set; }

        public double total_tax { get; set; }

        public double quantity { get; set; }

        public virtual sales_order sales_order { get; set; }

        public virtual stock_item stock_item { get; set; }
    }
}
