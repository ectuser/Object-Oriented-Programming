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
        private void ShowBuildings(Colony colony)
        {
            BuildingsSelectList.Items.Clear();
            List<Building> list = colony.GetBuildings();
            for (int i = 0; i < list.Count; i++)
            {
                BuildingsSelectList.Items.Add(list[i].Id);
            }
        }
        private void ShowColonies(Planet planet)
        {
            ColoniesSelectList.Items.Clear();
            List<Colony> list = planet.GetColonies();
            for (int i = 0; i < list.Count; i++)
            {
                ColoniesSelectList.Items.Add(list[i].Name);
            }
        }
        private void ShowMarketStatus()
        {
            MarketPanel.Controls.Clear();
            _prices = _market.GetPriceList();
            int yPosition = 0;
            Label typeColumn = new Label
            {
                Location = new Point(0, 30 * yPosition),
                Text = "Type",
                Height = 30,
                Width = 50
            };
            Label amountColumn = new Label
            {
                Location = new Point(60, 30 * yPosition),
                Text = "Amount",
                Height = 30,
                Width = 50
            };
            //Label buyColumn = new Label
            //{
            //    Location = new Point(120, 30 * yPosition),
            //    Text = "Buy",
            //    Height = 30,
            //    Width = 50
            //};
            Label sellColumn = new Label
            {
                Location = new Point(180, 30 * yPosition),
                Text = "Sell",
                Height = 30,
                Width = 50
            };

            MarketPanel.Controls.Add(typeColumn);
            MarketPanel.Controls.Add(amountColumn);
            //MarketPanel.Controls.Add(buyColumn);
            MarketPanel.Controls.Add(sellColumn);
            yPosition += 1;
            for (int i = 0; i < _prices.Count(); i++)
            {
                int xPosition = 0;
                Dictionary<string, dynamic> el = _prices[i];
                foreach (KeyValuePair<string, dynamic> keyValue in el)
                {
                    Label newLabel = new Label();
                    newLabel.Location = new Point(xPosition * 60, 30 * yPosition);
                    if (keyValue.Key == "type")
                    {
                        newLabel.Text = keyValue.Value.TypeString;
                    }
                    else
                    {
                        newLabel.Text = keyValue.Value.ToString();
                    }
                    newLabel.Height = 30;
                    newLabel.Width = 50;
                    xPosition++;
                    MarketPanel.Controls.Add(newLabel);
                }
                yPosition++;
            }
        }
        public static void ShowStatus(string text)
        {
            _statusBar.Text = text;
        }
        private void ShowPlanetData(Planet planet)
        {
            string data = "";
            string nameData = "Name : " + planet.Name + "\n";
            string radiusData = "Radius : " + planet.Radius + "\n";
            string coordinatesData = "Coordinates : x : " + planet.coordinates.X + ", y : " + planet.coordinates.Y + "\n";
            string coloniesData = "Number of colonies: " + planet.GetColonies().Count() + "\n";
            string resourcesData = "Resource fields on the planet: \n";
            List<HeapResource> list = planet.GetResources();
            for (int i = 0; i < list.Count(); i++)
            {
                resourcesData += list[i].Amount + " of " + list[i].Type.TypeString + "\n";
            }
            data = nameData + radiusData + coordinatesData + coloniesData + resourcesData;
            PlanetInfoData.Text = data;
        }
        private void ShowColoniesData(Colony colony)
        {
            string data = "";
            string nameData = "Name : " + colony.Name + "\n";
            string parentPlanet = "Parent planet : " + colony.ParentPlanet.Name + "\n";
            string moneyData = "Money : " + colony.Money + "\n";
            string buildingsData = "Number of buildings : " + colony.GetBuildings().Count() + "\n";
            string resourcesData = "Resources : \n";
            Dictionary<string, HeapResource> tempList = colony.GetStorage();
            foreach (KeyValuePair<string, HeapResource> keyValue in tempList)
            {
                resourcesData += keyValue.Value.Amount + " of " + keyValue.Key + "\n";
            }
            data = nameData + parentPlanet + moneyData + buildingsData + resourcesData;
            ColonyInfoData.Text = data;
        }
        private void ShowBuildingsData(Building building, Colony colony)
        {
            string data = "";
            string idData = "ID : " + building.Id + "\n";
            string typeData = "Type : " + building.Type + "\n";
            string parentColony = "Parent colony: " + colony.Name + "\n";
            data = idData + typeData + parentColony;
            BuildingInfoData.Text = data;
        }
    }
}
