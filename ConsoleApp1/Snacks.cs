using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Snacks
    {
        public long ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
      //  public bool IsActive { get; set; }


        public bool isAvailable()
        {
            return Amount > 0;
        }

    }
}
