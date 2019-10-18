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

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string planetName = PlanetsInput.Text;
            PlanetsInput.Text = "";
            CreatePlanet(planetName);
            //string text = PlanetsSelectList.GetItemText(PlanetsSelectList.SelectedItem);
            //label1.Text = text;
            //PlanetsSelectList.getSelectedItem();
            //planetsList.Add(planetName);
            //label1.Text += ;
            //PlanetsSelectList.Items.Add(planetName);
        }
        private void CreatePlanet(string name)
        {
            if (planetsList.All(x => x.name != name))
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
        // Update lists
        private void UpdateWindowPlanetsList()
        {
            //PlanetsSelectList.DataSource = null;
            PlanetsSelectList.Items.Clear();
            for (int i = 0; i < planetsList.Count(); i++)
            {
                PlanetsSelectList.Items.Add(planetsList[i].name);
            }

        }
        // Update Lists end

        private void RemovePlanetButton_Click(object sender, EventArgs e)
        {
            string text = PlanetsSelectList.GetItemText(PlanetsSelectList.SelectedItem);
            
            int index = planetsList.FindIndex(i => i.name == text);
            planetsList.RemoveAt(index);
            UpdateWindowPlanetsList();
        }

        private void PlanetsInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ColoniesSelectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = ColoniesSelectList.SelectedItem.ToString();
            string tempPlanetName = PlanetsSelectList.SelectedItem.ToString();
            Planet tempPlanet = DefinePlanetByName(tempPlanetName);
            Colony tempColony = DefineColonyByName(text, tempPlanet.GetColonies());
            if (tempColony.name != "error")
            {
                ShowBuildings(tempColony);
            }
            //Console.WriteLine(text);
        }
        private void ShowBuildings(Colony colony)
        {
            BuildingsSelectList.Items.Clear();
            List<Building> list = colony.GetBuildings();
            for (int i = 0; i < list.Count; i++)
            {
                BuildingsSelectList.Items.Add(list[i].id);
            }
        }
        private Colony DefineColonyByName(string name, List<Colony> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].name == name)
                {
                    return list[i];
                }
            }
            //Console.WriteLine("error");
            ShowStatus("error");
            return new Colony("error");
        }


        private void PlanetsSelectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildingsSelectList.Items.Clear(); // clear buildings list
            string text = PlanetsSelectList.SelectedItem.ToString();
            Planet planet = DefinePlanetByName(text);
            if (planet.name != "error")
            {
                ShowColonies(planet);
            }
            //Console.WriteLine(text);
        }
        private Planet DefinePlanetByName(string name)
        {
            for (int i = 0; i < planetsList.Count; i++)
            {
                if (planetsList[i].name == name)
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
                ColoniesSelectList.Items.Add(list[i].name);
            }
        }
        private void CreateColonyButton_Click(object sender, EventArgs e)
        {
            if (PlanetsSelectList.SelectedIndex == -1)
            {
                //Console.WriteLine("Select at least one planet");
                ShowStatus("Select at least one planet");
            }
            else
            {
                string planetName = PlanetsSelectList.SelectedItem.ToString();
                Planet planet = DefinePlanetByName(planetName);
                string colonyName = ColonyInput.Text;
                ColonyInput.Text = "";
                planet.CreateColony(colonyName);
                UpdateWindowColoniesList(planet);
            }
        }
        private void UpdateWindowColoniesList(Planet planet)
        {
            ColoniesSelectList.Items.Clear();
            List<Colony> tempList = planet.GetColonies();
            for (int i = 0; i < tempList.Count(); i++)
            {
                ColoniesSelectList.Items.Add(tempList[i].name);
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
                Colony tempColony = DefineColonyByName(colonyName, tempPlanet.GetColonies());
                string buildingType = BuildingInput.Text;
                BuildingInput.Text = "";
                tempColony.CreateBuilding(buildingType);
                UpdateWindowBuildingsList(tempColony);
            }
        }
        private void UpdateWindowBuildingsList(Colony colony)
        {
            BuildingsSelectList.Items.Clear();
            List<Building> tempList = colony.GetBuildings();
            for (int i = 0; i < tempList.Count(); i++)
            {
                BuildingsSelectList.Items.Add(tempList[i].id);
            }
        }

        private void BuildingInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
