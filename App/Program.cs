// See https://aka.ms/new-console-template for more information
using ClassLibrary.Boundry;
using ClassLibrary.Controllers;
using ClassLibrary.Interfaces;

Console.WriteLine("Hello, World!");

IUserInterface UI = new UserInterface(new GodkendLaan(), new Display());
IRenteserverInterface RS = new RenteserverInterface();
UI._godkendLaan._beregnYdelser = new BeregnYdelser(RS, UI._display);

bool finish = false;
do
{
    string input;
    System.Console.WriteLine("Indtast A, R, F: ");
    input = Console.ReadLine();
    if (string.IsNullOrEmpty(input)) continue;
    
    switch (input[0])
    {
        case 'A':
        {
            System.Console.WriteLine("Indtast beløb: ");
            double beloeb = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Indtast varighed: ");
            int varighed = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine("Indtast indtægt: ");
            double indtaegt = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Indtast udgifter: ");
            double udgifter = Convert.ToDouble(Console.ReadLine());
            UI.Ansoeg(10000, 12, 100000, 50000);
            
            break;
        }

        case 'R':
            System.Console.WriteLine("Intast NyRente");
            RS.SetRente(Convert.ToDouble(Console.ReadLine())); 
            break;

        case 'F':
        {
            System.Console.WriteLine("FrigivBeløb Til Kunde ");
            System.Console.WriteLine("__________________");
            System.Console.WriteLine("Indtast beløb: ");
            double beloeb = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Indtast Kontonummer: ");
            int kontonummer = Convert.ToInt32(Console.ReadLine());
            UI.FrigivLaan(beloeb, kontonummer);
            break;
        }

        case 'E':
            System.Console.WriteLine("Done - Goodbye ");
            finish = true;
            break;

        default:
            break;
    }

} while (!finish);

