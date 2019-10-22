using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Helpers
{
    public static class Tax
    {
        private const double TAX_RATE = 0.15;
        public static int CalcTax(int amount)
        {
            return (int)(amount*TAX_RATE);
        }
    }
}
