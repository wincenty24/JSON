using JSON_DOWNLOADER.Items;//including files
using System;
using System.IO;
using System.Linq;

namespace JSON_DOWNLOADER
{
    class Program
    {


        private static  void DownloadCOntent(ref Manager mag)
        {
            while (true)
            {
                Console.WriteLine("Set url using ';' as the separator");
                string links = Console.ReadLine();
                mag.GetLinks(links);
                bool status = mag.LinksChooser(ref mag);
                if(status)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
        private static void GetDirectory(ref Manager mag)
        {
            while (true)
            {
                Console.WriteLine("Set directory using ';' as the separator");
                string dir = Console.ReadLine();
                bool result = mag.DirChooser(dir);
                if(result)
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        private static void Save(ref Manager mag)
        {
            mag.Save();
        }


        static void Main(string[] args)
        {
            Manager manager = new();
            DownloadCOntent(ref manager);
            GetDirectory(ref manager);
            Save(ref manager);
        }
    }
}
