using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckSaver.Models.Repository;
using System.Diagnostics;
using CheckSaver.Models;
using CheckSaver.Models.InputModels;

namespace CheckSaverTestProjects
{
    [TestClass]
    public class NeighbourTestClass
    {
        CheckSaveDbRepository _repository = new CheckSaveDbRepository();
        InvoiceDbRepository _invoiceDbRepository = new InvoiceDbRepository();

        [TestMethod]
        public void TestMethod1()
        {
            var res = _repository.GetNeighboursNames();

            foreach (var item in res)
            {
                Debug.WriteLine(string.Format("{0}: {1}", item.Name, item.IsDefault));
            }

            Assert.AreEqual(true, res[0].IsDefault);
            
        }

        [TestMethod]
        public void TestMethod2()
        {
            ElectricityTarif tarif = _invoiceDbRepository.GetActualElectricityTarif(2,2016);

            var summ = tarif.Calculate(650).ToString("F");
            Assert.AreEqual("514.05", summ);
        }

        [TestMethod]
        public void TestMethod3()
        {
            ElectricityTarif tarif = _invoiceDbRepository.GetActualElectricityTarif(2, 2016);

            var summ = tarif.Calculate(320).ToString("F");
            Assert.AreEqual("219.18", summ);
        }

        [TestMethod]
        public void TestMethod4()
        {
            ElectricityTarif tarif = _invoiceDbRepository.GetActualElectricityTarif(2, 2016);

            var summ = tarif.Calculate(94).ToString("F");
            Assert.AreEqual("42.86", summ);
        }

        //[TestMethod]
        //public void TestMethod5()
        //{

        //    Assert.AreNotEqual(0, _invoiceDbRepository.AddInvoice(
        //        new InvoiceInputModel() {
        //            Address = "test",
        //            ColdWaterInput = new InvoiceInputModel.Utilities<WaterTarif>()
        //            {
        //                StartValue = "0",
        //                FinishValue = "50",
        //                Cost = "25",
        //                Difference = "50",
        //                Tarif = new WaterTarif(),
        //            },
        //            CreationDate = DateTime.Now.Date,
        //            ElectricityInput = new InvoiceInputModel.Utilities<ElectricityTarif>()
        //            {
        //                StartValue = "0",
        //                FinishValue = "50",
        //                Cost = "25",
        //                Difference = "50",
        //                Tarif = new ElectricityTarif(),
        //            },

        //            FixedPaysInput = new System.Collections.Generic.List<FixedPaysInputModel>(),

        //            GasInput = new InvoiceInputModel.Utilities<GasTarif>()
        //            {
        //                StartValue = "0",
        //                FinishValue = "50",
        //                Cost = "25",
        //                Difference = "50",
        //                Tarif = new GasTarif(),
        //            },

        //            HotWaterInput = new InvoiceInputModel.Utilities<WaterTarif>()
        //            {
        //                StartValue = "0",
        //                FinishValue = "50",
        //                Cost = "25",
        //                Difference = "50",
        //                Tarif = new WaterTarif(),
        //            },
        //            Month = 06,
        //            TotalSum = "1000",
        //            Year = 2016
        //        }));
        //}
    }
}
