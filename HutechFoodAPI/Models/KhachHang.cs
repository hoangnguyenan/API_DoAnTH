//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HutechFoodAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            this.DonDatHangs = new HashSet<DonDatHang>();
            this.DSYeuThiches = new HashSet<DSYeuThich>();
            this.ViTiens = new HashSet<ViTien>();
        }
    
        public int MaKH { get; set; }
        public string HoTenKH { get; set; }
        public string TaiKhoanKH { get; set; }
        public string MatKhauKH { get; set; }
        public string EmailKH { get; set; }
        public string DiaChiKH { get; set; }
        public Nullable<int> DienThoaiKH { get; set; }
        public Nullable<System.DateTime> NgaySinhKH { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonDatHang> DonDatHangs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DSYeuThich> DSYeuThiches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ViTien> ViTiens { get; set; }
    }
}
