using Newtonsoft.Json.Linq;
using OrderCopier.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace OrderCopier.Ecommerce.BaseLinker
{
    public class BaseLinkerConnector : IEcommerceConnector
    {
        private ILogger _logger;
        public BaseLinkerConnector(ILogger logger)
        {
            _logger = logger;
        }
        public object GetResponse(string token, string method, string parameters)
        {
            string URLAddress = "https://api.baselinker.com/connector.php";
            string param = $"token={token}&method={method}&parameters={parameters}";
            JObject response = new JObject();
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded; charset=UTF-8";
                    string res = client.UploadString(URLAddress, param);
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
