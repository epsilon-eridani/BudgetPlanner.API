using BudgetPlanner.Data;
using BudgetPlanner.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SomeUI
{
    class Program
    {
        private static ItemContext _context = new ItemContext();

        static void Main(string[] args)
        {
            //InsertParentCategory();
            //InsertMultipleParentCategories();
            //GetParentCategories();
            //GetParentCategoriesByNames();
            //GetParentCategoryByNames();
            //UpdateDescription();
            //UpdateMultipleParentCategories();
            MultipleOperations();
        }

        private static void MultipleOperations()
        {
            var parentCategory = _context.ParentCategories.FirstOrDefault();
            parentCategory.Name += "...";
            _context.ParentCategories.Add(new ParentCategory { Name = "Jedzenie", Description = "Pieniądze wydane na jedzenie, napoje" });
            _context.SaveChanges();
        }

        private static void UpdateMultipleParentCategories()
        {
            var parentCategories = _context.ParentCategories.Where(s => s.Name == "Mieszkanie").ToList();
            parentCategories.ForEach(s => s.Name += "dodatek");
            _context.SaveChanges();
        }

        private static void UpdateDescription()
        {
            var parentCategory = _context.ParentCategories.FirstOrDefault(s => s.Name == "Samochód");
            parentCategory.Description += ", paliwo, naprawy.";
            _context.SaveChanges();
        }

        private static void GetParentCategoryByNames()
        {
            var categoryName = "Samochód";
            var parentCategory = _context.ParentCategories.FirstOrDefault(s => s.Name == categoryName);
        }

        private static void GetParentCategoriesByNames()
        {
            var parentCategories = _context.ParentCategories.Where(s => s.Name == "Jedzenie").ToList();
        }

        private static void GetParentCategories()
        {
            using (var context = new ItemContext())
            {
                var parentCategories = context.ParentCategories.ToList();
                var GetParentCategoryQuery = context.ParentCategories;

                foreach (var category in GetParentCategoryQuery)
                {
                    Console.WriteLine(category.Name);
                }
            }

            
        }

        private static void InsertMultipleParentCategories()
        {
            var parentCategory = new ParentCategory { Name = "Mieszkanie", Description = "Wydatki związane z utrzymaniem domu/mieszkania" };
            var parentCategory2 = new ParentCategory { Name = "Samochód", Description = "Wydatki związane z samochodem" };
            using (var context = new ItemContext())
            {
                context.ParentCategories.AddRange(new List<ParentCategory> { parentCategory, parentCategory2 });
                context.SaveChanges();
            }
        }

        private static void InsertParentCategory()
        {
            var parentCategory = new ParentCategory { Name = "Jedzenie", Description = "Pieniądze wydane na jedzenie, napoje" };
            using (var context = new ItemContext())
            {
                context.ParentCategories.Add(parentCategory);
                context.SaveChanges();
            }
        }

    }
}
