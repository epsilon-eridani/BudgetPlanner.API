using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanner.Domain
{
    public class ParentCategory
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<CustomCategory> CustomCategories { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
