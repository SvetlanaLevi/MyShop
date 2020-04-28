using System.IO;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MyShop.API
{
    public static class SendRequest
    {
        public static string SendingRequest(string URI)
        {
            WebRequest request = WebRequest.CreateHttp(URI);
            Stream dataStream;
            request.Method = "GET";
            request.ContentType = "application/json";            
            WebResponse response = request.GetResponse();
            string result;
            using (dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
            }
            response.Close();
            return result;
        }
    }
}
