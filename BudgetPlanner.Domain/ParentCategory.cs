using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanner.Domain
{
    public class ParentCategory : ClientChangeTracker
    {
        public ParentCategory()
        {
            Items = new List<Item>();
            CustomCategories = new List<CustomCategory>();
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<CustomCategory> CustomCategories { get; set; }

        public List<Item> Items { get; set; }
    }
}
