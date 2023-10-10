
namespace GarageApp.UI
{
    public class ConsoleUI : IUI
    {
        public void Print(string message)
        {
            Console.WriteLine(message);
        }

        public string GetString()
        {
            return Console.ReadLine()!;
        }

        public int GetInt()
        {
            return 1;
        }

    }
}
