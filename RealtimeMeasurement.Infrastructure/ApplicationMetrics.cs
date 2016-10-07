using Metrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealtimeMeasurement.Infrastructure
{
    public class ApplicationMetrics: IApiMetrics
    {
        private readonly Counter interest = Metric.Counter("InterestCounter", Unit.Calls);

        private readonly Counter booking = Metric.Counter("BookingCounter", Unit.Calls);

        private readonly Counter payment = Metric.Counter("PaymentCounter", Unit.Calls);

        private readonly Counter cancel = Metric.Counter("CancelCounter", Unit.Calls);

        private readonly Counter home = Metric.Counter("HomePage", Unit.Calls);

        private readonly Counter product = Metric.Counter("ProductPage", Unit.Calls);

        private readonly Counter cart = Metric.Counter("CartPage", Unit.Calls);

        public ApplicationMetrics Instance
        {
            get
            {
                return new ApplicationMetrics();
            }
        }

        public void interestMetric(string item)
        {
            interest.Increment(item);
        }

        public void bookingMetric(string item)
        {
            booking.Increment(item);
        }

        public void paymentMetric(string item)
        {
            payment.Increment(item);
        }

        public void cancelMetric(string item)
        {
            cancel.Increment(item);
        }

        public void homePage()
        {
            home.Increment();
        }

        public void productPage()
        {
            product.Increment();
        }

        public void cartPage()
        {
            cart.Increment();
        }
    }

    public interface IApiMetrics
    {
        void interestMetric(string item);
        void bookingMetric(string item);
        void paymentMetric(string item);
        void cancelMetric(string item);
        void homePage();
        void productPage();
        void cartPage();
    }
}
