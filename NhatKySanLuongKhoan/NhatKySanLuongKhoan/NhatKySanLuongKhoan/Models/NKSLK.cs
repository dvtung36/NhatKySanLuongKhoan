namespace NhatKySanLuongKhoan.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NKSLK")]
    public partial class NKSLK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NKSLK()
        {
            DMCVs = new HashSet<DMCV>();
            DMNCs = new HashSet<DMNC>();
        }

        [Key]
        [StringLength(10)]
        public string MaKhoan { get; set; }

        [StringLength(50)]
        public string TenKhoan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaythuchien { get; set; }

        public int? Giobatdau { get; set; }

        public int? Gioketthuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DMCV> DMCVs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DMNC> DMNCs { get; set; }
    }
}
