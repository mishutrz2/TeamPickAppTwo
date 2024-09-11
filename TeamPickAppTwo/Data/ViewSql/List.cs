namespace TeamPickAppTwo.Data.ViewSql
{
    public class List
    {
        public Guid ListId { get; set; }

        public string? Name { get; set; }

        public string? Location { get; set; }

        public ICollection<UserList> UserLists { get; set; } = new List<UserList>();
    }
}
