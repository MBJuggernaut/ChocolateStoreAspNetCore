using ChocolateStoreConsoleApp.Models;
using System;
using System.Linq;

namespace ChocolateStoreConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SalesContext context = new SalesContext();

            string s = context.Items.FirstOrDefault(x=>x.Id==1).Name;
            string s2 = context.Items.FirstOrDefault(x => x.Id == 2).Name;
            Console.WriteLine(s);
            Console.WriteLine(s2);

        }
    }
}
