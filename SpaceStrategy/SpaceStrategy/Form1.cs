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
        private List<MarketStorageElement> _prices; // prices for resources
        public static Label _statusBar;

        public Form1()
        {
            InitializeComponent();


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
