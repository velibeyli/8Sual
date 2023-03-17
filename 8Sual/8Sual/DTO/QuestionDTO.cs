using _8Sual.Model;

namespace _8Sual.DTO
{
    public class QuestionDTO
    {
        public string Content { get; set; }
        public string FirstAnswer { get; set; }
        public string SecondAnswer { get; set; }
        public string ThirdAnswer { get; set; }
        public string FourthAnswer { get; set; }
        public int CategoryId { get; set; }
        public int AnswerId { get; set; }
    }
}
