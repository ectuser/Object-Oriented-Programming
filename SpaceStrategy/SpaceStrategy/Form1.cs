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
        private Market _market = new Market();
        private List<Dictionary<string, dynamic>> _prices; // prices for resources
        public static Label _statusBar;

        public static List<Resource> resourceTypes;
        public static List<Building> buildingTypes;

        public Form1()
        {
            InitializeComponent();

            // Define which types resources and buildings could be
            Resource[] resourceTypesRaw = { new Wood(), new Stone(), new Food()};
            resourceTypes = new List<Resource>(resourceTypesRaw);

            Building[] buildingTypesRaw = { new Sawmill(1, new Colony("example", new Planet("example"))), new Quarry(2, new Colony("example", new Planet("example"))), new Pasture(3, new Colony("example", new Planet("example"))) };
            buildingTypes = new List<Building>(buildingTypesRaw);

            _prices = _market.GetPriceList();
            ShowMarketStatus();

            // Some start inits:
            InitTimer();
            BuildingsListInit();
            ResourceListInit();
            _statusBar = StatusBar; // This thing is used to show status or some errors
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void CreatePlanet(string name)
        {
            // Check that there's no Planet with the same name
            if (planetsList.All(x => x.Name != name))
            {
                Planet tempPlanet = new Planet(name);
                planetsList.Add(tempPlanet);
                UpdateWindowPlanetsList();
            }
            else
            {
                ShowStatus("Planet with this name already exists");
            }
        }
    }
}
