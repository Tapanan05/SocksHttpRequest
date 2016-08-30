using System;
using System.IO;
using SocksHttpWeb;
using System.Net;
namespace test
{
    class Program
    {
        static string WebMethodSocks(string uri)
        {
            WebRequest req = SocksHttpWebRequest.Create(uri);
            req.Proxy = new WebProxy(new Uri("socks5://192.168.0.231:1080"));
            string res;
            using (WebResponse resp = req.GetResponse())
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                res = sr.ReadToEnd();

            return res;
        }

        static string HttpWebMethodSocks(string uri)
        {
            HttpWebRequest req = (HttpWebRequest)SocksHttpWebRequest.Create(uri);
            req.Proxy = new WebProxy(new Uri("socks5://192.168.0.231:1080"));
            string res;
            using (HttpWebResponse resp = (HttpWebResponse)req.GetResponse())
            using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
                res = sr.ReadToEnd();

            return res;
        }



        static void Main(string[] args)
        {
            Console.WriteLine(WebMethodSocks("http://google.com"));

            Console.WriteLine(HttpWebMethodSocks("http://google.com"));

            Console.ReadKey();
        }
    }
}
