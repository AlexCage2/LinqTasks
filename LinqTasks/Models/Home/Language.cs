namespace LinqTasks.Models.Home
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<ProgrammingTask> Tasks { get; set; }
    }
}
