using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanner.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository ItemRepository { get; }

        IRepository<ParentCategory> CategoryRepository { get; }

        int Complete();
    }
}
