using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class Medication
    {
        public int timesPerDay { get; set; }
    public string name { get; set; }
    public List<float> drugTime { get; set; }

        public Medication(string name, int timesPerDay)
        {
            timesPerDay = this.timesPerDay;
            name = this.name;
            for (int i = 0; i < timesPerDay; i++)
            {
                drugTime.Add(24/timesPerDay*i);
            }
        }
    }
