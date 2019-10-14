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
            Planet tempPlanet = new Planet(name);
            planetsList.Add(tempPlanet);
            UpdateWindowList();
        }
        private void UpdateWindowList()
        {
            //PlanetsSelectList.DataSource = null;
            PlanetsSelectList.Items.Clear();
            for (int i = 0; i < planetsList.Count(); i++)
            {
                PlanetsSelectList.Items.Add(planetsList[i].GetName());
            }

        }

        private void RemovePlanetButton_Click(object sender, EventArgs e)
        {
            string text = PlanetsSelectList.GetItemText(PlanetsSelectList.SelectedItem);
            
            int index = planetsList.FindIndex(i => i.GetName() == text);
            label1.Text = index.ToString();
            planetsList.RemoveAt(index);
            UpdateWindowList();
        }

        private void PlanetsInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
