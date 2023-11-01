using System;
using System.Security.Cryptography.X509Certificates;
using TestProject;

namespace HypotheekBerekenaar.Classes
{
    public class Mortgage
    {
        public int? FixedInterestPeriodInYears { get; set; }
        public double? InterestRate { get; set; }
        public double? MaxMortgage { get; set; }
        Person Person { get; set; }
        public Mortgage(Person person)
        {
            Person = person;
        }

        public void ShowAndCommitInterestPeriods(ConsoleNameRetriever test)
        {
            Console.WriteLine("Interest Periods:");
            Console.WriteLine("1. 1 year is 2%");
            Console.WriteLine("2. 5 years is 3%");
            Console.WriteLine("3. 10 years is 3.5%");
            Console.WriteLine("4. 20 years is 4.5%");
            Console.WriteLine("5. 30 years is 5%");

            Console.Write("Enter how many years: ");
            int choice = int.Parse(test.GetNextName());

            switch (choice)
            {
                case 1:
                    FixedInterestPeriodInYears = 1;
                    InterestRate = 2;
                    break;
                case 2:
                    FixedInterestPeriodInYears = 5;
                    InterestRate = 3;
                    break;
                case 3:
                    FixedInterestPeriodInYears = 10;
                    InterestRate = 3.5;
                    break;
                case 4:
                    FixedInterestPeriodInYears = 20;
                    InterestRate = 4.5;
                    break;
                case 5:
                    FixedInterestPeriodInYears = 30;
                    InterestRate = 5;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }
        }

        public void CalculateMortgage()
        {
            double yearIncome = Person.TotalIncome * 12;

            if (Person.HasDebt)
            {
                yearIncome = yearIncome * 0.75;
            }

            double maxMortgage = yearIncome * 4.25;
            
            MaxMortgage = maxMortgage;
        }

        public void MortageView()
        {
            Console.WriteLine("---------------------------");
            Console.WriteLine("Your fixed interest period: " + FixedInterestPeriodInYears + " years - " + InterestRate + "%");

            Console.WriteLine("Your max mortgage: " + MaxMortgage);

            double? monthlyRent = InterestRate / 100 / 12;
            double? monthlyRentInEuro = MaxMortgage * monthlyRent;

            Console.WriteLine("Your monthly rent: €" + monthlyRentInEuro);

            double? totalMonths = FixedInterestPeriodInYears * 12;
            double? monthlyPaymentExcl = MaxMortgage / totalMonths;
            Console.WriteLine("Your monthly payment excl rent: €" + monthlyPaymentExcl);

            double? monthlyPaymentIncl = monthlyPaymentExcl + monthlyRentInEuro;
            Console.WriteLine("Your monthly payment incl rent: €" + monthlyPaymentIncl);

            double? TotalPaymentAfterYears = monthlyPaymentIncl * 12 * FixedInterestPeriodInYears;
            Console.WriteLine("Total payment after " + FixedInterestPeriodInYears + " years: €" + TotalPaymentAfterYears);
            Console.WriteLine("---------------------------");
        }

    }
}
