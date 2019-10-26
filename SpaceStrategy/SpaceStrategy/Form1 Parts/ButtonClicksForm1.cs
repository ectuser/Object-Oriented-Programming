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
            // check that there's selected colony
            if (ColoniesSelectList.SelectedIndex == -1)
            {
                ShowStatus("Select at least one planet");
            }
            else
            {
                // Define some shit like Planets and Colonies to create Building for a particular colony
                string planetName = PlanetsSelectList.SelectedItem.ToString();
                Planet tempPlanet = DefinePlanetByName(planetName);
                string colonyName = ColoniesSelectList.SelectedItem.ToString();
                Colony tempColony = DefineColonyByName(colonyName, tempPlanet.GetColonies(), tempPlanet);
                // Same check as before
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
                else
                {
                    ShowStatus("Select at least 1 type of building");
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
            if (PlanetsSelectList.SelectedItem != null)
            {
                string planetName = PlanetsSelectList.SelectedItem.ToString();
                if (ColoniesSelectList.SelectedItem != null)
                {
                    string colonyName = ColoniesSelectList.SelectedItem.ToString();
                    Planet tempPlanet = DefinePlanetByName(planetName);
                    tempPlanet.RemoveColony(colonyName);
                    UpdateWindowColoniesList(tempPlanet);
                }
                else
                    ShowStatus("Select at least one colony");
            }
            else
                ShowStatus("Select at least one colony");
        }
        private void RemovePlanetButton_Click(object sender, EventArgs e)
        {
            if (PlanetsSelectList.SelectedItem != null)
            {
                string text = PlanetsSelectList.GetItemText(PlanetsSelectList.SelectedItem);

                int index = planetsList.FindIndex(i => i.Name == text);
                planetsList.RemoveAt(index);
                UpdateWindowPlanetsList();
            }
            else
                ShowStatus("Select at least one planet");
        }

        private void BuyResourcesButton_Click(string amountText, Colony tempColony, Dictionary<string, dynamic> resource)
        {
            if (int.TryParse(amountText, out int amount))
            {
                if (tempColony.Money >= resource["sell"] * amount && resource["amount"] >= amount)
                {
                    double before = resource["amount"];
                    double price = resource["sell"] * amount;
                    tempColony.BuyResource(resource, amount, price);
                    resource["amount"] -= amount;
                    double after = resource["amount"];
                    resource["sell"] *= before / after;
                    _market.SetNewResourceData(resource);
                }
            }
        }

        private void SellResourcesButton_Click(string amountText, Colony tempColony, Dictionary<string, dynamic> resource)
        {
            if (int.TryParse(amountText, out int amount))
            {
                if (tempColony.GetStorage()[resource["type"].Type].Amount >= amount)
                {
                    double before = resource["amount"];
                    double price = resource["sell"] * amount;
                    tempColony.SellResource(resource, amount, price);
                    resource["amount"] += amount;
                    double after = resource["amount"];
                    resource["sell"] *= before / after;
                    _market.SetNewResourceData(resource);
                }
            }
                
        }

        private void BuySellButton_Click(object sender, EventArgs e)
        {
            // there should be selected resources and input shouln't be empty
            if (ResourcesSelectedList.SelectedItem != null && ResourceAmountInput.Text != "")
            {
                string resourceType = ResourcesSelectedList.SelectedItem.ToString();
                // Some planet should be selected
                if (PlanetsSelectList.SelectedItem != null)
                {
                    string tempPlanetName = PlanetsSelectList.SelectedItem.ToString();
                    Planet tempPlanet = DefinePlanetByName(tempPlanetName);
                    // Some colony should be selected
                    if (ColoniesSelectList.SelectedItem != null)
                    {
                        string text = ColoniesSelectList.SelectedItem.ToString();
                        Colony tempColony = DefineColonyByName(text, tempPlanet.GetColonies(), tempPlanet);

                        Dictionary<string, dynamic> resource = _market.DefineResourceType(resourceType); // get market prices for resource
                        string amountText = ResourceAmountInput.Text;
                        ResourceAmountInput.Text = "";

                        var btn = (Button)sender;
                        string name = (btn.Name);
                        if (name == "BuyResourcesButton")
                        {
                            BuyResourcesButton_Click(amountText, tempColony, resource);
                        }
                        else if (name == "SellResourcesButton")
                        {
                            SellResourcesButton_Click(amountText, tempColony, resource);
                        }

                    }
                    else
                        ShowStatus("Select at least one colony");
                }
                else
                    ShowStatus("Select at least one planet");
            }
            else
                ShowStatus("Select at least one resource type or type something in input");
        }
        
        private void RemoveBuildingButton_Click(object sender, EventArgs e)
        {
            if (PlanetsSelectList.SelectedItem != null)
            {
                string planetName = PlanetsSelectList.SelectedItem.ToString();
                if (ColoniesSelectList.SelectedItem != null)
                {
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
                    else
                        ShowStatus("Select at least one Building");
                }
                else
                    ShowStatus("Select at leats one Building");
            }
            else
                ShowStatus("Select at leats one Building");
        }
    }
}
