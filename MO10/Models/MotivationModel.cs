using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MO10
{
    public class MotivationModel
    {
        public MotivationModel() { }

        public MotivationModel(string aim, double value, string description)
        {
            Aim = aim;
            Value = value;
            Description = description;
        }

        public MotivationModel(string aim, double value)
        {
            Aim = aim;
            Value = value;
            Description = "no description";
        }

        public string Aim { get; set; }
        public double Value { get; set; }
        public string Description { get; set; }
    }
}
