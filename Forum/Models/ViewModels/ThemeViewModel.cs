using Forum.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models.ViewModels
{
    public class ThemeViewModel
    {
        public IEnumerable<Update> Themes { get; set; }
    }
}
