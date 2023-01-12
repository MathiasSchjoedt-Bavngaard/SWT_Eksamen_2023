using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry
{
    public class Display : IDisplay
    {
        private IOutput _myOutput;
        public double LaanerRente { get; private set; }

        public Display(IOutput output)
        {
            _myOutput = output;
        }


        public void VisYdelseForStor(double ydelse)
        {
            throw new NotImplementedException();
        }

        public void VisLaanGodkendt(double ydelse)
        {
            throw new NotImplementedException();
        }

        public void OpdaterLaaneRente(double rente)
        {
            LaanerRente = rente;

            throw new NotImplementedException();
        }
    }
}