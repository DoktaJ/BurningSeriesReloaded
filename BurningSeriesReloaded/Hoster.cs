using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BurningSeriesReloaded
{
    public static class Hoster
    {
        public static string StreamCloudDirektLink(string streamcloudUrl)
        {
            using (WebClient webClient = new WebClient())
            {
                
                NameValueCollection myCol = new NameValueCollection();
                myCol.Clear();
                myCol.Add("op", "download2");
                myCol.Add("usr", "login");
                myCol.Add("id", streamcloudUrl.Split('/')[3]);
                myCol.Add("fname", streamcloudUrl.Split('/')[4]);
                myCol.Add("referer", "");
                myCol.Add("hash", "");
                myCol.Add("iamhuman", "Weiter zum Video");
                byte[] responseArray = webClient.UploadValues(streamcloudUrl, myCol);
                string response = Encoding.ASCII.GetString(responseArray);
                var regex = new Regex("file: \"(.*?)\",");
                Match match = regex.Match(response);
                
                return match.Groups[1].Value;

            }

        }

        public static string VivoDirektLink(string vivoUrl)
        {
            using (WebClient webClient = new WebClient())
            {

                string VivoSource = webClient.DownloadString(vivoUrl);
                var regexHash = new Regex("\"hash\" value=\"(.*?)\"");
                var regexExpires = new Regex("\"expires\" value=\"(.*?)\"");
                var regexTimestamp = new Regex("\"timestamp\" value=\"(.*?)\"");
                Match matchHash = regexHash.Match(VivoSource); //matchVivo.Groups[1].Value)
                Match matchExpires = regexExpires.Match(VivoSource); //matchExpires.Groups[1].Value)
                Match matchTimestamp = regexTimestamp.Match(VivoSource); //matchTimestamp.Groups[1].Value)
                string hash = matchHash.Groups[1].Value;
                string expires = matchExpires.Groups[1].Value;
                string timestamp = matchTimestamp.Groups[1].Value;
                NameValueCollection myCol = new NameValueCollection();
                myCol.Clear();
                myCol.Add("hash", hash);
                myCol.Add("expires", expires);
                myCol.Add("timestamp",timestamp);
                byte[] responseArray = webClient.UploadValues(vivoUrl, myCol);
                string response = Encoding.ASCII.GetString(responseArray);
               // MessageBox.Show(response);
                var regex = new Regex("data-url=\"(.*?)\"");
                Match match = regex.Match(response);
                return match.Groups[1].Value;

            }

        }
    }
}
