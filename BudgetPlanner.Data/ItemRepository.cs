using BudgetPlanner.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        public double CountExpenses()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ChartData> GetPieChartData(int[] categories)
        {
            var tvp = new TableValuedParameterBuilder("dbo.ArrayInt", new SqlMetaData("CategoryId", SqlDbType.Int))
            .AddRow(categories)
            .CreateParameter("p0");

            var pieChartData = _ApplicationDbContext.ChartData.FromSql($"EXEC GetTotalPerCategories @p0", tvp).ToList();
            return pieChartData;
        }

        public ApplicationDbContext _ApplicationDbContext;
    }
}
