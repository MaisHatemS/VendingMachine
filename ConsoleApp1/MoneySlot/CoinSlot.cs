using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MoneySlot
{
    public class CoinSlot
    {
        public const double TenCents  = 0.10;
        public const double TwentyCents = 0.20;
        public const double fiftyCents  = 0.50;
        public const double OneDollar = 1;

        public  static double[] AcceptedCoins = new double[] { 0.10, 0.20, 0.50, 1 };
     
        private static double value;

        private CoinSlot(double values)
        {
            value = values;
        }

        public static double getValue()
        {
            return value;
        }

        public static bool isValidInput(double input)
        {
            input = input/100.0;
            if (AcceptedCoins.Contains(input))
                return true;
            else

                return false;
        }
        public static List<double> GetTotalRemaining(double inputtotal)
        {
            List<double> totalRemaining = new List<double>();
            var Remaining = AcceptedCoins.Select(e => e).Where(e => inputtotal >= e).OrderByDescending(e => e).FirstOrDefault();
            totalRemaining.Add(Remaining);
            inputtotal = inputtotal - Remaining;
            if (inputtotal > 0)
                for (int i = AcceptedCoins.Length - 1; i >= 0; i--)
                {

                    if (AcceptedCoins[i] <= inputtotal)
                    {
                        totalRemaining.Add(AcceptedCoins[i]);
                        inputtotal = inputtotal - AcceptedCoins[i];
                        if (inputtotal <= 0)
                            break;
                        if (inputtotal >= AcceptedCoins[i])
                            i++;
                      
                    }

                }

            return totalRemaining;


        }
    }
}
