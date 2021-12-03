namespace NhatKySanLuongKhoan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMNC")]
    public partial class DMNC
    {
        public int? Giobatdau { get; set; }

        public int? GIoketthuc { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaKhoan { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaNC { get; set; }

        public virtual NHANCONG NHANCONG { get; set; }

        public virtual NKSLK NKSLK { get; set; }
    }
}
