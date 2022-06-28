using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSON_DOWNLOADER.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace JSON_DOWNLOADER.Items.Tests
{
    [TestClass()]
    public class JsonAgentTests_
    {

        [TestMethod()]
        public void IsJsonTest()
        {
            string path = Directory.GetCurrentDirectory();
            string refContent = File.ReadAllText(@$"{path}\Items\test_files\jsonRefFile.txt");
            bool result = JsonAgent.IsJson(refContent);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void IsJsonTest2()
        {
            string path = Directory.GetCurrentDirectory();
            string refContent = File.ReadAllText(@$"{path}\Items\test_files\wrongJson1.txt");
            bool result = JsonAgent.IsJson(refContent);
            Assert.AreEqual(false, result);
        }
    }
}