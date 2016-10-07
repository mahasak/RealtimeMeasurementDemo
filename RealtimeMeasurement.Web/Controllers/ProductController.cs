using RealtimeMeasurement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtimeMeasurement.Web.Controllers
{
    public class ProductController : Controller
    {
        IApiMetrics apiMetrics;
        public ProductController(IApiMetrics apiMetrics)
        {
            this.apiMetrics = apiMetrics;
        }
        // GET: Home
        public ActionResult Index()
        {
            this.ViewBag.Title = "Product";
            this.ViewBag.HomeActive = "";
            this.ViewBag.ProductActive = "active";
            this.ViewBag.CartActive = "";
            apiMetrics.productPage();
            return View();
        }
    }
}