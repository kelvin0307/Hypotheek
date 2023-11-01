using HypotheekBerekenaar.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestProject;

namespace HypotheekBerekenaar
{
    public class MainCode
    {
        private ConsoleNameRetriever _nameRetriever;

        public MainCode(ConsoleNameRetriever nameRetriever)
        {
            _nameRetriever = nameRetriever;
        }

        public void start()
        {
            Person person = new Person();


            Console.Write("Your income per month?: ");
            double income = Convert.ToDouble(_nameRetriever.GetNextName());

            Assert.IsNotNull(income);

            person.Income = income;

            bool hasPartner = person.AskForPartner(_nameRetriever);

            if (hasPartner)
            {
                Console.Write("Your partner income per month?: ");
                double parterIncome = Convert.ToDouble(_nameRetriever.GetNextName());

                person.HasPartner = true;
                person.PartnerIncome = parterIncome;
            }
            person.AskForDebt(_nameRetriever);

            Console.Write("What are the 4 numbers of your ZIPcode?: ");

            int ZIPCode = Convert.ToInt32(_nameRetriever.GetNextName());

            bool checkedLength = ZIPCodeChecker.CheckZIPCodeLength(ZIPCode);

            Assert.IsTrue(checkedLength);

            ZIPCodeChecker.CheckZIPCode(ZIPCode);

            Mortgage mortgage = new Mortgage(person);

            mortgage.ShowAndCommitInterestPeriods(_nameRetriever);

            mortgage.CalculateMortgage();

            mortgage.MortageView();

        }
    }
}
