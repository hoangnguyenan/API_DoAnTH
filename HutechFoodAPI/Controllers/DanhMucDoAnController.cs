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
    public class DanhMucDoAnController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/DanhMucDoAn
        public IQueryable<DanhMucDoAn> GetDanhMucDoAns()
        {
            return db.DanhMucDoAns;
        }

        // GET: api/DanhMucDoAn/5
        [ResponseType(typeof(DanhMucDoAn))]
        public IHttpActionResult GetDanhMucDoAn(int id)
        {
            DanhMucDoAn danhMucDoAn = db.DanhMucDoAns.Find(id);
            if (danhMucDoAn == null)
            {
                return NotFound();
            }

            return Ok(danhMucDoAn);
        }

        // PUT: api/DanhMucDoAn/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDanhMucDoAn(int id, DanhMucDoAn danhMucDoAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != danhMucDoAn.MaDM)
            {
                return BadRequest();
            }

            db.Entry(danhMucDoAn).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DanhMucDoAnExists(id))
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

        // POST: api/DanhMucDoAn
        [ResponseType(typeof(DanhMucDoAn))]
        public IHttpActionResult PostDanhMucDoAn(DanhMucDoAn danhMucDoAn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DanhMucDoAns.Add(danhMucDoAn);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = danhMucDoAn.MaDM }, danhMucDoAn);
        }

        // DELETE: api/DanhMucDoAn/5
        [ResponseType(typeof(DanhMucDoAn))]
        public IHttpActionResult DeleteDanhMucDoAn(int id)
        {
            DanhMucDoAn danhMucDoAn = db.DanhMucDoAns.Find(id);
            if (danhMucDoAn == null)
            {
                return NotFound();
            }

            db.DanhMucDoAns.Remove(danhMucDoAn);
            db.SaveChanges();

            return Ok(danhMucDoAn);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DanhMucDoAnExists(int id)
        {
            return db.DanhMucDoAns.Count(e => e.MaDM == id) > 0;
        }
    }
}