using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Refactoring
{
    class FileManager
    {
        public static List<T> LoadJsonFile<T>(string fileName)
        {
            var fileText = File.ReadAllText(fileName);

            return JsonConvert.DeserializeObject<List<T>>(fileText);
        }

        public static void SaveJsonFile<T>(string fileName, List<T> list)
        {
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(fileName, json);
        }
    }
}
