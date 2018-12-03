using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MO10
{
    public class MotivationViewModel
    {
        private List<MotivationModel> Models = new List<MotivationModel>();

        public bool isEmptyOrNull()
        {
            if(Models == null)
                return true;
            if(Models.Count == 0)
                return true;
            else
                return false;
        }

        public List<MotivationModel> GetAll()
        {
            return Models;
        }

        public void Add(MotivationModel motivation)
        {
            Models.Add(motivation);
        }

        public void RemoveByAim(string aim)
        {
            foreach(var model in Models)
            {
                if(model.Aim == aim)
                {
                    Models.Remove(model);
                    break;
                }
            }
            UpdateData();
        }

        public void Clear()
        {
            Models.Clear();
        }

        public void UpdateData()
        {
            if(File.Exists(@"./../../Models/Data.json"))
            {
                File.Delete(@"./../../Models/Data.json");
            }

            TextWriter textWriter = new StreamWriter(@"./../../Models/Data.json", true);
            string output = "[\n";
            foreach(var motivation in Models)
            {
                output += JsonConvert.SerializeObject(motivation, Formatting.Indented) + ",\n";
            }
            output = output.Substring(0, output.Length - 2);
            if(Models.Count > 0)
                output += "\n]";
            textWriter.Write(output);
            textWriter.Close();

            FetchCurrentCollection();
        }

        public void FetchCurrentCollection()
        {
            if(Models.Count != 0)
            {
                Clear();
                if(File.Exists(@"./../../Models/Data.json"))
                {
                    string JSONString = File.ReadAllText(@"./../../Models/Data.json");
                    Models = JsonConvert.DeserializeObject<List<MotivationModel>>(JSONString);
                }
            }
            else
            {
                Clear();
                if(File.Exists(@"./../../Models/Data.json"))
                {
                    string JSONString = File.ReadAllText(@"./../../Models/Data.json");
                    if(JSONString != null && JSONString != "")
                    {
                        Models = JsonConvert.DeserializeObject<List<MotivationModel>>(JSONString);
                    }
                }
            }
        }
    }
}
