using ConsoleApp1.MoneySlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class SnacksData
    {
        public static IList<Snacks> SnacksList { get; set; } = new List<Snacks>()
        {
            new Snacks{ID=1,Name="Lays",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5},
            new Snacks{ID=2,Name="Lays",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5},
            new Snacks{ID=3,Name="Pringles",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5},
            new Snacks{ID=4,Name="Coke",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=5,Name="Sandwish",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=6,Name="Water",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=7,Name="Snikars",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=8,Name="Pepsi",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=9,Name="Twix",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=10,Name="CheesCake",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=11,Name="FruitSalad",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=12,Name="Mentos",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=13,Name="",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=14,Name="Lays",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=15,Name="Lays",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=16,Name="Pringles",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=17,Name="Coke",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=18,Name="Sandwish",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=19,Name="Water",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=20,Name="Snikars",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=21,Name="Pepsi",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=22,Name="Twix",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=23,Name="CheesCake",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=24,Name="FruitSalad",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 },
            new Snacks{ID=25,Name="Mentos",Price= CoinSlot.fiftyCents + 2 * CoinSlot.getValue(), Amount=5 }
        };
  
    }


}
