using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Gpio;

namespace Deur
{
    class Sensor
    {
        private GpioPin gpSensor;
        public delegate void StuurLengteDelegate(int lengte);
        public StuurLengteDelegate stuurlengte;

        
        public Sensor(int pin)
        {
            Init(pin);
        }

        /// <summary>
        /// Initialiseren sensor.
        /// </summary>
        /// <param name="pin"></param>
        private void Init(int pin)
        {
            var gpio = GpioController.GetDefault();
            gpSensor = gpio.OpenPin(pin);
            gpSensor.SetDriveMode(GpioPinDriveMode.InputPullUp);
            gpSensor.DebounceTimeout = TimeSpan.FromMilliseconds(50);
            gpSensor.ValueChanged += stuurlengte_ValueChanged;
        }
        /// <summary>
        /// Lengte boot meten. (wordt momenteel random gegenereerd.
        /// </summary>
        /// <returns></returns>
        public int MeetLengteBoot()
        {
            Random rand = new Random();
            int lengteboot = rand.Next(5, 90);
            return lengteboot;
        }

        /// <summary>
        /// Delagate om lengte te sturen naar mainpage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stuurlengte_ValueChanged(GpioPin sender, GpioPinValueChangedEventArgs e)
        {
            if (e.Edge == GpioPinEdge.FallingEdge)
            {
                if (stuurlengte != null)
                {
                    //Trigger het event, zodat er iets gedaan wordt met de ontvangen data
                    stuurlengte(MeetLengteBoot());
                }
            }
        }

    }
}
