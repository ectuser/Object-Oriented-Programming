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

        // I USED ALL THIS STUFF MOSTLY TO GET SELECTED ELEMENT AND SHOW INFO ABOUT IT

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
            }
            else
                ShowStatus("Select at least one Colony");
        }
        private void PlanetsSelectList_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            else
                ShowStatus("Select at least one planet");
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
            else
                ShowStatus("Select at least one Building");
        }
    }
}
