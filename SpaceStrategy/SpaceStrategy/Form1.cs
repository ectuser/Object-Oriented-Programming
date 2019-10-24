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
        // Form and main events
        private List<Planet> planetsList = new List<Planet>();
        private Timer timer1;

        public static List<Resource> resourceTypes;
        public static List<Building> buildingTypes;

        private Market _market = new Market();
        private List<Dictionary<string, dynamic>> _prices;

        public Form1()
        {
            InitializeComponent();
            Resource[] resourceTypesRaw = { new Wood(), new Stone(), new Food()};
            resourceTypes = new List<Resource>(resourceTypesRaw);

            Building[] buildingTypesRaw = { new Sawmill(0, new Colony("example", new Planet("example"))), new Quarry(1, new Colony("example", new Planet("example"))), new Pasture(2, new Colony("example", new Planet("example"))) };
            buildingTypes = new List<Building>(buildingTypesRaw);
            _prices = _market.GetPriceList();
            InitTimer();
            ShowMarketStatus();
            ResourceListInit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button1_Click(object sender, EventArgs e)
        {
            string planetName = PlanetsInput.Text;
            PlanetsInput.Text = "";
            CreatePlanet(planetName);
        }
        private void CreatePlanet(string name)
        {
            if (planetsList.All(x => x.Name != name))
            {
                Planet tempPlanet = new Planet(name);
                planetsList.Add(tempPlanet);
                UpdateWindowPlanetsList();
            }
            else
            {
                //Console.WriteLine("Planet with this name already exists");
                ShowStatus("Planet with this name already exists");
            }
        }
        private void UpdateWindowPlanetsList()
        {
            //PlanetsSelectList.DataSource = null;
            PlanetsSelectList.Items.Clear();
            for (int i = 0; i < planetsList.Count(); i++)
            {
                PlanetsSelectList.Items.Add(planetsList[i].Name);
            }

        }

        private void RemovePlanetButton_Click(object sender, EventArgs e)
        {
            string text = PlanetsSelectList.GetItemText(PlanetsSelectList.SelectedItem);
            
            int index = planetsList.FindIndex(i => i.Name == text);
            planetsList.RemoveAt(index);
            UpdateWindowPlanetsList();
        }
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
        private void ShowBuildings(Colony colony)
        {
            BuildingsSelectList.Items.Clear();
            List<Building> list = colony.GetBuildings();
            for (int i = 0; i < list.Count; i++)
            {
                BuildingsSelectList.Items.Add(list[i].Id);
            }
        }
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
        private Planet DefinePlanetByName(string name)
        {
            for (int i = 0; i < planetsList.Count; i++)
            {
                if (planetsList[i].Name == name)
                {
                    return planetsList[i];
                }
            }
            //Console.WriteLine("error");
            ShowStatus("error");
            return new Planet("error");
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
        private void UpdateWindowColoniesList(Planet planet)
        {
            ColoniesSelectList.Items.Clear();
            List<Colony> tempList = planet.GetColonies();
            for (int i = 0; i < tempList.Count(); i++)
            {
                ColoniesSelectList.Items.Add(tempList[i].Name);
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
        private void ShowStatus(string text)
        {
            StatusBar.Text = text;
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

        private Building DefineBuildingByID(int id, List<Building> list, Colony colony)
        {
            for (int i = 0; i < list.Count(); i++)
            {
                if (list[i].Id == id)
                {
                    return list[i];
                }
            }
            return new Building(0, colony);
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
                string buildingType = BuildingInput.Text;
                for (int i = 0; i < buildingTypes.Count(); i++)
                {
                    if (buildingTypes[i].Type == buildingType)
                    {
                        tempColony.CreateBuilding(buildingTypes[i], tempColony);
                        UpdateWindowBuildingsList(tempColony);
                        BuildingInput.Text = "";
                        break;
                    }
                }
               
                //tempColony.CreateBuilding(buildingType);
                //UpdateWindowBuildingsList(tempColony);
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
                resourcesData += list[i].Amount + " of " + list[i].Type + "\n";
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

        private void RemoveBuildingButton_Click(object sender, EventArgs e)
        {
            // need fix
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

        public void InitTimer()
        {
            timer1 = new Timer();
            timer1.Tick += new EventHandler(TimerTick);
            timer1.Interval = 2000; // in miliseconds
            timer1.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            ResourceExtraction();
            UpdateAllData();
            ColoniesUseFood();
        }

        private void ResourceExtraction()
        {
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
            // need fix
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
            Label buyColumn = new Label
            {
                Location = new Point(120, 30 * yPosition),
                Text = "Buy",
                Height = 30,
                Width = 50
            };
            Label sellColumn = new Label
            {
                Location = new Point(180, 30 * yPosition),
                Text = "Sell",
                Height = 30,
                Width = 50
            };

            MarketPanel.Controls.Add(typeColumn);
            MarketPanel.Controls.Add(amountColumn);
            MarketPanel.Controls.Add(buyColumn);
            MarketPanel.Controls.Add(sellColumn);
            yPosition += 1;
            for (int i = 0; i < _prices.Count(); i++)
            {
                int xPosition = 0;
                Dictionary<string, dynamic> el = _prices[i];
                foreach(KeyValuePair<string, dynamic> keyValue in el)
                {
                    Label newLabel = new Label();
                    newLabel.Location = new Point(xPosition * 60, 30 * yPosition);
                    if (keyValue.Key == "type")
                    {
                        newLabel.Text = keyValue.Value.Type;
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

        private void ResourceListInit()
        {
            for (int i = 0; i < _prices.Count(); i++)
            {
                Dictionary<string, dynamic> el = _prices[i];
                ResourcesSelectedList.Items.Add(el["type"].Type);
            }
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
                        if (int.TryParse(amountText, out int amount))
                        {
                            if (tempColony.Money > resource["buy"] * amount && resource["amount"] > amount)
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
                        if (int.TryParse(amountText, out int amount))
                        {
                            if (tempColony.GetStorage()[resource["type"].Type].Amount > amount)
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



    }
}
