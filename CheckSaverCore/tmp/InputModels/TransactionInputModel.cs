﻿using System;

namespace CheckSaverCore.tmp.InputModels
{
    public class  TransactionsInputModel
    {
        public int Id { get; set; }
        public int WhoPay { get; set; }
        public int ForWhom { get; set; }
        public string Caption { get; set; }
        public System.DateTime Date { get; set; }
        public bool IsDebitOff { get; set; }
        public Nullable<int> CheckId { get; set; }
        public string Summa { get; set; }

        public virtual ExtentionsModels.Checks Checks { get; set; }
        public virtual ExtentionsModels.Neighbours WhoPayNP { get; set; }
        public virtual ExtentionsModels.Neighbours ForWhomNP { get; set; }
    }
}