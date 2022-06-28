using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace JSON_DOWNLOADER.Items
{
    public class Catalog
    {
        private string directory;
        public bool Valid { get; private set; }

        public Catalog()
        {
        }
        public Catalog(string directory) 
        {
            this.directory = directory;
        }
        public bool Is_exist()
        {
            bool result = Directory.Exists(directory);
            Valid = result;
            return result;
        }
        public void Set(string directory) 
        {
            this.directory = directory;
        }
        public string Get()
        {
            return directory;
        }

        public void Create()
        {
            Directory.CreateDirectory(directory);
        }
        public void Remove()
        {
            Directory.Delete(directory);
        }

    }
}
