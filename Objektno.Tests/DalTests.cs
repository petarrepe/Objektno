using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL.Models;

namespace Objektno.Tests
{
    [TestClass]
    public class DalTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (DAL.Facade facade = new DAL.Facade())
            {
                var employees = facade.FetchAll<CaffeModel>();

                var existsNOT = facade.Exists<CaffeModel>(100);
                var exists = facade.Exists<CaffeModel>(1);

                CaffeModel tt = new CaffeModel();
                tt.Name = "Test";
                tt.Adress = "test";
                var test = facade.FetchByAttributeValue<CaffeModel>(t => t.IDCaffe == 1);

                facade.Insert(tt);
            }



            using (DAL.Facade facade = new DAL.Facade())
            {
                var employees = facade.FetchAll<CaffeModel>();
                facade.Delete(employees[1]);
            }
        }
    }
}
