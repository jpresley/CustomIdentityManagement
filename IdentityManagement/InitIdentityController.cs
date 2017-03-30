using CustomIdentityManagement.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace CustomIdentityManagement
{
    public class InitIdentityController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();
        public DropCreateDatabaseIfModelChanges<DbContext> dbInit = new DropCreateDatabaseIfModelChanges<DbContext>();

        public ActionResult Index()
        {
            dbInit.InitializeDatabase(db);

            IdentityInitializer i = new IdentityInitializer();
            i.Init(db);

            return RedirectToAction("Index","Home");
        }
    }
}