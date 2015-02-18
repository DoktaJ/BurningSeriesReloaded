using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel.Design;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using BSViewer;
using BurningSeriesReloaded.JsonSessionID;
using BurningSeriesReloaded.Properties;
using Newtonsoft.Json;

namespace BurningSeriesReloaded
{


    internal class BurningSeries
    {


        public static string AusgewaehlteSerie { get; private set; }
        public static string AusgewaehlteStaffel { get; private set; }
        public static string AusgewaehltEpisode { get; private set; }
        public static string HosterId { get; private set; }
        public static bool HatFilm { get; private set; }

        public BurningSeries()
        {
            /*
                ToDo:
             *  Login done
             *  Sessions einfügen done
             *  Episodennummer anzeigen
             *  About
             *  etc.
             
            */
        }



        /// <summary>
        /// Holt alle Serien und deren ID und gibt sie als Array zurück
        /// </summary>
        /// <returns>Array mit allen Serien und dazugehöriger ID</returns>
        public static JsonAlleSerien[] Serien()
        {


            using (WebClient webClient = new WebClient())
            {
                string jsSerien = webClient.DownloadString("https://www.burning-seri.es/api/series");
                JsonAlleSerien[] jsonAlleSerien = JsonConvert.DeserializeObject<JsonAlleSerien[]>(jsSerien);
                return jsonAlleSerien;
            }
        }
        /// <summary>
        /// Holt sich alle Infos über die ausgewählte Serie
        /// </summary>
        /// <param name="ausgewaehlteSerie"></param>
        /// <returns>Array der Film und Staffelanzahl</returns>
        public static String[] SerienInfo(string ausgewaehlteSerie)
        {
            AusgewaehlteSerie = ausgewaehlteSerie;

            List<string> tmpList = new List<string>();
            tmpList.Clear();


            using (WebClient webClient = new WebClient())
            {
                string apikey = Settings.Default.ApiKey;
                string jsSerieInfo =
                    webClient.DownloadString("https://www.burning-seri.es/api/series/" + ausgewaehlteSerie + "/1/?s=" + apikey);

                JsonSerienInfos serienInfos = JsonConvert.DeserializeObject<JsonSerienInfos>(jsSerieInfo);

                // Überprüfen ob es von der Serie Filme gibt
                //
                if (Int32.Parse(serienInfos.series.movies) > 0)
                {
                    // Wenn es Filme gibt die Auswahl Filme an erster Stelle hinzufügen
                    //
                    tmpList.Add("Filme");
                    HatFilm = true;

                }
                // Für jede Staffel einen Eintrag in der Liste erstellen zum Anzeigen
                //
                for (int i = 0; i < int.Parse(serienInfos.series.seasons); i++)
                {
                    tmpList.Add("Staffel " + (i + 1));
                }

            }
            return tmpList.ToArray();
        }
        /// <summary>
        /// Holt sich die Episoden- und Filmnamen.
        /// </summary>
        /// <param name="ausgewaehlteStaffel"></param>
        /// <returns>Array der Episoden- und Filmnamen</returns>
        public static String[] EpisodenInfo(string ausgewaehlteStaffel)
        {
            string apikey = Settings.Default.ApiKey;
            AusgewaehlteStaffel = (Int32.Parse(ausgewaehlteStaffel)).ToString();
            List<string> tmpList = new List<string>();
            using (WebClient webClient = new WebClient())
            {
                if (HatFilm == false)
                {
                    AusgewaehlteStaffel = (Int32.Parse(AusgewaehlteStaffel) + 1).ToString();
                }
                string jsEpisoden =
                    webClient.DownloadString(
                        "https://www.burning-seri.es/api/series/" + AusgewaehlteSerie + "/" + AusgewaehlteStaffel + "/?s=" + apikey);
                JsonEpisodenInfo tmpJsonEpisodenInfo = JsonConvert.DeserializeObject<JsonEpisodenInfo>(jsEpisoden);


                for (var i = 0; i < tmpJsonEpisodenInfo.epi.Count; i++)
                {
                    var episode = tmpJsonEpisodenInfo.epi[i];
                    if (!(string.IsNullOrEmpty(episode.german)))
                    // Wenn es die Folge auf Deutsch gibt bzw. einen deutschen Namen
                    {
                        if (true)
                        {

                            if (episode.watched == "1")
                            {
                                tmpList.Add("Episode " + (i + 1) + ": " + episode.german + " ");
                            }
                            else
                            {
                                tmpList.Add("Episode " + (i + 1) + ": " + episode.german);
                            }

                        }
                        else
                        {
                            tmpList.Add(episode.german);
                        }

                    }
                    else
                    {
                        if (true)
                        {
                            if (episode.watched == "1")
                            {
                                tmpList.Add("Episode " + (i + 1) + ": " + episode.english + " ");
                            }
                            else
                            {
                                tmpList.Add("Episode " + (i + 1) + ": " + episode.english);
                            }
                        }
                        else
                        {
                            tmpList.Add(episode.english);
                        }

                    }
                }
                return tmpList.ToArray();
            }
        }


        /// <summary>
        /// Holt sich den Direktlink von Vivo, Streamcloud
        /// </summary>
        /// <param name="ausgewaehlteEpisode"></param>
        /// <returns>Direktlink von Vivo, wenn nicht vorhanden von Streamcloud</returns>
        public static String HoleLink(string ausgewaehlteEpisode)
        {
            string apikey = Settings.Default.ApiKey;
            AusgewaehltEpisode = (int.Parse(ausgewaehlteEpisode) + 1).ToString();
            try
            {
                HosterId = HoleId()["Vivo"];
                using (WebClient webClient = new WebClient())
                {
                    string jsLink =
                        webClient.DownloadString("https://www.burning-seri.es/api/watch/" + HosterId + "/?s=" + apikey);
                    JsonLinks jsonLink = JsonConvert.DeserializeObject<JsonLinks>(jsLink);

                    return Hoster.VivoDirektLink(jsonLink.fullurl);

                }
            }
            catch (KeyNotFoundException) // Kein VivoLink vorhanden
            {
                using (WebClient webClient = new WebClient())
                {
                    try
                    {
                        HosterId = HoleId()["Streamcloud"];
                        string jsLink = webClient.DownloadString("https://www.burning-seri.es/api/watch/" + HosterId + "/?s=" + apikey);
                        JsonLinks jsonLink = JsonConvert.DeserializeObject<JsonLinks>(jsLink);
                        return Hoster.StreamCloudDirektLink(jsonLink.fullurl);
                    }
                    catch (KeyNotFoundException e)
                    {
                        return "error1";
                    }
                }
            }
        }
        private static Dictionary<string, string> HoleId()
        {

            Dictionary<string, string> linksDictionary = new Dictionary<string, string>();


            using (WebClient webClient = new WebClient())
            {
                string apikey = Settings.Default.ApiKey;
                string jsLinks = webClient.DownloadString("https://www.burning-seri.es/api/series/" + AusgewaehlteSerie + "/" + AusgewaehlteStaffel + "/" + AusgewaehltEpisode + "/?s=" + apikey);
                JsonID jsonAlleLinks = JsonConvert.DeserializeObject<JsonID>(jsLinks);

                for (int i = 0; i < jsonAlleLinks.links.Count; i++)
                {
                    if (jsonAlleLinks.links[i].hoster == "Streamcloud" || jsonAlleLinks.links[i].hoster == "Vivo")
                    {
                        linksDictionary.Add(jsonAlleLinks.links[i].hoster, jsonAlleLinks.links[i].id);
                    }

                }

                return linksDictionary;
            }
        }
        /// <summary>
        /// Login bei BurningSeries falls kein API Key.
        /// </summary>
        /// <returns>BurningSeries API Key</returns>
        public static string ApiKey()
        {
            using (var LoginForm = new frmLogin())
            {
                if (Settings.Default.ApiKey == "")
                {
                    if (LoginForm.ShowDialog() == DialogResult.OK)
                    {
                        string apikey = "";
                        using (WebClient webClient = new WebClient())
                        {
                            NameValueCollection myCol = new NameValueCollection();
                            myCol.Clear();
                            myCol.Add("login[user]", LoginForm.Username);
                            myCol.Add("login[pass]", LoginForm.Password);

                            byte[] responseArray = webClient.UploadValues("https://www.burning-seri.es/api/login", myCol);
                            string response = Encoding.ASCII.GetString(responseArray);
                            JsonApiKey Apikey = JsonConvert.DeserializeObject<JsonApiKey>(response);
                            // var Apikey = JsonConvert.DeserializeObject<ApiKey>(response);

                            if (response == "{\"error\":\"Username oder Passwort falsch\"}")
                            {

                                Settings.Default.ApiKey = "";
                                return "errorUnPwWrong";
                            }



                            Settings.Default.ApiKey = Apikey.session;
                            Settings.Default.Save();
                            return Apikey.session;


                        }
                    }
                    else
                    {
                        Settings.Default.ApiKey = "";
                        return "errorunkown";
                    }
                }
                else
                {
                    return Settings.Default.ApiKey;
                }

            }

        }

    }

}
