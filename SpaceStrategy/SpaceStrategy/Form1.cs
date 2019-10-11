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
        abstract class GameObject { }
        abstract class PlanetObject { }
        class SpaceCoordinates
        {
            public float x;
            public float y;
        }
        class Planet : GameObject
        {
            private int radius;
            public string name; // need to fix public -> private
            private int ID;
            private SpaceCoordinates coordinates;
            private List<Colony> ColonyList = new List<Colony>();

            public Planet(string name, int ID)
            {
                this.name = name;
                this.ID = ID;
            }

            private void CreateColony(string name)
            {
                Colony tempColony = new Colony(name);
                ColonyList.Add(tempColony);
            }
        }
        class Colony : PlanetObject
        {
            private string name;
            private int money;

            // Constructor
            public Colony(string name)
            {
                this.name = name;
            }
        }


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
            //planetsList.Add(planetName);
            //label1.Text += ;
            //PlanetsSelectList.Items.Add(planetName);
        }
        private void CreatePlanet(string name)
        {
            Planet tempPlanet = new Planet(name, planetsList.Count);
            planetsList.Add(tempPlanet);
            UpdateWindowList();
        }
        private void UpdateWindowList()
        {
            //PlanetsSelectList.DataSource = null;
            PlanetsSelectList.Items.Clear();
            for (int i = 0; i < planetsList.Count; i++)
            {
                PlanetsSelectList.Items.Add(planetsList[i].name); // need to fix name
            }

        }


        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
