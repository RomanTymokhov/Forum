using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Forum.Domain.Repositories;
using Forum.Models.Account;
using Forum.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

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
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var updLst = await updateRepo.GetTopicsAsync();
                return View(new UpdatesViewModel { UpdateList = updLst });
            }
            else return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Update(string id)
        {
            var updLst = await updateRepo.GetConcreteTopicAsync(id);
            return View(new UpdatesViewModel { UpdateList = updLst });
        }

        [Authorize]
        public IActionResult CreateUpdate()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateUpdate(string topicName, string message, bool isTheme, string themeId)
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var updateId = Guid.NewGuid();

            var update = new Update
            {
                Theme = isTheme ? topicName : string.Empty,
                Message = message,
                IsTheme = isTheme,
                Id = updateId.ToString(),
                ThemeId = isTheme ? updateId.ToString() : themeId,
                UserId = user.Id
            };

            await updateRepo.AddUpdateAsync(update);

            return RedirectToAction("UpdateInfo", new { id = updateId.ToString() });
        }

        [Authorize]
        public async Task<IActionResult> UpdateInfo(string id)
        {
            var updt = await updateRepo.GetUpdateAsync(id);

            return View(updt);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditUpdate(string id)
        {
            var updt = await updateRepo.GetUpdateAsync(id);

            return View(updt);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditUpdate2(string id, string message)
        {
            var updt = await updateRepo.GetUpdateAsync(id);
            updt.Message = message;
            await updateRepo.EditUpdateAsync(updt);

            return RedirectToAction("UpdateInfo", new { id = updt.Id });
        }
    }
}