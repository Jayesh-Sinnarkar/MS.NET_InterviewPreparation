using AccountManagement.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Utils
{
    public static class StubbedData
    {
        public static List<Account> addStubbedData()
        {
            List<Account> list = new List<Account>();
            Account acc1 = new Account("jayesh@gmail.com", "1234", "Jayesh Sinnarkar", 1000000);
            Account acc2 = new Account("div@gmail.com", "1235", "Divyanshu Tiwari", 20000);
            Account acc3 = new Account("tushar@gmail.com", "1236", "Tushar Satalkar", 30000);
            Account acc4 = new Account("pranay@gmail.com", "1237", "Pranay Gudekar", 40000);
            Account acc5 = new Account("ashish@gmail.com", "1238", "Ashish Thattikota", 50000);
            list.Add(acc1);
            list.Add(acc2); 
            list.Add(acc3);
            list.Add(acc4);
            list.Add(acc5);
            return list;

        }
    }
}
