using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public static class Discount
    {
        public static int CalcDiscountAmount(int total, int disc_percent)
        {
            var discPercent = (double)disc_percent;

            double discountRate = ((double)discPercent) / ((double)100);

            var calcDiscountRate = total * discountRate;

            return total - (int)calcDiscountRate;
        }
    }
}
