using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Poc_on_Cookie.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SetCookie()
        {
            // Create a new cookie
            HttpCookie cookie = new HttpCookie("UserPreferences");
            cookie["Theme"] = "Dark";
            cookie["FontSize"] = "Medium";
            cookie.Expires = DateTime.Now.AddDays(7); // Set the expiration date

            // Add the cookie to the response
            Response.Cookies.Add(cookie);

            return Content("Cookie has been set.");
        }
        // Action to get a cookie
        public ActionResult GetCookie()
        {
            // Retrieve the cookie from the request
            HttpCookie cookie = Request.Cookies["UserPreferences"];

            if (cookie != null)
            {
                string theme = cookie["Theme"];
                string fontSize = cookie["FontSize"];
                return Content($"Theme: {theme}, FontSize: {fontSize}");
            }
            else
            {
                return Content("No cookie found.");
            }
        }
        // Action to delete a cookie
        public ActionResult DeleteCookie()
        {
            // Retrieve the cookie from the request
            HttpCookie cookie = Request.Cookies["UserPreferences"];

            if (cookie != null)
            {
                // Set the cookie's expiration date to a past date to delete it
                cookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(cookie);
                return Content("Cookie has been deleted.");
            }
            else
            {
                return Content("No cookie found to delete.");
            }
        }
    }
}