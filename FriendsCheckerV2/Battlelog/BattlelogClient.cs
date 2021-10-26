using Newtonsoft.Json;
using FriendsCheckerV2.Models;
using System;
using System.Collections.Generic;
using System.Web;
using FriendsCheckerV2.Battlelog.Models;

namespace FriendsCheckerV2.Battlelog
{
    public static class BattlelogClient
    {
        public static WarsawFriends GetFriends(string userName)
        {
            try
            {
                using var webClient = new GZipWebClient();
                webClient.Headers.Add("X-AjaxNavigation", "1");
                var result = webClient.DownloadString($"https://battlelog.battlefield.com/bf4/user/{userName}/friends/");
                return JsonConvert.DeserializeObject<WarsawFriends>(result);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        ///     Get users by personaNames
        /// </summary>
        /// <param name="personaNames">Array of persona names</param>
        /// <returns></returns>
        public static Response<Dictionary<ulong, DashUser>> GetUsersByPersonaNames(string[] personaNames, DashKind kind = DashKind.Light)
        {
            try
            {
                using var webClient = new GZipWebClient();
                var httpValueCollection = HttpUtility.ParseQueryString(string.Empty);
                foreach (var personaName in personaNames)
                {
                    httpValueCollection.Add("personaNames", personaName);
                }
                httpValueCollection.Add("kind", kind.ToString().ToLower());
                var uriBuilder = new UriBuilder("https://battlelog.battlefield.com/bf4/battledash/getUsersByPersonaNames") {
                    Query = httpValueCollection.ToString()
                };
                string result = webClient.DownloadString(uriBuilder.ToString());
                return JsonConvert.DeserializeObject<Response<Dictionary<ulong, DashUser>>>(result);
            }
            catch (Exception e)
            {
                //Handle exceptions here however you want
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        /// <summary>
        ///     Get users by personaIds
        /// </summary>
        /// <param name="personaIds">Array of persona Ids</param>
        /// <returns></returns>
        public static Response<Dictionary<ulong, DashUser>> GetUsersByPersonaIds(string[] personaIds, DashKind kind = DashKind.Light)
        {
            try
            {
                using var webClient = new GZipWebClient();
                var httpValueCollection = HttpUtility.ParseQueryString(string.Empty);
                foreach (var personaId in personaIds)
                {
                    httpValueCollection.Add("personaIds[]", personaId);
                }
                httpValueCollection.Add("kind", kind.ToString().ToLower());
                var uriBuilder = new UriBuilder("https://battlelog.battlefield.com/bf4/battledash/getUsersByPersonaIds") {
                    Query = httpValueCollection.ToString()
                };
                string result = webClient.DownloadString(uriBuilder.ToString());
                return JsonConvert.DeserializeObject<Response<Dictionary<ulong, DashUser>>>(result);
            }
            catch (Exception e)
            {
                //Handle exceptions here however you want
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        /// <summary>
        ///     Get users by userIds
        /// </summary>
        /// <param name="userIds">Array of user Ids</param>
        /// <returns></returns>
        public static Response<Dictionary<ulong, DashUser>> GetUsersByUserIds(string[] userIds, DashKind kind = DashKind.Light)
        {
            try
            {
                using var webClient = new GZipWebClient();
                var httpValueCollection = HttpUtility.ParseQueryString(string.Empty);
                foreach (var userId in userIds)
                {
                    httpValueCollection.Add("userIds[]", userId);
                }
                httpValueCollection.Add("kind", kind.ToString().ToLower());
                var uriBuilder = new UriBuilder("https://battlelog.battlefield.com/bf4/battledash/getUsersById") {
                    Query = httpValueCollection.ToString()
                };
                string result = webClient.DownloadString(uriBuilder.ToString());
                return JsonConvert.DeserializeObject<Response<Dictionary<ulong, DashUser>>>(result);
            }
            catch (Exception e)
            {
                //Handle exceptions here however you want
                Console.WriteLine(e.ToString());
                return null;
            }
        }
    }
}
