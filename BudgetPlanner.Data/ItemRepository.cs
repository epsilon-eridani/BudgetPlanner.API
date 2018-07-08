using BudgetPlanner.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BudgetPlanner.Data
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationDbContext ApplicationDbContext) : base(ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public IEnumerable<Item> GetGreatestExpense(int count)
        {
            return _ApplicationDbContext.Items.OrderByDescending(c => c.Amount).Take(count).ToList();
        }



        public IEnumerable<Item> GetExpenses(int pageIndex, int pageSize)
        {
            return _ApplicationDbContext.Items
                .OrderBy(c => c.Date)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public string GetChartJson()
        {
            var labels = _ApplicationDbContext.Items
                .OrderBy(d => d.Date)
                .Select(x => new {x.Date, x.Amount})
                .ToList();

            var result = JsonConvert.SerializeObject(labels);

            return result;
        }

        public double CountExpenses()
        {
            throw new NotImplementedException();
        }

        public ApplicationDbContext _ApplicationDbContext;
    }
}
