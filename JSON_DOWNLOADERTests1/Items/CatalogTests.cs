using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSON_DOWNLOADER.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_DOWNLOADER.Items.Tests
{
    [TestClass()]
    public class CatalogTests
    {
        [TestMethod()]
        public void getTest()
        {
            Catalog cat = new(@"C:/Users");

            string dir = cat.Get();

            Assert.AreEqual(dir, @"C:/Users");
        }
        [TestMethod()]
        public void setTest()
        {
            Catalog cat = new();
            cat.Set(@"C:\Users");

            string dir = cat.Get();

            Assert.AreEqual(dir, @"C:\Users");
        }
        [TestMethod()]
        public void Create_remove_Test()
        {
            Catalog cat = new();
            cat.Set("test_catalog");
            
            if(cat.Is_exist()) 
            {
                cat.Remove();
            }

            cat.Create();
            Assert.AreEqual(cat.Is_exist(), true);

            cat.Remove();
            Assert.AreEqual(cat.Is_exist(), false);
        }

        [TestMethod()]
        public void Is_existTest()
        {
            Catalog cat = new(@"C:\Users");
            Assert.AreEqual(cat.Is_exist(), true);
        }
    }
}