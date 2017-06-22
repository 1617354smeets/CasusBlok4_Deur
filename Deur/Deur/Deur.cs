using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Windows.Devices.Gpio;

namespace Deur
{
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
            gpBlauw.Write(GpioPinValue.High);
            gpBlauw.SetDriveMode(GpioPinDriveMode.Output);
            gpGroen.Write(GpioPinValue.High);
            gpGroen.SetDriveMode(GpioPinDriveMode.Output);
        }
        public void DeurOpen(bool positie)
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
                    gpRood.Write(GpioPinValue.High);
                    int i = 0;
                    while (i < 20)
                    {
                        gpBlauw.Write(GpioPinValue.Low);
                        buzzer.Buzz(GpioPinValue.Low);
                        Task.Delay(500).Wait();
                        buzzer.Buzz(GpioPinValue.High);
                        gpBlauw.Write(GpioPinValue.High);
                        Task.Delay(500).Wait();
                        i++;
                    }
                    gpBlauw.Write(GpioPinValue.Low);
                }
                else
                {
                    Debug.Write("Deur gaat dicht");
                    gpGroen.Write(GpioPinValue.High);
                    int i = 0;
                    while (i < 20)
                    {
                        gpRood.Write(GpioPinValue.Low);
                        Task.Delay(500).Wait();
                        gpRood.Write(GpioPinValue.High);
                        i++;
                    }
                    gpRood.Write(GpioPinValue.Low);
                }
                deurOpen = positie;
            }
        }
    }
}
