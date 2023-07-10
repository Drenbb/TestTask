using System.Collections;
using System.Collections.Generic;

namespace TestTask.Interfaces
{
    public interface IJsonWork
    {
        public string Serialize<T>(List<T> persons);
        public List<T> Deserialize<T>(string json);
    }
}