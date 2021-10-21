using Newtonsoft.Json.Linq;
using OrderCopier.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace OrderCopier.Ecommerce.BaseLinker
{
    public class BaseLinkerConnector : IEcommerceConnector
    {
        private ILogger _logger;
        public BaseLinkerConnector(ILogger logger)
        {
            _logger = logger;
        }
        public object GetResponse(IEnumerable<KeyValuePair<string,string>> myData)
        {
            string URLAddress = "https://api.baselinker.com/connector.php";
            JObject response = new JObject();
            try
            {
                using (WebClient client = new WebClient())
                {
                    var content = string.Join("&", myData.Select(x => $"{x.Key}={HttpUtility.UrlEncode(x.Value)}").ToArray());

                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=UTF-8";
                    string res = client.UploadString(URLAddress, content);
                    response = JObject.Parse(res);
                }
            }
            catch (WebException wex)
            {
                _logger.Error($"Error while response getting. Reason: {wex.Message}");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error while response getting {ex.Message}");
            }
            

            return response;
        }
    }
}
