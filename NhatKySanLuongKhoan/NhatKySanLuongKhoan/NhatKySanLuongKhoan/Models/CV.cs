namespace NhatKySanLuongKhoan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CV")]
    public partial class CV
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CV()
        {
            DMCVs = new HashSet<DMCV>();
        }

        [Key]
        [StringLength(10)]
        public string MaCV { get; set; }

        [StringLength(50)]
        public string TenCV { get; set; }

        public int? DinhMucKhoan { get; set; }

        [StringLength(10)]
        public string DonViKhoan { get; set; }

        public int? HeSoKhoan { get; set; }

        public int? DinhMucLaoDong { get; set; }

        public int? DonGia { get; set; }

        [Required]
        [StringLength(10)]
        public string MaSP { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DMCV> DMCVs { get; set; }
    }
}
