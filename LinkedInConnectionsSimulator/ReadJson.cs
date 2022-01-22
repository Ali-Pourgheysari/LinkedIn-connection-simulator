using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedInConnectionsSimulator
{
    public static class ReadJson
    {
        static public Dictionary<int, Informations> readJsonfile()
        {
            Dictionary<int, Informations> Entity = new Dictionary<int, Informations>();

            string path = Application.StartupPath.Remove(Application.StartupPath.Length - 38) + "users2.json";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Informations> items = JsonConvert.DeserializeObject<List<Informations>>(json);
                int counter = 1;
                foreach (var item in items)
                {
                    Entity.Add(counter++, item);
                }
            }
            return Entity;
        }
    }
}

