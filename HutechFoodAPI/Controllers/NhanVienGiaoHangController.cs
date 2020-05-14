using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using HutechFoodAPI.Models;

namespace HutechFoodAPI.Controllers
{
    public class NhanVienGiaoHangController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/NhanVienGiaoHang
        public IQueryable<NhanVienGiaoHang> GetNhanVienGiaoHangs()
        {
            return db.NhanVienGiaoHangs;
        }

        // GET: api/NhanVienGiaoHang/5
        [ResponseType(typeof(NhanVienGiaoHang))]
        public IHttpActionResult GetNhanVienGiaoHang(int id)
        {
            NhanVienGiaoHang nhanVienGiaoHang = db.NhanVienGiaoHangs.Find(id);
            if (nhanVienGiaoHang == null)
            {
                return NotFound();
            }

            return Ok(nhanVienGiaoHang);
        }

        // PUT: api/NhanVienGiaoHang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhanVienGiaoHang(int id, NhanVienGiaoHang nhanVienGiaoHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nhanVienGiaoHang.MaNV)
            {
                return BadRequest();
            }

            db.Entry(nhanVienGiaoHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NhanVienGiaoHangExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/NhanVienGiaoHang
        [ResponseType(typeof(NhanVienGiaoHang))]
        public IHttpActionResult PostNhanVienGiaoHang(NhanVienGiaoHang nhanVienGiaoHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhanVienGiaoHangs.Add(nhanVienGiaoHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhanVienGiaoHang.MaNV }, nhanVienGiaoHang);
        }

        // DELETE: api/NhanVienGiaoHang/5
        [ResponseType(typeof(NhanVienGiaoHang))]
        public IHttpActionResult DeleteNhanVienGiaoHang(int id)
        {
            NhanVienGiaoHang nhanVienGiaoHang = db.NhanVienGiaoHangs.Find(id);
            if (nhanVienGiaoHang == null)
            {
                return NotFound();
            }

            db.NhanVienGiaoHangs.Remove(nhanVienGiaoHang);
            db.SaveChanges();

            return Ok(nhanVienGiaoHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhanVienGiaoHangExists(int id)
        {
            return db.NhanVienGiaoHangs.Count(e => e.MaNV == id) > 0;
        }
    }
}