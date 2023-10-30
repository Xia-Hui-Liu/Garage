using GarageApp.UI;

namespace GarageApp
{
    //Xiahui
    internal class Program
    {
        static void Main(string[] args)
        {
            var ui = new ConsoleUI();
            var manager = new Manager(ui);
            manager.Run();
        }

    }
}