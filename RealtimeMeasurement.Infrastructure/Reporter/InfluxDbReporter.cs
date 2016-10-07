using Metrics.Reporters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Metrics;
using Metrics.MetricData;
using System.Threading;
using System.Configuration;
using InfluxData.Net.InfluxDb;
using InfluxData.Net.Common.Enums;
using InfluxData.Net.InfluxDb.Models;

namespace RealtimeMeasurement.Infrastructure.Reporter
{
    public class InfluxDbReporter : MetricsReport
    {
        private readonly string url;
        private readonly string username;
        private readonly string password;
        private readonly string database;
        public InfluxDbReporter(string url,string database, string username, string password)
        {
            this.url = url;
            this.database = database;
            this.username = username;
            this.password = password;
        }

        public async void RunReport(
            MetricsData metricsData, 
            Func<HealthStatus> healthStatus, 
            CancellationToken token)
        {
            var influxDbClient = new InfluxDbClient(
                    this.url,
                    this.username,
                    this.password,
                    InfluxDbVersion.v_1_0_0
                );

            var dataPoints = new List<Point>();

            foreach (var counter in metricsData.Counters)
            {
                var counterValue = counter.ValueProvider.GetValue(resetMetric: true);
                
                if(counterValue.Items.Length > 0)
                {
                    var tags = new Dictionary<string, object>();

                    foreach (var item in counterValue.Items)
                    {
                        var keyVal = item.Item.Split(':');

                        var tagName = "item";
                        var tagValue = item.Item;
                        long measureValue = (long)item.Count;

                        if (keyVal.Length > 1)
                        {
                            tagName = keyVal[0];
                            tagValue = keyVal[1];
                        }
                        
                        var dataPoint = new Point()
                        {
                            Name = counter.Name,
                            Tags = new Dictionary<string, object>()
                            {
                                { tagName, tagValue },
                            },
                            Fields = new Dictionary<string, object>()
                            {
                                { "value",  measureValue }
                            },
                            Timestamp = DateTime.UtcNow
                        };

                        dataPoints.Add(dataPoint);
                    }

                    
                }
                else
                {
                    var dataPoint = new Point()
                    {
                        Name = counter.Name,
                        Fields = new Dictionary<string, object>()
                        {
                            { "value",  (long)counterValue.Count }
                        },
                        Timestamp = DateTime.UtcNow
                    };
                    dataPoints.Add(dataPoint);
                }
            }
            var response = await influxDbClient.Client.WriteAsync(this.database, dataPoints);
            
        }
            
    }
}

