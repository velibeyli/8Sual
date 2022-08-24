

using System.Text.Json.Serialization;

namespace _8Sual.Model
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string FourthAnswer { get; set; }
        public int CategoryId { get; set; }
        public int AnswerId { get; set; }
        [JsonIgnore]
        public QuestionAnswer Answer { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
       
    }
}
