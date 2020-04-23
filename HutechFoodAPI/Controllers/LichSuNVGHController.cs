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
    public class LichSuNVGHController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/LichSuNVGH
        public IQueryable<LichSuNVGH> GetLichSuNVGHs()
        {
            return db.LichSuNVGHs;
        }

        // GET: api/LichSuNVGH/5
        [ResponseType(typeof(LichSuNVGH))]
        public IHttpActionResult GetLichSuNVGH(int id)
        {
            LichSuNVGH lichSuNVGH = db.LichSuNVGHs.Find(id);
            if (lichSuNVGH == null)
            {
                return NotFound();
            }

            return Ok(lichSuNVGH);
        }

        // PUT: api/LichSuNVGH/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLichSuNVGH(int id, LichSuNVGH lichSuNVGH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lichSuNVGH.MaLS)
            {
                return BadRequest();
            }

            db.Entry(lichSuNVGH).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichSuNVGHExists(id))
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

        // POST: api/LichSuNVGH
        [ResponseType(typeof(LichSuNVGH))]
        public IHttpActionResult PostLichSuNVGH(LichSuNVGH lichSuNVGH)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LichSuNVGHs.Add(lichSuNVGH);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (LichSuNVGHExists(lichSuNVGH.MaLS))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = lichSuNVGH.MaLS }, lichSuNVGH);
        }

        // DELETE: api/LichSuNVGH/5
        [ResponseType(typeof(LichSuNVGH))]
        public IHttpActionResult DeleteLichSuNVGH(int id)
        {
            LichSuNVGH lichSuNVGH = db.LichSuNVGHs.Find(id);
            if (lichSuNVGH == null)
            {
                return NotFound();
            }

            db.LichSuNVGHs.Remove(lichSuNVGH);
            db.SaveChanges();

            return Ok(lichSuNVGH);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LichSuNVGHExists(int id)
        {
            return db.LichSuNVGHs.Count(e => e.MaLS == id) > 0;
        }
    }
}