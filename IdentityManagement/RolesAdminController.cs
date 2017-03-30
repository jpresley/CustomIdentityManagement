using System.Linq;
using System.Net;
using System.Web.Mvc;
using CustomIdentityManagement.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CustomIdentityManagement
{
    [Authorize(Roles = "Admin")]
    public class RolesAdminController : Controller
    {
        ApplicationDbContext context;

        public RolesAdminController()
        {
            context = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = context.Roles.Find(id);
            return View(role);
        }

        [HttpPost]
        public ActionResult Edit(IdentityRole Role)
        {
            context.Entry(Role).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(string id)
        {
            var role = context.Roles.Find(id);
            context.Roles.Remove(role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}