using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Metrics;
using RealtimeMeasurement.Infrastructure.Reporter;

namespace RealtimeMeasurement.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            
            Metric.Config
                .WithHttpEndpoint("http://localhost:1234/")
                  .WithReporting(reports => {
                      reports.WithReport(
                          new InfluxDbReporter(
                              "http://localhost:8086", 
                              "dashboard", 
                              "grafana", 
                              "grafana"
                          ), 
                          TimeSpan.FromSeconds(5)
                      );
                  })
                .WithAllCounters();
        }
    }
}
