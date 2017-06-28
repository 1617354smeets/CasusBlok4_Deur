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
            gpKlep.Write(GpioPinValue.Low);
            Task.Delay(5000).Wait();
            gpKlep.Write(GpioPinValue.High);
            return false;
        }
    }
}
