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
    public class ViTienController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/ViTien
        public IQueryable<ViTien> GetViTiens()
        {
            return db.ViTiens;
        }

        // GET: api/ViTien/5
        [ResponseType(typeof(ViTien))]
        public IHttpActionResult GetViTien(int id)
        {
            ViTien viTien = db.ViTiens.Find(id);
            if (viTien == null)
            {
                return NotFound();
            }

            return Ok(viTien);
        }

        // PUT: api/ViTien/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViTien(int id, ViTien viTien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viTien.MaViTien)
            {
                return BadRequest();
            }

            db.Entry(viTien).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViTienExists(id))
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

        // POST: api/ViTien
        [ResponseType(typeof(ViTien))]
        public IHttpActionResult PostViTien(ViTien viTien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViTiens.Add(viTien);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viTien.MaViTien }, viTien);
        }

        // DELETE: api/ViTien/5
        [ResponseType(typeof(ViTien))]
        public IHttpActionResult DeleteViTien(int id)
        {
            ViTien viTien = db.ViTiens.Find(id);
            if (viTien == null)
            {
                return NotFound();
            }

            db.ViTiens.Remove(viTien);
            db.SaveChanges();

            return Ok(viTien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViTienExists(int id)
        {
            return db.ViTiens.Count(e => e.MaViTien == id) > 0;
        }
    }
}