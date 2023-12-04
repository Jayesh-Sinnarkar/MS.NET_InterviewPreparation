using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.POCO
{
    public class Account
    {
        public static int Count { set; get; }
        public int Id { set; get; }
        public string CustName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public double AccountBalance { get; set; }

        public Account(string Email = null, string Password = null,string CustName = null, double AccountBalance = 0)
        {
            this.Id = Count + 1;
            this.CustName = CustName;
            this.Email = Email;
            this.Password = Password;
            this.AccountBalance = AccountBalance;
            Count++;
        }

        public Account(int id) { this.Id = id; }

        public override bool Equals(object obj)
        {
            return obj is Account account &&
                   (Email.Equals(account.Email) || Id == account.Id);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $"\nAccount[ Id = {this.Id}, Name= {this.CustName}, Email = {this.Email}, Password= {this.Password}, Balance = {this.AccountBalance} ]";
        }


    }
}
