namespace NhatKySanLuongKhoan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DMCV")]
    public partial class DMCV
    {
        public int? SanLuongThucTe { get; set; }

        public int? SoLo { get; set; }

        public int? SanLuongApDung { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string MaCV { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string MaKhoan { get; set; }

        public virtual CV CV { get; set; }

        public virtual NKSLK NKSLK { get; set; }
    }
}
