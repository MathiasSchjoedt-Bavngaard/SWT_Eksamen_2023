using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry
{
    public class Display : IDisplay
    {
        private IOutput _myOutput;

        public Display(IOutput output)
        {
            _myOutput = output;
        }

        public Display()
        {
            _myOutput = new Output();
        }


        public void VisYdelseForStor(double ydelse)
        {
            _myOutput.OutputLine($"Ydelsen: {ydelse}  er for stor");
        }

        public void VisLaanGodkendt(double ydelse)
        {
            _myOutput.OutputLine($"Laan Godkendt med Ydelse: {ydelse} ");
        }

        public void OpdaterLaaneRente(double rente)
        {
            _myOutput.OutputLine($"Laan rente er nu: {rente} % ");
        }
    }
}