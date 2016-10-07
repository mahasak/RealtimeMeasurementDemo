using Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using RealtimeMeasurement.Infrastructure;

namespace RealtimeMeasurement.Web.Controllers
{
    public class MetricController : System.Web.Http.ApiController
    {
        IApiMetrics apiMetrics;

        public MetricController(IApiMetrics apiMetrics)
        {
            this.apiMetrics = apiMetrics;
        }

        [HttpPost]
        [Route("api/metric/interest/{id}")]
        public void Interest(int id)
        {
            apiMetrics.interestMetric(String.Format("item:{0}", id.ToString()));
        }

        [HttpPost]
        [Route("api/metric/booking/{id}")]
        public void Booking(int id)
        {
            apiMetrics.bookingMetric(String.Format("item:{0}", id.ToString()));
        }

        [HttpPost]
        [Route("api/metric/payment/{id}")]
        public void Payment(int id)
        {
            apiMetrics.paymentMetric(String.Format("item:{0}", id.ToString()));
        }

        [HttpPost]
        [Route("api/metric/cancel/{id}")]
        public void Cancel(int id)
        {
            apiMetrics.cancelMetric(String.Format("item:{0}", id.ToString()));
        }
    }
}