using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSON_DOWNLOADER.Items
{
    public class Manager
    {
        public List<JsonAgent> jsonList = new List<JsonAgent>();

        

        public static string[] Separate(string links)
        {
            string linksWithoutSpace = links.Replace(" ", string.Empty);
            string[] urls = linksWithoutSpace.Split(';');
            return urls;
        }

        public void GetLinks(string links) 
        {
            string[] splittedLinks = Separate(links);
            foreach(string link in splittedLinks)
            {
                jsonList.Add(new JsonAgent(link));
                int idx = jsonList.Count() - 1;
                (bool status, string content) = jsonList[idx].Download();
               
                if(!status)
                {
                    Console.WriteLine(content);
                    jsonList.RemoveAt(idx);
                }

            }
        }
        public bool LinksChooser(ref Manager mag)
        {
            //returning false -> don't add new links
            //false -> true add new links
            Console.WriteLine("Would you like to add links? y/n");
            bool key = false;
            while (true)
            {
                string addMoreLinks = Console.ReadLine();
                if (addMoreLinks == "y")
                {
                    break;
                }
                else if (addMoreLinks == "n")
                {
                    if (mag.jsonList.Count > 0)
                    {
                        key = true;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine($"Didn't recognize {addMoreLinks}, please use y or n");
                    continue;
                }
            }

            return key;
        }
        private void Fill(string cat)
        {
            foreach(var json in jsonList)
            {
                json.SetCatalong(cat);
            }
        }

        private bool chooseCreatingDir(ref Catalog cat)
        {
            bool ret = false;
            Console.WriteLine("Would you like to create the new catalog? y/n");
            while (true)
            {
                string key = Console.ReadLine();

                if(key == "y")
                {
                    cat.Create();
                }
                else if (key == "n")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            return ret;
        }

        public bool DirChooser(string dir)
        {
            //returning false -> go next

            Catalog cat = new(dir);
            bool isExist = cat.Is_exist();
            if(isExist)
            {
                Fill(dir);
                return true;
            }
            else
            {
                Console.WriteLine("The directory does not exist");
                return chooseCreatingDir(ref cat)? true : false;
            }            
        }

        public void Save()
        {
            foreach(var json in jsonList)
            {
                try
                {
                    json.Str2Json(json.link);

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }

    }
}
