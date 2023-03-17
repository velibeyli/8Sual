namespace _8Sual.Options
{
    public class QuestionType
    {
        public int CategoryId { get; set; }
        public int Count { get; set; }
    }

    public class QuestionOptions
    {
        public Dictionary<string, QuestionType> QuestionTypes { get; set; }
    }
}
