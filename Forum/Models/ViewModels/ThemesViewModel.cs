using Forum.Models.Account;
using System.Collections.Generic;

namespace Forum.Models.ViewModels
{
    public class ThemesViewModel
    {
        public IEnumerable<Update> Themes { get; set; }
    }
}
