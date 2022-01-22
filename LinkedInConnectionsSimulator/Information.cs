using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedInConnectionsSimulator
{
    public class Informations
    {
        public string name { get; set; }
        public string dateOfBirth { get; set; }
        public string universityLocation { get; set; }
        public string field { get; set; }
        public string workPlace { get; set; }
        public List<string> Specialties { get; set; }
        public List<string> ConnectionId { get; set; }
    }
}
