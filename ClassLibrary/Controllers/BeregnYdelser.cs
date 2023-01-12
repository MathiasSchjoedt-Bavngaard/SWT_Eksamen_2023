using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Boundry;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Controllers
{
    public class BeregnYdelser : IBeregnYdelser
    {
        public double AktuelRente { get; private set; }

        private IRenteserverInterface _renteserver;
        private IDisplay _display;

        public BeregnYdelser()
        {
            _renteserver = new RenteserverInterface();
            _renteserver.NyRente += new EventHandler(RenteSkiftet);
            _display = new Display();
            AktuelRente = 0.05;
        }
        public BeregnYdelser(IRenteserverInterface renteserver)
        {
            _renteserver = renteserver;
            _renteserver.NyRente += new EventHandler(RenteSkiftet);
            _display = new Display();
            AktuelRente = 0.05;
        }
        public BeregnYdelser(IRenteserverInterface renteserver, IDisplay display)
        {
            _renteserver = renteserver;
            _renteserver.NyRente += new EventHandler(RenteSkiftet);
            _display = display;
            AktuelRente = 0.05;
        }
        public BeregnYdelser(IDisplay display)
        {
            _renteserver = new RenteserverInterface();
            _renteserver.NyRente += new EventHandler(RenteSkiftet);
            _display = display;
            AktuelRente = 0.05;
        }

        private void RenteSkiftet(object? sender, EventArgs e)
        {
            AktuelRente = _renteserver.Rente;
            OpdaterRenteDisplayed();
        }

        private void OpdaterRenteDisplayed()
        {
            _display.OpdaterLaaneRente(AktuelRente);
        }
        

        public double BeregnYdelse(double beloeb, int varighed)
    {
        double ydelse = double.MaxValue;

        if (varighed >= 1 && varighed <= 120)
        {
            if (AktuelRente == 0)
            {
                ydelse = beloeb / varighed;
            }
            else
            {
                ydelse = beloeb * AktuelRente / (1 - Math.Pow(1 + AktuelRente, -varighed));
            }
        }

        return ydelse;
    }
    }
}