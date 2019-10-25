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
        private void ColoniesSelectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ColoniesSelectList.SelectedItem != null)
            {
                string text = ColoniesSelectList.SelectedItem.ToString();
                string tempPlanetName = PlanetsSelectList.SelectedItem.ToString();
                Planet tempPlanet = DefinePlanetByName(tempPlanetName);
                Colony tempColony = DefineColonyByName(text, tempPlanet.GetColonies(), tempPlanet);
                if (tempColony.Name != "error")
                {
                    ShowBuildings(tempColony);
                }
                ShowColoniesData(tempColony);
                //Console.WriteLine(text);
            }
        }
        private void PlanetsSelectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildingsSelectList.Items.Clear(); // clear buildings list
            if (PlanetsSelectList.SelectedItem != null)
            {
                string text = PlanetsSelectList.SelectedItem.ToString();
                Planet planet = DefinePlanetByName(text);
                if (planet.Name != "error")
                {
                    ShowColonies(planet);
                }
                ShowPlanetData(planet);
            }
        }
        private void BuildingsSelectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (BuildingsSelectList.SelectedItem != null)
            {
                string text = ColoniesSelectList.SelectedItem.ToString();
                string tempPlanetName = PlanetsSelectList.SelectedItem.ToString();
                Planet tempPlanet = DefinePlanetByName(tempPlanetName);
                Colony tempColony = DefineColonyByName(text, tempPlanet.GetColonies(), tempPlanet);

                string idText = BuildingsSelectList.SelectedItem.ToString();

                if (int.TryParse(idText, out int id))
                {
                    Building tempBuilding = DefineBuildingByID(id, tempColony.GetBuildings(), tempColony);
                    ShowBuildingsData(tempBuilding, tempColony);
                }
            }
        }
    }
}
