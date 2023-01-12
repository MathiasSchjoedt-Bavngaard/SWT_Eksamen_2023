using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Interfaces
{
    public interface IGodkendLaan
    {
        public bool Ansoeg(double beloeb, int varighed, double indtaegt, double udgifter);
        public bool FrigivLaan(double beloeb,int kontonummer);
        public IKontoserverInterface _kontoserver { get; set; }
        public IBeregnYdelser _beregnYdelser { get; set; }
        public IDisplay _display { get; set; }
        public IPrinter _printer { get; set; }
    }
}
