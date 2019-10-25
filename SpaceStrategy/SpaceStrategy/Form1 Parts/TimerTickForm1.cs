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
        private void TimerTick(object sender, EventArgs e)
        {
            ResourceExtraction();
            UpdateAllData();
            ColoniesUseFood();
        }

        private void ResourceExtraction()
        {
            // need fix
            for (int i = 0; i < planetsList.Count(); i++)
            {
                List<Colony> colonyList = planetsList[i].GetColonies();
                for (int j = 0; j < colonyList.Count(); j++)
                {
                    List<Building> buildingList = colonyList[j].GetBuildings();
                    for (int h = 0; h < buildingList.Count(); h++)
                    {
                        buildingList[h].ExtractResources();
                    }
                }
            }
        }

        private void UpdateAllData()
        {
            ShowMarketStatus();
            if (PlanetsSelectList.SelectedItem != null)
            {
                string tempPlanetName = PlanetsSelectList.SelectedItem.ToString();
                Planet tempPlanet = DefinePlanetByName(tempPlanetName);
                ShowPlanetData(tempPlanet);
                if (ColoniesSelectList.SelectedItem != null)
                {
                    string text = ColoniesSelectList.SelectedItem.ToString();
                    Colony tempColony = DefineColonyByName(text, tempPlanet.GetColonies(), tempPlanet);
                    ShowColoniesData(tempColony);
                    if (BuildingsSelectList.SelectedItem != null)
                    {
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
        private void ColoniesUseFood()
        {
            for (int i = 0; i < planetsList.Count(); i++)
            {
                for (int j = 0; j < planetsList[i].GetColonies().Count(); j++)
                {
                    planetsList[i].GetColonies()[j].UseFood();
                }
            }
        }
    }
}
