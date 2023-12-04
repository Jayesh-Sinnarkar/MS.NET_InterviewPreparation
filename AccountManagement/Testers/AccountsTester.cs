using AccountManagement.POCO;
using AccountManagement.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Testers
{
    internal class AccountsTester
    {
        public static Account? CurrentUser { get; set; }

        public static void Main(string[] args)
        {
            bool exit = false;
            AccountUtils AccUtils = new AccountUtils();
            AccUtils.addStubbedData();
            while(!exit)
            {
                try
                {
                    Console.WriteLine(
                        "\n*******Account Management*******\n" +
                        "   1. View All Accounts - Admin Only\n" +
                        "   2. LongIn\n" +
                        "   3. Create New Account\n" +
                        "   0. Exit\n"            
                        );
                    Console.Write("\nPlease enter your choice: ");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1://View All Accounts - Admin Only
                            Console.Write("\nEnter Password: ");
                            AccUtils.ShowAllAccounts(Console.ReadLine());
                            break;
                        case 2://LongIn
                            Console.Write("\nEnter Email Id: ");
                            string mail = Console.ReadLine();
                            Console.Write("\nEnter Password: ");
                            string pwd = Console.ReadLine();
                            AccUtils.LogIn(mail,pwd);
                            if(AccountsTester.CurrentUser != null)
                            {
                                displaySecondMenu(AccountsTester.CurrentUser, AccUtils);
                            }
                            break;
                        case 3://Create New Account
                            Console.Write("\nEnter Customer Name: ");
                            string CustName = Console.ReadLine(); 
                            Console.Write("\nEnter Email Id: ");
                            string Email = Console.ReadLine(); 
                            Console.Write("\nEnter Password: ");
                            string Password =  Console.ReadLine(); 
                            Console.Write("\nEnter Opening Balance: ");
                            double AccountBalance = Convert.ToUInt64(Console.ReadLine());
                            AccUtils.CreateAccount(CustName, Email, Password, AccountBalance);
                            break;

                        
                        case 0://Exit
                            exit = true;
                            break;
                    }

                }catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            
            }
        }

        private static void displaySecondMenu(Account currentUser, AccountUtils accUtils)
        {
            bool returnPrev = false;

            while (!returnPrev)
            {
                Console.WriteLine("\n****OPTIONS****" +
                    "\n   A. Deposit Amount" +
                    "\n   B. Withdraw Amount" +
                    "\n   C. Transfer Amount" +
                    "\n   D. Display Balance" +
                    "\n   E. LogOut");
                Console.Write("Enter your choice: ");
                char ch = Console.ReadLine()[0];

                switch (ch)
                {
                    case 'A': //A. Deposit Amount
                        Console.WriteLine("Enter Amount to Deposit:");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        string str = accUtils.AddBalance(amount,AccountsTester.CurrentUser);
                        Console.WriteLine(str);
                        break;

                    case 'B': //B. Withdraw Amount
                        Console.Write("\n Enter Amount to Withdraw: ");
                        double withAmount = Convert.ToDouble(Console.ReadLine());
                        string meg = accUtils.WithdrawBalance(withAmount,AccountsTester.CurrentUser);
                        Console.WriteLine(meg);
                        break;

                    case 'C': //C. Transfer Amount"
                        Console.Write("\n Enter Amount to Transfer: ");
                        double amt = Convert.ToDouble(Console.ReadLine());
                        Console.Write("\n Enter Destination Account Number: ");
                        int destAccNo = Convert.ToInt32(Console.ReadLine());
                        accUtils.TransferBalance(amt,AccountsTester.CurrentUser , destAccNo);
                        break;
                    case 'D':
                        string dispMsg = accUtils.DisplayBalance(AccountsTester.CurrentUser);
                        Console.WriteLine(dispMsg);
                        break;

                    case 'E': //D. LogOut
                        AccountsTester.CurrentUser = null;
                        returnPrev = true;
                        Console.WriteLine("Logging Out...");
                        break;
                }

            }
            
        }
    }
}
