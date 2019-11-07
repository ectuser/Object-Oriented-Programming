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
            // check that there's selected colony or planet
            if (ColoniesSelectList.SelectedIndex == -1 || PlanetsSelectList.SelectedItem == null)
            {
                ShowStatus("Excuse me. Select at least one fucking planet or colony. Thank you.");
                return;
            }
            string planetName = PlanetsSelectList.SelectedItem.ToString();
            Planet tempPlanet = DefinePlanetByName(planetName);
            string colonyName = ColoniesSelectList.SelectedItem.ToString();
            Colony tempColony = DefineColonyByName(colonyName, tempPlanet.GetColonies(), tempPlanet);
            // Same check as before
            if (BuildingTypeSelectList.SelectedItem == null)
            {
                ShowStatus("Excuse me. Select at least one fucking building type. OK? Thank you.");
                return;
            }
            string buildingType = BuildingTypeSelectList.SelectedItem.ToString();
            for (int i = 0; i < buildingTypes.Count(); i++)
            {
                if (buildingTypes[i].Type == buildingType)
                {
                    // check that colony is able to create new building
                    if ( !(tempColony.AreThereEnoughResources(buildingToBuild: buildingTypes[i])))
                    {
                        ShowStatus("Ha Ha. You're too poor to create this building or don't have enough resources.");
                        return;
                    }
                    tempColony.CreateBuilding(buildingTypes[i], tempColony);
                    UpdateWindowBuildingsList(tempColony);
                    break;
                }
            }
        }

        private void CreateColonyButton_Click(object sender, EventArgs e)
        {
            if (PlanetsSelectList.SelectedIndex == -1)
            {
                ShowStatus("Excuse me. Select at least one fucking planet or colony. Thank you.");
                return;
            }
            string planetName = PlanetsSelectList.SelectedItem.ToString();
            Planet planet = DefinePlanetByName(planetName);
            string colonyName = ColonyInput.Text;
            ColonyInput.Text = "";
            planet.CreateColony(colonyName);
            UpdateWindowColoniesList(planet);
        }

        private void RemoveColonyButton_Click(object sender, EventArgs e)
        {
            if (PlanetsSelectList.SelectedIndex == -1 || ColoniesSelectList.SelectedItem == null)
            {
                ShowStatus("Excuse me. Select at least one fucking planet or colony. Thank you.");
                return;
            }
            string planetName = PlanetsSelectList.SelectedItem.ToString();
            string colonyName = ColoniesSelectList.SelectedItem.ToString();
            Planet tempPlanet = DefinePlanetByName(planetName);
            tempPlanet.RemoveColony(colonyName);
            UpdateWindowColoniesList(tempPlanet);
        }

        private void RemovePlanetButton_Click(object sender, EventArgs e)
        {
            if (PlanetsSelectList.SelectedItem == null)
            {
                ShowStatus("Excuse me. Select at least one fucking planet or colony. Thank you.");
                return;
            }
            string text = PlanetsSelectList.GetItemText(PlanetsSelectList.SelectedItem);
            var planetToRemove = planetsList.Single(i => i.Name == text);
            planetsList.Remove(planetToRemove);
            UpdateWindowPlanetsList();
        }

        private void BuyResourcesButton_Click(int amount, Colony tempColony, MarketStorageElement resource)
        {
            if (tempColony.Money < resource.Buy * amount || resource.Amount < amount)
            {
                ShowStatus("Excuse me there are no damn resources or you're just poor fuck. Good luck!");
                return;
            }
            double price = resource.Buy * amount;
            tempColony.BuyResource(resource, amount, price);
            resource.Amount -= amount;
            _market.SetNewResourceData(resource);
        }

        private void SellResourcesButton_Click(int amount, Colony tempColony, MarketStorageElement resource)
        {
            List<ResourceInt> storage = tempColony.GetStorage();
            for (int i = 0; i < storage.Count(); i++)
            {
                if (storage[i].Type.TypeString == resource.ResType.TypeString)
                {
                    if (storage[i].Number < amount)
                    {
                        Console.WriteLine(storage[i].Number + " " + resource.Amount);
                        ShowStatus("Excuse me this f*cking colony doesn't have enough resources to sell them");
                        return;
                    }
                }
            }
            //double before = resource["amount"];
            double price = resource.Sell * amount;
            tempColony.SellResource(resource, amount, price);
            resource.Amount += amount;
            //double after = resource["amount"];
            //resource["sell"] *= before / after;
            _market.SetNewResourceData(resource);
        }

        private void BuySellButton_Click(object sender, EventArgs e)
        {
            // there should be selected resources and input shouln't be empty
            if (ResourcesSelectedList.SelectedItem == null || ResourceAmountInput.Text == "")
            {
                ShowStatus("You didn't select any fucking resource or didn't type any text.");
                return;
            }
            string resourceType = ResourcesSelectedList.SelectedItem.ToString();
            // Some planet should be selected
            if (PlanetsSelectList.SelectedItem == null || ColoniesSelectList.SelectedItem == null)
            {
                ShowStatus("Excuse me. Select at least one fucking planet or colony. Thank you.");
                return;
            }
            string tempPlanetName = PlanetsSelectList.SelectedItem.ToString();
            Planet tempPlanet = DefinePlanetByName(tempPlanetName);
            string text = ColoniesSelectList.SelectedItem.ToString();
            Colony tempColony = DefineColonyByName(text, tempPlanet.GetColonies(), tempPlanet);

            MarketStorageElement resource = _market.DefineResourceType(resourceType); // get market prices for resource
            string amountText = ResourceAmountInput.Text;
            ResourceAmountInput.Text = "";
            if (int.TryParse(amountText, out int amount))
            {
                if (amount < 0)
                {
                    ShowStatus("Excuse me your you typed some shit with minus. Please try again.");
                    return;
                }
                var btn = (Button)sender;
                string name = (btn.Name);
                if (name == "BuyResourcesButton")
                {
                    BuyResourcesButton_Click(amount, tempColony, resource);
                }
                else if (name == "SellResourcesButton")
                {
                    SellResourcesButton_Click(amount, tempColony, resource);
                }
            }
            else
                ShowStatus("Excuse me you typed some shit. Not a number");
        }

        
        private void RemoveBuildingButton_Click(object sender, EventArgs e)
        {
            if (PlanetsSelectList.SelectedItem == null || ColoniesSelectList.SelectedItem == null || BuildingsSelectList.SelectedItem == null)
            {
                ShowStatus("Select some shit from other windows please.");
                return;
            }
            string planetName = PlanetsSelectList.SelectedItem.ToString();
            string colonyName = ColoniesSelectList.SelectedItem.ToString();
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
