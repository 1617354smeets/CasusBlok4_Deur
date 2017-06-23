using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.Devices.Gpio;

namespace Deur
{
    /// <summary>
    /// Door common cathode RGB worden High en Low omgewisseld.
    /// High = aan ; Low = uit;
    /// </summary>
    class Deur
    {
        //variabelen
        private bool deurOpen;
        private GpioPin gpRood;
        private GpioPin gpBlauw;
        private GpioPin gpGroen;

        //Buzzer
        Buzzer buzzer = new Buzzer(23);

        //get
        public bool Status { get { return deurOpen; } }


        public Deur(bool status, int redPIN, int greenPIN, int bluePIN)
        {
            deurOpen = status;
            Init(redPIN, greenPIN, bluePIN);
        }
        private void Init(int redPIN, int bluePIN, int greenPIN)
        {
            var gpio = GpioController.GetDefault();
            gpRood = gpio.OpenPin(redPIN);
            gpBlauw = gpio.OpenPin(bluePIN);
            gpGroen = gpio.OpenPin(greenPIN);
            gpRood.Write(GpioPinValue.High);
            gpRood.SetDriveMode(GpioPinDriveMode.Output);
            gpBlauw.Write(GpioPinValue.Low);
            gpBlauw.SetDriveMode(GpioPinDriveMode.Output);
            gpGroen.Write(GpioPinValue.Low);
            gpGroen.SetDriveMode(GpioPinDriveMode.Output);
        }
        public bool DeurOpen(bool positie)
        {
            if (positie == deurOpen)
            {
                Debug.WriteLine("Deur staat al goed");
            }
            else
            {
                if (positie)
                {
                    Debug.Write("Deur gaat open");
                    gpRood.Write(GpioPinValue.Low);
                    int i = 0;
                    while (i < 20)
                    {
                        gpGroen.Write(GpioPinValue.High);
                        buzzer.Buzz(GpioPinValue.High);
                        Task.Delay(500).Wait();
                        buzzer.Buzz(GpioPinValue.Low);
                        gpGroen.Write(GpioPinValue.Low);
                        Task.Delay(500).Wait();
                        i++;
                    }
                    gpGroen.Write(GpioPinValue.High);
                }
                else
                {
                    Debug.Write("Deur gaat dicht");
                    gpGroen.Write(GpioPinValue.Low);
                    int i = 0;
                    while (i < 20)
                    {
                        gpRood.Write(GpioPinValue.High);
                        Task.Delay(500).Wait();
                        gpRood.Write(GpioPinValue.Low);
                        i++;
                    }
                    gpRood.Write(GpioPinValue.High);
                }
                deurOpen = positie;
            }
            return deurOpen;
        }
    }
}
