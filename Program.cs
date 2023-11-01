using HypotheekBerekenaar;
using TestProject;

namespace Hypotheek
{
    public class Program
    {
        static void Main(string[] args)
        {
            MainCode main = new MainCode(new ConsoleNameRetriever());
            main.start();
        }
    }
}