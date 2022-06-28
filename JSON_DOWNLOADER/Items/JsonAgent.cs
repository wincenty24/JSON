using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Web.Helpers;
using Newtonsoft.Json.Linq;

namespace JSON_DOWNLOADER.Items
{
    public class JsonAgent
    {
        private Catalog catalog;
        private Url url;
        public string link  { get; private set; }
        public JsonAgent(string link, string directory)
        {
            url = new Url(link);
            catalog = new Catalog(directory);
        }
        public JsonAgent(string link)
        {
            url = new Url(link);
            url.IsValid();
        }
        public JsonAgent()
        {

        }
        public bool SetUrl(string link)
        {
            if (url == null)
            {
                url = new Url(link);
            }
            else
            {
                url.SetLink(link);
            }
            return url.IsValid();
        }
        public bool SetCatalong(string directory)
        {
            if (catalog == null)
            {
                catalog = new Catalog(directory);
            }
            else
            {
                catalog.Set(directory);
            }
            return catalog.Is_exist();
        }
        public static bool IsJson(string str)
        {
            try
            {
                JContainer.Parse(str);
                return true;
            }
            catch
            {
                return false;
            }
        }
        private string GetName()
        {
            string[] splitted = url.GetLink().Split('/');
            string lastElement = splitted.Last();
            if (lastElement.Contains(".json"))
            {
                return lastElement;
            }
            else
            {
                string date = DateTime.Now.ToString("HH:mm:ss tt");
                string corrected = date.Replace(":", "_").Replace(" ", "_");
                return corrected + ".json";
            }
        }
        
        public (bool, string) Str2Json(string str)
        {
            try
            {
                if (catalog.Valid)
                {
                    using StreamWriter file = new($@"{catalog.Get()}\{GetName()}");
                    file.Write(str);
                    return (true, "");
                }
                else
                {
                    return (false, "your catalog is not validated");
                }
            }
            catch(Exception e)
            {
                return (false, e.ToString());
            }
        }

        public (bool, string) Download()
        {
            try
            {
                if (url.valid)
                {
                    using (var webClient = new System.Net.WebClient())
                    {
                        string content = webClient.DownloadString(url.GetLink());
                        link = content;
                        return (true, content);
                    }
                }
                else
                {
                    return (false, "your link is not validated");
                }
            }
            catch (Exception e)
            {
                return (false, e.ToString());
            }
        }
    }
}
