using System.Collections.Generic;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using TestTask.Interfaces;

namespace TestTask
{
    public class JsonWork : IJsonWork
    {
        private JsonSerializerOptions options = new JsonSerializerOptions()
        {
             PropertyNamingPolicy =  JsonNamingPolicy.CamelCase,
             WriteIndented = true,
             Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
             
        };
        public string Serialize<T>(List<T> persons)
        {
           return JsonSerializer.Serialize(persons,options);
        }

        public List<T> Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<List<T>>(json,options);
        }
    }
}