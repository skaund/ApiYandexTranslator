using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;

namespace YandexTranslator
{
    public class YandexTranslate
    {
        string _tokken = "YOUR TOKEN";
        string folder_id = "YOUR FOLDER ID";

        public string GetTranslate(string text)
        {
            var url = "https://translate.api.cloud.yandex.net/translate/v2/translate";


            JObject body = new JObject();

            body["targetLanguageCode"] = "ru";
            body["folder_id"] = folder_id;
            body["texts"] = new JArray(text);

            WebRequest req = WebRequest.Create(url);
            req.Method = "POST";

            req.ContentType = "application/json";

            req.Headers.Add("Authorization", $"Bearer {_tokken}");

            using (var streamWriter = new StreamWriter(req.GetRequestStream()))
            {

                streamWriter.Write(body.ToString());
                streamWriter.Flush();
                streamWriter.Close();
            }

            var httpResponse = (HttpWebResponse)req.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return result;
            }
        }

        internal string GetTranslate()
        {
            throw new System.NotImplementedException();
        }
    }
}
