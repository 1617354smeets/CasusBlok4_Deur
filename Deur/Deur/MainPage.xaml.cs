using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Deur
{
    /// <summary>
    /// Deurcontroller. De controller classe waarin alles aangestuurd wordt.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //Aanmaken van objecten
        Klep klep = new Klep(24);
        Deur deur = new Deur(false, 21, 20, 16);
        Sensor sensor = new Sensor(26);
        Stoplicht stoplicht1 = new Stoplicht(19, 13);
        Stoplicht stoplicht2 = new Stoplicht(6, 5);
        SocketClient client;
        SocketServer server;

        //Het nummer van de deur
        private int deurnr = 1;

        public MainPage()
        {
            this.InitializeComponent();

            client = new SocketClient("169.254.152.32", 9000, deurnr);
            server = new SocketServer(9000, client);

            Init();

            //Handel de ontvangen data van de server af
            server.OnDataOntvangen += TranslateData;
        }

        /// <summary>
        /// Sturen van gegevens naar simulatie. Bv: Sensor lengte.
        /// </summary>
        private void Init()
        {
            sensor.stuurlengte += stuurlengte;
        }

        /// <summary>
        /// Omzetten van ontvangen data naar acties.
        /// </summary>
        /// <param name="data"></param>
        private void TranslateData(string data)
        {
            string[] datalist = data.Split('|');
            if (data.StartsWith("deur"))
            {
                deur.DeurOpen(Convert.ToBoolean(datalist[1]));
            }
            else if (data.StartsWith("klep"))
            {
                klep.KlepOpen(Convert.ToBoolean(datalist[1]));
            }
            else if (data.StartsWith("stoplicht"))
            {
                if (Convert.ToInt32(datalist[1]) == 1)
                {
                    stoplicht1.VeranderKleur(datalist[2]);
                }
                stoplicht1.VeranderKleur(datalist[2]);
            }
        }
        public void stuurlengte(int lengte)
        {
            Debug.Write("Boot lengte: " + lengte.ToString());
            server.OnDataOntvangen("deur|true");
            //client.Verstuur("sensor|" + lengte);
        }

        /// <summary>
        /// Protocol om deur te sluiten of openen.
        /// </summary>
        /// <param name="positie"></param>
    }
}
