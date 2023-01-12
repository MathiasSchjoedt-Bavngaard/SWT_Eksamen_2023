using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;
using ClassLibrary.Boundry;
using System.Reflection.Metadata;


namespace ClassLibrary.Controllers
{
    public class GodkendLaan : IGodkendLaan
    {
        public IKontoserverInterface _kontoserver { get; set; }
        public IBeregnYdelser _beregnYdelser { get; set; }
        public IDisplay _display { get; set; }
        public IPrinter _printer { get; set; }


        public GodkendLaan()
        {
            _kontoserver = new KontoserverInterface();
            _beregnYdelser = new BeregnYdelser();
            _display = new Display();
            _printer = new Printer();
        }
        public GodkendLaan(IPrinter printer, IDisplay display, IKontoserverInterface kontoserver, IBeregnYdelser beregnYdelser)
        {
            _kontoserver = kontoserver;
            _beregnYdelser = beregnYdelser;
            _display = display;
            _printer = printer;
        }
        

        public bool Ansoeg(double beloeb, int varighed, double indtaegt, double udgifter)
        {
            double ydelse = _beregnYdelser.BeregnYdelse(beloeb, varighed);
            bool godkendt = (ydelse < BeregnTiProcent(indtaegt, udgifter));
            
            if (!godkendt)
            {
                return YdelseForStor(ydelse);
            }
            else
            { 
                return YdelseOk(beloeb, varighed, ydelse);
            }
        }

        public bool FrigivLaan(double beloeb ,int kontonummer)
        {
            return _kontoserver.BogFoerBeloeb(beloeb, kontonummer);
        }
        

        private double BeregnTiProcent(double indtaegt, double udgifter)
        {
            return (indtaegt - udgifter) * 0.1;

        }

        private bool YdelseForStor(double ydelse)
        {
            _display.VisYdelseForStor(ydelse);
            return false;
        }
        
        private bool YdelseOk(double beloeb, int varighed, double ydelse)
        {
            _display.VisLaanGodkendt(ydelse);
            _printer.UdskrivLaaneDokument(beloeb, varighed, ydelse);
            return true;
        }
    }
}
