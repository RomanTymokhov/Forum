using Forum.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Domain.Repositories
{
    public interface IUpdateRepo
    {
        Task<Update> GetUpdateAsync(string id);
        Task AddUpdateAsync(Update update);
        Task<IList<Update>> ToListAsync();
        Task<IList<Update>> GetThemeListAsync();
        Task<IList<Update>> GetConcreteThemeListAsync(string id);
    }
}
