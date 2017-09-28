using System;
using System.IO;
using System.Net;
using System.Xml;
using System.Collections.Generic;
using System.Configuration;
using Exchange.Contracts.ShowCase;

namespace Exchange.ClientLib
{
    /// <summary>
    /// This class is to be used by clients of the Data Exchange to perform data exchanges
    /// </summary>
    public class ExchangeData
    {
        /// <summary>
        /// Use to request data from the DES
        /// </summary>
        /// <param name="epsURL"></param>
        /// <returns></returns>
        public static string RequestData(string epsURL)
        {
            return RequestData(epsURL, null, null, null);
        }

        /// <summary>
        /// Use to request data from the DES passing credentials
        /// </summary>
        /// <param name="epsURL"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="friendlyDBName"></param>
        /// <returns></returns>
        public static string RequestData(string epsURL, string userName, string password, string friendlyDBName)
        {
            return RequestData(epsURL, userName, password, friendlyDBName, false);
        }

        /// <summary>
        /// Use to request data from the DES including the cookie in the thread
        /// </summary>
        /// <param name="epsURL"></param>
        /// <param name="includeAuthCookie"></param>
        /// <returns></returns>
        public static string RequestData(string epsURL, bool includeAuthCookie)
        {
            return RequestData(epsURL, null, null, null, includeAuthCookie);
        }
        
        /// <summary>
        /// Use to request data from the DES including the cookie passed
        /// </summary>
        /// <param name="epsURL"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string RequestData(string epsURL, string cookie)
        {
            string response;
            XmlDocument res_xmldoc = new XmlDocument();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(epsURL);
            request.Method = "GET";
            request.Headers.Add("cookie", cookie);
            using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
            {
                using(Stream res_stream = res.GetResponseStream())
                {
                    // Load the response stream into an xml document
                    res_xmldoc.Load(res_stream);
                    response = res_xmldoc.OuterXml;
                }               
            }
            return response;
        }

        private static string RequestData(string epsURL, string userName, string password, string friendlyDBName, bool includeAuthCookie)
        {
            string response;
            XmlDocument res_xmldoc = new XmlDocument();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(epsURL);
            request.Method = "GET";

            if (includeAuthCookie)
            {
                Security.Claims.ClaimsPrincipal c = System.Threading.Thread.CurrentPrincipal as Security.Claims.ClaimsPrincipal;
                if (c != null)
                {
                    request.Headers.Add("cookie", c.AuthenticationCookie);
                }
            }
            else if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(friendlyDBName))
            {
                using(AuthenticationServiceClient authclient = new AuthenticationServiceClient("WSHttpBinding_IAuthenticationService"))
                {
                    Dictionary<string, string> props = new Dictionary<string, string>();

                    props.Add("friendlydbname", friendlyDBName);
                    AuthenticationResponse authresponse = authclient.AuthenticateUser(userName, password, props);
                    if (!authresponse.HasError)
                    {
                        request.Headers.Add("cookie", authresponse.AuthenticationCookie);
                    }
                    else
                    {
                        throw new Exception(authresponse.ErrorMessage);
                    }
                }        
            }

            using (HttpWebResponse res = (HttpWebResponse)request.GetResponse())
            {
                using(Stream res_stream = res.GetResponseStream())
                {
                    // Load the response stream into an xml document
                    res_xmldoc.Load(res_stream);
                    response = res_xmldoc.OuterXml;
                }               
            }
            return response;
        }
       
        /// <summary>
        /// Use to Post data in a XMLDocument to the DES.
        /// </summary>
        /// <param name="epsURL"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string PostData(string epsURL, XmlDocument data)
        {
            return PostData(epsURL, data, null, null, null);
        }

        /// <summary>
        /// Use to Post data in a XMLDocument to the DES.
        /// </summary>
        /// <param name="epsURL"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string PostData(string epsURL, XmlDocument data, string userName, string password, string friendlyDBName)
        {
            return PostData(epsURL, data, userName, password, friendlyDBName, false);
        }

        /// <summary>
        /// Use to Post data in as string to the DES. The data needs to be valid xml.
        /// </summary>
        /// <param name="epsURL"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string PostData(string epsURL, string data)
        {
            return PostData(epsURL, data, null, null, null);
        }

        /// <summary>
        /// Post data in string to the DES including the authentication cookie currently set in the thread
        /// </summary>
        /// <param name="epsURL"></param>
        /// <param name="data"></param>
        /// <param name="passAuthCookie">Authentication Cookie in the thread</param>
        /// <returns></returns>
        public static string PostData(string epsURL, string data, bool includeAuthCookie)
        {
            XmlDocument datax = new XmlDocument();
            datax.LoadXml(data);
            return PostData(epsURL, datax, null, null, null, includeAuthCookie);
        }

        /// <summary>
        ///  Post xml data to the DES including the authentication cookie passed
        /// </summary>
        /// <param name="epsURL"></param>
        /// <param name="data"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public static string PostData(string epsURL, XmlDocument data, string cookie)
        {
            byte[] sentXML;
            byte[] responseData;
            using (WebClient wc = new WebClient())
            {
                wc.Encoding = System.Text.Encoding.UTF8;
                wc.Headers.Add("Content-Type", "application/xml");
                wc.Headers.Add("cookie", cookie);
                sentXML = System.Text.Encoding.UTF8.GetBytes(data.OuterXml);
                responseData = responseData = wc.UploadData(epsURL, "POST", sentXML);
            }
            return System.Text.Encoding.ASCII.GetString(responseData);
        }

        /// <summary>
        /// Use to Post xml data to the DES passing credentials. The data needs to be valid xml.
        /// </summary>
        /// <param name="epsURL"></param>
        /// <param name="data"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="friendlyDBName"></param>
        /// <returns></returns>
        public static string PostData(string epsURL, string data, string userName, string password, string friendlyDBName)
        {
            XmlDocument datax = new XmlDocument();
            datax.LoadXml(data);
            return PostData(epsURL, datax);
        }

        private static string PostData(string epsURL, XmlDocument data, string userName, string password, string friendlyDBName, bool includeAuthCookie)
        {
            string response = "";
            byte[] responseData;

            Uri epsURI = new Uri(epsURL);
            try
            {
                using (WebClient wc = new WebClient())
                {
                    wc.Encoding = System.Text.Encoding.UTF8;
                    wc.Headers.Add("Content-Type", "application/xml");

                    if (includeAuthCookie)
                    {
                        Security.Claims.ClaimsPrincipal c = System.Threading.Thread.CurrentPrincipal as Security.Claims.ClaimsPrincipal;
                        if (c != null)
                        {
                            wc.Headers.Add("cookie", c.AuthenticationCookie);
                        }
                    }
                    else if (!string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password) && !string.IsNullOrEmpty(friendlyDBName))
                    {
                        using(AuthenticationServiceClient authclient = new AuthenticationServiceClient("WSHttpBinding_IAuthenticationService"))
                        {
                            Dictionary<string, string> props = new Dictionary<string, string>();

                            props.Add("friendlydbname", friendlyDBName);
                            AuthenticationResponse authresponse = authclient.AuthenticateUser(userName, password, props);
                            if (!authresponse.HasError)
                            {
                                wc.Headers.Add("cookie", authresponse.AuthenticationCookie);
                            }
                            else
                            {
                                throw new Exception(authresponse.ErrorMessage);
                            }
                        }
                    }

                    byte[] sentXML = System.Text.Encoding.UTF8.GetBytes(data.OuterXml);
                    responseData = wc.UploadData(epsURI, "POST", sentXML);
                }
                response = System.Text.Encoding.ASCII.GetString(responseData);
            }
            catch (Exception ex)
            {
                response += "\r\n" + ex.ToString();
            }

            return response;
        }
    }
}
