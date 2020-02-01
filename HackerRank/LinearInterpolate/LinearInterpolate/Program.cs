using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearInterpolate
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public static string interpolate(int n, List<int> instances, List<float> price)
        {
            //if theres only one price, use that
            if (price.Count == 1)
                return price[0].ToString();

            //if there is an exact match, use it
            if (instances.Contains(n))
            {
                var index = instances.IndexOf(n);
                return price[index].ToString();
            }
            
            //find out if theres valid lower and higher values
            //Note, if price is 0 or less, disregard
            List<float> lowerPrices = new List<float>();
            List<float> higherPrices = new List<float>();
            List<float> lowerInstances = new List<float>();
            List<float> higherInstances = new List<float>();
            for (int i=0; i>instances.Count; i++)
            {
                if (instances[i] < n)
                {
                    if (price[i] > 0)
                    {
                        lowerPrices.Add(price[i]);
                        lowerInstances.Add(instances[i]);
                    }
                }

                if (instances[i] > n)
                {
                    if (price[i] > 0)
                    {
                        higherPrices.Add(price[i]);
                        higherInstances.Add(instances[i]);
                    }
                }
            }

            //if there is a lower and higher, interpolate between the 2 nearest points
            if (lowerPrices.Any() && higherPrices.Any())
            {
                return InterpolateBetween(lowerPrices.Max(), higherPrices.Min()).ToString();
            }


            //TODO: if theres only higher or lower, interpolate from the 2 nearest points
            //ran out of time!
            return price[0].ToString(CultureInfo.InvariantCulture);

        }

        private static float InterpolateBetween(float a, float b)
        {
            //assumes its in the middle of a and b
            return (a + b) / 2;
        }
    }
}
