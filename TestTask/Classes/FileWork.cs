using System;
using System.IO;
using System.Threading.Tasks;
using TestTask.Interfaces;

namespace TestTask.Classes
{
    public class FileWork : IFileWork
    {
        public async Task WriteFile(string json)
        {
            await File.WriteAllTextAsync(
                Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + "Persons.json", json);
        }

        public async Task<string> ReadFile()
        {
            return await File.ReadAllTextAsync(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" + "Persons.json");
        }
    }
}