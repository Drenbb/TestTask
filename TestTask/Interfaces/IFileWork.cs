using System.Threading.Tasks;

namespace TestTask.Interfaces
{
    public interface IFileWork
    {
        public Task WriteFile(string json);
        public Task<string> ReadFile();
        
    }
}