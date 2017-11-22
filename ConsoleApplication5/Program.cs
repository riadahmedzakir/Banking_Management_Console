using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Debit aDebit = new Debit();
            aDebit.printAccount();
            Debit aDebitAccount = new Debit("Riad", 10000, 28, 8, 1992);
            aDebitAccount.printAccount();
            aDebitAccount.deposit();
            aDebitAccount.withdraw();
            aDebitAccount.printAccount();
            Console.ReadKey();*/

            Bank aBankSystem = new Bank();

            Console.WriteLine("1.Create a Account");
            Console.WriteLine("2.Deposit");
            Console.WriteLine("3.Withdraw");
            Console.WriteLine("4.Check Infomation");
            Console.WriteLine("5.Exit");

            

            while(true)
            {
                Console.Write("\nEnter Option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                if (option == 1)
                {
                    Console.WriteLine("\n1.Debit Account");
                    Console.WriteLine("2.Credit Account");
                    Console.WriteLine("3.Savings Account");
                    Console.Write("\nEnter Account Type: ");
                    int accountType = Convert.ToInt32(Console.ReadLine());
                    aBankSystem.createAccount(accountType);
                }
                else if (option == 2)
                {
                    aBankSystem.deposit();
                } 
                else if (option == 3)
                {
                    aBankSystem.withdraw();
                }
                else if (option == 4)
                {
                    aBankSystem.printInfo();
                }
                else if (option == 5)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nNo Option Matches! Enter Again");
                    //Console.Clear();
                }
            }
        }
    }

    class Dob
    {
        private int day;
        private int month;
        private int year;

        public bool set(int d, int m, int y)
        {
            if ((d > 0 && d <= 31) && (m > 0 && m <= 12) && (y > 0))
            {
                day = d;
                month = m;
                year = y;
                return true;
            }
            else
            {
                return false;
            }
        }

        public int getDay() { return day; }
        public int getMonth() { return month; }
        public int getYear() { return year; }
        public void setBirthday(int a, int b, int c) { day = a; month = b; year = c; }

        public String getDate()
        {
            String date = String.Concat(Convert.ToString(day),"-",Convert.ToString(month),"-", Convert.ToString(year));
            return date;
        }
    }

    static class IdGenerator
    {
        private static int serial_no = 1;

        public static string Generate(int a, int b, int c)
        {
            Dob n = new Dob();
            n.setBirthday(a, b, c);
            String y = Convert.ToString(n.getYear());
            String m = Convert.ToString(n.getMonth());
            String serial = Convert.ToString(serial_no);

            String Id = string.Concat(y, "-", m, "-000", serial);
            serial_no++;
            return Id;
        }
    }

    abstract class Account
    {
        private readonly String accountName;
        private readonly String accountID;
        private int accountBalance;
        private Dob Birthday = new Dob();

        public Account()
        {
            accountName = null;
            accountID = null;
            accountBalance = 0;
            Birthday.setBirthday(0, 0, 0);
        }

        public Account(String a, int b, int d, int m, int y)
        {
            accountName = a;
            accountID = IdGenerator.Generate(d,m,y);
            accountBalance = b;
            Birthday.setBirthday(d, m, y);
        }

        public int getBalance() { return accountBalance; }
        public string getID() { return accountID; } 
        public void setBalance(int a) { accountBalance = a; }
        public abstract bool deposit();
        public abstract bool withdraw();

        public void printAccount()
        {
            Console.WriteLine("Account Name: {0}", accountName);
            Console.WriteLine("Account ID: {0}", accountID);
            Console.WriteLine("Date of Birthday: {0}", Birthday.getDate());
            Console.WriteLine("Account Balance: {0}", accountBalance);
        }
    }

    class Debit : Account
    {
        private int transLimit = 20000;
        public Debit() : base() { }
        public Debit(String a, int b, int d, int m, int y) : base(a, b, d, m, y) { }
        public override bool deposit()
        {
            Console.Write("Enter Ammount Deposit: ");
            int a = Convert.ToInt32(Console.ReadLine());
            if ( base.getBalance() > 100000 )
            {
                //transLimit = transLimit + a;
                Console.WriteLine("Fail to Deposit");
                return false;
            }
            else
            {
                int b = base.getBalance() + a;
                base.setBalance(b);
                Console.WriteLine("Deposit Successful!");
                return true;
            }
        }
        public override bool withdraw()
        {
            Console.Write("Enter Withdraw Ammount: ");
            int a = Convert.ToInt32(Console.ReadLine());
            if( transLimit > 20000 )
            {
                Console.WriteLine("Cannot Withdraw!");
                return false;
            }  
            else
            {
                Console.WriteLine("Withdraw Successful!");
                int b = base.getBalance() - a;
                base.setBalance(b);
                transLimit = transLimit - a;
                return true;
            }
        }
    }

    class Credit : Account
    {
        private int withdrawLimit = 20000;
        public Credit() : base() { }
        public Credit(String a, int b, int d, int m, int y) : base(a, b, d, m, y) { }

        public override bool deposit()
        {
            Console.Write("Enter Ammount Deposit: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = base.getBalance() + a;
            base.setBalance(b);
            Console.WriteLine("Deposit Successful!");
            return true;            
        }

        public override bool withdraw()
        {
            Console.Write("Enter Withdraw Ammount: ");
            int a = Convert.ToInt32(Console.ReadLine());
            if (withdrawLimit > 20000)
            {
                Console.WriteLine("Cannot Withdraw!");
                return false;
            }
            else
            {
                Console.WriteLine("Withdraw Successful!");
                int b = base.getBalance() - a;
                base.setBalance(b);
                withdrawLimit = withdrawLimit - a;
                return true;
            }
        }
    }

    class Savings : Account
    {
        public Savings() : base() { }
        public Savings(String a, int b, int d, int m, int y) : base(a,b,d,m,y) { }

        public override bool deposit()
        {
            Console.Write("Enter Ammount Deposit: ");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = base.getBalance() + a;
            base.setBalance(b);
            Console.WriteLine("Deposit Successful!");
            return true;
        }

        public override bool withdraw()
        {
                Console.Write("Enter Ammount Deposit: ");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Withdraw Successful!");
                int b = base.getBalance() - a;
                base.setBalance(b);
                return true;           
        }
    }

    class Bank
    {
        private Account[] accounts = new Account[10];
        public static int accountCounter = 0;

        public Bank()
        {
            for(int i=0; i<10; i++)
            {
                accounts[i] = new Debit();
            }
        }

        public void createAccount(int a)
        {
            if (a == 1)
            {
                Console.Write("Enter Account Name: ");
                string name = Convert.ToString(Console.ReadLine());
                Console.Write("Enter Balance: ");
                int balance = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birthday(DD): ");
                int day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birthmonth(MM): ");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birthyear(YYYY): ");
                int year = Convert.ToInt32(Console.ReadLine());
                Debit aDeibtAccount = new Debit(name, balance, day, month, year);
                accounts[accountCounter] = aDeibtAccount;
                accountCounter++;
            }
            
            else if (a == 2)
            {
                Console.Write("Enter Account Name: ");
                string name = Convert.ToString(Console.ReadLine());
                Console.Write("Enter Balance: ");
                int balance = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birthday(DD): ");
                int day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birthmonth(MM): ");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birthyear(YYYY): ");
                int year = Convert.ToInt32(Console.ReadLine());
                Credit aCreditAccount = new Credit(name, balance, day, month, year);
                accounts[accountCounter] = aCreditAccount;
                accountCounter++;
            }
            
            else if (a == 3)
            {
                Console.Write("Enter Account Name: ");
                string name = Convert.ToString(Console.ReadLine());
                Console.Write("Enter Balance: ");
                int balance = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birthday(DD): ");
                int day = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birthmonth(MM): ");
                int month = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Birthyear(YYYY): ");
                int year = Convert.ToInt32(Console.ReadLine());
                Savings aSavingsAccount = new Savings(name, balance, day, month, year);
                accounts[accountCounter] = aSavingsAccount;
                accountCounter++;
            }
            else
            {
                Console.WriteLine("Wrong Input");
            }
        }

        public void deposit()
        {
            Console.Write("Enter Account ID: ");
            String id = Convert.ToString(Console.ReadLine());
            /*Console.Write("Enter Ammount to Deposit: ");
            int balance = Convert.ToInt32(Console.ReadLine());
            int depositID = 0;*/
            int checker = 0;

            for(int i=0; i<10; i++)
            {
                if( accounts[i].getID() == id)
                {
                    accounts[i].deposit();
                    break;
                }
                else
                {
                    checker++;
                    if (checker == 10) { Console.WriteLine("No Account Found!"); }
                }
            }            
        }

        public void withdraw()
        {
            Console.Write("Enter Account ID: ");
            String id = Convert.ToString(Console.ReadLine());
            /*.Write("Enter Ammount to Withdraw: ");
            int balance = Convert.ToInt32(Console.ReadLine());
            int depositID = 0;*/
            int checker = 0;

            for (int i = 0; i < 10; i++)
            {
                if (accounts[i].getID() == id)
                {
                    accounts[i].withdraw();
                    break;
                }
                else
                {
                    checker++;
                    if (checker == 10) { Console.WriteLine("No Account Found!"); }
                }
            }
        }

        public void printInfo()
        {
            Console.Write("Enter Account ID: ");
            String id = Convert.ToString(Console.ReadLine());
            int checker = 0;

            for (int i = 0; i < 10; i++)
            {
                if (accounts[i].getID() == id)
                {
                    accounts[i].printAccount();
                    break;
                }
                else
                {
                    checker++;
                    if(checker == 10) { Console.WriteLine("No Account Found!"); }
                }
            }
        }
    }
}
