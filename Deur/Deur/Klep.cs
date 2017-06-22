using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using System.Diagnostics;

namespace Deur
{
    class Klep
    {
        private GpioPin gpKlep;
        private bool klepOpen;
        public Klep(int pin)
        {
            var gpio = GpioController.GetDefault();
            gpKlep = gpio.OpenPin(pin);
            gpKlep.Write(GpioPinValue.High);
            gpKlep.SetDriveMode(GpioPinDriveMode.Output);
        }
        public bool KlepOpen(bool positie)
        {
            if (klepOpen == positie)
            {
                Debug.WriteLine("Klep staat al goed");
            }
            else
            {
                if (positie)
                {
                    gpKlep.Write(GpioPinValue.Low);
                }
                else
                {
                    gpKlep.Write(GpioPinValue.High);
                }
                klepOpen = positie;
            }
            return klepOpen;
        }
    }
}
