using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry
{

    public class UserInterface : IUserInterface
    {
        public IGodkendLaan _godkendLaan { get; set; }
        public IDisplay _display { get; set; }
        
        public UserInterface(IGodkendLaan godkendLaan, IDisplay display)
        {
            _godkendLaan = godkendLaan;
            _display = display;

        }
        
        
        public bool Ansoeg(double beloeb, int varighed, double indtaegt, double udgifter)
        {
            return _godkendLaan.Ansoeg(beloeb, varighed, indtaegt, udgifter);
        }

        public bool FrigivLaan(double beloeb, int kontonummer)
        {
            return _godkendLaan.FrigivLaan(beloeb, kontonummer);
        }
    }
}
