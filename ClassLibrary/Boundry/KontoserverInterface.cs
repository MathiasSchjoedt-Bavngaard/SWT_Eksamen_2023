using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry;

public class KontoserverInterface : IKontoserverInterface
{
    public bool BogFoerBeloeb(double beloeb, int kontoNummer)
    {

        //not Implementet korrekt
        if (beloeb > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
