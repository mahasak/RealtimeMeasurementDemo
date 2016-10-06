using Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace RealtimeMeasurement.Infrastructure.HttpModule
{
    public class RequestMeasure : IHttpModule
    {
        private static readonly Counter requestCounter = Metric.Counter("RequestCounter", Unit.Calls);

        private static readonly Counter responseCounter = Metric.Counter("ResponseCounter", Unit.Calls);

        private static readonly Counter counter = Metric.Counter("ResponseCounter", Unit.Calls);
        private static readonly Meter meter = Metric.Meter("ResponseCounter", Unit.Calls);
        private static readonly Timer timer = Metric.Timer("ResponseCounter", Unit.Calls);
        private static readonly Histogram histogram = Metric.Histogram("ResponseCounter", Unit.Calls);

        public void Dispose()
        {
            // Do nothing here
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
            context.PreSendRequestHeaders += OnPreSendRequestHeaders;
        }

        private void OnPreSendRequestHeaders(object sender, EventArgs e)
        {
            var application = sender as HttpApplication;
            var tag = "success";
            
            HttpContext context = HttpContext.Current;

            if (context != null
                && context.Response != null
                && context.Response.StatusCode >= 400)
            {
                tag = "error";
            }
            responseCounter.Increment(
                String.Format("{0}:{1}", tag, context.Response.StatusCode.ToString())
            );
            
        }

        private void OnBeginRequest(object sender, EventArgs e)
        {
            requestCounter.Increment();

            counter.Increment("tag", 1);
            counter.Decrement("tag", 1);

            meter.Mark("tag");
            meter.Mark("tag", 2);

            timer.StartRecording();
            timer.EndRecording();
            timer.Reset();


            histogram.Update(100);


        }
    }
}
