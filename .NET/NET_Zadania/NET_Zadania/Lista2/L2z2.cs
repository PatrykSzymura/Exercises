using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
{
    public class L2z2
    {
        public L2z2()
        {
          ATM ing = new ATM();
        }
        
    }

    class ATM
    {
        private Dictionary<int,int> Banknotes;

        public ATM()
        {
            var rnd = new Random();

            this.Banknotes = new Dictionary<int,int>();
            this.Banknotes.Add(500, rnd.Next(1, 10));
            this.Banknotes.Add(200, rnd.Next(1, 10));
            this.Banknotes.Add(100, rnd.Next(1, 10));
            this.Banknotes.Add(50,  rnd.Next(1, 10));
            this.Banknotes.Add(20,  rnd.Next(1, 10));
            this.Banknotes.Add(10,  rnd.Next(1, 10));

        }

        private int MaxPioniondze()
        {
            int sum = 0;
            foreach (int denomination in this.Banknotes.Keys)
            {
                sum += (denomination * this.Banknotes[denomination]);
            }
            return sum;
        }

        private bool CanWithdraw(int amount)
        {
            return (amount < MaxPioniondze()) ? true : false;
        }

        public void DisplayBanknotes(Dictionary<int,int> banknotes)
        {
            Console.WriteLine(" _________________");
            Console.WriteLine("| Nominal | Ilosc |");
            Console.WriteLine("|_________|_______|");
            foreach (int banknote in banknotes.Keys)
            {
                Console.WriteLine("| {0,-7} | {1,5} |", banknote, banknotes[banknote]);
            }
            Console.WriteLine("|_________|_______|");
        }

        private Dictionary<int, int> CalculateNotes(int amount, Dictionary<int, int> availableBanknotes)
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

        public void WithdrawMoney(int amount)
        {
            if (CanWithdraw(amount))
            {
                Dictionary<int, int> WithdrawalMoney = CalculateNotes(amount, this.Banknotes);
              
                foreach(int denominations in WithdrawalMoney.Keys)
                {
                    this.Banknotes[denominations] -= WithdrawalMoney[denominations];
                }
            }
            else
            {
                Console.WriteLine("ATM has insufficient amount of money");
            }
        }  
        
        public void DepositMoney(int amount)
        {
            if(amount == (amount / 10) * 10)
            {
                Dictionary<int, int> Deposit = CalculateNotes(amount, this.Banknotes);
                
                foreach(int denominations in Deposit.Keys)
                {
                    this.Banknotes[denominations] += Deposit[denominations];
                }
            }
            else
            {
                Console.WriteLine("Cannot Insert Coins");
            }
        }
    }
    
    class BankAccount
    {
        private String Login, 
                       PIN;
        private int AccountBalance;

        public BankAccount(String login = "login", String pin = "2137", int AccountBalance = 1000)
        {
            this.AccountBalance = AccountBalance;
            this.Login = login;
            this.PIN = pin;
        }

        public bool CanWithdraw(int amount)
        {
            return (AccountBalance >= amount) ? true : false;
        }

        public bool CheckCredientials(String login, String pin)
        {
            Dictionary<String, bool> Verification = new Dictionary<string, bool>();
            Verification.Add("pin",   false);
            Verification.Add("login", false);

            if (login == this.Login)
            {
                Verification["login"] = true;   
            }

            if (pin == this.PIN)
            {
                Verification["pin"] = true;
            }
            
            foreach (bool ver in  Verification.Values) 
            {
                if (!ver) { return false; }
            }

            return true;
        }

        public void MakeTransaction(int amount)
        {
            if (CanWithdraw(amount)) 
            {
                this.AccountBalance += amount;
            }
        }
    }

    class ATM_Console_Interface
    {
        public ATM_Console_Interface(HashSet<BankAccount> bankAccounts) {
            ATM aTM = new ATM();

            String login, pin;
            do {
                Console.WriteLine("Login: ");
                login = Console.ReadLine();
                Console.WriteLine("Pin: ");
                pin = Console.ReadLine();

            } while ();
            
            
           
        }
        private bool HandleAccountsVerification(HashSet<BankAccount> bankAccounts,String Login, String Pin)
        {

            return false;
        }
    }
}

