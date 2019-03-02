using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Domain.Repositories;
using Forum.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class ForumController : Controller
    {
        public readonly IUpdateRepo updateRepo;

        public ForumController(IUpdateRepo updateRepo)
        {
            this.updateRepo = updateRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Themes()
        {
            var tvm = new ThemesViewModel { Themes = await updateRepo.ToListAsync() };

            return View(new ThemesViewModel { Themes = await updateRepo.ToListAsync() });
        }
    }
}