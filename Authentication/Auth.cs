using Battlelog.Models;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace Authentication
{
    public class Auth
    {
        private GZipWebClient client;

        string API = @"http://battlelog.battlefield.com";

        //public string Code { get; set; }
        public string SessionId { get; set; }
        public string SoldierName { get; set; }
        public string PersonaId { get; set; }
        public string SecondFactoryAuthToken { get; set; }

        public Auth() {
            client = new GZipWebClient();
        }

        public void Login(string email, string password, string secondFactoryAuthToken = null) {
            try {
                if (!string.IsNullOrEmpty(secondFactoryAuthToken)) {
                    client.CookieContainer.Add(new Cookie("_nx_mpcid", secondFactoryAuthToken, "/", ".ea.com"));
                }
                client.DownloadString("https://accounts.ea.com/connect/auth?locale=en_US&state=bf4&redirect_uri=https://battlelog.battlefield.com/sso/?tokentype=code&response_type=code&client_id=battlelog&display=web/login");
                // fid = HttpUtility.ParseQueryString(new Uri(client.ResponseHeaders["Location"]).Query).Get("fid");
                client.DownloadString(client.ResponseHeaders["Location"]);
                var loginRequestUrl = $"https://signin.ea.com{client.ResponseHeaders["Location"]}";
                client.DownloadString(loginRequestUrl);

                // Login
                var reqparm = new System.Collections.Specialized.NameValueCollection();
                reqparm.Add("_eventId", "submit");
                reqparm.Add("_rememberMe", "on");
                reqparm.Add("country", "FI");
                reqparm.Add("email", email);
                reqparm.Add("gCaptchaResponse", "");
                reqparm.Add("isIncompletePhone", "");
                reqparm.Add("isPhoneNumberLogin", "false");
                reqparm.Add("password", password);
                reqparm.Add("passwordForPhone", "");
                reqparm.Add("phoneNumber", "");
                reqparm.Add("rememberMe", "on");
                byte[] responsebytes = client.UploadValues(loginRequestUrl, "POST", reqparm);
                string responsebody = Encoding.UTF8.GetString(responsebytes);

                loginRequestUrl = $"https://signin.ea.com{client.ResponseHeaders["Location"]}";
                // TODO: Check if end or challenge. If challenge, needs authentication from email or authenticator application
                var endOrChallenge = client.DownloadString(loginRequestUrl);
                if (endOrChallenge.Contains("&_eventId=challenge")) {
                    LoginVerification(loginRequestUrl);
                }
                else if (endOrChallenge.Contains("&_eventId=end")) {
                    client.DownloadString(loginRequestUrl + "&_eventId=end");
                }
                else {
                    throw new ApplicationException("Error: Should've have got an end or challenge request.");
                }

                // Finish login
                client.DownloadString(client.ResponseHeaders["Location"]);
                client.DownloadString(client.ResponseHeaders["Location"]);
                client.DownloadString($"https://battlelog.battlefield.com{client.ResponseHeaders["Location"]}");
                var cookies = client.ResponseCookies;
                SessionId = cookies["beaker.session.id"].Value;
            }
            catch (Exception e) {
                Debug.WriteLine($"Error: {e.Message}");
                throw new ApplicationException("Incorrect email or password!");
            }
        }

        private void LoginVerification(string loginRequestUrl) {
            client.DownloadString(loginRequestUrl + "&_eventId=challenge");
            loginRequestUrl = $"https://signin.ea.com{client.ResponseHeaders["Location"]}";
            client.DownloadString(loginRequestUrl); // HTML Page for login verification type input

            string type = Prompt.ShowTypeDialog();

            var reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("_eventId", "submit");
            reqparm.Add("codeType", type); // EMAIL or APP
            client.UploadValues(loginRequestUrl, "POST", reqparm);

            loginRequestUrl = $"https://signin.ea.com{client.ResponseHeaders["Location"]}";
            client.DownloadString(loginRequestUrl); // HTML Page for login verification code input

            string promptValue = Prompt.ShowDialog("Verification code", "Login Verification");

            reqparm = new System.Collections.Specialized.NameValueCollection();
            reqparm.Add("_eventId", "submit");
            reqparm.Add("_trustThisDevice", "on");
            reqparm.Add("oneTimeCode", promptValue); // The code
            reqparm.Add("trustThisDevice", "on");
            client.UploadValues(loginRequestUrl, "POST", reqparm);

            // Save settings for next time
            var cookies = client.ResponseCookies;
            SecondFactoryAuthToken = cookies["_nx_mpcid"].Value;
        }

        public void RetrieveInfo() {
            // Retrieve some info
            var page = client.DownloadString(client.ResponseHeaders["Location"]);
            var source = WebUtility.HtmlDecode(page);
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(source);
            var findclasses = doc.DocumentNode
                            .Descendants("a")
                            .Where(d =>
                               d.Attributes.Contains("class")
                               &&
                               d.Attributes["class"].Value.Contains("persona")
                            ).ToArray();
            var link = findclasses[0].GetAttributeValue("href", "");
            var parts = link.Split('/');
            SoldierName = parts[3];
            PersonaId = parts[5];
        }

        public WarsawFriends GetFriends() {
            try {
                if (client.Headers["X-AjaxNavigation"] == null) {
                    client.Headers.Add("X-AjaxNavigation", "1");
                }
                var result = client.DownloadString($"{API}/bf4/user/{SoldierName}/friends/");
                return (JsonConvert.DeserializeObject<WarsawFriends>(result));
            }
            catch {
                return (null);
            }
        }

        public WarsawOverview GetFriend(string userName) {
            try {
                if (client.Headers["X-AjaxNavigation"] == null) {
                    client.Headers.Add("X-AjaxNavigation", "1");
                }
                var result = client.DownloadString($"{API}/bf4/user/{userName}");
                return (JsonConvert.DeserializeObject<WarsawOverview>(result));
            }
            catch {
                return (null);
            }
        }
    }
}
