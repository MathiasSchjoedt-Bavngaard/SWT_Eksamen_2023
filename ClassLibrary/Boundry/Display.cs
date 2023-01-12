using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry
{
    public class Display : IDisplay
    {
        private IOutput myOutput;
        public double LaanerRente { get; private set; }

        public Display(IOutput output)
        {
            myOutput = output;
        }


        public void VisYdelseForStor(double ydelse)
        {
            throw new NotImplementedException();
        }

        public void VisLaanGodkendt(double ydelse)
        {
            throw new NotImplementedException();
        }

        public void OpdaterLaaneRente()
        {
            throw new NotImplementedException();
        }
    }
}