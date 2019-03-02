using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Forum.Domain.Repositories;
using Forum.Models.Account;
using Forum.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    public class ForumController : Controller
    {
        private readonly IUpdateRepo updateRepo;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<AppUser> userManager;

        public ForumController(IUpdateRepo updateRepo, IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            this.updateRepo = updateRepo;
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Updates()
        {
            return View(new UpdatesViewModel { UpdateList = await updateRepo.ToListAsync() });
        }

        [HttpPost]
        public async Task<IActionResult> Update(string id)
        {
            return View(await updateRepo.ReturnUpdateAsync(id));
        }

        
        public IActionResult CreateTopic()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTopic(string topicName, string message, bool isTheme)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var updateId = Guid.NewGuid();

            var update = new Update
            {
                Theme = topicName,
                Message = message,
                IsTheme = isTheme,
                Id = updateId.ToString(),
                ThemeId = isTheme ? updateId.ToString() : string.Empty,
                UserId = user.Id
            };

            await updateRepo.AddUpdateAsync(update);

            return RedirectToAction("Updates", "Forum");
        }
    }
}