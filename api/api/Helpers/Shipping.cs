using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public static class Shipping
    {
        private const int FREE_SHIPPING_AMOUNT = 50000;
        private const int SHIPPING_COST = 3000;
        public static int CalcShippingFee(int total)
        {
            if(total >= FREE_SHIPPING_AMOUNT)
            {
                return 0;
            }
            return SHIPPING_COST;
        }
    }
}
