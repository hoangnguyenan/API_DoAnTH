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
    public class QuyenAdminController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/QuyenAdmin
        public IQueryable<QuyenAdmin> GetQuyenAdmins()
        {
            return db.QuyenAdmins;
        }

        // GET: api/QuyenAdmin/5
        [ResponseType(typeof(QuyenAdmin))]
        public IHttpActionResult GetQuyenAdmin(int id)
        {
            QuyenAdmin quyenAdmin = db.QuyenAdmins.Where(n => n.MaAdmin == id).SingleOrDefault();
            if (quyenAdmin == null)
            {
                return NotFound();
            }

            return Ok(quyenAdmin);
        }

        // PUT: api/QuyenAdmin/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuyenAdmin(int id, QuyenAdmin quyenAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quyenAdmin.MaAdmin)
            {
                return BadRequest();
            }
            db.Entry(quyenAdmin).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuyenAdminExists(id))
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

        // POST: api/QuyenAdmin
        [ResponseType(typeof(QuyenAdmin))]
        public IHttpActionResult PostQuyenAdmin(QuyenAdmin quyenAdmin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QuyenAdmins.Add(quyenAdmin);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (QuyenAdminExists(quyenAdmin.MaAdmin))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = quyenAdmin.MaAdmin }, quyenAdmin);
        }

        // DELETE: api/QuyenAdmin/5
        [ResponseType(typeof(QuyenAdmin))]
        public IHttpActionResult DeleteQuyenAdmin(int id)
        {
            QuyenAdmin quyenAdmin = db.QuyenAdmins.Where(n=>n.MaAdmin == id).SingleOrDefault();
            if (quyenAdmin == null)
            {
                return NotFound();
            }

            db.QuyenAdmins.Remove(quyenAdmin);
            db.SaveChanges();

            return Ok(quyenAdmin);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuyenAdminExists(int id)
        {
            return db.QuyenAdmins.Count(e => e.MaAdmin == id) > 0;
        }
    }
}