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
    public class AdminRoleController : ApiController
    {
        private HutechfoodEntities db = new HutechfoodEntities();

        // GET: api/AdminRoles
        public List<AdminRole> GetAdminRoles()
        {
            // Get all data admin
            List<Admin> listAdmin = db.Admins.ToList();
            // Get all data QuyenAdmin
            List<QuyenAdmin> listRole = db.QuyenAdmins.ToList();
            // Init data model
            List<AdminRole> listAdminRole = new List<AdminRole>();
            AdminRole adminRoleTemp = new AdminRole();
            // Add data
            foreach (Admin admin in listAdmin)
            {
                // Admin
                adminRoleTemp.Id = admin.Id;
                adminRoleTemp.HotenAdmin = admin.HotenAdmin;
                adminRoleTemp.PassAdmin = admin.PassAdmin;
                adminRoleTemp.UserAdmin = admin.UserAdmin;
                adminRoleTemp.EmailAdmin = admin.EmailAdmin;
                // QuyenAdmin
                QuyenAdmin quyenAdminTemp = listRole.Where(n => n.MaAdmin == admin.Id).SingleOrDefault();
                if(quyenAdminTemp != null)
                {
                    adminRoleTemp.MaQuyen = quyenAdminTemp.MaQuyen;
                    // Add to list
                    listAdminRole.Add(adminRoleTemp);
                }

            }
            return listAdminRole;
        }

        // GET: api/AdminRoles/5
        [ResponseType(typeof(AdminRole))]
        public IHttpActionResult GetAdminRole(int id)
        {
            Admin admin = db.Admins.Find(id);
            QuyenAdmin quyenAdmin = db.QuyenAdmins.Where(n => n.MaAdmin == admin.Id).SingleOrDefault();
            if (admin == null || quyenAdmin == null)
            {
                return NotFound();
            }

            AdminRole adminRole = new AdminRole();
            // Admin
            adminRole.Id = admin.Id;
            adminRole.HotenAdmin = admin.HotenAdmin;
            adminRole.PassAdmin = admin.PassAdmin;
            adminRole.UserAdmin = admin.UserAdmin;
            adminRole.EmailAdmin = admin.EmailAdmin;
            adminRole.MaQuyen = quyenAdmin.MaQuyen;

            return Ok(adminRole);
        }

        // PUT: api/AdminRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAdminRole(int id, AdminRole adminRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adminRole.Id)
            {
                return BadRequest();
            }

            Admin admin = new Admin();
            admin.Id = adminRole.Id;
            admin.HotenAdmin = adminRole.HotenAdmin;
            admin.PassAdmin = adminRole.PassAdmin;
            admin.UserAdmin = adminRole.UserAdmin;
            admin.EmailAdmin = adminRole.EmailAdmin;

            db.Entry(admin).State = EntityState.Modified;
            try
            {
                //QuyenAdmin quyenAdmin1 = new QuyenAdmin();
                //quyenAdmin.MaAdmin = admin.Id;
                //quyenAdmin.MaQuyen = adminRole.MaQuyen;
                QuyenAdmin quyenAdmin = db.QuyenAdmins.Where(n => n.MaAdmin == admin.Id).SingleOrDefault();
                quyenAdmin.MaQuyen = adminRole.MaQuyen;
                db.Entry(quyenAdmin).State = EntityState.Added;
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminRoleExists(id))
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

        // POST: api/AdminRoles
        public IHttpActionResult PostAdminRole(AdminRole adminRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Admin admin = new Admin();
            admin.HotenAdmin = adminRole.HotenAdmin;
            admin.PassAdmin = adminRole.PassAdmin;
            admin.UserAdmin = adminRole.UserAdmin;
            admin.EmailAdmin = adminRole.EmailAdmin;
            db.Admins.Add(admin);
            db.SaveChanges();

            QuyenAdmin quyenAdmin = new QuyenAdmin();
            quyenAdmin.MaAdmin = admin.Id;
            quyenAdmin.MaQuyen = adminRole.MaQuyen;
            db.QuyenAdmins.Add(quyenAdmin);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = adminRole.Id }, adminRole);
        }

        // DELETE: api/AdminRoles/5
        [ResponseType(typeof(AdminRole))]
        public IHttpActionResult DeleteAdminRole(int id)
        {
            AdminRole adminRole = db.AdminRoles.Find(id);
            if (adminRole == null)
            {
                return NotFound();
            }

            db.AdminRoles.Remove(adminRole);
            db.SaveChanges();

            return Ok(adminRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdminRoleExists(int id)
        {
            return db.AdminRoles.Count(e => e.Id == id) > 0;
        }
    }
}