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
    
    public partial class LichSuGD
    {
        public int MaGD { get; set; }
        public string MoTa { get; set; }
        public Nullable<short> TinhTrang { get; set; }
        public Nullable<decimal> SoTienDaNap { get; set; }
        public Nullable<decimal> SoTienDaTieu { get; set; }
        public Nullable<System.DateTime> NgayNapTien { get; set; }
        public Nullable<System.DateTime> NgayTieuTien { get; set; }
        public int MaViTien { get; set; }
    
        public virtual ViTien ViTien { get; set; }
    }
}
