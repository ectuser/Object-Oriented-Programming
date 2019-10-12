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
            private string name;
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
            public string GetName()
            {
                return name;
            }
            public int GetID()
            {
                return ID;
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
            //string text = PlanetsSelectList.GetItemText(PlanetsSelectList.SelectedItem);
            //label1.Text = text;
            //PlanetsSelectList.getSelectedItem();
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

            // need fix
            ListViewItem item1 = new ListViewItem("Something");
            item1.SubItems.Add("SubItem1a");
            item1.SubItems.Add("SubItem1b");
            item1.SubItems.Add("SubItem1c");

            ListViewItem item2 = new ListViewItem("Something2");
            item2.SubItems.Add("SubItem2a");
            item2.SubItems.Add("SubItem2b");
            item2.SubItems.Add("SubItem2c");

            ListViewItem item3 = new ListViewItem("Something3");
            item3.SubItems.Add("SubItem3a");
            item3.SubItems.Add("SubItem3b");
            item3.SubItems.Add("SubItem3c");

            PlanetsSelectList.Items.AddRange(new ListViewItem[] { item1, item2, item3 });
            //for (int i = 0; i < planetsList.Count; i++)
            //{

            //}
        }

        private void RemovePlanetButton_Click(object sender, EventArgs e)
        {

        }

        private void PlanetsInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
