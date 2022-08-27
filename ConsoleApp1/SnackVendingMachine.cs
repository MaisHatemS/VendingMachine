using MySqlX.XDevAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SnackVendingMachine:ISnackVendingMachine
    {
        public IPayment payment;

       

        public SnackVendingMachine(IPayment payments)
        {
            this.payment = payments;

        }
     
        public  void DisplayMenu()
        {


            while (true)
            {

                Console.WriteLine(" *****  HELLO  *******");
                Console.WriteLine();
                Console.WriteLine("            MAIN MENU");
                Console.WriteLine("PRESS 1 TO DISPLAY SNACKS AVAILABLE");
                Console.WriteLine("PRESS 2 TO QUIT");
                Console.WriteLine();
                Console.WriteLine("*************************");

                String inputOption = Console.ReadLine();

                switch (inputOption)
                {
                    case "1":
                        Console.WriteLine("AVAILABLE SNACKS: ");
                        DisplaySnacks(SnacksData.SnacksList);
                        break;
                    case "2":
                        Console.WriteLine("**************************************");
                        Console.WriteLine("THANK YOU! HAVE A NICE DAY!");
                        break;
                    default:
                        Console.WriteLine("INVALID OPTION :( TRY AGAIN");
                        Console.WriteLine("*****************************");
                        break;

                }
            }
        }

        public  void DisplaySnacks(IList<Snacks> SnacksList)
        {
            Console.WriteLine(" ================");
            int i = 0;
            foreach (var snackItem in  SnacksList)
            {
                Console.Write(snackItem.ID );
                if (i == 4)
                {
                    Console.WriteLine();
                    i = 0;
                }
                else
                {
                    Console.Write("||");
                    i++;
                }
              

            }
            Console.WriteLine(" ================");

            Console.WriteLine("PLEASE ENTER The Number OF THE DESIRED SNACK.");
            var userInput = Console.ReadLine();
            if (SnacksList.Any(x=>x.ID.ToString() == userInput))
            {
                var Snack = SnacksList.Select(e => e).Where(e => e.ID.ToString() == userInput).FirstOrDefault();

                if (Snack.isAvailable())
                {
                    Console.WriteLine(Snack .Name + " is AVAILABLE and the  PRICE: " + Snack.Price);
                    payment.moneyDeposit(Snack);
                }
                else
                {
                    Console.WriteLine("NOT AVAILABLE!");
                   

                }
            }
            else
            {
                Console.WriteLine("INVALID Input Kindly Put A Valid Number ");
                DisplayMenu();
            }

          
        }

    }
}
