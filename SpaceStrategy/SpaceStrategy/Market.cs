using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public class Market
    {
        private List<Dictionary<string, dynamic>> _priceList;

        public Market()
        {
            _priceList = PricesInit();
        }

        public List<Dictionary<string, dynamic>> GetPriceList()
        {
            return _priceList;
        }

        public Dictionary<string, dynamic> DefineResourceType(string type)
        {
            for (int i = 0; i < _priceList.Count(); i++)
            {
                if (_priceList[i]["type"].Type == type)
                {
                    return _priceList[i];
                }
            }
            Dictionary<string, dynamic> error = new Dictionary<string, dynamic>
            {
                { "error", "error" }
            };
            return error;
        }


        private List<Dictionary<string, dynamic>> PricesInit()
        {
            List<Dictionary<string, dynamic>> list = new List<Dictionary<string, dynamic>>();
            Dictionary<string, dynamic> wood = new Dictionary<string, dynamic>
            {
                { "type", new Wood() },
                { "amount", 100 },
                { "buy", 5 },
                { "sell", 5 }
            };
            Dictionary<string, dynamic> stone = new Dictionary<string, dynamic>
            {
                { "type", new Stone() },
                { "amount", 100 },
                { "buy", 5 },
                { "sell", 5 }
            };
            Dictionary<string, dynamic> food = new Dictionary<string, dynamic>
            {
                { "type", new Food() },
                { "amount", 100 },
                { "buy", 5 },
                { "sell", 5 }
            };
            list.Add(wood); list.Add(stone); list.Add(food);
            return list;
        }
        public void SetNewResourceData(Dictionary<string, dynamic> resource)
        {
            for (int i = 0; i < _priceList.Count(); i++)
            {
                if (_priceList[i]["type"].Type == resource["type"].Type)
                {
                    _priceList[i] = resource;
                }
            }
        }
    }
}
