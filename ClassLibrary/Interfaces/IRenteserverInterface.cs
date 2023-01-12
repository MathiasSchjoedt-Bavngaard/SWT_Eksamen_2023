namespace ClassLibrary.Interfaces;

public interface IRenteserverInterface
{
    double Rente { get; }
    event EventHandler<NyRenteEventArgs> NyRente;
}

public class NyRenteEventArgs : EventArgs
{
    public double NyRente { get; init; }
}