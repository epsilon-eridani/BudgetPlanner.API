using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.API.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }

        public int Category { get; set; }

        public double Amount { get; set; }

        public bool IsExpense { get; set; }
        
        public DateTime Date { get; set; }

        public string Description { get; set; }    
    }
}
