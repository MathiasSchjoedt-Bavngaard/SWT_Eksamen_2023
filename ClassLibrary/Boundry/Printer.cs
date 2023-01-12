using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry;

public class Printer : IPrinter
{
    public IOutput output { get; set; }
    public Printer()
    {
        output = new Output();
    }

    public void UdskrivLaaneDokument(double beloeb, int varighed, double ydelse)
    {
        
        output.OutputLine($"Laan Dokument");
        output.OutputLine($"Beloeb: {beloeb}");
        output.OutputLine($"Varighed: {varighed}");
        output.OutputLine($"Ydelse: {ydelse}");
    }
    
}