namespace NhatKySanLuongKhoan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANCONG")]
    public partial class NHANCONG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANCONG()
        {
            DMNCs = new HashSet<DMNC>();
        }

        [Key]
        [StringLength(10)]
        public string MaNC { get; set; }

        [StringLength(50)]
        public string Hoten { get; set; }

        [StringLength(50)]
        public string NgaySinh { get; set; }

        [StringLength(50)]
        public string PhongBan { get; set; }

        [StringLength(20)]
        public string ChucVu { get; set; }

        [StringLength(50)]
        public string QueQuan { get; set; }

        public int? LuongHopDong { get; set; }

        public int? LuongBaoHiem { get; set; }

        [Required]
        [StringLength(5)]
        public string GioiTinh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DMNC> DMNCs { get; set; }
    }
}
