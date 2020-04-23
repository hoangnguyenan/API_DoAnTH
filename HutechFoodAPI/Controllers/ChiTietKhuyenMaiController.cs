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
    public class ChiTietKhuyenMaiController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/ChiTietKhuyenMai
        public IQueryable<ChiTietKhuyenMai> GetChiTietKhuyenMais()
        {
            return db.ChiTietKhuyenMais;
        }

        // GET: api/ChiTietKhuyenMai/5
        [ResponseType(typeof(ChiTietKhuyenMai))]
        public IHttpActionResult GetChiTietKhuyenMai(int id)
        {
            ChiTietKhuyenMai chiTietKhuyenMai = db.ChiTietKhuyenMais.Find(id);
            if (chiTietKhuyenMai == null)
            {
                return NotFound();
            }

            return Ok(chiTietKhuyenMai);
        }

        // PUT: api/ChiTietKhuyenMai/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChiTietKhuyenMai(int id, ChiTietKhuyenMai chiTietKhuyenMai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chiTietKhuyenMai.MaKM)
            {
                return BadRequest();
            }

            db.Entry(chiTietKhuyenMai).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChiTietKhuyenMaiExists(id))
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

        // POST: api/ChiTietKhuyenMai
        [ResponseType(typeof(ChiTietKhuyenMai))]
        public IHttpActionResult PostChiTietKhuyenMai(ChiTietKhuyenMai chiTietKhuyenMai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChiTietKhuyenMais.Add(chiTietKhuyenMai);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ChiTietKhuyenMaiExists(chiTietKhuyenMai.MaKM))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = chiTietKhuyenMai.MaKM }, chiTietKhuyenMai);
        }

        // DELETE: api/ChiTietKhuyenMai/5
        [ResponseType(typeof(ChiTietKhuyenMai))]
        public IHttpActionResult DeleteChiTietKhuyenMai(int id)
        {
            ChiTietKhuyenMai chiTietKhuyenMai = db.ChiTietKhuyenMais.Find(id);
            if (chiTietKhuyenMai == null)
            {
                return NotFound();
            }

            db.ChiTietKhuyenMais.Remove(chiTietKhuyenMai);
            db.SaveChanges();

            return Ok(chiTietKhuyenMai);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChiTietKhuyenMaiExists(int id)
        {
            return db.ChiTietKhuyenMais.Count(e => e.MaKM == id) > 0;
        }
    }
}