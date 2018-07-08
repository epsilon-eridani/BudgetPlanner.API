using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanner.Domain
{
    public class CurrentState
    {
        public Guid ID { get; set; }

        public DateTime Date { get; set; }

        public double TodayOutcome { get; set; }

        public double TodayIncome { get; set; }

        public double Balance { get; set; }

        public ApplicationUser User { get; set; }

        public Guid User_Guid { get; set; }
    }
}
