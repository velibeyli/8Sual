namespace _8Sual.Model
{
    public class Winner
    {
        public int Id { get; set; }
        public DateTime WinningDate { get; set; }
        public int Score { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
