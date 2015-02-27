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
            Date = check.DateTime.ToShortDateString();
            Payer = check.Neighbor.Name;
            Store = check.Store.Title;
            Summa = check.Summ.ToString();

            PurchasesList = new List<PurchaseDetailModel>();
            TotalList=new List<string>();
            Dictionary<string, decimal> dictonary = new Dictionary<string, decimal>();

            foreach (Purchase purchase in check.Purchase)
            {
                var model = new PurchaseDetailModel()
                {
                    Count = purchase.Count.ToString(),
                    Price = purchase.Product.Price.ToString(),
                    Summa = purchase.Summa.ToString(),
                    Title = purchase.Product.Name
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

        public string Date { get; set; }
        public String Payer { get; set; }
        public String Store { get; set; }
        public List<PurchaseDetailModel> PurchasesList { get; set; }
        public string Summa { get; set; }
        public List<string> TotalList { get; set; }


        public class PurchaseDetailModel
        {
            public string Title { get; set; }
            public string Count { get; set; }
            public string Price { get; set; }
            public string Summa { get; set; }
            public string Summary { get; set; }
            public string PricePerPerson { get; set; }
        }
    }
}