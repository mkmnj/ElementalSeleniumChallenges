using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Tests.HelpMethods
{
    public class HTTPMethods
    {
        public HttpStatusCode GetStatusCode(string uri)
        {
            HttpStatusCode statusCode;

            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                statusCode = response.StatusCode;
            }
            
            catch(WebException we)
            {
                statusCode = ((HttpWebResponse)we.Response).StatusCode;
            }

            return statusCode;
        }
    }
}
