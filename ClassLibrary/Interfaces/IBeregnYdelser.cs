namespace ClassLibrary.Interfaces;

public interface IBeregnYdelser
{
    public double BeregnYdelse(double beloeb, int varighed);
    public double AktuelRente { get; }
    
}