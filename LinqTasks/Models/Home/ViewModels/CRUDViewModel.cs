using Microsoft.AspNetCore.Mvc.Rendering;

namespace LinqTasks.Models.Home.ViewModels
{
    public abstract class CRUDViewModel
    {
        public bool IsInvalid { get; set; }
        public ProgrammingTask? ProgrammingTask { get; set; }
        public SelectList Languages { get; set; } = new SelectList(new List<Language>(), "Id", "Name");
        public SelectList Difficulties { get; set; } = new SelectList(new List<Difficulty>(), "Id", "Name");
    }
}
