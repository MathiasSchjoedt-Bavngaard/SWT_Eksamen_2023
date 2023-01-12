using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;

namespace ClassLibrary.Controllers
{
    public class BeregnYdelser : IBeregnYdelser
    {
        public double AktuelRente { get; private set; }

        // Her mangler constructor

        // Her mangler en event handler

        // Denne metode er implementeret, men skal testes
        // Den bruger annuitetsformlen
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