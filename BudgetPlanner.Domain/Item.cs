using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BudgetPlanner.Domain
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public double Amount { get; set; }

        public bool IsExpense { get; set; }

        public DateTime Date { get; set; }

        public CustomCategory CustomCategory { get; set; }

        public int CustomCategoryId { get; set; }

        public ParentCategory ParentCategory { get; set; }

        public int ParentCategoryId { get; set; }

        public string Description { get; set; }


    }
}
