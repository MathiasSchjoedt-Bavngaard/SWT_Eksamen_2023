using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IDisplay
    {
        void VisYdelseForStor(double ydelse);
        void VisLaanGodkendt(double ydelse);
        void OpdaterLaaneRente();
    }
}
