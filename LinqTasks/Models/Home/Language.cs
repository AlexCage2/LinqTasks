namespace LinqTasks.Models.Home
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public List<ProgrammingTask> Tasks { get; set; } = new();
    }
}
