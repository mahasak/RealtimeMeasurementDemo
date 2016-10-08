using Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealtimeMeasurement.Infrastructure.Metrics;

namespace RealtimeMeasurement.Web.Controllers
{
    public class MetricController : System.Web.Http.ApiController
    {
        IWebsiteMetric apiMetrics;

        public MetricController(IWebsiteMetric apiMetrics)
        {
            this.apiMetrics = apiMetrics;
        }

        [HttpPost]
        [Route("api/metric/interest/{id}")]
        public void Interest(int id)
        {
            apiMetrics.markWhenCustomerInterest(String.Format("item:{0}", id.ToString()));
        }

        [HttpPost]
        [Route("api/metric/booking/{id}")]
        public void Booking(int id)
        {
            apiMetrics.markWhenCustomerBooking(String.Format("item:{0}", id.ToString()));
        }

        [HttpPost]
        [Route("api/metric/payment/{id}")]
        public void Payment(int id)
        {
            apiMetrics.markWhenCustomerMadePayment(String.Format("item:{0}", id.ToString()));
        }

        [HttpPost]
        [Route("api/metric/cancel/{id}")]
        public void Cancel(int id)
        {
            apiMetrics.markWhenCustomerCancel(String.Format("item:{0}", id.ToString()));
        }
    }
}