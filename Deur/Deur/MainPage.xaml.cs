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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Deur
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //temp
        string data;

        //Aanmaken van objecten
        Deur deur = new Deur(false);
        Sensor sensor = new Sensor(100);
        Stoplicht stoplicht1 = new Stoplicht(21, 22);
        Stoplicht stoplicht2 = new Stoplicht(16, 17);

        public MainPage()
        {
            this.InitializeComponent();
            Init();
        }

        /// <summary>
        /// Sturen van gegevens naar simulatie. Bv: Sensor lengte.
        /// </summary>
        private void Init()
        {

        }

        private void TranslateData(string data) //Data meegeven
        {
            string[] datalist = data.Split('@');
            if (data.StartsWith("deur"))
            {
                DeurPositie(Convert.ToBoolean(datalist[1]));
            }
            else if (data.StartsWith("klep"))
            {
                deur.KlepOpen(Convert.ToBoolean(datalist[1]));
            }
        }
        private void DeurPositie(bool positie)
        {
            if (positie)
            {
                stoplicht1.VeranderKleur("groen");
                stoplicht2.VeranderKleur("groen");
                deur.DeurOpen(true);
            }
            else
            {
                stoplicht1.VeranderKleur("rood");
                stoplicht2.VeranderKleur("rood");
                deur.DeurOpen(false);
            }
        }
    }
}
