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
        private void UpdateWindowPlanetsList()
        {
            //PlanetsSelectList.DataSource = null;
            PlanetsSelectList.Items.Clear();
            for (int i = 0; i < planetsList.Count(); i++)
            {
                PlanetsSelectList.Items.Add(planetsList[i].Name);
            }

        }
        private void UpdateWindowColoniesList(Planet planet)
        {
            ColoniesSelectList.Items.Clear();
            List<Colony> tempList = planet.GetColonies();
            for (int i = 0; i < tempList.Count(); i++)
            {
                ColoniesSelectList.Items.Add(tempList[i].Name);
            }
        }
        private void UpdateWindowBuildingsList(Colony colony)
        {
            BuildingsSelectList.Items.Clear();
            List<Building> tempList = colony.GetBuildings();
            for (int i = 0; i < tempList.Count(); i++)
            {
                BuildingsSelectList.Items.Add(tempList[i].Id);
            }
        }
    }
}
