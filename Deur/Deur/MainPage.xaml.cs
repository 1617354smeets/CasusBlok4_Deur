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
        private void Init()
        {

        }
    }
}
