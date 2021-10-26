using Battlelog.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace Battlelog
{
    public class BattlelogClient
    {
        private static Regex illegalInFileName = new Regex(string.Format("[{0}]", Regex.Escape(new string(Path.GetInvalidFileNameChars()))), RegexOptions.Compiled);

        #region Retrieve Web Page
        public static String GetWebPage(String url) {
            try {
                var request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

                Task<WebResponse> responseTask = Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
                using (var responseStream = responseTask.Result.GetResponseStream()) {
                    var reader = new StreamReader(responseStream);
                    return reader.ReadToEnd();
                }
            }
            catch (WebException e) {
                if (e.Status.Equals(WebExceptionStatus.Timeout))
                    throw new Exception("HTTP request timed-out");
                else
                    throw;
            }
        }

        public static String fetchWebPage(ref String html_data, String url, bool ajax = false) {
            try {
                var request = (HttpWebRequest)HttpWebRequest.Create(url);
                request.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip,deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
                if (ajax) {
                    request.Headers.Add("X-AjaxNavigation", "1");
                }

                using (var response = request.GetResponse())
                using (var sr = new StreamReader(response.GetResponseStream())) {
                    html_data = sr.ReadToEnd();
                }

                return html_data;

            }
            catch (WebException e) {
                if (e.Status.Equals(WebExceptionStatus.Timeout))
                    throw new Exception("HTTP request timed-out");
                else
                    throw;
            }
        }
        #endregion

        /// <summary>
        /// Retrieve the User block with player name
        /// </summary>
        /// <param name="player"></param>
        /// <param name="personaId"></param>
        /// <returns></returns>
        public static User GetUser(String player, String personaId = null) {
            if (player == null)
                return (null);

            try {
                /* First fetch the player's main page to get the persona id */
                String result = "";

                if (personaId == null)
                    personaId = GetPersonaId(player);

                if (personaId == null)
                    return (null);

                fetchWebPage(ref result, $"http://battlelog.battlefield.com/bf4/soldier/{player}/stats/{personaId}/pc/", true);

                var res = JsonConvert.DeserializeObject<WarsawStats>(result);
                if (res?.context?.user != null) {
                    res.context.user.personaId = res.context.personaId;
                }
                if (res?.context?.club?.tag != null) {
                    res.context.user.ClanTag = res.context.club.tag;
                }

                return (res?.context?.user);
            }
            catch (Exception e) {
                //Handle exceptions here however you want
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        /// <summary>
        /// Retrieve the personaId of the player
        /// </summary>
        /// <param name="player">{String} soldierName</param>
        /// <returns></returns>
        public static string GetPersonaId(String player) {
            try {

                /* First fetch the player's main page to get the persona id */
                String result = "";
                fetchWebPage(ref result, "http://battlelog.battlefield.com/bf4/user/" + player, true);

                var deserialized = JsonConvert.DeserializeObject<WarsawOverview>(result);

                /* Extract the persona id */

                if (!deserialized.context.profilePersonas.Any(x => x.@namespace.Equals("cem_ea_id") && x.personaName.Equals(player, StringComparison.OrdinalIgnoreCase))) {
                    throw new Exception("could not find persona-id for ^b" + player);
                }
                else {
                    return (deserialized.context.profilePersonas.FirstOrDefault(x => x.@namespace.Equals("cem_ea_id") && x.personaName.Equals(player, StringComparison.OrdinalIgnoreCase)).personaId);
                }
            }
            catch (Exception e) {
                //Handle exceptions here however you want
                Console.WriteLine(e.ToString());
            }

            return null;
        }

        public static SERVER_INFO GetServerShow(string GUID) {
            try {
                String result = "";
                fetchWebPage(ref result, $"http://battlelog.battlefield.com/bf4/servers/show/pc/{GUID}/?json=1");

                Hashtable json = JsonConvert.DeserializeObject<Hashtable>(result);

                // check we got a valid response
                if (!(json.ContainsKey("type") && json.ContainsKey("message")))
                    throw new Exception("JSON response does not contain \"type\" or \"message\" fields");

                String type = (String)json["type"];

                /* verify we got a success message */
                if (!(type.StartsWith("success")))
                    throw new Exception("JSON response was type=" + type);

                var message = (json["message"] as JObject).ToObject<Hashtable>();
                if (!(message.ContainsKey("SERVER_INFO")))
                    throw new Exception("JSON response does not contain \"SERVER_INFO\" field");

                return (JsonConvert.DeserializeObject<SERVER_INFO>(JsonConvert.SerializeObject(message["SERVER_INFO"])));
            }
            catch (Exception e) {
                //Handle exceptions here however you want
                Console.WriteLine(e.ToString());
                return (null);
            }
        }

        public static int GetEpochSeconds(DateTime date) {
            TimeSpan t = date - new DateTime(1970, 1, 1);
            return (int)t.TotalSeconds;
        }

        public static UInt64 CalculateHash(string read) {
            UInt64 hashedValue = 3074457345618258791ul;
            for (int i = 0; i < read.Length; i++) {
                hashedValue += read[i];
                hashedValue *= 3074457345618258799ul;
            }
            return hashedValue;
        }
    }
}
