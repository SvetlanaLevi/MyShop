using MyShop.DB.Models;
using Newtonsoft.Json.Linq;

namespace MyShop.API
{
    public static class ValuteRequest
    {
        public static Valute GetValute(string valuteId)
        {
            Valute valute = new Valute { Id = valuteId };
            if (valuteId != "RUB")
            {
                string URI = "https://www.cbr-xml-daily.ru/daily_json.js";
                JObject o = JObject.Parse(SendRequest.SendingRequest(URI));
                valute.Value = (decimal)o.SelectToken($"Valute.{valuteId}.Value");
                valute.Nominal = (int)o.SelectToken($"Valute.{valuteId}.Nominal");
            }
            else
            {
                valute.Value = 1;
                valute.Nominal = 1;
            }
            return valute;
        }
    }
}
