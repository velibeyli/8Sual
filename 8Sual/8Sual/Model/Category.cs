using System.Text.Json.Serialization;

namespace _8Sual.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        [JsonIgnore]
        public IEnumerable<Question> Questions { get; set; }
    }
}
