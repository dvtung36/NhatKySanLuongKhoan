namespace NhatKySanLuongKhoan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tylelamviec_v
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaKhoan { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaNC { get; set; }

        public double? tyle { get; set; }
    }
}
