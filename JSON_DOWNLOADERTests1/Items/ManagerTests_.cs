using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSON_DOWNLOADER.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JSON_DOWNLOADER.Items.Tests
{
    [TestClass()]
    public class ManagerTests_
    {
        [TestMethod()]
        public void SeparateTest()
        {
            const string input = "a ; b; c;   d";
            string[] result = Manager.Separate(input);
            string[] reference = { "a", "b", "c", "d" };
            CollectionAssert.AreEqual(reference, result);
        }

        [TestMethod()]
        public void LinksChooserTest()
        {
            Manager mag = new();

            var output = new StringWriter();
            Console.SetOut(output);
            var stringReader = new StringReader("y");

            Console.SetIn(stringReader);
            bool result = mag.LinksChooser(ref mag);
            Assert.AreEqual(false, result);
        }
        [TestMethod()]
        public void LinksChooserTest2()
        {
            Manager mag = new();
            mag.jsonList.Add(new JsonAgent("https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json"));
            var output = new StringWriter();
            Console.SetOut(output);
            var stringReader = new StringReader("n");

            Console.SetIn(stringReader);
            bool result = mag.LinksChooser(ref mag);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void LinksChooserTest3()
        {
            Manager mag = new();

            var output = new StringWriter();
            Console.SetOut(output);
            var stringReader = new StringReader("n");

            Console.SetIn(stringReader);
            bool result = mag.LinksChooser(ref mag);
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void GetLinksTest()
        {
            Manager mag = new();

            mag.GetLinks("https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json");

            int result = mag.jsonList.Count;

            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void DirChooserTest()
        {
            Manager mag = new();
            mag.GetLinks("https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json");
            bool result = mag.DirChooser(@"C:Users/");
            Assert.AreEqual(true, result);
        }
        [TestMethod()]

        public void DirChooserTest2()
        { 
            Manager mag = new();
            mag.GetLinks("https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json");
            var output = new StringWriter();
            Console.SetOut(output);
            var stringReader = new StringReader("n");

            Console.SetIn(stringReader);
            bool result = mag.DirChooser(@"C:Heszke/");
            Assert.AreEqual(false, result);
        }
    }
}