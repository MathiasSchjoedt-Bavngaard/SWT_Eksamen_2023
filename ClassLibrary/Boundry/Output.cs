using ClassLibrary.Interfaces;

namespace ClassLibrary.Boundry
{
    public class Output : IOutput
    {
        public void OutputLine(string line)
        {
            System.Console.WriteLine(line);
        }
        
    }
}