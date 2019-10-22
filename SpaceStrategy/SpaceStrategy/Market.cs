using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class Market
    {
        private Dictionary<Resource, int> priceList;

        public Market()
        {
            priceList = new Dictionary<Resource, int>
            {
                { new Wood(), 5 },
                { new Stone(), 5 },
                { new Food(), 5 }
            };
        }

        public Dictionary<Resource, int> GetPriceList()
        {
            return priceList;
        }
    }
}
