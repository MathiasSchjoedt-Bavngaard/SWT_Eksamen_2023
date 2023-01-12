namespace ClassLibrary.Interfaces;

public interface IRenteserverInterface
{
    double Rente { get; }
    event EventHandler NyRente;
}