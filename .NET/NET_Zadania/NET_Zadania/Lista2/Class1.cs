using Lista2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace lista2
{
    public class Class1
    {
        public Class1()
        {
            BankAccount[] accounts = {
                new BankAccount("papa","1235"),
                new BankAccount()
            };
            ATM_Console_Interface ing = new ATM_Console_Interface(accounts);
        }

    }

    class BankAccount2
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

        public int CheckBalance() { return this.AccountBalance; }

        public bool CanWithdraw(int amount)
        {
            return (AccountBalance >= amount) ? true : false;
        }

        public bool CheckCredientials(String login, String pin)
        {
            Dictionary<String, bool> Verification = new Dictionary<string, bool>();
            Verification.Add("pin", false);
            Verification.Add("login", false);

            if (login == this.Login)
            {
                Verification["login"] = true;
            }

            if (pin == this.PIN)
            {
                Verification["pin"] = true;
            }

            foreach (bool ver in Verification.Values)
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

    class ATM_2
	{
        private Dictionary<int, int> Banknotes;
        private BankAccount2[] AccountDatabase;

        public ATM_2(BankAccount2[] Database)
		{
            this.AccountDatabase = Database;

            var rnd = new Random();

            this.Banknotes = new Dictionary<int, int>();
            this.Banknotes.Add(500, rnd.Next(1, 10));
            this.Banknotes.Add(200, rnd.Next(1, 10));
            this.Banknotes.Add(100, rnd.Next(1, 10));
            this.Banknotes.Add(50, rnd.Next(1, 10));
            this.Banknotes.Add(20, rnd.Next(1, 10));
            this.Banknotes.Add(10, rnd.Next(1, 2));

            
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

        public void DisplayBanknotes(Dictionary<int, int> banknotes)
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

        public void DisplayBanknotes()
        {
            Console.WriteLine(" _________________");
            Console.WriteLine("| Nominal | Ilosc |");
            Console.WriteLine("|_________|_______|");
            foreach (int banknote in this.Banknotes.Keys)
            {
                Console.WriteLine("| {0,-7} | {1,5} |", banknote, this.Banknotes[banknote]);
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

        public void DepositMoney(int amount)
        {
            if (amount == (amount / 10) * 10)
            {
                Dictionary<int, int> Deposit = CalculateNotes(amount, this.Banknotes);

                foreach (int denominations in Deposit.Keys)
                {
                    this.Banknotes[denominations] += Deposit[denominations];
                }
            }
            else
            {
                Console.WriteLine("Cannot Insert Coins");
            }
        }

        public bool WithdrawMoney(int amount)
        {
            if (CanWithdraw(amount))
            {
                Dictionary<int, int> WithdrawalMoney = CalculateNotes(amount, this.Banknotes);

                foreach (int denominations in WithdrawalMoney.Keys)
                {
                    if (this.Banknotes[denominations] - WithdrawalMoney[denominations] >= 0)
                    {
                        this.Banknotes[denominations] -= WithdrawalMoney[denominations];
                    }
                    else { return false; }
                }
                return true;
            }
            else
            {
                Console.WriteLine("ATM has insufficient amount of money");
                return false;
            }
        }

        private bool HandleAccountsVerification(String Login, String Pin)
        {
            foreach (BankAccount bankAccount in this.AccountDatabase)
            {
                if (bankAccount.CheckCredientials(Login, Pin))
                {
                    return true;
                }
            }

            return false;
        }

        public static ATM_2 ATM_Console_Interface(BankAccount2[] bankAccounts)
        {
            ATM_2 aTM = new ATM_2(bankAccounts);
            BankAccount CurrentBankAccount;

            aTM.DisplayBanknotes();

            String login = string.Empty, pin = string.Empty;
            do
            {
                if (login != "-") { Console.WriteLine("Incorrect Pin or Login"); }

                Console.WriteLine("Login: ");
                login = Console.ReadLine();
                Console.WriteLine("Pin: ");
                pin = Console.ReadLine();

            } while (aTM.HandleAccountsVerification(login, pin));

            BankAccount Current = new BankAccount();

            foreach (BankAccount2 bankAccount in bankAccounts)
            {
                if (bankAccount.CheckCredientials(login, pin))
                {
                    Current = bankAccount;
                }
            }

            bool exit = true;
            do
            {
                Console.WriteLine("Choose Option:");
                Console.WriteLine("1.Check Balance");
                Console.WriteLine("2.Deposit money");
                Console.WriteLine("3.Withdraw money");
                int cho = int.Parse(Console.ReadLine());

                int amount1 = 0;

                switch (cho)
                {
                    case 1:
                        Console.WriteLine("Current balance: {0}", Current.CheckBalance());
                        break;
                    case 2:
                        Console.WriteLine("Specify amount of money to deposit");
                        amount1 = int.Parse(Console.ReadLine());
                        Current.MakeTransaction(Math.Abs(amount1));
                        aTM.DepositMoney(amount1);
                        break;
                    case 3:
                        Console.WriteLine("Specify amount of money to withdraw");
                        amount1 = int.Parse(Console.ReadLine());

                        if (amount1 <= Current.CheckBalance())
                        {
                            Current.MakeTransaction(-Math.Abs(amount1));
                            aTM.WithdrawMoney(amount1);
                        }
                        else
                        {
                            Console.WriteLine("Insufficient account funds");
                        }
                        break;
                    case 4:
                        exit = false;
                        break;
                }
                aTM.DisplayBanknotes();
            } while (exit);
            aTM.DisplayBanknotes();

            return aTM;
        }
    }




}
