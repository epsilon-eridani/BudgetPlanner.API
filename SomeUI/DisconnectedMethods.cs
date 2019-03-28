using BudgetPlanner.Domain;
using BudgetPlanner.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SomeUI
{
    internal static class DisconnectedMethods
    {
        private static void DisplayState(List<EntityEntry> es, string method)
        {
            Console.WriteLine(method);
            es.ForEach(e => Console.WriteLine(
                $"{e.Entity.GetType().Name} : {e.State.ToString()}"));
            Console.WriteLine();
        }

        public static void AddGraphAllNew()
        {
            var parentCategoryGraph = new ParentCategory
            {
                Name = "Kosmetyki",
                Description = "Wydatki na kosmetyki"
            };
            parentCategoryGraph.CustomCategories.Add(new CustomCategory
            { Name = "Perfumy", Description = "Wydatki na perfumy" });

            using(var context = new ItemContext())
            {
                context.ParentCategories.Add(parentCategoryGraph);

                var es = context.ChangeTracker.Entries().ToList();
                DisplayState(es, "AddGraphAllNew");
                
            }

        }
    }
}
