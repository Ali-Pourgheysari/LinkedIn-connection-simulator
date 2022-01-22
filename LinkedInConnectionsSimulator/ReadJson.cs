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
    class ReadJson
    {
        Dictionary<int, Informations> people = new Dictionary<int, Informations>();

        void readJson()
        {
            string path = Application.StartupPath.Remove(Application.StartupPath.Length - 38) + "users.txt";
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                List<Informations> items = JsonConvert.DeserializeObject<List<Informations>>(json);
            }
            
        }

    }

    public class Informations
    {
        public string name { get; set; }
        public string dateOfBirth { get; set; }
        public string universityLocation { get; set; }
        public string field { get; set; }
        public string workPlace { get; set; }
        public string[] specialties { get; set; }
        public string[] connectionId { get; set; }
    }
}
