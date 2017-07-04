using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Deur
{
    class Buzzer
    {
        private GpioPin gpBuzzer;

        /// <summary>
        /// Initialiseren van Buzzer.
        /// </summary>
        /// <param name="pin"></param>
        public Buzzer(int pin)
        {
            var gpio = GpioController.GetDefault();
            gpBuzzer = gpio.OpenPin(pin);
            gpBuzzer.Write(GpioPinValue.High);
            gpBuzzer.SetDriveMode(GpioPinDriveMode.Output);
        }
        
        /// <summary>
        /// Buzzer aan of uit zetten.
        /// </summary>
        /// <param name="mode"></param>
        public void Buzz(GpioPinValue mode)
        {
            gpBuzzer.Write(mode);
        }
    }
}
