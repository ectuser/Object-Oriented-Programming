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
                showStatus("Planet with this name already exists", StatusBar);
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
        private void UpdateWindowColoniesList(Planet planet)
        {
            ColoniesSelectList.Items.Clear();
            List<Colony> tempList = planet.GetColonies(); 
            for (int i = 0; i < tempList.Count(); i++)
            {
                ColoniesSelectList.Items.Add(tempList[i].name);
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
            //string text = ColoniesSelectList.SelectedItem.ToString();
            //Colony colony = DefinePlanetByName(text);
            //if (planet.GetName() != "error")
            //{
            //    ShowColonies(planet);
            //}
            //Console.WriteLine(text);
        }

        private void PlanetsSelectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string text = PlanetsSelectList.SelectedItem.ToString();
            Planet planet = DefinePlanetByName(text);
            if (planet.name != "error")
            {
                ShowColonies(planet);
            }
            //Console.WriteLine(text);
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
            showStatus("error", StatusBar);
            return new Planet("error");
        }

        private void CreateColonyButton_Click(object sender, EventArgs e)
        {
            if (PlanetsSelectList.SelectedIndex == -1)
            {
                //Console.WriteLine("Select at least one planet");
                showStatus("Select at least one planet", StatusBar);
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

        private void RemoveColonyButton_Click(object sender, EventArgs e)
        {
            string planetName = PlanetsSelectList.SelectedItem.ToString();
            string colonyName = ColoniesSelectList.SelectedItem.ToString();
            Planet tempPlanet = DefinePlanetByName(planetName);
            tempPlanet.RemoveColony(colonyName);
            UpdateWindowColoniesList(tempPlanet);
        }
        public static void showStatus(string text, Label StatusBar)
        {
            StatusBar.Text = text;
        }

        private void BuildingsSelectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
