using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deur
{
    class Sensor
    {
        int sensorLengte;

        public Sensor(int lengte)
        {
            sensorLengte = lengte;
        }
        public bool MeetLengteBoot()
        {
            return true;
        }
    }
}
