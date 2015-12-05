using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckSaver.Models.Repository;
using System.Diagnostics;

namespace CheckSaverTestProjects
{
    [TestClass]
    public class NeighbourTestClass
    {
        CheckSaveDbRepository _repository = new CheckSaveDbRepository();

        [TestMethod]
        public void TestMethod1()
        {
            var res = _repository.GetNeighboursNames();

            foreach (var item in res)
            {
                Debug.WriteLine(string.Format("{0}: {1}", item.name, item.isDefault));
            }

            Assert.AreEqual(true, res[0].isDefault);
            
        }
    }
}
