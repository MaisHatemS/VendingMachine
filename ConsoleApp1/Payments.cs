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
       

        public Payments()
        {
        }

      
        public  void moneyDeposit(Snacks item)
        {
            var cancelChargeRemaining = new List<double>();// the money that will back to the customer if he is cancel the payment 
            var total = 0.0; // total money customer is entered 
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
                    cancelChargeRemaining.Clear();
                    Console.WriteLine("ENTER COINS AMOUNT IN CENTS [DOMINATIONS 10  20  50  100 ] ");

                    var option = Convert.ToDouble(Console.ReadLine());
                    if (CoinSlot.isValidInput(option))// check if its a coin cents 
                    {
                   
                            option = option * 0.01;
                        total += option;

                        while (total != item.Price && total < item.Price)//until the enter money is equal or more than the item price
                        {
                            cancelChargeRemaining.Add(option*100.0);
                            Console.WriteLine("The " + item.Name + "Price is :" + item.Price + " Remaining to Pay : " + (item.Price - total));
                            Console.WriteLine("PRESS 0 TO CANCEL PURCHASE");

                       

                                option = Convert.ToInt32(Console.ReadLine());
                         
                            if (option == 0)
                            {
                                Console.Write("Thank You ! Don't forget Your Inserted Money :");

                                foreach (var i in cancelChargeRemaining)
                                {
                                    Console.Write(i+" ");

                                }
                              
                                Environment.Exit(0);
           
                            }
                            else
                            {
                              
                                if (CoinSlot.isValidInput(option))
                                {
                                    option = option * 0.01;
                                    total += option;
                                }
                                else
                                {
                                    Console.WriteLine("INVALID INPUT");
                                }

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
                                Console.WriteLine("CALCULATING CHANGE: " + ((input - item.Price) * 100.0)/ 100.0);
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
                    cancelChargeRemaining.Clear();
                    Console.WriteLine("ENTER NOTES AMOUNT [ONLY ACCEPTS 20$ and 50$ ]");
                    var inputMoney = Convert.ToInt32(Console.ReadLine());
                    if (NotesSlot.isValidInput(inputMoney))
                    {
                        total += inputMoney;
                        while (total != item.Price && total < item.Price)
                        {
                            cancelChargeRemaining.Add(inputMoney);
                            
                            Console.WriteLine("The " + item.Name + "Price is :" + item.Price + " Remaining to Pay : " + (item.Price - total));
                            Console.WriteLine("PRESS 0 TO CANCEL PURCHASE");
                            option = Convert.ToInt32(Console.ReadLine());

                            if (option == 0)
                            {
                                Console.Write("Thank You ! Don't forget Your Inserted Money :");

                                foreach (var i in cancelChargeRemaining)
                                {
                                    Console.Write(i + " ");

                                }

                                Environment.Exit(0);

                            }
                            else
                            {

                                if (NotesSlot.isValidInput(option))
                                {
                                    
                                    total += option;
                                }
                                else
                                {
                                    Console.WriteLine("INVALID INPUT");
                                }

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

                    Environment.Exit(0);

                    break;
                default:
                    Console.WriteLine("INVALID INPUT");
                    break;
            }

        }
       
      
    }
}



