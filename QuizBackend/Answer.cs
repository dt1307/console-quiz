namespace QuizBackend
{
    public class Answer
    {
        public int Id { get; set; }
        public bool IsCorrect { get; set; }
        public string Text { get; set; }
        public int DisplayOrder { get; set; }
    }
}