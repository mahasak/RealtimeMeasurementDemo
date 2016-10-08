using RealtimeMeasurement.Infrastructure.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtimeMeasurement.Web.Controllers
{
    public class ProductController : Controller
    {
        IWebsiteMetric websiteMetric;

        public ProductController(IWebsiteMetric websiteMetric)
        {
            this.websiteMetric = websiteMetric;
        }
        
        // GET: Product
        public ActionResult Index()
        {
            this.ViewBag.Title = "Product";

            this.ViewBag.HomeActive = "";
            this.ViewBag.ProductActive = "active";
            this.ViewBag.CartActive = "";

            websiteMetric.markWhenCustomerOnProductPage();

            return View();
        }
    }
}