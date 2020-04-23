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
    public class CuaHangController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/CuaHang
        public IQueryable<CuaHang> GetCuaHangs()
        {
            return db.CuaHangs;
        }

        // GET: api/CuaHang/5
        [ResponseType(typeof(CuaHang))]
        public IHttpActionResult GetCuaHang(int id)
        {
            CuaHang cuaHang = db.CuaHangs.Find(id);
            if (cuaHang == null)
            {
                return NotFound();
            }

            return Ok(cuaHang);
        }

        // PUT: api/CuaHang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCuaHang(int id, CuaHang cuaHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cuaHang.MaCH)
            {
                return BadRequest();
            }

            db.Entry(cuaHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CuaHangExists(id))
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

        // POST: api/CuaHang
        [ResponseType(typeof(CuaHang))]
        public IHttpActionResult PostCuaHang(CuaHang cuaHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CuaHangs.Add(cuaHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cuaHang.MaCH }, cuaHang);
        }

        // DELETE: api/CuaHang/5
        [ResponseType(typeof(CuaHang))]
        public IHttpActionResult DeleteCuaHang(int id)
        {
            CuaHang cuaHang = db.CuaHangs.Find(id);
            if (cuaHang == null)
            {
                return NotFound();
            }

            db.CuaHangs.Remove(cuaHang);
            db.SaveChanges();

            return Ok(cuaHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CuaHangExists(int id)
        {
            return db.CuaHangs.Count(e => e.MaCH == id) > 0;
        }
    }
}