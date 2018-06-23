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
            //AddChildToExistingObjectWhileTracked();
            //EagerLoadingWithMultipleBranches();
            //AnonymousTypeViaProjectionWithRelated();
            //ExplicitLoadingWithChildFilter();
            //UsingRelatedDataForFiltersAndMore();
            GetItemsByCategory();
        }

        private static void GetItemsByCategory()
        {
            var context = new ItemContext();

            var items = context.Items
                .Where(s => s.ParentCategory.Name == "Jedzenie")
                .ToList();

            foreach (var item in items)
            {
                Console.WriteLine(item.Name);
            }         
        }

        private static void UsingRelatedDataForFiltersAndMore()
        {
            var categories = _context.ParentCategories
                .Where(s => s.CustomCategories.Any(q => q.Name.Contains("Alkohol")))
                .ToList();
        }

        private static void AnonymousTypeViaProjectionWithRelated()
        {
            var categoryStatistic = _context.ParentCategories
                .Select(s => new { s.ID, s.Name, ItemsCount = s.Items.Count })
                .ToList();
        }

        private static void EagerLoadingWithMultipleBranches()
        {
            var parentCategory = _context.ParentCategories
                .Include(s => s.CustomCategories)
                .Include(s => s.Items);
        }

        private static void AddChildToExistingObjectWhileTracked()
        {
            var parentCategory = _context.ParentCategories.FirstOrDefault(s => s.Name == "Samochód");
            parentCategory.Items.Add(new Item { Name = "Test", Amount = 20, IsExpense = true, Date = System.DateTime.Now, Description = "Sample description"});
            _context.SaveChanges();
        }
    }
}
