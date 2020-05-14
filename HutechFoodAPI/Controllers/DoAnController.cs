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
    public class DoAnController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/DoAn
        public IQueryable<DoAn> GetDoAns()
        {
            return db.DoAns;
        }

        // GET: api/DoAn/5
        [ResponseType(typeof(DoAn))]
        public IHttpActionResult GetDoAn(int id)
        {
            DoAn doAn = db.DoAns.Find(id);
            if (doAn == null)
            {
                return NotFound();
            }

            return Ok(doAn);
        }

        // PUT: api/DoAn/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDoAn(int id, DoAn doAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != doAn.MaDA)
            {
                return BadRequest();
            }

            db.Entry(doAn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DoAnExists(id))
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

        // POST: api/DoAn
        [ResponseType(typeof(DoAn))]
        public IHttpActionResult PostDoAn(DoAn doAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DoAns.Add(doAn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = doAn.MaDA }, doAn);
        }

        // DELETE: api/DoAn/5
        [ResponseType(typeof(DoAn))]
        public IHttpActionResult DeleteDoAn(int id)
        {
            DoAn doAn = db.DoAns.Find(id);
            if (doAn == null)
            {
                return NotFound();
            }

            db.DoAns.Remove(doAn);
            db.SaveChanges();

            return Ok(doAn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DoAnExists(int id)
        {
            return db.DoAns.Count(e => e.MaDA == id) > 0;
        }
    }
}