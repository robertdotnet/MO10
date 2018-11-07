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
        public List<MotivationModel> models = new List<MotivationModel>();

        public void Add(MotivationModel motivation)
        {
            models.Add(motivation);
        }

        public void Remove(MotivationModel motivation)
        {
            models.Remove(motivation);
        }

        public void UpdateData()
        {
            if (File.Exists(@"./../../Models/Data.json"))
            {
                File.Delete(@"./../../Models/Data.json");
            }
            TextWriter textWriter = new StreamWriter(@"./../../Models/Data.json", true);
            foreach (var motivation in models)
            {
                string output = JsonConvert.SerializeObject(motivation);
                textWriter.Write(output);
            }
            textWriter.Close();
            ShowNewData();
        }

        private void ShowNewData()
        {

        }
    }
}
