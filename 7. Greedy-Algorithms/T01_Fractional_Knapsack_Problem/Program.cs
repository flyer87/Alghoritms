using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace T01_Fractional_Knapsack_Problem
{
    class Program
    {        
        static int maxCapacity;
        static private  OrderedBag<PriceWeigth> priceWeigth =
                new OrderedBag<PriceWeigth>();

        static void Main(string[] args)
        {        
            ReadInput();
            FillTheKnapsack(priceWeigth, maxCapacity);
        }

        private static void FillTheKnapsack(OrderedBag<PriceWeigth> priceWeigth, int maxCapacity)
        {            
            double totalPrice = 0;
            
            int lastItemIndex = 0; 
            var priceWeigthList = priceWeigth.Reversed().ToList();

            int currentLoad = 0;
            while (currentLoad < maxCapacity)
            {
                int crntItemWeight = priceWeigthList[lastItemIndex].Weight;
                if (currentLoad + crntItemWeight <= maxCapacity)
                {
                    totalPrice += priceWeigthList[lastItemIndex].Price;
                    lastItemIndex++;
                    currentLoad += crntItemWeight;
                }
                else
                {                    
                    double pricePortion = (maxCapacity - currentLoad) / (double)crntItemWeight;
                    totalPrice += (priceWeigthList[lastItemIndex].Price * pricePortion);
                    currentLoad += crntItemWeight;
                }
            }

            Console.WriteLine("Total price = {0:f2}", totalPrice);
        }

        static private void ReadInput()
        {
            string line = Console.ReadLine();
            string[] lineTokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            maxCapacity = int.Parse(lineTokens[1]);

            line = Console.ReadLine();
            lineTokens = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int itemsCnt = int.Parse(lineTokens[1]);
            
            for (int i = 0; i < itemsCnt; i++)
            {
                line = Console.ReadLine();
                lineTokens = line.Split(new char[] { '-', '>', ' ' }, StringSplitOptions.RemoveEmptyEntries).
                    ToArray();                
                priceWeigth.Add(new PriceWeigth() { Price = int.Parse(lineTokens[0]), Weight = int.Parse(lineTokens[1]) } ); 
            }
        }
    }

    class PriceWeigth : IComparable
    {
        public int Price { get; set; }
        public int Weight { get; set; }        
        public int CompareTo(object obj)
        {
            return (this.Price / this.Weight).CompareTo(
                (obj as PriceWeigth).Price / (obj as PriceWeigth).Weight);
        }
    }

}

