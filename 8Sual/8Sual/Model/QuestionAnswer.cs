using System.Text.Json.Serialization;

namespace _8Sual.Model
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string AnswerContent { get; set; }
        [JsonIgnore]
        public Question Question { get; set; }
        public int QuestionId { get; set; }
    }
}
