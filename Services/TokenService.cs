using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace hrhdashboard.Services
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string refresh_token { get; set; }
        public string scope { get; set; }
    }
    public class Utils
    {
        public string GetToken()
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://41.89.93.183:8080/o/token/");

            string passw = "grant_type=password&username=10004&password=public&client_id=zzAmdUPF6MLcbLdbSkdv1MkRgYD9vuG8B8Bv4lIq&client_secret=JdxZDwF1NlLxxDyTkRIUT6az2YQ1olm4wN8y856CkpntiiRP2XqLPueDpUR3OZvPDxdiyZ4P2lNajoJLdGpS8ZmwGYNOx65qK3jXCndjbbfBZF8Uu0eDTOB4adkJQCnr";
            byte[] bytes = new ASCIIEncoding().GetBytes(passw);
            httpWebRequest.Method = "POST";
            httpWebRequest.ContentType = "application/x-www-form-urlencoded";
            httpWebRequest.ContentLength = (long)bytes.Length;
            using (Stream requestStream = httpWebRequest.GetRequestStream())
                requestStream.Write(bytes, 0, bytes.Length);
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            string res = new StreamReader(httpWebResponse.GetResponseStream()).ReadToEnd();

            Token token = (Token)JsonConvert.DeserializeObject<Token>(res);

            return token.access_token;// rootObject.access_token;
        }
        private RestClient RestCliente = new RestClient("http://41.89.93.183:8080/api/");

        private CookieContainer SessionCookie = new CookieContainer();

        private void ServiceSession() // once per session only
        {
            RestRequest login = new RestRequest("/accounts/login/", Method.POST); // path to your login on rest-framework
            RestCliente.Authenticator = new HttpBasicAuthenticator("10004", "public");


            IRestResponse loginresponse = RestCliente.Execute(login);

            if (loginresponse.StatusCode == HttpStatusCode.OK)
            {
                var cookie = loginresponse.Cookies.FirstOrDefault();
                SessionCookie.Add(new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain));

            }

            RestCliente.CookieContainer = SessionCookie;


        }
        private void InfoRequest()
        {
            RestRequest infoneeded = new RestRequest("http://41.89.93.183:8080/api/gis/drilldown/county/8?format=json", Method.GET);

            IRestResponse response = RestCliente.Execute(infoneeded);

            Console.WriteLine(response.Content);
        }
        public string getCounty()
        {
            ServiceSession();
            InfoRequest();

            return "";
        }
    }
}
