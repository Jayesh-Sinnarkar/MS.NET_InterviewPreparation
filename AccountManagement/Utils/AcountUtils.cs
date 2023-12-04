using AccountManagement.POCO;
using AccountManagement.Testers;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Utils
{
    internal class AccountUtils
    {
        public List<Account> accounts = new List<Account>();


        //LogIn
        public void LogIn(string username, string password)
        {
            Account tempAcc = new Account(username, password);
            if(accounts.Contains(tempAcc))
            {
                int index = accounts.IndexOf(tempAcc);
                AccountsTester.CurrentUser = accounts[index];
            }
            else
            {
                Console.WriteLine("Invalid Credentials...");
            }
        }

        //Create Account
        public void CreateAccount( string CustName, string Email, string Password, double AccountBalance)
        {
            Account acc = new Account( CustName, Email, Password, AccountBalance);
            if(accounts.Contains(acc))
            {
                Console.WriteLine("Account Already Exists...!");
                return;
            }
            Account.Count++;
            accounts.Add(acc);
            Console.WriteLine("Account Created For:"+acc);
        }

        //Add Balance
        public string AddBalance(double amount, Account acc)
        {
            Console.WriteLine($"Account Balance Before Deposit is {acc.AccountBalance}");
            acc.AccountBalance += amount;
            return $"Account Balance After Deposit is {acc.AccountBalance}";
        }

        //Display Balance
        public string DisplayBalance(Account acc)
        {
            return $"Current Outstanding Amount is {acc.AccountBalance}";
        }

        //Withdraw Balance
        public string WithdrawBalance(double amount, Account acc)
        {
            Console.WriteLine($"Account Balance Before Withrawal is {acc.AccountBalance}");
            acc.AccountBalance -= amount;
            return $"Account Balance After Deposit is {acc.AccountBalance}";

        }

        //Transfer Balance
        public void TransferBalance(double amount,Account srcAccount, int destAccId)
        {
            Account destAcc = new Account( destAccId );
            if (!accounts.Contains(destAcc))
            {
                Console.WriteLine("Destination Accuont Does Not Exists...");
                return;
            }
            bool procceed = false;
            int index = accounts.IndexOf(destAcc);
            destAcc = accounts[index];
            Console.WriteLine("Check Destination Account Details bellow: \n" +
                              $"{destAcc}");
            Console.Write("Do you want to procceed with transaction?[Yes|No] : ");
            String ch = Console.ReadLine();
            ch = ch.ToUpper().Equals("YES") || ch.ToUpper().Equals("Y") ? "YES" : "NO";
            if (ch.Equals("NO"))
            {
                Console.WriteLine("Cancelling Transaction... Thank You");
                return;
            }
            else if (ch.Equals("YES"))
            {
                AccountUtils accUtils = new AccountUtils();
                string message = accUtils.WithdrawBalance(amount, srcAccount);
                Console.WriteLine(message);
                accUtils.AddBalance(amount, destAcc);
                Console.WriteLine("Transaction Successful...");
            }
            return;
        }

        //Show All Accounts
        public void ShowAllAccounts(string password)
        {
            if(!password.Equals("12345"))
            {
                Console.WriteLine("Invalid password....");
                return;
            }
            foreach(Account acc in accounts)
            {
                Console.WriteLine(acc.ToString());
            }
            Console.WriteLine();
        }
        //Add Stubbed Data
        public void addStubbedData()
        {
            accounts = StubbedData.addStubbedData();
        }

    }
}
