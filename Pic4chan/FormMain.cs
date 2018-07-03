using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Pic4chan
{
    public partial class FormMain : Form
    {
        private string BaseUrl = string.Empty;
        private string SavePath = string.Empty;

        private string SelectProgram = "b/";

        public FormMain()
        {
            InitializeComponent();
        }

        delegate void Callback(string msg);

        private void SetMessage(string msg)
        {
            if (this.InvokeRequired)
            {

                //Callback d = new Callback(spider.GetWebInfo);
                //this.Invoke(d, new object[] { msg });
            }
            else
            {
                this.resultText.Text = msg;
            }
        }



        Thread nt;



        private void OK_Click(object sender, EventArgs e)
        {
            if (OK.Text == "GetThem:)")
            {
                resultText.Text = string.Empty;
                OK.Text = "Getting...";
            }
            else
            {
                nt.Abort();
                OK.Text = "GetThem:)";

            }
            //SpiderLib.Spider spider = new SpiderLib.Spider();
            SpiderLib.synSpider spider = new SpiderLib.synSpider();
            spider.BaseUrl = BaseUrl + SelectProgram;
            spider.SavePath = SavePath + lbSelectItem.Text;

            nt = new Thread(spider.GetWebInfo);
            nt.Start();
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
                case "Food && Cooking":
                    SelectProgram = "ck/";
                    break;
                case "Random":
                    SelectProgram = "b/";
                    break;
                default:
                    SelectProgram = "ck/";
                    break;
            }

            if (SelectProgram == "ck/")
            {
                lbSelectItem.Text = "Food && Cooking";
            }
            else
            {
                lbSelectItem.Text = selectItem.Text;
            }

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            BaseUrl = System.Configuration.ConfigurationManager.AppSettings["url"];
            SavePath = System.Configuration.ConfigurationManager.AppSettings["savePath"];
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
