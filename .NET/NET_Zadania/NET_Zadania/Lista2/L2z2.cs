using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
{
    public class L2z2
    {
        public L2z2()
        {
          Bankomat ing = new Bankomat();
        }
        
    }

    class Bankomat
    {
        private Dictionary<int,int> Piniondze;

        public Bankomat()
        {
            var rnd = new Random();

            this.Piniondze = new Dictionary<int,int>();
            this.Piniondze.Add(500, rnd.Next(1, 10));
            this.Piniondze.Add(200, rnd.Next(1, 10));
            this.Piniondze.Add(100, rnd.Next(1, 10));
            this.Piniondze.Add(50,  rnd.Next(1, 10));
            this.Piniondze.Add(20,  rnd.Next(1, 10));
            this.Piniondze.Add(10,  rnd.Next(1, 10));

            Console.WriteLine(MaxPioniondze());
        }

        private int MaxPioniondze()
        {
            int sum = 0;
            foreach (int denomination in this.Piniondze.Keys)
            {
                sum += (denomination * this.Piniondze[denomination]);
            }
            return sum;
        }

        private bool CanWithdraw(int amount)
        {
            return (amount > MaxPioniondze()) ? true : false;
        }

        private static Dictionary<int, int> CalculateWithdraw(int amount, Dictionary<int, int> availableBanknotes)
        {
            int[] denominations = { 500, 200, 100, 50, 20, 10 };
            Dictionary<int, int> withdrawal = new Dictionary<int, int>();

            foreach (int denomination in denominations)
            {
                int count = Math.Min(amount / denomination, availableBanknotes[denomination]);
                if (count > 0)
                {
                    withdrawal.Add(denomination, count);
                    amount -= count * denomination;
                }
            }

            return withdrawal;
        }
    }
}

