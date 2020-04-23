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
    public class ViTriGiaoHangController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/ViTriGiaoHang
        public IQueryable<ViTriGiaoHang> GetViTriGiaoHangs()
        {
            return db.ViTriGiaoHangs;
        }

        // GET: api/ViTriGiaoHang/5
        [ResponseType(typeof(ViTriGiaoHang))]
        public IHttpActionResult GetViTriGiaoHang(int id)
        {
            ViTriGiaoHang viTriGiaoHang = db.ViTriGiaoHangs.Find(id);
            if (viTriGiaoHang == null)
            {
                return NotFound();
            }

            return Ok(viTriGiaoHang);
        }

        // PUT: api/ViTriGiaoHang/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutViTriGiaoHang(int id, ViTriGiaoHang viTriGiaoHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != viTriGiaoHang.MaVT)
            {
                return BadRequest();
            }

            db.Entry(viTriGiaoHang).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ViTriGiaoHangExists(id))
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

        // POST: api/ViTriGiaoHang
        [ResponseType(typeof(ViTriGiaoHang))]
        public IHttpActionResult PostViTriGiaoHang(ViTriGiaoHang viTriGiaoHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ViTriGiaoHangs.Add(viTriGiaoHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = viTriGiaoHang.MaVT }, viTriGiaoHang);
        }

        // DELETE: api/ViTriGiaoHang/5
        [ResponseType(typeof(ViTriGiaoHang))]
        public IHttpActionResult DeleteViTriGiaoHang(int id)
        {
            ViTriGiaoHang viTriGiaoHang = db.ViTriGiaoHangs.Find(id);
            if (viTriGiaoHang == null)
            {
                return NotFound();
            }

            db.ViTriGiaoHangs.Remove(viTriGiaoHang);
            db.SaveChanges();

            return Ok(viTriGiaoHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ViTriGiaoHangExists(int id)
        {
            return db.ViTriGiaoHangs.Count(e => e.MaVT == id) > 0;
        }
    }
}