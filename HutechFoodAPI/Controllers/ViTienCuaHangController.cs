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
    public class ViTienCuaHangController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/ViTienCuaHang
        public IQueryable<ViTienCuaHang> GetViTienCuaHangs()
        {
            return db.ViTienCuaHangs;
        }

        // GET: api/ViTienCuaHang/5
        [ResponseType(typeof(ViTienCuaHang))]
        public IHttpActionResult GetViTienCuaHang(int id)
        {
            ViTienCuaHang viTienCuaHang = db.ViTienCuaHangs.Find(id);
            if (viTienCuaHang == null)
            {
                return NotFound();
            }

            return Ok(viTienCuaHang);
        }

        // PUT: api/ViTienCuaHang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViTienCuaHang(int id, ViTienCuaHang viTienCuaHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viTienCuaHang.MaViCH)
            {
                return BadRequest();
            }

            db.Entry(viTienCuaHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViTienCuaHangExists(id))
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

        // POST: api/ViTienCuaHang
        [ResponseType(typeof(ViTienCuaHang))]
        public IHttpActionResult PostViTienCuaHang(ViTienCuaHang viTienCuaHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViTienCuaHangs.Add(viTienCuaHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viTienCuaHang.MaViCH }, viTienCuaHang);
        }

        // DELETE: api/ViTienCuaHang/5
        [ResponseType(typeof(ViTienCuaHang))]
        public IHttpActionResult DeleteViTienCuaHang(int id)
        {
            ViTienCuaHang viTienCuaHang = db.ViTienCuaHangs.Find(id);
            if (viTienCuaHang == null)
            {
                return NotFound();
            }

            db.ViTienCuaHangs.Remove(viTienCuaHang);
            db.SaveChanges();

            return Ok(viTienCuaHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViTienCuaHangExists(int id)
        {
            return db.ViTienCuaHangs.Count(e => e.MaViCH == id) > 0;
        }
    }
}