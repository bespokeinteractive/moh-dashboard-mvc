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
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://api.kmhfltest.health.go.ke/o/token/");

            string passw = "grant_type=password&username=10004&password=public&client_id=xMddOofHI0jOKboVxdoKAXWKpkEQAP0TuloGpfj5&client_secret=PHrUzCRFm9558DGa6Fh1hEvSCh3C9Lijfq8sbCMZhZqmANYV5ZP04mUXGJdsrZLXuZG4VCmvjShdKHwU6IRmPQld5LDzvJoguEP8AAXGJhrqfLnmtFXU3x2FO1nWLxUx";
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
        private RestClient RestCliente = new RestClient("http://api.kmhfltest.health.go.ke");

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
            RestRequest infoneeded = new RestRequest("http://api.kmhfltest.health.go.ke/api/gis/drilldown/county/8?format=json", Method.GET);

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
