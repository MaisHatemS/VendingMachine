using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp1.MoneySlot
{
    public class CardSlot
    {
        public static Dictionary<string, Regex> Card_slots = new Dictionary<string, Regex>()
                {
                    { "VISA",new Regex("^4[0-9]{12}(?:[0-9]{3}){0,2}$")},
                    {"MASTERCARD" ,new Regex("^(?:5[1-5]|2(?!2([01]|20)|7(2[1-9]|3))[2-7])\\d{14}$")},
                    {"AMERICAN_EXPRESS" ,new Regex("^3[47][0-9]{13}$")},
                    {"DINERS_CLUB" ,new Regex("^3(?:0[0-5]|[68][0-9])[0-9]{11}$")},
                    {"DISCOVER",new Regex("^6(?:011|[45][0-9]{2})[0-9]{12}$" )}
                };



        public static string IsCreditCardInfoValid(String cardNumber)//check if the card is valid and then return the card type
        {
            cardNumber = cardNumber.Replace(" ","");

            foreach (var card in Card_slots)
            {
                if (card.Value.IsMatch(cardNumber)) 
                    return card.Key;
            }

            return "UnValid";
        }

    }
}
