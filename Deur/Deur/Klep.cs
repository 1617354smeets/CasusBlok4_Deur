using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Deur
{
    class Klep
    {
        private GpioPin gpKlep;
        public Klep(int pin)
        {
            var gpio = GpioController.GetDefault();
            gpKlep = gpio.OpenPin(pin);
            gpKlep.Write(GpioPinValue.High);
            gpKlep.SetDriveMode(GpioPinDriveMode.Output);
        }
        public void KlepOpen(bool positie)
        {
            if (positie)
            {
                gpKlep.Write(GpioPinValue.Low);
            }
            else
            {
                gpKlep.Write(GpioPinValue.Low);
            }
        }
    }
}
