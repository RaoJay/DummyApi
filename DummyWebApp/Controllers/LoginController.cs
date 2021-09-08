using DummyWebApp.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DummyWebApp.Controllers
{
    public class LoginController : Controller
    {
        private List<User> users = new List<User> { new User { name="Khan", pwd = "test_pass"}, new User { name="Harry", pwd="pass_test"} };
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}