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
    public class DSYeuThichController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/DSYeuThich
        public IQueryable<DSYeuThich> GetDSYeuThiches()
        {
            return db.DSYeuThiches;
        }

        // GET: api/DSYeuThich/5
        [ResponseType(typeof(DSYeuThich))]
        public IHttpActionResult GetDSYeuThich(int id)
        {
            DSYeuThich dSYeuThich = db.DSYeuThiches.Find(id);
            if (dSYeuThich == null)
            {
                return NotFound();
            }

            return Ok(dSYeuThich);
        }

        // PUT: api/DSYeuThich/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDSYeuThich(int id, DSYeuThich dSYeuThich)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dSYeuThich.MaYT)
            {
                return BadRequest();
            }

            db.Entry(dSYeuThich).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DSYeuThichExists(id))
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

        // POST: api/DSYeuThich
        [ResponseType(typeof(DSYeuThich))]
        public IHttpActionResult PostDSYeuThich(DSYeuThich dSYeuThich)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DSYeuThiches.Add(dSYeuThich);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = dSYeuThich.MaYT }, dSYeuThich);
        }

        // DELETE: api/DSYeuThich/5
        [ResponseType(typeof(DSYeuThich))]
        public IHttpActionResult DeleteDSYeuThich(int id)
        {
            DSYeuThich dSYeuThich = db.DSYeuThiches.Find(id);
            if (dSYeuThich == null)
            {
                return NotFound();
            }

            db.DSYeuThiches.Remove(dSYeuThich);
            db.SaveChanges();

            return Ok(dSYeuThich);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DSYeuThichExists(int id)
        {
            return db.DSYeuThiches.Count(e => e.MaYT == id) > 0;
        }
    }
}