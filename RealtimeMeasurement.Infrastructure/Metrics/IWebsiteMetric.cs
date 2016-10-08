using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeMeasurement.Infrastructure.Metrics
{
    public interface IWebsiteMetric
    {
        void markWhenCustomerInterest(string item);
        void markWhenCustomerBooking(string item);
        void markWhenCustomerMadePayment(string item);
        void markWhenCustomerCancel(string item);
        void markWhenCustomerOnHomePage();
        void markWhenCustomerOnProductPage();
        void markWhenCustomerOnCartPage();
    }
}
