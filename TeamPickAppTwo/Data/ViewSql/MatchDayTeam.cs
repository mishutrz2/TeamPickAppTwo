namespace TeamPickAppTwo.Data.ViewSql
{
    public class MatchDayTeam
    {
        public Guid MatchDayId { get; set; }
        public MatchDay MatchDay { get; set; }

        public Guid TeamId { get; set; }
        public Team Team { get; set; }
    }
}
