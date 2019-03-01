using Forum.Domain.Repositories;
using Forum.Models.Account;
using Forum.Persistance.Contexts;
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

        public async Task AddUpdate(Update update)
        {
            await forumContext.ForumUpdates.AddAsync(update);
            await forumContext.SaveChangesAsync();
        }
    }
}
