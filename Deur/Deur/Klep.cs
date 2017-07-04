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

        /// <summary>
        /// Initialiseren van klep.
        /// </summary>
        /// <param name="pin"></param>
        public Klep(int pin)
        {
            var gpio = GpioController.GetDefault();
            gpKlep = gpio.OpenPin(pin);
            gpKlep.Write(GpioPinValue.High);
            gpKlep.SetDriveMode(GpioPinDriveMode.Output);
        }

        /// <summary>
        /// Klep openen en sluiten (Veranderen waterlevel).
        /// Klep gaat open; wacht 5 seconden; klep sluit.
        /// </summary>
        /// <param name="positie"></param>
        /// <returns></returns>
        public bool KlepOpen(bool positie)
        {
            gpKlep.Write(GpioPinValue.Low);
            Task.Delay(5000).Wait();
            gpKlep.Write(GpioPinValue.High);
            return false;
        }
    }
}
