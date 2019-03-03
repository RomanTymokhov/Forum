using Forum.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forum.Domain.Repositories
{
    public interface IUpdateRepo
    {
        Task<Update> GetUpdateAsync(string id);
        Task AddUpdateAsync(Update update);
        Task EditUpdateAsync(Update update);
        Task<IList<Update>> ToListAsync();
        Task<IList<Update>> GetTopicsAsync();
        Task<IList<Update>> GetConcreteTopicAsync(string id);
    }
}
