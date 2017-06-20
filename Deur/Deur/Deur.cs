using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Deur
{
    class Deur
    {
        bool deurOpen;
        bool klepOpen;

        public Deur(bool status)
        {
            deurOpen = status;
        }
        public void DeurOpen(bool positie)
        {
            deurOpen = positie;
            Debug.Write("Deur gaat open: " + positie);
        }
        public void KlepOpen(bool positie)
        {
            klepOpen = positie;
            Debug.Write("Klep gaat open: " + positie);
        }
    }
}
