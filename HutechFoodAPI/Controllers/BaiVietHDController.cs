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
    public class BaiVietHDController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/BaiVietHD
        public IQueryable<BaiVietHD> GetBaiVietHDs()
        {
            return db.BaiVietHDs;
        }

        // GET: api/BaiVietHD/5
        [ResponseType(typeof(BaiVietHD))]
        public IHttpActionResult GetBaiVietHD(int id)
        {
            BaiVietHD baiVietHD = db.BaiVietHDs.Find(id);
            if (baiVietHD == null)
            {
                return NotFound();
            }

            return Ok(baiVietHD);
        }

        // PUT: api/BaiVietHD/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBaiVietHD(int id, BaiVietHD baiVietHD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != baiVietHD.MaBVHD)
            {
                return BadRequest();
            }

            db.Entry(baiVietHD).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaiVietHDExists(id))
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

        // POST: api/BaiVietHD
        [ResponseType(typeof(BaiVietHD))]
        public IHttpActionResult PostBaiVietHD(BaiVietHD baiVietHD)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BaiVietHDs.Add(baiVietHD);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = baiVietHD.MaBVHD }, baiVietHD);
        }

        // DELETE: api/BaiVietHD/5
        [ResponseType(typeof(BaiVietHD))]
        public IHttpActionResult DeleteBaiVietHD(int id)
        {
            BaiVietHD baiVietHD = db.BaiVietHDs.Find(id);
            if (baiVietHD == null)
            {
                return NotFound();
            }

            db.BaiVietHDs.Remove(baiVietHD);
            db.SaveChanges();

            return Ok(baiVietHD);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BaiVietHDExists(int id)
        {
            return db.BaiVietHDs.Count(e => e.MaBVHD == id) > 0;
        }
    }
}