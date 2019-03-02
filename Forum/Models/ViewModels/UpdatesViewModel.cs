using Forum.Models.Account;
using System.Collections.Generic;

namespace Forum.Models.ViewModels
{
    public class UpdatesViewModel
    {
        public IEnumerable<Update> UpdateList { get; set; }
    }
}
