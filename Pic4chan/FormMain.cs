using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pic4chan
{
    public partial class FormMain : Form
    {
        private string BaseUrl = string.Empty;

        private string SelectProgram = "ck/";

        public FormMain()
        {
            InitializeComponent();
        }

        delegate void Callback(string msg);

        private void SetMessage(string msg)
        {
            if (this.InvokeRequired)
            {
                Callback d = new Callback(SetMessage);
                this.Invoke(d, new object[] { msg });
            }
            else
            {
                this.resultText.Text = msg;
            }
        }

        private void GetWebInfo(object o)
        {
            string url = o.ToString();
            try
            {

                HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:56.0) Gecko/20100101 Firefox/56.0";
                httpWebRequest.Method = "GET";
                WebResponse webresponse = httpWebRequest.GetResponse();
                StreamReader sr = new StreamReader(webresponse.GetResponseStream());
                List<string> result = ProcessHtml(sr.ReadLine());
                foreach (var item in result)
                {
                    GetPictrueFormNet(item);

                    SetMessage(resultText.Text + "\r\n" + item);
                }

                MessageBox.Show("Completed!");

            }
            catch (Exception ex)
            {
                resultText.Text = ex.Message;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void GetPictrueFormNet(string item)
        {
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp("http:" + item);
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:56.0) Gecko/20100101 Firefox/56.0";
                httpWebRequest.Method = "GET";
                WebResponse webresponse = httpWebRequest.GetResponse();
                //StreamReader sr = new StreamReader(webresponse.GetResponseStream());
                Image image = Image.FromStream(webresponse.GetResponseStream());
                image.Save("C:\\" + item.Split('/')[item.Split('/').Length - 1]);
                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {

                throw ex;
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

        private void OK_Click(object sender, EventArgs e)
        {
            Thread nt = new Thread(GetWebInfo);
            resultText.Text = string.Empty;
            nt.Start(BaseUrl + SelectProgram);
            //GetWebInfo(BaseUrl + SelectProgram);

        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectItem = (sender as ToolStripMenuItem);
            switch (selectItem.Text)
            {
                case "Anime && Manga":
                    SelectProgram = "a/";
                    break;
                case "Video Games":
                    SelectProgram = "v/";
                    break;
                case "Oekaki":
                    SelectProgram = "i/";
                    break;
                case "Travel":
                    SelectProgram = "trv/";
                    break;
                default:
                    SelectProgram = "ck/";
                    break;
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            BaseUrl = System.Configuration.ConfigurationSettings.AppSettings.Get("url");
        }
    }
}
