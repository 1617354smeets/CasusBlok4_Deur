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
        public Buzzer(int pin)
        {
            var gpio = GpioController.GetDefault();
            gpBuzzer = gpio.OpenPin(pin);
            gpBuzzer.Write(GpioPinValue.High);
            gpBuzzer.SetDriveMode(GpioPinDriveMode.Output);
        }
        public void Buzz(GpioPinValue mode)
        {
            gpBuzzer.Write(mode);
        }
    }
}
