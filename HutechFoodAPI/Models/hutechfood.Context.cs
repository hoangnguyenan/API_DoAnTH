﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HutechfoodEntities3 : DbContext
    {
        public HutechfoodEntities3() :base("name=HutechfoodEntities3")
        {
            Configuration.ProxyCreationEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<BaiVietBanChay> BaiVietBanChays { get; set; }
        public virtual DbSet<BaiVietGT> BaiVietGTs { get; set; }
        public virtual DbSet<BaiVietHD> BaiVietHDs { get; set; }
        public virtual DbSet<CaiDat> CaiDats { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHangs { get; set; }
        public virtual DbSet<ChiTietKhuyenMai> ChiTietKhuyenMais { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<CuaHang> CuaHangs { get; set; }
        public virtual DbSet<DanhMucDoAn> DanhMucDoAns { get; set; }
        public virtual DbSet<DoAn> DoAns { get; set; }
        public virtual DbSet<DonDatHang> DonDatHangs { get; set; }
        public virtual DbSet<DSYeuThich> DSYeuThiches { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMais { get; set; }
        public virtual DbSet<LichSuGD> LichSuGDs { get; set; }
        public virtual DbSet<LichSuNVGH> LichSuNVGHs { get; set; }
        public virtual DbSet<LienHe> LienHes { get; set; }
        public virtual DbSet<NhanVienGiaoHang> NhanVienGiaoHangs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ViTien> ViTiens { get; set; }
        public virtual DbSet<ViTienCuaHang> ViTienCuaHangs { get; set; }
        public virtual DbSet<ViTriGiaoHang> ViTriGiaoHangs { get; set; }
    }
}