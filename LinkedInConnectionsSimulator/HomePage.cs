using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinkedInConnectionsSimulator
{
    public partial class HomePage : Form
    {
        Dictionary<int, Informations> Entity;
        Dictionary<int, int> WeightMap;
        private int _key;
        private bool _newperson;
        private string _inputfilename;

        public HomePage(Dictionary<int, Informations> E, int key, bool newperson, string filename)
        {
            InitializeComponent();
            Entity = E;
            _key = key;
            WeightMap = new Dictionary<int, int>();
            _newperson = newperson;
            _inputfilename = filename;
        }

        public void CalcConnectionWeight(int weight, int key, List<string> passed)
        {
            if (weight == 0)
            {
                return;
            }
            foreach (var item in Entity[key].ConnectionId)
            {
                if (Convert.ToInt32(item) != _key)
                {
                    if (!Entity[_key].ConnectionId.Contains(item))
                    {
                        if (WeightMap.ContainsKey(Convert.ToInt32(item)))
                        {
                            WeightMap[Convert.ToInt32(item)] += weight;
                        }
                        else
                        {
                            WeightMap.Add(Convert.ToInt32(item), weight);
                        }
                    }
                    if (!passed.Contains(item))
                    {
                        passed.Add(item);
                        if (Entity[_key].ConnectionId.Contains(item))
                        {
                            CalcConnectionWeight(weight, Convert.ToInt32(item), passed);
                        }
                        else
                        {
                            CalcConnectionWeight(weight - 1, Convert.ToInt32(item), passed);
                        }
                    }
                }
            }
        }

        public void getTwentyConnections()
        {
            if (!_newperson)
            {
                List<string> passed = new List<string>();
                foreach (var item in Entity[_key].ConnectionId)
                {
                    passed.Add(item);
                    CalcConnectionWeight(5, Convert.ToInt32(item), passed);
                }
            }
            else
            {
                foreach (var item in Entity)
                {
                    WeightMap.Add(item.Key, 0);
                }
                WeightMap.Remove(Entity.Last().Key);
            }
            

            foreach (var item in Entity[_key].Specialties)
            {
                foreach (var mapkey in WeightMap.Keys.ToList())
                {
                    if (Entity[Convert.ToInt32(mapkey)].Specialties.Contains(item))
                    {
                        WeightMap[mapkey] += 15;
                    }
                }
            }

            foreach (var mapkey in WeightMap.Keys.ToList())
            {

                if (Entity[Convert.ToInt32(mapkey)].field.Contains(Entity[_key].field))
                {
                    WeightMap[mapkey] += 7;
                }
                if (Entity[Convert.ToInt32(mapkey)].universityLocation.Contains(Entity[_key].universityLocation))
                {
                    WeightMap[mapkey] += 5;
                }
                if (Entity[Convert.ToInt32(mapkey)].dateOfBirth.Contains(Entity[_key].dateOfBirth))
                {
                    WeightMap[mapkey] += 2;
                }
                if (Entity[Convert.ToInt32(mapkey)].workPlace.Contains(Entity[_key].workPlace))
                {
                    WeightMap[mapkey] += 3;
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void HomePage_Load(object sender, EventArgs e)
        {
            getTwentyConnections();

            var SortedMapByValue = (from entry in WeightMap orderby entry.Value descending select entry).Take(20).ToDictionary(x => x.Key, x => x.Value);
            Dictionary<int, string> FindalDic = new Dictionary<int, string>();
            foreach (var item in SortedMapByValue.Keys)
            {
                FindalDic.Add(item, Entity[item].name);
            }
            dataGridView1.DataSource = FindalDic.ToList();
        }

        private void btnFollow_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please choose a person in the list to follow!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int SecondId = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                if (Entity[SecondId].ConnectionId.Contains(_key.ToString()))
                {
                    MessageBox.Show("You have already followed this user!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Entity[SecondId].ConnectionId.Add(_key.ToString());
                    if (Entity[_key].ConnectionId != null)
                    {
                        Entity[_key].ConnectionId.Add(SecondId.ToString());
                    }
                    else
                    {
                        List<string> connection = new List<string>();
                        connection.Add(SecondId.ToString());
                        Entity[_key].ConnectionId = connection;
                    }

                    List<outpoutinfo> jsonoutput = new List<outpoutinfo>();
                    foreach (var item in Entity)
                    {
                        jsonoutput.Add( new outpoutinfo
                        {
                            id = item.Key,
                            name = item.Value.name,
                            dateOfBirth = item.Value.dateOfBirth,
                            universityLocation = item.Value.universityLocation,
                            field = item.Value.field,
                            workPlace = item.Value.workPlace,
                            Specialties = item.Value.Specialties,
                            ConnectionId = item.Value.ConnectionId
                        });
                    }

                    string path = Application.StartupPath.Remove(Application.StartupPath.Length - 38) + $"{_inputfilename}.json";
                    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonoutput, Newtonsoft.Json.Formatting.Indented);
                    File.WriteAllText(path, output);

                    MessageBox.Show($"You are following \"{Entity[SecondId].name}\"", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    HomePage h = new HomePage(Entity, _key, false, _inputfilename);
                    this.Hide();
                    h.Show();
                }  
            }
        }
    }

    public class outpoutinfo : Informations
    {
        public int id { get; set; }
    }
}
