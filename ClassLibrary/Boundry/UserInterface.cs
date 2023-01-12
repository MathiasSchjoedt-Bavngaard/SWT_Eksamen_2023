using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry
{

    public class UserInterface : IUserInterface
    {
        public void VisYdelse(double ydelse)
        {
            Console.WriteLine("Ydelsen er: " + ydelse);
        }

    }
}
