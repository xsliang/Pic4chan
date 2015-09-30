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

        private void GetWebInfo(string url)
        {
            try
            {
                resultText.Text = string.Empty;
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp(url);
                WebResponse webresponse = httpWebRequest.GetResponse();
                StreamReader sr = new StreamReader(webresponse.GetResponseStream());
                List<string> result = ProcessHtml(sr.ReadLine());
                foreach (var item in result)
                {
                    GetPictrueFormNet(item);
                    resultText.Text = resultText.Text + "\r\n" + item;
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
                WebResponse webresponse = httpWebRequest.GetResponse();
                //StreamReader sr = new StreamReader(webresponse.GetResponseStream());
                Image image = Image.FromStream(webresponse.GetResponseStream());
                image.Save("C:\\" + item.Split('/')[item.Split('/').Length - 1]);
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
            GetWebInfo(BaseUrl + SelectProgram);
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem selectItem = (sender as ToolStripMenuItem);
            switch (selectItem.Text)
            {
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
