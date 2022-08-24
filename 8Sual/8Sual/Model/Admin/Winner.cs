using System.Text.Json.Serialization;

namespace _8Sual.Model.Admin
{
    public class Winner
    {
        public int Id { get; set; }
        public DateTime WinningDate { get; set; }
        public int Score { get; set; }
        public int UserId { get; set; }
        [JsonIgnore]
        public User? User { get; set; }
    }
}
