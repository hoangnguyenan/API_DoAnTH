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
    public class LichSuGDController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/LichSuGD
        public IQueryable<LichSuGD> GetLichSuGDs()
        {
            return db.LichSuGDs;
        }

        // GET: api/LichSuGD/5
        [ResponseType(typeof(LichSuGD))]
        public IHttpActionResult GetLichSuGD(int id)
        {
            LichSuGD lichSuGD = db.LichSuGDs.Find(id);
            if (lichSuGD == null)
            {
                return NotFound();
            }

            return Ok(lichSuGD);
        }

        // PUT: api/LichSuGD/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLichSuGD(int id, LichSuGD lichSuGD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lichSuGD.MaGD)
            {
                return BadRequest();
            }

            db.Entry(lichSuGD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LichSuGDExists(id))
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

        // POST: api/LichSuGD
        [ResponseType(typeof(LichSuGD))]
        public IHttpActionResult PostLichSuGD(LichSuGD lichSuGD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LichSuGDs.Add(lichSuGD);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = lichSuGD.MaGD }, lichSuGD);
        }

        // DELETE: api/LichSuGD/5
        [ResponseType(typeof(LichSuGD))]
        public IHttpActionResult DeleteLichSuGD(int id)
        {
            LichSuGD lichSuGD = db.LichSuGDs.Find(id);
            if (lichSuGD == null)
            {
                return NotFound();
            }

            db.LichSuGDs.Remove(lichSuGD);
            db.SaveChanges();

            return Ok(lichSuGD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LichSuGDExists(int id)
        {
            return db.LichSuGDs.Count(e => e.MaGD == id) > 0;
        }
    }
}