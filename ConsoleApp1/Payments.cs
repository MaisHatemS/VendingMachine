using ConsoleApp1.MoneySlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Payments:IPayment
    {
        public ISnackVendingMachine snackVending;

        public Payments()
        {
        }

        public Payments(ISnackVendingMachine snackVending)
        {
            this.snackVending = snackVending;
        }
        public  void moneyDeposit(Snacks item)
        {
            var total = 0.0;
            Console.WriteLine("*****   PAYMENT METHOD   ******");
            Console.WriteLine("PRESS 1 TO PAY IN COINS");
            Console.WriteLine("PRESS 2 TO PAY WITH CARD");
            Console.WriteLine("PRESS 3 TO PAY WITH NOTES");
            Console.WriteLine("PRESS 4 TO CANCEL PURCHASE");
            Console.WriteLine("********************************");
            Console.WriteLine();

            var inputPayMethod = Convert.ToInt32(Console.ReadLine());

            switch (inputPayMethod)
            {
                case 1:
                    Console.WriteLine("ENTER COINS AMOUNT [DOMINATIONS 10c  20c  50c  $1 ]");

                    var option = Convert.ToDouble(Console.ReadLine());
                    if (CoinSlot.isValidInput(option))
                    {
                        if (option != 1)
                            option = option * 0.01;
                        total += option;
                        while (total != item.Price && total < item.Price)
                        {
                            if (option == 0)
                            {

                                snackVending.DisplayMenu();
                            }
                            Console.WriteLine("The " + item.Name + "Price is :" + item.Price + " Remaining to Pay : " + (item.Price - total));
                            Console.WriteLine("PRESS 0 TO CANCEL PURCHASE");

                       

                                option = Convert.ToInt32(Console.ReadLine());
                                {

                                    if (option == 1)
                                        option = 1 * 100;
                                    total += option;
                                }

                        }

                        if (total - item.Price >= 0)
                        {
                            if (item.isAvailable())
                            {
                                Console.WriteLine("MONEY ACCEPTED.");
                                Console.WriteLine("SUCCESSFULLY PURCHASED " + item.Name);
                                Console.Write("CALCULATING CHANGE: ");
                                foreach (var coins in CoinSlot.GetTotalRemaining(total - item.Price))
                                {
                                    Console.Write(coins + "c ");
                                }
                                Console.WriteLine();

                                item.Amount -= 1;//
                                Console.WriteLine(item.Name + " REMAINING Snack Items: " + item.Amount);
                                Console.WriteLine("THANK YOU! HAVE A NICE DAY!");
                                Console.WriteLine("*****************************");
                            }
                        }

                        else
                        {
                            Console.WriteLine(" NOT ENOUGH MONEY");
                        }


                    }
                    else
                    {
                        Console.WriteLine("INVALID INPUT");
                    }
                    

                    break;
                case 2:
                    Console.WriteLine("ENTER VALID CARD NUMBER");
                    String inputCardNumber = Console.ReadLine();
                    Console.WriteLine("VALIDATING CARD...");
                    string card = CardSlot.IsCreditCardInfoValid(inputCardNumber);
                    if (card.Equals("UnValid"))
                    {
                        Console.WriteLine("UNKNOWN CARD TYPE... REDIRECTING TO PAYMENT MENU");
                        moneyDeposit(item);
                    }
                    else
                    {
                        Console.WriteLine("VALID " + card + " CARD. PRECEED...");
                        Console.WriteLine("ENTER MONEY AMOUNT TO WITHDRAW FROM CARD");
                       var input = Convert.ToDouble(Console.ReadLine());
                        if (input - item.Price >= 0)
                        {
                            if (item.Amount >= 1)
                            {
                                Console.WriteLine("MONEY ACCEPTED.");
                                Console.WriteLine("SUCCESSFULLY PURCHASED " + item.Name);
                                Console.WriteLine("CALCULATING CHANGE: " + (input - item.Price * 100.0)/ 100.0);
                                item.Amount -= 1;
                                Console.WriteLine(item.Name + " REMAINING: " + item.Amount);
                                Console.WriteLine("THANK YOU! HAVE A NICE DAY! :");
                                Console.WriteLine("*********************************");
                            }
                        }
                        else
                        {
                            Console.WriteLine("NOT ENOUGH MONEY ");
                        }
                      
                    }

                    break;
                case 3:
                    Console.WriteLine("ENTER NOTES AMOUNT [ONLY ACCEPTS 20$ and 50$ ]");
                    var inputMoney = Convert.ToInt32(Console.ReadLine());
                    if (NotesSlot.isValidInput(inputMoney))
                    {
                        total += inputMoney;
                        while (total != item.Price && total < item.Price)
                        {
                            if (inputMoney == 0)
                            {

                                snackVending.DisplayMenu();
                            }
                            Console.WriteLine("The " + item.Name + "Price is :" + item.Price + " Remaining to Pay : " + (item.Price - total));
                            Console.WriteLine("PRESS 0 TO CANCEL PURCHASE");
                           
                           
                                option = Convert.ToInt32(Console.ReadLine());
                                {

                                    if (option == 1)
                                        option = 1 * 100;
                                    total += option;
                                }



                        }

                        if (total - item.Price >= 0)
                        {
                            if (item.isAvailable())
                            {
                                Console.WriteLine("MONEY ACCEPTED.");
                                Console.WriteLine("SUCCESSFULLY PURCHASED " + item.Name);
                                Console.Write("CALCULATING CHANGE: ");
                                foreach (var coins in NotesSlot.GetTotalRemaining(total - item.Price))
                                {
                                    Console.Write(coins + " ");
                                }
                                Console.WriteLine();

                                item.Amount -= 1;//
                                Console.WriteLine(item.Name + " REMAINING Snack Items: " + item.Amount);
                                Console.WriteLine("THANK YOU! HAVE A NICE DAY!");
                                Console.WriteLine("*****************************");
                            }
                        }

                        else
                        {
                            Console.WriteLine(" NOT ENOUGH MONEY");
                        }


            }
                    else
                    {
                        Console.WriteLine("INVALID INPUT");
                    }
                    break;

                case 4:

                    snackVending.DisplayMenu();

                    break;
                default:
                    Console.WriteLine("INVALID INPUT");
                    break;
            }

        }
       
      
    }
}



