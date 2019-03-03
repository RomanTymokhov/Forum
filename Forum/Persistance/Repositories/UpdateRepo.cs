using Forum.Domain.Repositories;
using Forum.Models.Account;
using Forum.Persistance.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Persistance.Repositories
{
    public class UpdateRepo : IUpdateRepo
    {
        private readonly ForumContext forumContext;

        public UpdateRepo(ForumContext context)
        {
            forumContext = context;
        }

        public async Task<IList<Update>> ToListAsync() => 
            await forumContext.ForumUpdates.ToListAsync();

        public async Task<IList<Update>> GetTopicsAsync() =>
            await forumContext.ForumUpdates.Where(u => u.IsTheme).ToListAsync();

        public async Task<IList<Update>> GetConcreteTopicAsync(string id) =>
            await forumContext.ForumUpdates.Where(u => u.ThemeId == id).ToListAsync();

        public async Task<Update> GetUpdateAsync(string id) => 
            await forumContext.ForumUpdates.FirstOrDefaultAsync(u => u.Id == id);

        public async Task AddUpdateAsync(Update update)
        {
            await forumContext.ForumUpdates.AddAsync(update);
            await forumContext.SaveChangesAsync();
        }

        public async Task EditUpdateAsync(Update update)
        {
            forumContext.Update(update);
            await forumContext.SaveChangesAsync();
        }
    }
}
