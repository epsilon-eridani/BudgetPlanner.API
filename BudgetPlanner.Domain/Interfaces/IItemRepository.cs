using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanner.Domain
{
    public interface IItemRepository : IRepository<Item>
    {
        IEnumerable<Item> GetGreatestExpense(int count);
        IEnumerable<Item> GetExpenses(int pageIndex, int pageSize);
        IEnumerable<ChartData> GetPieChartData(int[] categories);
        double CountExpenses();
    }
}
