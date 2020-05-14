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
    public class CaiDatController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/CaiDat
        public IQueryable<CaiDat> GetCaiDats()
        {
            return db.CaiDats;
        }

        // GET: api/CaiDat/5
        [ResponseType(typeof(CaiDat))]
        public IHttpActionResult GetCaiDat(int id)
        {
            CaiDat caiDat = db.CaiDats.Find(id);
            if (caiDat == null)
            {
                return NotFound();
            }

            return Ok(caiDat);
        }

        // PUT: api/CaiDat/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCaiDat(int id, CaiDat caiDat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != caiDat.MaCD)
            {
                return BadRequest();
            }

            db.Entry(caiDat).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaiDatExists(id))
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

        // POST: api/CaiDat
        [ResponseType(typeof(CaiDat))]
        public IHttpActionResult PostCaiDat(CaiDat caiDat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CaiDats.Add(caiDat);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = caiDat.MaCD }, caiDat);
        }

        // DELETE: api/CaiDat/5
        [ResponseType(typeof(CaiDat))]
        public IHttpActionResult DeleteCaiDat(int id)
        {
            CaiDat caiDat = db.CaiDats.Find(id);
            if (caiDat == null)
            {
                return NotFound();
            }

            db.CaiDats.Remove(caiDat);
            db.SaveChanges();

            return Ok(caiDat);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaiDatExists(int id)
        {
            return db.CaiDats.Count(e => e.MaCD == id) > 0;
        }
    }
}