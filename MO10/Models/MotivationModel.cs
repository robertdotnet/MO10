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

        public MotivationModel(string aim, double finalValue, string description)
        {
            Aim = aim;
            CurrentValue = 0;
            FinalValue = finalValue;
            Description = description;
        }

        public MotivationModel(string aim, double finalValue)
        {
            Aim = aim;
            CurrentValue = 0;
            FinalValue = finalValue;
            Description = "no description";
        }

        public string Aim { get; set; }
        public double CurrentValue { get; set; }
        public double FinalValue { get; set; }
        public string Description { get; set; }
    }
}
