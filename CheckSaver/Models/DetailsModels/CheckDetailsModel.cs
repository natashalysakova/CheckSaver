using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckSaver.Models.DetailsModels
{
    public class CheckDetailsModel
    {
        public CheckDetailsModel(Check check)
        {
            Date = check.DateTime;
            Payer = check.Neighbor.Name;
            Store = check.Store;
            Summa = check.Summ;
            Id = check.Id;

            PurchasesList = new List<PurchaseDetailModel>();
            TotalList=new List<string>();
            Dictionary<string, decimal> dictonary = new Dictionary<string, decimal>();

            foreach (Purchase purchase in check.Purchase)
            {
                var model = new PurchaseDetailModel()
                {
                    Count = purchase.Count,
                    Price = purchase.Product.Price,
                    Summa = purchase.Summa,
                    Title = purchase.Product.Name,
                    Id = purchase.Id
                };

                string summary = string.Empty;
                foreach (Currency VARIABLE in purchase.Currency)
                {
                    summary += VARIABLE.Neighbor.Name + ",";
                    if (!dictonary.ContainsKey(VARIABLE.Neighbor.Name))
                    {
                        dictonary.Add(VARIABLE.Neighbor.Name, VARIABLE.CurrencyPrice);
                    }
                    else
                    {
                        dictonary[VARIABLE.Neighbor.Name] += VARIABLE.CurrencyPrice;
                    }
                }
                model.PricePerPerson = purchase.Currency.First().CurrencyPrice.ToString();
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
        public Store Store { get; set; }
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