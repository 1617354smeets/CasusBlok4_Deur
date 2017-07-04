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

        /// <summary>
        /// Initialiseren van verkeerslicht.
        /// </summary>
        /// <param name="pin1"></param>
        /// <param name="pin2"></param>
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
        /// <summary>
        /// Veranderen van kleur stoplicht. (rood/groen)
        /// </summary>
        /// <param name="kleur"></param>
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
