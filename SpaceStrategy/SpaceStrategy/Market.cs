using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceStrategy
{
    public struct MarketStorageElement
    {
        public Resource ResType { get; }
        public int Amount { get; set; }
        public double Buy { get; set; }
        public double Sell { get; set; }

        public MarketStorageElement(Resource type, int amount, int buy, int sell)
        {
            ResType = type;
            Amount = amount;
            Buy = buy;
            Sell = sell;
        }

    }

    public class Market
    {
        private List<MarketStorageElement> _priceList;
        private List<MarketStorageElement> _prevPriceList;

        public Market()
        {
            _priceList = PricesInit();
            _prevPriceList = _priceList;
        }

        public List<MarketStorageElement> GetPriceList()
        {
            return _priceList;
        }

        public MarketStorageElement DefineResourceType(string type)
        {
            for (int i = 0; i < _priceList.Count(); i++)
            {
                if (_priceList[i].ResType.TypeString == type)
                {
                    return _priceList[i];
                }
            }
            Console.WriteLine("Can't define market resource type!");
            MarketStorageElement error = new MarketStorageElement();
            return error;
        }


        private List<MarketStorageElement> PricesInit()
        {
            List<MarketStorageElement> list = new List<MarketStorageElement>();
            MarketStorageElement wood = new MarketStorageElement(type: new Wood(), amount: 100, buy:6 , sell: 5);
            MarketStorageElement stone = new MarketStorageElement(type: new Stone(), amount: 100, buy:6 , sell: 5);
            MarketStorageElement food = new MarketStorageElement(type: new Food(), amount: 100, buy:6 , sell: 5);
            list.Add(wood); list.Add(stone); list.Add(food);
            return list;
        }
        public void SetNewResourceData(MarketStorageElement resource)
        {
            // if something has been changed this method changes particular resource
            for (int i = 0; i < _priceList.Count(); i++)
            {
                if (_priceList[i].ResType.TypeString == resource.ResType.TypeString)
                {
                    _priceList[i] = resource;
                }
            }
        }

        //public void ChangeBuySell()
        //{
        //    for (int i = 0; i < _priceList.Count(); i++)
        //    {
        //        double before = _prevPriceList[i].Amount;
        //        double after = _priceList[i].Amount;

        //        double k = after / before;

        //        MarketStorageElement el;
        //        el = _priceList[i];
        //        Console.WriteLine(el.Sell + " " + k);
        //        el.Sell *= k;
        //        Console.WriteLine(el.Sell);
        //        SetNewResourceData(el);
        //    }
        //    _prevPriceList = _priceList;
        //}

    }
}
