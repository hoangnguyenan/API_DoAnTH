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
    
    public partial class ViTien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ViTien()
        {
            this.LichSuGDs = new HashSet<LichSuGD>();
        }
    
        public int MaViTien { get; set; }
        public int MaKH { get; set; }
        public Nullable<int> SoDu { get; set; }
    
        public virtual KhachHang KhachHang { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LichSuGD> LichSuGDs { get; set; }
    }
}