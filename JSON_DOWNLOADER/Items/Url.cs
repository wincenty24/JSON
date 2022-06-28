using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JSON_DOWNLOADER.Items
{
    public class Url
    {
        private string link;
        private string status;
        public bool valid { get; private set; }
        //to check available status, look at HttpStatusCode.cs
        public Url()
        {
        }
        public Url(string link)
        {
            SetLink(link);
        }
        public void SetLink(string link)
        {
            this.link = link;
        }

        public bool IsValid()
        {
            //if a link is unvalidated, as the status, IsValid() set the expectations
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(link);
                req.Timeout = 10000;//set timeout to 10 sec
                using var resp = req.GetResponse() as HttpWebResponse;
                //returned status depends on https://developer.mozilla.org/en-US/docs/Web/HTTP/Status
                status = resp.StatusCode.ToString();
                bool isValidStatus = ((int)resp.StatusCode >= 100) && ((int)resp.StatusCode < 400) ? true : false;
                valid = isValidStatus;
                return isValidStatus;
            }
            catch (WebException)
            {
                status = $"404 web not found";
                valid = false;
                return false;
            }
            catch (Exception e)
            {
                status = e.ToString();
                valid = false;
                return false;
            }
        }
        public static (bool, string) IsValid(string link)
        {
            //return firstly link validation and nextly message status
            try
            {
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(link);
                req.Timeout = 10000;//set timeout to 10 sec
                using var resp = req.GetResponse() as HttpWebResponse;
                //returned status depends on https://developer.mozilla.org/en-US/docs/Web/HTTP/Status
                bool isValidStatus = ((int)resp.StatusCode >= 100) && ((int)resp.StatusCode < 400) ? true : false;
                return (isValidStatus, resp.StatusCode.ToString());

            }
            catch (WebException)
            {
                return (false, $"404 web not found");
            }
            catch (Exception e)
            {
                return (false, e.ToString());
            }
        }

        public bool IsWellWormated()
        {
            return Uri.IsWellFormedUriString(link, UriKind.Absolute);
        }

        public string GetStatus() 
        {
            return status;
        }
        public string GetLink()
        {
            return link;
        }
    }
}
