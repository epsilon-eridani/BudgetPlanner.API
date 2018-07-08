using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BudgetPlanner.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BudgetPlanner.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly IItemRepository _itemRepository;

        public HomeController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }


        public IActionResult Index()
        {
            return View(_itemRepository);
        }
    }
}