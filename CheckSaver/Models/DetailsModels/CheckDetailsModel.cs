using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckSaver.Models.DetailsModels
{
    public class CheckDetailsModel
    {
        public CheckDetailsModel(Checks check)
        {
            Date = check.Date;
            Payer = check.Neighbours.Name;
            Store = check.Stores;
            Id = check.Id;

            PurchasesList = new List<PurchaseDetailModel>();
            TotalList=new List<string>();
            Dictionary<string, decimal> dictonary = new Dictionary<string, decimal>();

            foreach (Purchases purchase in check.Purchases)
            {
                var model = new PurchaseDetailModel()
                {
                    Count = purchase.Count,
                    Price = purchase.Products.GetPrice(check.StoreId),
                    Summa = purchase.Summ,
                    Title = purchase.Products.Title,
                    Id = purchase.Id
                };

                string summary = string.Empty;
                //foreach (Currency VARIABLE in purchase.Currency)
                //{
                //    summary += VARIABLE.Neighbor.Name + ",";
                //    if (!dictonary.ContainsKey(VARIABLE.Neighbor.Name))
                //    {
                //        dictonary.Add(VARIABLE.Neighbor.Name, VARIABLE.CurrencyPrice);
                //    }
                //    else
                //    {
                //        dictonary[VARIABLE.Neighbor.Name] += VARIABLE.CurrencyPrice;
                //    }
                //}
                //model.PricePerPerson = purchase.Currency.First().CurrencyPrice.ToString();
                model.Summary = summary;

                

                PurchasesList.Add(model);


            }

            foreach (KeyValuePair<string, decimal> pair in dictonary)
            {
                TotalList.Add(pair.Key + " : " + pair.Value);
            }

        }

        public DateTime Date { get; set; }
        public String Payer { get; set; }
        public Stores Store { get; set; }
        public List<PurchaseDetailModel> PurchasesList { get; set; }
        public decimal Summa { get; set; }
        public List<string> TotalList { get; set; }
        public int Id { get; set; }

        public class PurchaseDetailModel
        {
            public string Title { get; set; }
            public decimal Count { get; set; }
            public decimal Price { get; set; }
            public decimal Summa { get; set; }
            public string Summary { get; set; }
            public string PricePerPerson { get; set; }
            public int Id { get; set; }
        }
    }
}