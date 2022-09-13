using _8Sual.Model.Admin;

namespace _8Sual.DTO
{
    public class StatisticDTO
    {
        public DateTime Gamedate { get; set; }
        public int CorrectAnswer { get; set; }
        public int Score { get; set; }
        public StatisticDTO(Statistic statistic)
        {
            Gamedate = statistic.Gamedate;
            Score = statistic.Score;
            CorrectAnswer = statistic.CorrectAnswer;
        }
        public StatisticDTO()
        {

        }
    }
}
