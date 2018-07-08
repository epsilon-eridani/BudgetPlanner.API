using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetPlanner.Domain
{
    public class Item : ClientChangeTracker
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public double Amount { get; set; }

        public bool IsExpense { get; set; }

        public DateTime Date { get; set; }

        public ParentCategory ParentCategory { get; set; }

        public int ParentCategoryId { get; set; }

        public string Description { get; set; }

        public ApplicationUser User { get; set; }

    }
}
