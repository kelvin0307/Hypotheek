using TestProject;

namespace HypotheekBerekenaar.Classes
{
    public class Person
    {
        public double Income { get; set; }
        public bool HasPartner { get; set; } = false;
        public double? PartnerIncome { get; set; }
        public double TotalIncome => Income + (HasPartner ? PartnerIncome ?? 0 : 0);
        public bool HasDebt { get; set; }
        public int ZIPCode { get; set; }


        public bool AskForPartner(ConsoleNameRetriever test)
        {
            while (true)
            {
                Console.WriteLine("Do you have a partner?");
                Console.WriteLine("No");
                Console.WriteLine("Yes");
                string userInput = test.GetNextName().ToLower();

                if (userInput == "yes")
                {
                    this.HasPartner = true;
                    return true;
                }
                else if (userInput == "no")
                {
                    this.HasPartner = false;
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid answer, try again");
                }
            }
        }

        public bool AskForDebt(ConsoleNameRetriever test)
        {
            while (true)
            {
                Console.WriteLine("Do you have debt?");
                Console.WriteLine("No");
                Console.WriteLine("Yes");
                string userInput = test.GetNextName().ToLower();

                if (userInput == "yes")
                {
                    this.HasDebt = true;
                    return true;
                }
                else if (userInput == "no")
                {
                    this.HasDebt = false;
                    return false;
                }
                else
                {
                    Console.WriteLine("Invalid answer, try again");
                }
            }
        }

    }

}
