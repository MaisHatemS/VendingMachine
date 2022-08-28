using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.MoneySlot
{
    public class NotesSlot
    {

        public static double[] AcceptedNotes = new double[] { 20 , 50 };


        public static bool isValidInput(double input)
        {
            if (AcceptedNotes.Contains(input))
                return true;
            else
                return false;
        }
        public static List<string> GetTotalRemaining(double inputtotal)
        {
            List<string> totalRemaining = new List<string>();
            var Remaining = AcceptedNotes.Select(e => e).Where(e => inputtotal >= e).OrderByDescending(e => e).FirstOrDefault();
            totalRemaining.Add(Remaining.ToString());
            inputtotal = inputtotal - Remaining;
            if (inputtotal > 0)
                for (int i = AcceptedNotes.Length - 1; i >= 0; i--)
                {

                    if (AcceptedNotes[i] <= inputtotal)
                    {
                        totalRemaining.Add(AcceptedNotes[i].ToString());
                        inputtotal = inputtotal - AcceptedNotes[i];
                        if (inputtotal <= 0)
                            break;

                    }

                }
            if (inputtotal > 0)
            {
                var raminingCoin = CoinSlot.GetTotalRemaining(inputtotal);
                foreach (var coin in raminingCoin)
                {

                    totalRemaining.Add(coin+" ");
                }
             

            }
            return totalRemaining;


        }
    }

}
