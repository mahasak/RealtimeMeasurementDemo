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

        public async void RunReport(MetricsData metricsData, Func<HealthStatus> healthStatus, CancellationToken token)
        {
            var influxDbClient = GetInfluxDbClient();

            var dataPoints = new List<Point>();

            foreach (var counter in metricsData.Counters)
            {
                var counterValue = counter.ValueProvider.GetValue(resetMetric: true);
                
                if(counterValue.Items.Length > 0)
                {
                    var tags = new Dictionary<string, object>();

                    counterValue.Items.ToList().ForEach(
                        item => dataPoints.Add(CreateDataPoint(counter.Name, (long)item.Count, CreateTags(item.Item)))
                    );
                }
                else
                {
                    dataPoints.Add(CreateDataPoint(counter.Name, (long)counterValue.Count, CreateTags()));
                }
            }

            var response = await influxDbClient.Client.WriteAsync(this.database, dataPoints);
        }

        private InfluxDbClient GetInfluxDbClient()
        {
            return new InfluxDbClient(this.url, this.username, this.password, InfluxDbVersion.v_1_0_0);

        }

        private Dictionary<string, object> CreateTags(string item = "")
        {
            if (item.Equals(String.Empty))
                return new Dictionary<string, object>();

            var keyVal = item.Split(':');

            var tagName = "item";
            var tagValue = item;

            if (keyVal.Length > 1)
            {
                tagName = keyVal[0];
                tagValue = keyVal[1];
            }

            return new Dictionary<string, object>() { { tagName,  tagValue } };
        }
        private Point CreateDataPoint(string metricName, long metricValue, Dictionary<string, object> tags)
        {
            return new Point()
            {
                Name = metricName,
                Fields = new Dictionary<string, object>() { { "value", metricValue } },
                Tags = tags,
                Timestamp = DateTime.UtcNow
            };
        }
    }
}