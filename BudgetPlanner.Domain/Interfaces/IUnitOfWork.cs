using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanner.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository ItemRepository { get; }

        IRepository<ParentCategory> CategoryRepository { get; }

        IRepository<ApplicationUser> UserRepository { get; }

        int Complete();
    }
}
