namespace NhatKySanLuongKhoan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("SANPHAM")]
    public partial class SANPHAM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SANPHAM()
        {
            CVs = new HashSet<CV>();
            Hinh = "~/Upload/SanPham/add.png";
        }

        [Key]
        [StringLength(10)]
        public string MaSP { get; set; }

        [Required]
        [StringLength(50)]
        public string TenSP { get; set; }

        [Required]
        [StringLength(10)]
        public string SoDK { get; set; }

        [Required]
        [StringLength(50)]
        public string HanSD { get; set; }

        [StringLength(50)]
        public string QuyCach { get; set; }

        [Required]
        [StringLength(50)]
        public string NgayDangKy { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgaySanXuat { get; set; }

        [StringLength(250)]
        public string Hinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CV> CVs { get; set; }
        [NotMapped]
        public HttpPostedFileBase uploadhinh { get; set; }
    }
}
