using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Deur
{
    class Stoplicht
    {
        GpioPin gpRood;
        GpioPin gpGroen;

        public Stoplicht(int pin1, int pin2)
        {
            Init(pin1, pin2);
        }

        //Initialiseert stoplicht, stoplicht staat standaard uit.
        private void Init(int pin1, int pin2)
        {
            var gpio = GpioController.GetDefault();
            gpGroen = gpio.OpenPin(pin1);
            gpRood = gpio.OpenPin(pin2);
            gpGroen.SetDriveMode(GpioPinDriveMode.Output);
            gpRood.SetDriveMode(GpioPinDriveMode.Output);
            gpGroen.Write(GpioPinValue.High);
            gpRood.Write(GpioPinValue.High);
        }
        public void VeranderKleur(string kleur)
        {
            if (kleur == "groen")
            {
                gpGroen.Write(GpioPinValue.Low);
                gpRood.Write(GpioPinValue.High);
            }
            else {
                gpGroen.Write(GpioPinValue.High);
                gpRood.Write(GpioPinValue.Low);
            }
        }
    }
}
