using BudgetPlanner.Data;
using BudgetPlanner.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SomeUI
{
    class ModuleFour
    {
        #region initMethods
        private static ItemContext _context = new ItemContext();

        private static void RawSqlWithOutputParameters()
        {
            var procResult = new SqlParameter
            {
                ParameterName = "@procResult",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Direction = System.Data.ParameterDirection.Output,
                Size = 50
            };
            _context.Database.ExecuteSqlCommand(
                "exec FindLongestName @procResult OUT", procResult);
            Console.WriteLine($"Longest name: {procResult.Value}");
        }

        private static void PerformRawSqlQuery()
        {
            var customCategories = _context.CustomCategories.FromSql("SELECT * FROM CustomCategories")
                .OrderByDescending(s => s.Name)
                .Where(s => s.Name.Contains("o"))
                .ToList();

            foreach (var category in customCategories)
            {
                Console.WriteLine(category.Name + ": " + category.Description);
            }
        }

        private static void InsertCustomCategory()
        {
            var customCategory = new CustomCategory
            {
                Name = "Środki czyszczące",
                Description = "Chemia do domu",
                ParentCategoryId = GetParentCategoryId("Mieszkanie")
            };
            _context.CustomCategories.Add(customCategory);
            _context.SaveChanges();
        }

        private static void InsertCustomCategories()
        {
            var customCategoryFirst = new CustomCategory { Name = "Paliwo", Description = "Paliwo do mojego samochodu", ParentCategoryId = 3 };
            var customCategorySecond = new CustomCategory { Name = "Alkohol", Description = "Piwo, wino i inne", ParentCategoryId = 1 };

            _context.CustomCategories.AddRange(new List<CustomCategory> { customCategoryFirst, customCategorySecond });
            _context.SaveChanges();
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

        private static int GetParentCategoryId(string parentCategoryName)
        {
            var parentCategory = _context.ParentCategories.FirstOrDefault(s => s.Name == parentCategoryName);
            return parentCategory.ID;
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
        #endregion
    }
}
