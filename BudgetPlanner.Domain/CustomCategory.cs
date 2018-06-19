using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetPlanner.Domain
{
    public class CustomCategory
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ParentCategory ParentCategory { get; set; }

        public int ParentCategoryId { get; set; }

        public ICollection<Item> Items { get; set; }

    }
}
