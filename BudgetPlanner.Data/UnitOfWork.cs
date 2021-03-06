﻿using BudgetPlanner.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetPlanner.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private Repository<ParentCategory> categoryRepository;
        private Repository<ApplicationUser> userRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            ItemRepository = new ItemRepository(_context);
        }

        public IRepository<ParentCategory> CategoryRepository
        {
            get
            {
                return categoryRepository = categoryRepository ?? new Repository<ParentCategory>(_context);
            }
        }

        public IRepository<ApplicationUser> UserRepository
        {
            get
            {
                return userRepository = userRepository ?? new Repository<ApplicationUser>(_context);
            }
        }

        public IItemRepository ItemRepository { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();    
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
