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
        private Colony DefineColonyByName(string name, List<Colony> list, Planet planet)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Name == name)
                {
                    return list[i];
                }
            }
            ShowStatus("error");
            return new Colony("error", planet);
        }



        private Planet DefinePlanetByName(string name)
        {
            for (int i = 0; i < planetsList.Count; i++)
            {
                if (planetsList[i].Name == name)
                {
                    return planetsList[i];
                }
            }
            Console.WriteLine("You have some problems with planets my dude");
            return new Planet("error");
        }



        private Building DefineBuildingByID(int id, List<Building> list, Colony colony)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].Id == id)
                {
                    return list[i];
                }
            }
            Console.WriteLine("There are issues with your buildings mate");
            return new Building(0, new Colony("Error", new Planet("error")));
        }
    }
}
