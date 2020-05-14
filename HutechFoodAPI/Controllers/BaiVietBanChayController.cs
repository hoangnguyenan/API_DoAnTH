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
    public class BaiVietBanChayController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/BaiVietBanChay
        public IQueryable<BaiVietBanChay> GetBaiVietBanChays()
        {
            return db.BaiVietBanChays;
        }

        // GET: api/BaiVietBanChay/5
        [ResponseType(typeof(BaiVietBanChay))]
        public IHttpActionResult GetBaiVietBanChay(int id)
        {
            BaiVietBanChay baiVietBanChay = db.BaiVietBanChays.Find(id);
            if (baiVietBanChay == null)
            {
                return NotFound();
            }

            return Ok(baiVietBanChay);
        }

        // PUT: api/BaiVietBanChay/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBaiVietBanChay(int id, BaiVietBanChay baiVietBanChay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != baiVietBanChay.MaBV)
            {
                return BadRequest();
            }

            db.Entry(baiVietBanChay).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaiVietBanChayExists(id))
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

        // POST: api/BaiVietBanChay
        [ResponseType(typeof(BaiVietBanChay))]
        public IHttpActionResult PostBaiVietBanChay(BaiVietBanChay baiVietBanChay)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BaiVietBanChays.Add(baiVietBanChay);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = baiVietBanChay.MaBV }, baiVietBanChay);
        }

        // DELETE: api/BaiVietBanChay/5
        [ResponseType(typeof(BaiVietBanChay))]
        public IHttpActionResult DeleteBaiVietBanChay(int id)
        {
            BaiVietBanChay baiVietBanChay = db.BaiVietBanChays.Find(id);
            if (baiVietBanChay == null)
            {
                return NotFound();
            }

            db.BaiVietBanChays.Remove(baiVietBanChay);
            db.SaveChanges();

            return Ok(baiVietBanChay);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BaiVietBanChayExists(int id)
        {
            return db.BaiVietBanChays.Count(e => e.MaBV == id) > 0;
        }
    }
}