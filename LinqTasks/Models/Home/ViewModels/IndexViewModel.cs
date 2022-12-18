using Microsoft.AspNetCore.Mvc.Rendering;

namespace LinqTasks.Models.Home.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<ProgrammingTask> ProgrammingTasksLevel { get; set; } = null!;
    }
}
