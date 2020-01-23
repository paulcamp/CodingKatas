using System;

namespace SolidExamples
{
    class LiskovSub
    {
        //principle states [base class usage can be overridden by derived class]

        public class Customer
        {
            public virtual double GetDiscountAmount(double totalSales)
            {
                return 0;
            }

            public virtual void ApplyDiscount()
            {
                //do something
            }
        }

        public class Enquiry : Customer
        {
            public override double GetDiscountAmount(double totalSales)
            {
                return base.GetDiscountAmount(totalSales) - 5;
            }

            public override void ApplyDiscount()
            {
                throw new Exception("Not allowed");
            }
        }

        //in the above example, an "Enquiry" is an entity that could become a real "Customer" at some point in the future but not now.
        //as an "Enquiry" they should not be able to Apply a Discount

        interface IDiscount
        {
            double GetDiscountAmount(double totalSales);
        }

        interface IDatabaseThing
        {
            void ApplyDiscount();
        }

        public class EnquiryLiskov : IDiscount
        {
            public double GetDiscountAmount(double totalSales)
            {
                return totalSales - 5;
            }
        }

        public class CustomerLiskov : IDiscount, IDatabaseThing
        {
            public double GetDiscountAmount(double totalSales)
            {
                return totalSales;
            }

            public void ApplyDiscount()
            {
                //store to database
            }
        }

    }
}
