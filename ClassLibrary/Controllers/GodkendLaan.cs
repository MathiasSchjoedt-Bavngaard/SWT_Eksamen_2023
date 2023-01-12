using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Interfaces;


namespace ClassLibrary.Controllers
{
    public class GodkendLaan : IGodkendLaan
    {
        public int Method2(int input)
        {
            Console.WriteLine("MSB made this and input is: " + input);
            Console.WriteLine("Output Should be: " + (input + 2));
            return input + 2;
        }

        public bool Ansoeg(double beloeb, int varighed, double indtaegt, double udgifter)
        {

            throw new NotImplementedException();
        }

        public bool FrigivLaan(int kontonummer)
        {
            throw new NotImplementedException();
        }
    }
}
