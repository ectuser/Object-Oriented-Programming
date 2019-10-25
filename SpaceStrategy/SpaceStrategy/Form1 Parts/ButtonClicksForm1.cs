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
        private void PlanetButton_Cick(object sender, EventArgs e)
        {
            string planetName = PlanetsInput.Text;
            PlanetsInput.Text = "";
            CreatePlanet(planetName);
        }
        private void CreateBuildingButton_Click(object sender, EventArgs e)
        {
            if (ColoniesSelectList.SelectedIndex == -1)
            {
                //Console.WriteLine("Select at least one planet");
                ShowStatus("Select at least one planet");
            }
            else
            {
                string planetName = PlanetsSelectList.SelectedItem.ToString();
                Planet tempPlanet = DefinePlanetByName(planetName);
                string colonyName = ColoniesSelectList.SelectedItem.ToString();
                Colony tempColony = DefineColonyByName(colonyName, tempPlanet.GetColonies(), tempPlanet);
                if (BuildingTypeSelectList.SelectedItem != null)
                {
                    string buildingType = BuildingTypeSelectList.SelectedItem.ToString();
                    for (int i = 0; i < buildingTypes.Count(); i++)
                    {
                        if (buildingTypes[i].Type == buildingType)
                        {
                            tempColony.CreateBuilding(buildingTypes[i], tempColony);
                            UpdateWindowBuildingsList(tempColony);
                            break;
                        }
                    }
                }
            }
        }
        private void CreateColonyButton_Click(object sender, EventArgs e)
        {
            if (PlanetsSelectList.SelectedIndex == -1)
            {
                ShowStatus("Select at least one planet");
            }
            else
            {
                string planetName = PlanetsSelectList.SelectedItem.ToString();
                Planet planet = DefinePlanetByName(planetName);
                string colonyName = ColonyInput.Text;
                ColonyInput.Text = "";
                planet.CreateColony(colonyName, planet);
                UpdateWindowColoniesList(planet);
            }
        }
        private void RemoveColonyButton_Click(object sender, EventArgs e)
        {
            string planetName = PlanetsSelectList.SelectedItem.ToString();
            string colonyName = ColoniesSelectList.SelectedItem.ToString();
            Planet tempPlanet = DefinePlanetByName(planetName);
            tempPlanet.RemoveColony(colonyName);
            UpdateWindowColoniesList(tempPlanet);
        }
        private void RemovePlanetButton_Click(object sender, EventArgs e)
        {
            string text = PlanetsSelectList.GetItemText(PlanetsSelectList.SelectedItem);

            int index = planetsList.FindIndex(i => i.Name == text);
            planetsList.RemoveAt(index);
            UpdateWindowPlanetsList();
        }
        private void BuyResourcesButton_Click(object sender, EventArgs e)
        {
            if (ResourcesSelectedList.SelectedItem != null && ResourceAmountInput.Text != "")
            {
                string resourceType = ResourcesSelectedList.SelectedItem.ToString();
                if (PlanetsSelectList.SelectedItem != null)
                {
                    string tempPlanetName = PlanetsSelectList.SelectedItem.ToString();
                    Planet tempPlanet = DefinePlanetByName(tempPlanetName);
                    if (ColoniesSelectList.SelectedItem != null)
                    {
                        string text = ColoniesSelectList.SelectedItem.ToString();
                        Colony tempColony = DefineColonyByName(text, tempPlanet.GetColonies(), tempPlanet);

                        Dictionary<string, dynamic> resource = _market.DefineResourceType(resourceType);
                        string amountText = ResourceAmountInput.Text;
                        ResourceAmountInput.Text = "";
                        if (int.TryParse(amountText, out int amount))
                        {
                            if (tempColony.Money >= resource["buy"] * amount && resource["amount"] >= amount)
                            {
                                int price = resource["buy"] * amount;
                                tempColony.BuyResource(resource, amount, price);
                                resource["amount"] -= amount;
                                _market.SetNewResourceData(resource);
                            }
                        }
                    }
                }
            }
        }

        private void SellResourcesButton_Click(object sender, EventArgs e)
        {
            if (ResourcesSelectedList.SelectedItem != null && ResourceAmountInput.Text != "")
            {
                string resourceType = ResourcesSelectedList.SelectedItem.ToString();
                if (PlanetsSelectList.SelectedItem != null)
                {
                    string tempPlanetName = PlanetsSelectList.SelectedItem.ToString();
                    Planet tempPlanet = DefinePlanetByName(tempPlanetName);
                    if (ColoniesSelectList.SelectedItem != null)
                    {
                        string text = ColoniesSelectList.SelectedItem.ToString();
                        Colony tempColony = DefineColonyByName(text, tempPlanet.GetColonies(), tempPlanet);

                        Dictionary<string, dynamic> resource = _market.DefineResourceType(resourceType);
                        string amountText = ResourceAmountInput.Text;
                        ResourceAmountInput.Text = "";
                        if (int.TryParse(amountText, out int amount))
                        {
                            if (tempColony.GetStorage()[resource["type"].Type].Amount >= amount)
                            {
                                int price = resource["sell"] * amount;
                                tempColony.SellResource(resource, amount, price);
                                resource["amount"] += amount;
                                _market.SetNewResourceData(resource);
                            }
                        }
                    }
                }
            }
        }
        private void RemoveBuildingButton_Click(object sender, EventArgs e)
        {
            string planetName = PlanetsSelectList.SelectedItem.ToString();
            string colonyName = ColoniesSelectList.SelectedItem.ToString();
            if (BuildingsSelectList.SelectedItem != null)
            {
                string idStr = BuildingsSelectList.SelectedItem.ToString();
                Planet tempPlanet = DefinePlanetByName(planetName);
                Colony tempColony = DefineColonyByName(colonyName, tempPlanet.GetColonies(), tempPlanet);
                if (int.TryParse(idStr, out int id))
                {
                    tempColony.RemoveBuilding(id);
                    UpdateWindowBuildingsList(tempColony);
                }
            }

        }
    }
}
