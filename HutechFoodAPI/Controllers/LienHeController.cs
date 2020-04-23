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
    public class LienHeController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/LienHe
        public IQueryable<LienHe> GetLienHes()
        {
            return db.LienHes;
        }

        // GET: api/LienHe/5
        [ResponseType(typeof(LienHe))]
        public IHttpActionResult GetLienHe(int id)
        {
            LienHe lienHe = db.LienHes.Find(id);
            if (lienHe == null)
            {
                return NotFound();
            }

            return Ok(lienHe);
        }

        // PUT: api/LienHe/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLienHe(int id, LienHe lienHe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lienHe.MaLH)
            {
                return BadRequest();
            }

            db.Entry(lienHe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LienHeExists(id))
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

        // POST: api/LienHe
        [ResponseType(typeof(LienHe))]
        public IHttpActionResult PostLienHe(LienHe lienHe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LienHes.Add(lienHe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lienHe.MaLH }, lienHe);
        }

        // DELETE: api/LienHe/5
        [ResponseType(typeof(LienHe))]
        public IHttpActionResult DeleteLienHe(int id)
        {
            LienHe lienHe = db.LienHes.Find(id);
            if (lienHe == null)
            {
                return NotFound();
            }

            db.LienHes.Remove(lienHe);
            db.SaveChanges();

            return Ok(lienHe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LienHeExists(int id)
        {
            return db.LienHes.Count(e => e.MaLH == id) > 0;
        }
    }
}