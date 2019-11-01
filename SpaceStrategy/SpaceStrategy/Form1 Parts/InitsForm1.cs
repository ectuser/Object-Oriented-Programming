using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceStrategy
{
    public partial class Form1 : Form
    {
        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(TimerTick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }
        private void BuildingsListInit()
        {
            for (int i = 0; i < Registry.buildingTypes.Count(); i++)
            {
                BuildingTypeSelectList.Items.Add(Registry.buildingTypes[i].Type);
            }
        }
        private void ResourceListInit()
        {
            for (int i = 0; i < _prices.Count(); i++)
            {
                Dictionary<string, dynamic> el = _prices[i];
                ResourcesSelectedList.Items.Add(el["type"].Type);
            }
        }
    }
}
