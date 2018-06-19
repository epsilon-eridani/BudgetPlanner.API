using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BudgetPlanner.API.Models
{
    public class CustomCategory
    {       
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        public int CategoryId { get; set; }

    }
}
