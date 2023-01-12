using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry;

public class RenteserverInterface : IRenteserverInterface
{
    public double Rente { get; private set; }

    public event EventHandler NyRente;
    
}