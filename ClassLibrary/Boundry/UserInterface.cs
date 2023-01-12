using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry
{

    public class UserInterface : IUserInterface
    {
        IGodkendLaan _godkendLaan;
        IDisplay _display;
        UserInterface()
        {
            _godkendLaan = new ClassLibrary.Controllers.GodkendLaan();
            _display = new Display();
            
        }
        
        
        public void Ansoeg(double beloeb, int varighed, double indtaegt, double udgifter)
        {
            _godkendLaan.Ansoeg( beloeb,  varighed,  indtaegt,  udgifter);
        }
    }
}
