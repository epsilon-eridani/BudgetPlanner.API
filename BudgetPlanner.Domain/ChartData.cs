using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BudgetPlanner.Domain
{
    public class ChartData
    {
        [Key]
        public string Labels { get; set; }
        public double Values { get; set; }
    }
}
