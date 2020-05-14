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
    public class ChucVuController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/ChucVu
        public IQueryable<ChucVu> GetChucVus()
        {
            return db.ChucVus;
        }

        // GET: api/ChucVu/5
        [ResponseType(typeof(ChucVu))]
        public IHttpActionResult GetChucVu(int id)
        {
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return NotFound();
            }

            return Ok(chucVu);
        }

        // PUT: api/ChucVu/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChucVu(int id, ChucVu chucVu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chucVu.Id)
            {
                return BadRequest();
            }

            db.Entry(chucVu).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChucVuExists(id))
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

        // POST: api/ChucVu
        [ResponseType(typeof(ChucVu))]
        public IHttpActionResult PostChucVu(ChucVu chucVu)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChucVus.Add(chucVu);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chucVu.Id }, chucVu);
        }

        // DELETE: api/ChucVu/5
        [ResponseType(typeof(ChucVu))]
        public IHttpActionResult DeleteChucVu(int id)
        {
            ChucVu chucVu = db.ChucVus.Find(id);
            if (chucVu == null)
            {
                return NotFound();
            }

            db.ChucVus.Remove(chucVu);
            db.SaveChanges();

            return Ok(chucVu);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChucVuExists(int id)
        {
            return db.ChucVus.Count(e => e.Id == id) > 0;
        }
    }
}