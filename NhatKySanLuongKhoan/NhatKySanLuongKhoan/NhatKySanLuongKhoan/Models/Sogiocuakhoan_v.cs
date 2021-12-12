namespace NhatKySanLuongKhoan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sogiocuakhoan_v
    {
        [Key]
        [StringLength(10)]
        public string MaKhoan { get; set; }

        public double? sogio { get; set; }
    }
}
