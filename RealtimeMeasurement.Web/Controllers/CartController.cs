using RealtimeMeasurement.Infrastructure.Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealtimeMeasurement.Web.Controllers
{
    public class CartController : Controller
    {
        IWebsiteMetric websiteMetric;
    
        public CartController(IWebsiteMetric websiteMetric)
        {
            this.websiteMetric = websiteMetric;
        }

        // GET: Cart
        public ActionResult Index()
        {
            this.ViewBag.Title = "Cart";

            this.ViewBag.HomeActive = "";
            this.ViewBag.ProductActive = "";
            this.ViewBag.CartActive = "active";

            websiteMetric.markWhenCustomerOnCartPage();
            return View();
        }
    }
}