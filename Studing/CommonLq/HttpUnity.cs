using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CommonLq
{
    public class HttpUnity<T> where T : class, new()
    {
        /// <summary>
        /// 返回字符串
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="timeOut"></param>
        /// <param name="encode"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static string PostRequest(string url, string postData, int timeOut = 30000, string encode = "UTF-8", string contentType = "application/x-www-form-urlencoded")
        {
            var result = "";
            try
            {
                HttpWebRequest mRequest = (HttpWebRequest)WebRequest.Create(url);
                //相应请求的参数
                byte[] data = Encoding.GetEncoding(encode).GetBytes(postData);
                mRequest.Method = "Post";
                mRequest.ContentType = contentType;
                mRequest.ContentLength = data.Length;
                mRequest.Timeout = timeOut;
                Stream requestStream = mRequest.GetRequestStream();//请求流
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
                var mResponse = (HttpWebResponse)mRequest.GetResponse(); //响应流
                var responseStream = mResponse.GetResponseStream();
                if (responseStream != null)
                {
                    var streamReader = new StreamReader(responseStream, Encoding.GetEncoding(encode));//获取返回的信息
                    result = streamReader.ReadToEnd();
                    streamReader.Close();
                    responseStream.Close();
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        /// <summary>
        /// 返回XML
        /// </summary>
        /// <param name="remoteUrl"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        public static XmlDocument PostRequestXml(string remoteUrl, string postData, int timeOut = 30000, string encode = "UTF-8", string contentType = "application/x-www-form-urlencoded")
        {
            if (string.IsNullOrEmpty(postData) || string.IsNullOrEmpty(remoteUrl))
            {
                return null;
            }
            XmlDocument xml = null;
            try
            {
                string result = PostRequest(remoteUrl, postData, timeOut, encode, contentType);
                if (string.IsNullOrEmpty(result)) return null;
                xml = new XmlDocument();
                xml.LoadXml(result);
            }
            catch (Exception ex)
            {

            }
            return xml;
        }
        /// <summary>
        /// 返回实体对象
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="timeOut"></param>
        /// <param name="encode"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static T PostResultT(string url, string postData, int timeOut = 30000, string encode = "UTF-8", string contentType = "application/x-www-form-urlencoded")
        {
            T t = new T();
            try
            {
                string s = PostRequest(url, postData, timeOut, encode, contentType);
                t = JsonConvert.DeserializeObject<T>(s);
            }
            catch (Exception ex)
            {

            }
            return t;
        }
        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="inputCharset"></param>
        /// <returns></returns>
        public static string GetDataFromServer(string url, string inputCharset)
        {
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
            {
                using (Stream resStream = response.GetResponseStream())
                {
                    Encoding encoding = null;

                    if (!string.IsNullOrEmpty(inputCharset))
                    {
                        try
                        {
                            encoding = Encoding.GetEncoding(inputCharset);
                        }
                        catch (Exception ex)
                        {
                            throw;
                        }
                    }

                    StreamReader reader = null;

                    if (encoding != null)
                    {
                        reader = new StreamReader(resStream, encoding);
                    }
                    else
                    {
                        reader = new StreamReader(resStream);
                    }

                    return reader.ReadToEnd();
                }
            }
        }
    }
}
