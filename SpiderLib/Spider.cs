using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;

namespace SpiderLib
{
    public class RequestState
    {
        // This class stores the state of the request.
        const int BUFFER_SIZE = 102400;
        public StringBuilder requestData;
        public byte[] bufferRead;
        public WebRequest request;
        public WebResponse response;
        public Stream responseStream;
        public string item;
        public RequestState()
        {
            bufferRead = new byte[BUFFER_SIZE];
            requestData = new StringBuilder("");
            request = null;
            responseStream = null;
            item = string.Empty;
        }
    }

    public class Spider
    {
        public string BaseUrl { get; set; }

        public string SavePath { get; set; }

        List<string> result = new List<string>();

        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public static ManualResetEvent allDone2 = new ManualResetEvent(false);
        const int BUFFER_SIZE = 102400;

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

                    RequestState myRequestState = new RequestState();
                    myRequestState.request = httpWebRequest;
                    IAsyncResult asyncResult = (IAsyncResult)httpWebRequest.BeginGetResponse(new AsyncCallback(RespCallback), myRequestState);
                    allDone.WaitOne();

                    myRequestState.response.Close();

                    foreach (var item in result)
                    {
                        GetPictrueFormNet(item);

                        //SetMessage(resultText.Text + "\r\n" + item);
                    }

                    //WebResponse webresponse = httpWebRequest.GetResponse();
                    //StreamReader sr = new StreamReader(webresponse.GetResponseStream());
                    //List<string> result = ProcessHtml(sr.ReadLine());
                    //foreach (var item in result)
                    //{
                    //    GetPictrueFormNet(item);

                    //    //SetMessage(resultText.Text + "\r\n" + item);
                    //}

                    Thread.Sleep(10000);
                    //MessageBox.Show("Completed!");
                }
            }
            catch (Exception ex)
            {
                //SetMessage(resultText.Text + "\r\n" + ex.Message);
            }

        }

        private void RespCallback(IAsyncResult asynchronousResult)
        {
            // Set the State of request to asynchronous.
            RequestState myRequestState = (RequestState)asynchronousResult.AsyncState;
            WebRequest myWebRequest1 = myRequestState.request;
            // End the Asynchronous response.
            myRequestState.response = myWebRequest1.EndGetResponse(asynchronousResult);
            // Read the response into a 'Stream' object.
            Stream responseStream = myRequestState.response.GetResponseStream();
            myRequestState.responseStream = responseStream;
            // Begin the reading of the contents of the HTML page and print it to the console.
            IAsyncResult asynchronousResultRead = responseStream.BeginRead(myRequestState.bufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
        }

        private void RespCallback2(IAsyncResult asynchronousResult)
        {
            try
            {
                // Set the State of request to asynchronous.
                RequestState myRequestState = (RequestState)asynchronousResult.AsyncState;
                WebRequest myWebRequest1 = myRequestState.request;
                // End the Asynchronous response.
                myRequestState.response = myWebRequest1.EndGetResponse(asynchronousResult);
                // Read the response into a 'Stream' object.
                Stream responseStream = myRequestState.response.GetResponseStream();
                myRequestState.responseStream = responseStream;
                // Begin the reading of the contents of the HTML page and print it to the console.
                IAsyncResult asynchronousResultRead = responseStream.BeginRead(myRequestState.bufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack2), myRequestState);
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void ReadCallBack(IAsyncResult asyncResult)
        {
            try
            {
                // Result state is set to AsyncState.
                RequestState myRequestState = (RequestState)asyncResult.AsyncState;
                Stream responseStream = myRequestState.responseStream;
                int read = responseStream.EndRead(asyncResult);
                // Read the contents of the HTML page and then print to the console.
                if (read > 0)
                {
                    myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.bufferRead, 0, read));
                    IAsyncResult asynchronousResult = responseStream.BeginRead(myRequestState.bufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
                }
                else
                {
                    //Console.WriteLine("\nThe HTML page Contents are:  ");
                    if (myRequestState.requestData.Length > 1)
                    {
                        string sringContent;
                        sringContent = myRequestState.requestData.ToString();

                        result.AddRange(ProcessHtml(sringContent));

                        //Console.WriteLine(sringContent);
                    }
                    //Console.WriteLine("\nPress 'Enter' key to continue........");
                    responseStream.Close();
                    allDone.Set();
                }
            }
            catch (WebException e)
            {
                Console.WriteLine("WebException raised!");
                Console.WriteLine("\n{0}", e.Message);
                Console.WriteLine("\n{0}", e.Status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception raised!");
                Console.WriteLine("Source : {0}", e.Source);
                Console.WriteLine("Message : {0}", e.Message);
            }

        }

        private void ReadCallBack2(IAsyncResult asyncResult)
        {
            try
            {
                // Result state is set to AsyncState.
                RequestState myRequestState = (RequestState)asyncResult.AsyncState;
                Stream responseStream = myRequestState.responseStream;
                int read = responseStream.EndRead(asyncResult);
                if (read > 0)
                {
                    //myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.bufferRead, 0, read));
                    IAsyncResult asynchronousResult = responseStream.BeginRead(myRequestState.bufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
                }
                else
                {
                    Image image = Image.FromStream(responseStream);
                    image.Save(SavePath + "/" + myRequestState.item.Split('/')[myRequestState.item.Split('/').Length - 1]);
                    responseStream.Close();
                    allDone2.Set();
                    Thread.Sleep(1000);
                }
                //int read = responseStream.EndRead(asyncResult);
                //// Read the contents of the HTML page and then print to the console.
                //if (read > 0)
                //{
                //    myRequestState.requestData.Append(Encoding.ASCII.GetString(myRequestState.bufferRead, 0, read));
                //    IAsyncResult asynchronousResult = responseStream.BeginRead(myRequestState.bufferRead, 0, BUFFER_SIZE, new AsyncCallback(ReadCallBack), myRequestState);
                //}
                //else
                //{
                //    Console.WriteLine("\nThe HTML page Contents are:  ");
                //    if (myRequestState.requestData.Length > 1)
                //    {
                //        string sringContent;
                //        sringContent = myRequestState.requestData.ToString();

                //        List<string> result = ProcessHtml(sringContent);

                //        foreach (var item in result)
                //        {
                //            GetPictrueFormNet(item);

                //            //SetMessage(resultText.Text + "\r\n" + item);
                //        }

                //        //Console.WriteLine(sringContent);
                //    }
                //    Console.WriteLine("\nPress 'Enter' key to continue........");
                //    responseStream.Close();
                //    allDone.Set();
                //}
            }
            catch (WebException e)
            {
                Console.WriteLine("WebException raised!");
                Console.WriteLine("\n{0}", e.Message);
                Console.WriteLine("\n{0}", e.Status);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception raised!");
                Console.WriteLine("Source : {0}", e.Source);
                Console.WriteLine("Message : {0}", e.Message);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        private void GetPictrueFormNet(string item)
        {
            try
            {
                HttpWebRequest httpWebRequest = WebRequest.CreateHttp("http:" + item);
                httpWebRequest.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:57.0) Gecko/20100101 Firefox/57.0";
                httpWebRequest.Accept = "*/*";
                httpWebRequest.Referer = "https://www.4chan.org/";
                httpWebRequest.Method = "GET";

                RequestState myRequestState = new RequestState();
                myRequestState.request = httpWebRequest;
                myRequestState.item = item;
                IAsyncResult asyncResult = (IAsyncResult)httpWebRequest.BeginGetResponse(new AsyncCallback(RespCallback2), myRequestState);
                allDone2.WaitOne();

                myRequestState.response.Close();

                //WebResponse webresponse = httpWebRequest.GetResponse();
                //StreamReader sr = new StreamReader(webresponse.GetResponseStream());
                //Image image = Image.FromStream(webresponse.GetResponseStream());
                //image.Save(SavePath + "/" + item.Split('/')[item.Split('/').Length - 1]);
                //Thread.Sleep(1000);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
