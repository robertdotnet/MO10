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

        public List<MotivationModel> GetAll()
        {
            return Models;
        }

        public void Add(MotivationModel motivation)
        {
            Models.Add(motivation);
        }

        public void Remove(MotivationModel motivation)
        {
            Models.Remove(motivation);
        }

        public void Clear()
        {
            Models.Clear();
        }

        public void UpdateData()
        {
            if (File.Exists(@"./../../Models/Data.json"))
            {
                File.Delete(@"./../../Models/Data.json");
            }

            TextWriter textWriter = new StreamWriter(@"./../../Models/Data.json", true);
            string output = "[\n";
            foreach (var motivation in Models)
            {
                output += JsonConvert.SerializeObject(motivation, Formatting.Indented) + ",\n";
            }
            output = output.Substring(0, output.Length - 2);
            output += "\n]";
            textWriter.Write(output);
            textWriter.Close();

            FetchCurrentCollection();
        }

        public void FetchCurrentCollection()
        {
            Clear();
            if (File.Exists(@"./../../Models/Data.json"))
            {
                string JSONString = File.ReadAllText(@"./../../Models/Data.json");
                Models = JsonConvert.DeserializeObject<List<MotivationModel>>(JSONString);
            }
        }
    }
}
