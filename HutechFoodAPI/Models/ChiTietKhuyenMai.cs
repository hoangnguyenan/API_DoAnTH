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
    
    public partial class ChiTietKhuyenMai
    {
        public int MaKM { get; set; }
        public int MaCH { get; set; }
        public Nullable<decimal> GiaKM { get; set; }
        public Nullable<int> SoLuongKM { get; set; }
        public int MaDA { get; set; }
    
        public virtual DoAn DoAn { get; set; }
        public virtual KhuyenMai KhuyenMai { get; set; }
    }
}
