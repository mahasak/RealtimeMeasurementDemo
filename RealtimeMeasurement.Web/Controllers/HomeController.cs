using RealtimeMeasurement.Infrastructure.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtimeMeasurement.Web.Controllers
{
    public class HomeController : Controller
    {
        IWebsiteMetric websiteMetric;

        public HomeController(IWebsiteMetric websiteMetric)
        {
            this.websiteMetric = websiteMetric;
        }

        // GET: Home
        public ActionResult Index()
        {
            this.ViewBag.Title = "Home";

            this.ViewBag.HomeActive = "active";
            this.ViewBag.ProductActive = "";
            this.ViewBag.CartActive = "";

            websiteMetric.markWhenCustomerOnHomePage();

            return View();
        }
    }
}