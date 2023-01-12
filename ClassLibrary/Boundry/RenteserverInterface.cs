using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry;

public class RenteserverInterface : IRenteserverInterface
{
    public double Rente { get; private set; }

    public event EventHandler<NyRenteEventArgs> NyRente;

    public RenteserverInterface()
    {
        Rente = 0.015;
    }

    public void SetRente(double nyRente)
    {
        if (Rente != nyRente)
        {
            Rente = nyRente;
            NyRenteEvent(nyRente);
        }
    }

    private void NyRenteEvent(double nyRente)
    {
        NyRente?.Invoke(this, new NyRenteEventArgs(){ NyRente = nyRente});
    }

}

