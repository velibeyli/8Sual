using _8Sual.Model;

namespace _8Sual.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public IEnumerable<Question> Questions { get; set; }
        public CategoryDTO(Category category)
        {
            Name = category.Name;
            Score = category.Score;
            Questions = category.Questions;
        }
    }
}
