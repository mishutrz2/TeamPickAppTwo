using Microsoft.AspNetCore.Identity;
using TeamPickAppTwo.Data.Enums;

namespace TeamPickAppTwo.Data.ViewSql
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public string? Nickname { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public PreferredFoot PreferredFoot { get; set; }

        public PreferredPosition PreferredPosition { get; set; }

        public ICollection<UserList> UserLists { get; set; } = new List<UserList>();
    }
}
