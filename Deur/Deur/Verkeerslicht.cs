using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;
using System.Diagnostics;

namespace Deur
{
    class Verkeerslicht
    {
        private GpioPin gpGroen;
        private GpioPin gpRood;

        public Verkeerslicht(int pin1, int pin2)
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
            gpRood.Write(GpioPinValue.Low);
        }
        public void VeranderKleur(string kleur)
        {
            Debug.Write("Stoplicht kleur: " + kleur);
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
