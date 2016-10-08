# RealtimeMeasurementDemo

Demonstrationon how to use Metrics.Net with InfluxDb and Grafana to visualize ASP.Net MVC Web Application for scalable application

# Prerequisite
- Grafana : http://grafana.org/download/
- InfluxDb : https://www.influxdata.com/downloads/
- Source Code : https://github.com/bigbearsio/GrafanaDemo

# Runnin InfluxDb
- Extract downloaded file to some folder
- Run "influxd"
- Go to influxdb web console : http://localhost:8083/
- Create influxdb user : CREATE USER "grafana" WITH PASSWORD 'grafana'
- Change it according to you code (if any)
- Create influxdb database: CREATE DATABASE "dashboard"

# Running Grafana
- Extract downloaded file to some folder
- Run "bin/grafana-server"
- login with default username/password (admin/admin)
- Add influxdb data source
- Parameter as follows
  - Name : influs-default (or any name you want)
  - Default : checked
  - Type : InfluxDB
  - url : http://localhost:8086
  - Access : Direct
  - Database : dashboard
  - User : grafana
  - Password : grafana
  - Defualt group by time : > 30s

# Checkout code from GitBuh
- You know how to do it !!!!