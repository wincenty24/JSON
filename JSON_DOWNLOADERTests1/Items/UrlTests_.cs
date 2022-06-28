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
    public class UrlTests_
    {
        [TestMethod()]
        public void IsNotWellWormatedTest()
        {
            Url url = new("https://www.google.com/$$%#@");

            Assert.AreEqual(false, url.IsWellWormated());
        }
        [TestMethod()]
        public void IsNotValidTest()
        {
            Url url = new("https://www.google.com/8");

            Assert.AreEqual(false, url.IsValid());
            Assert.AreEqual(false, url.valid);

        }
        [TestMethod()]

        public void IsValidTest()
        {
            Url url = new("https://www.google.com/");

            Assert.AreEqual(true, url.IsValid());
            Assert.AreEqual(true, url.valid);
        }

        [TestMethod()]
        public void GetStatusTest()
        {
            Url url = new("https://www.google.com/");
            url.IsValid();
            string status = url.GetStatus();
            Assert.AreEqual(true, url.valid);
            Assert.AreEqual("OK", status);
        }
        [TestMethod()]
        public void GetStatusTestWronUrl()
        {
            Url url = new("https://www.google.com/tyu123897hfdjs");
            url.IsValid();
            string status = url.GetStatus();
            Assert.AreEqual(false, url.valid);
            Assert.AreEqual("404 web not found", status);
        }

        [TestMethod()]
        public void IsValidTest1()
        {
            (bool isValidStatus, string message) = Url.IsValid("https://www.google.com/urieq7r8h23");
            Assert.AreEqual("404 web not found", message);
            Assert.AreEqual(false, isValidStatus);
        }
    }
}