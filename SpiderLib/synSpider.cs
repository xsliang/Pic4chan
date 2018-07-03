using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderLib
{
    /// <summary>
    /// 同步版爬虫
    /// </summary>
    public class synSpider
    {
        public string BaseUrl { get; set; }

        public string SavePath { get; set; }

        public void GetWebInfo()
        {
            string url = BaseUrl;
            try
            {
                while (true)
                {
                    HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
                    httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
                    httpWebRequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
                    httpWebRequest.Method = "GET";

                    WebResponse webresponse = httpWebRequest.GetResponse();
                    StreamReader sr = new StreamReader(webresponse.GetResponseStream());
                    List<string> result = ProcessHtml(sr.ReadLine());
                    foreach (var item in result)
                    {
                        string[] items = item.Split('/');

                        if (File.Exists(SavePath + "/" + items[items.Length - 1]))
                        {
                            continue;
                        }
                        else if (items[items.Length - 1].Contains(".webm"))
                        {
                            continue;
                        }
                        GetPictrueFormNet(item);

                        //SetMessage(resultText.Text + "\r\n" + item);
                    }

                    webresponse.Dispose();
                    httpWebRequest.Abort();

                    Thread.Sleep(10000);
                    //MessageBox.Show("Completed!");
                }
            }
            catch (Exception ex)
            {
                //SetMessage(resultText.Text + "\r\n" + ex.Message);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void GetPictrueFormNet(string item)
        {
            HttpWebRequest httpWebRequest = null;
            WebResponse webresponse = null;
            Image image = null;
            try
            {
                httpWebRequest = WebRequest.CreateHttp("https:" + item);
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Referer = "https://www.4chan.org/";
                httpWebRequest.Method = "GET";

                webresponse = httpWebRequest.GetResponse();
                image = Image.FromStream(webresponse.GetResponseStream());
                image.Save(SavePath + "/" + item.Split('/')[item.Split('/').Length - 1]);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                image.Dispose();
                webresponse.Dispose();
                httpWebRequest.Abort();
                Thread.Sleep(1000);
            }
        }

        private List<string> ProcessHtml(string html)
        {
            List<string> result = new List<string>();

            Regex regex = new Regex(@"<a class=""fileThumb""[^>]+>");
            MatchCollection matchs = regex.Matches(html);
            //result = matchs;
            foreach (var item in matchs)
            {
                Regex regexPicture = new Regex(@"href=""//[^""]+""");
                Match picName = regexPicture.Match(item.ToString());
                string sPicName = picName.Value;
                sPicName = sPicName.Replace("href=\"", string.Empty);
                sPicName = sPicName.Replace("\"", string.Empty);
                result.Add(sPicName.ToString());
            }
            return result;
        }
    }
}
