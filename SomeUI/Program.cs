using BudgetPlanner.Data;
using BudgetPlanner.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SomeUI
{
    class Program
    {
        private static ItemContext _context = new ItemContext();

        static void Main(string[] args)
        {
            using (var unitOfWork = new UnitOfWork(new ItemContext()))
            {
                var items = unitOfWork.Items.GetAll();
                foreach (var item in items)
                {
                    Console.WriteLine(item.Name);
                }

                var mostExpensiveItems = unitOfWork.Items.GetGreatestExpense(3);
                foreach (var item in mostExpensiveItems)
                {
                    Console.WriteLine($"{item.Name} : {item.Amount}");
                }

            }
        }


    }
}
