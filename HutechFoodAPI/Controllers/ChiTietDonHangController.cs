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
    public class ChiTietDonHangController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/ChiTietDonHang
        public IQueryable<ChiTietDonHang> GetChiTietDonHangs()
        {
            return db.ChiTietDonHangs;
        }

        // GET: api/ChiTietDonHang/5
        [ResponseType(typeof(ChiTietDonHang))]
        public IHttpActionResult GetChiTietDonHang(int id)
        {
            var chiTietDonHang = db.ChiTietDonHangs.Where(n=> n.MaDonHang == id);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }

            return Ok(chiTietDonHang);
        }

        // PUT: api/ChiTietDonHang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChiTietDonHang(int id, ChiTietDonHang chiTietDonHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietDonHang.MaDonHang)
            {
                return BadRequest();
            }

            db.Entry(chiTietDonHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietDonHangExists(id))
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

        // POST: api/ChiTietDonHang
        [ResponseType(typeof(ChiTietDonHang))]
        public IHttpActionResult PostChiTietDonHang(ChiTietDonHang chiTietDonHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietDonHangs.Add(chiTietDonHang);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChiTietDonHangExists(chiTietDonHang.MaDonHang))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chiTietDonHang.MaDonHang }, chiTietDonHang);
        }

        // DELETE: api/ChiTietDonHang/5
        [ResponseType(typeof(ChiTietDonHang))]
        public IHttpActionResult DeleteChiTietDonHang(int id)
        {
            ChiTietDonHang chiTietDonHang = db.ChiTietDonHangs.Find(id);
            if (chiTietDonHang == null)
            {
                return NotFound();
            }

            db.ChiTietDonHangs.Remove(chiTietDonHang);
            db.SaveChanges();

            return Ok(chiTietDonHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietDonHangExists(int id)
        {
            return db.ChiTietDonHangs.Count(e => e.MaDonHang == id) > 0;
        }
    }
}