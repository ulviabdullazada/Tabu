using Microsoft.AspNetCore.Components.Web;
using Newtonsoft.Json.Linq;
using Tabu.ExternalServices.Abstracts;

namespace Tabu.ExternalServices.Implements
{
    public class ErrorService(IHttpContextAccessor _http) : IErrorService
    {
        JObject _getFields()
        {
            string lang = _http.HttpContext?.Request.Headers["lang"].ToString();
            if (string.IsNullOrWhiteSpace(lang))
                lang = "az";
            using StreamReader sr = new StreamReader("errors/" + lang + ".json");
            return JObject.Parse(sr.ReadToEnd());
        }
        private string _getMessage(string code)
        {
            return _getFields()[code]!.Value<string>();
        }
        public string GetMessage(string code)
        {
            return _getMessage(code);
        }

        public string GetMessage(string code, params object[] args)
        {
            return String.Format(_getMessage(code), args);
        }

        public string GetField(string fieldName)
        {
            return _getFields()["fields"][fieldName].Value<string>();
        }
    }
}
