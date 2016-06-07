using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckSaver.Models.Repository;
using System.Diagnostics;
using CheckSaver.Models;
using CheckSaver.Models.InputModels;
using Moq;

namespace CheckSaverTestProjects
{
//    [TestClass]
//    public class NeighbourTestClass
//    {
//        CheckSaveDbRepository _repository = new CheckSaveDbRepository();
//        InvoiceDbRepository _invoiceDbRepository = new InvoiceDbRepository();

//        [TestMethod]
//        public void TestMethod1()
//        {
//            var res = _repository.GetNeighboursNames();

//            foreach (var item in res)
//            {
//                Debug.WriteLine(string.Format("{0}: {1}", item.Name, item.IsDefault));
//            }

//            Assert.AreEqual(true, res[0].IsDefault);
            
//        }

//        [TestMethod]
//        public void TestMethod2()
//        {
//            ElectricityTarif tarif = _invoiceDbRepository.GetActualElectricityTarif(2,2016);

//            var summ = tarif.Calculate(650).ToString("F");
//            Assert.AreEqual("514,05", summ);
//        }

//        [TestMethod]
//        public void TestMethod3()
//        {
//            ElectricityTarif tarif = _invoiceDbRepository.GetActualElectricityTarif(2, 2016);

//            var summ = tarif.Calculate(320).ToString("F");
//            Assert.AreEqual("219,18", summ);
//        }

//        [TestMethod]
//        public void TestMethod4()
//        {
//            ElectricityTarif tarif = _invoiceDbRepository.GetActualElectricityTarif(2, 2016);

//            var summ = tarif.Calculate(94).ToString("F");
//            Assert.AreEqual("42,86", summ);
//        }

//        [TestMethod]
//        public void TestMethod5()
//        {
//            _invoiceDbRepository.AddInvoice(new InvoiceInputModel());
//            //Assert.AreEqual("42,86", summ);
//        }
//    }
    class MyClass
    {
        public void Methiod()
        {
            var x = new Mock<CheckSaveDbRepository>();
            
        }
    }
}
