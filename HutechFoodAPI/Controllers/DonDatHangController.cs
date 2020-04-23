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
    public class DonDatHangController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/DonDatHang
        public List<DonDatHang> GetDonDatHangs()
        {
            return db.DonDatHangs.ToList();
        }

        // GET: api/DonDatHang/5
        [ResponseType(typeof(DonDatHang))]
        public IHttpActionResult GetDonDatHang(int id)
        {
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return NotFound();
            }

            return Ok(donDatHang);
        }

        // PUT: api/DonDatHang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDonDatHang(int id, DonDatHang donDatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != donDatHang.MaDonHang)
            {
                return BadRequest();
            }

            db.Entry(donDatHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonDatHangExists(id))
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

        // POST: api/DonDatHang
        [ResponseType(typeof(DonDatHang))]
        public IHttpActionResult PostDonDatHang(DonDatHang donDatHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DonDatHangs.Add(donDatHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = donDatHang.MaDonHang }, donDatHang);
        }

        // DELETE: api/DonDatHang/5
        [ResponseType(typeof(DonDatHang))]
        public IHttpActionResult DeleteDonDatHang(int id)
        {
            DonDatHang donDatHang = db.DonDatHangs.Find(id);
            if (donDatHang == null)
            {
                return NotFound();
            }

            db.DonDatHangs.Remove(donDatHang);
            db.SaveChanges();

            return Ok(donDatHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DonDatHangExists(int id)
        {
            return db.DonDatHangs.Count(e => e.MaDonHang == id) > 0;
        }
    }
}