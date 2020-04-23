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
    public class BaiVietGTController : ApiController
    {
        private HutechfoodEntities3 db = new HutechfoodEntities3();

        // GET: api/BaiVietGT
        public IQueryable<BaiVietGT> GetBaiVietGTs()
        {
            return db.BaiVietGTs;
        }

        // GET: api/BaiVietGT/5
        [ResponseType(typeof(BaiVietGT))]
        public IHttpActionResult GetBaiVietGT(int id)
        {
            BaiVietGT baiVietGT = db.BaiVietGTs.Find(id);
            if (baiVietGT == null)
            {
                return NotFound();
            }

            return Ok(baiVietGT);
        }

        // PUT: api/BaiVietGT/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBaiVietGT(int id, BaiVietGT baiVietGT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != baiVietGT.MaBVGT)
            {
                return BadRequest();
            }

            db.Entry(baiVietGT).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BaiVietGTExists(id))
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

        // POST: api/BaiVietGT
        [ResponseType(typeof(BaiVietGT))]
        public IHttpActionResult PostBaiVietGT(BaiVietGT baiVietGT)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BaiVietGTs.Add(baiVietGT);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = baiVietGT.MaBVGT }, baiVietGT);
        }

        // DELETE: api/BaiVietGT/5
        [ResponseType(typeof(BaiVietGT))]
        public IHttpActionResult DeleteBaiVietGT(int id)
        {
            BaiVietGT baiVietGT = db.BaiVietGTs.Find(id);
            if (baiVietGT == null)
            {
                return NotFound();
            }

            db.BaiVietGTs.Remove(baiVietGT);
            db.SaveChanges();

            return Ok(baiVietGT);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BaiVietGTExists(int id)
        {
            return db.BaiVietGTs.Count(e => e.MaBVGT == id) > 0;
        }
    }
}