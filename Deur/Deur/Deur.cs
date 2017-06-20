using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
        public void KlepOpen(bool positie)
        {
            klepOpen = positie;
        }
    }
}
