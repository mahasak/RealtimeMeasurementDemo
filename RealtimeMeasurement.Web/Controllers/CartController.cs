using RealtimeMeasurement.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtimeMeasurement.Web.Controllers
{
    public class CartController : Controller
    {
        IApiMetrics apiMetrics;
        public CartController(IApiMetrics apiMetrics)
        {
            this.apiMetrics = apiMetrics;
        }
        // GET: Home
        public ActionResult Index()
        {
            this.ViewBag.Title = "Cart";
            this.ViewBag.HomeActive = "";
            this.ViewBag.ProductActive = "";
            this.ViewBag.CartActive = "active";
            apiMetrics.cartPage();
            return View();
        }
    }
}