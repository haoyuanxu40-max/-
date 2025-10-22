using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication6.Models;
using ¨t²ÎºÝ.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        

        public IActionResult Index()
        {
            DBmanager dbmanager = new DBmanager();
            List<Package> packages = dbmanager.getPackages();
            
            var model = new PackageViewModel
            {
                Packages = packages
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(Package user)
        {

            DBmanager dbmanager = new DBmanager();
            try
            {
                user.PID = Guid.NewGuid().ToString().Substring(0, 8);
                user.STA = false;
                dbmanager.newPackage(user);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            return RedirectToAction("Index");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
