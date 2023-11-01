using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypotheekBerekenaar.Classes
{
    public class ZIPCodeChecker
    {
        public static bool CheckZIPCodeLength(int ZIPCode)
        {
            string ZIPCodeString = ZIPCode.ToString();
            if (ZIPCodeString.Length > 4)
            {
                return false;
            }
            return true;
        }

        public static bool CheckZIPCode(int ZIPCode)
        {
            if (ZIPCode == 9679 ||  ZIPCode == 9681 || ZIPCode == 9682)
            {
                Console.WriteLine("You can't get a mortgage because of your ZIPcode");
                return false;
            }
            return true;
        }
    }
}
