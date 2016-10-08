using Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeMeasurement.Infrastructure.Metrics
{
    public class WebsiteMetric: IWebsiteMetric
    {
        private readonly Counter interest = Metric.Counter("Interest", Unit.Calls);

        private readonly Counter booking = Metric.Counter("Booking", Unit.Calls);

        private readonly Counter payment = Metric.Counter("Payment", Unit.Calls);

        private readonly Counter cancel = Metric.Counter("Cancel", Unit.Calls);

        private readonly Counter home = Metric.Counter("OnHomePage", Unit.Calls);

        private readonly Counter product = Metric.Counter("OnProductPage", Unit.Calls);

        private readonly Counter cart = Metric.Counter("OnCartPage", Unit.Calls);
        
        public void markWhenCustomerInterest(string item)
        {
            interest.Increment(item);
        }

        public void markWhenCustomerBooking(string item)
        {
            booking.Increment(item);
        }

        public void markWhenCustomerMadePayment(string item)
        {
            payment.Increment(item);
        }

        public void markWhenCustomerCancel(string item)
        {
            cancel.Increment(item);
        }

        public void markWhenCustomerOnHomePage()
        {
            home.Increment();
        }

        public void markWhenCustomerOnProductPage()
        {
            product.Increment();
        }

        public void markWhenCustomerOnCartPage()
        {
            cart.Increment();
        }
    }
}