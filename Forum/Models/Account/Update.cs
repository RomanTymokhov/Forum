namespace Forum.Models.Account
{
    public class Update
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public string Theme { get; set; }
        public bool IsTheme { get; set; } = false;
        public string ThemeId { get; set; }

        public string UserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
