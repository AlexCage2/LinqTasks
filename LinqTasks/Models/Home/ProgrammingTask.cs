using System.ComponentModel.DataAnnotations;

namespace LinqTasks.Models.Home
{
    public class ProgrammingTask
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Условие задачи")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Код решения")]
        public string Code { get; set; }
        public string Result { get; set; }
        public int LanguageId { get; set; }
        public int DifficultyId { get; set; }

        public Language Language { get; set; }
        public Difficulty Difficulty { get; set; }

    }
}
