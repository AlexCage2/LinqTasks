using LinqTasks.Data;
using LinqTasks.Models.Home;
using LinqTasks.Models.Home.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LinqTasks.Controllers
{
    public class HomeController : Controller
    {
        /* Services */
        private readonly ILogger<HomeController> _logger;
        private DataContext _dbContext;

        /* Constructor */
        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _dbContext = context;
        }

        /* GET: Tasks */
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            IQueryable<ProgrammingTask> programmingTasksLevel1 = _dbContext
                .ProgrammingTasks
                .Include(task => task.Difficulty)
                .AsNoTracking();

            IndexViewModel indexViewModel = new IndexViewModel
            {
                ProgrammingTasksLevel = await programmingTasksLevel1.ToListAsync()
            };

            return View(indexViewModel);
        }

        /* GET: Create Task */
        [HttpGet("{action}")]
        public async Task<IActionResult> Create(int? difficultyId)
        {
            return await GetCreateViewAsync(difficultyId);
        }

        /* POST: Create Task */
        [HttpPost("{action}")]
        public async Task<IActionResult> Create(ProgrammingTask programmingTask)
        {
            if (programmingTask.DifficultyId == 1 && programmingTask.Result == null)
            {
                ModelState.AddModelError("Result", "Для задач уровня 1 необходимо добавить результат вывода");
            }

            if (!ModelState.IsValid)
            {
                return await GetCreateViewAsync(programmingTask.DifficultyId, true);
            }

            _dbContext.Add(programmingTask);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /* GET: Edit Task */
        [HttpGet("{action}")]
        public async Task<IActionResult> Edit(int? id)
        {
            return await GetEditViewAsync(id);
        }

        /* POST: Edit Task */
        [HttpPost("{action}")]
        public async Task<IActionResult> Edit(ProgrammingTask programmingTask)
        {
            if (programmingTask.DifficultyId == 1 && programmingTask.Result == null)
            {
                ModelState.AddModelError("Result", "Для задач уровня 1 необходимо добавить результат вывода");
            }

            if (!ModelState.IsValid)
            {
                return await GetEditViewAsync(programmingTask.Id, true);
            }

            _dbContext.Update(programmingTask);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /* POST: Delete Task */
        [HttpPost("{action}")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            ProgrammingTask programmingTask = new ProgrammingTask { Id = id.Value };
            _dbContext.Entry(programmingTask).State = EntityState.Deleted;
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /* Privacy Page */
        [Route("{action}")]
        public IActionResult Privacy()
        {
            return View();
        }

        /* Other Methods: */
        /* GetCreateViewAsync() */
        public async Task<IActionResult> GetCreateViewAsync(int? difficultyId, bool isFailedToValid = false)
        {
            IQueryable<Language> languages = _dbContext
                .Languages
                .OrderBy(language => language.Name);
            IQueryable<Difficulty> difficulties = _dbContext.Difficulties;

            CreateViewModel createViewModel = new CreateViewModel
            {
                IsInvalid = isFailedToValid,
                Languages = new SelectList(await languages.AsNoTracking().ToListAsync(), "Id", "Name"),
                Difficulties = new SelectList(await difficulties.AsNoTracking().ToListAsync(), "Id", "Name", difficultyId)
            };

            return View(createViewModel);
        }

        /* GetEditViewAsync() */
        public async Task<IActionResult> GetEditViewAsync(int? id, bool isFailedToValid = false)
        {
            if (id is null)
            {
                return NotFound();
            }

            ProgrammingTask? programmingTask = await _dbContext
                .ProgrammingTasks
                .AsNoTracking()
                .FirstOrDefaultAsync(task =>
                    task.Id == id);

            if (programmingTask is null)
            {
                return NotFound();
            }

            IQueryable<Language> languages = _dbContext.Languages;
            IQueryable<Difficulty> difficulties = _dbContext.Difficulties;

            var selectedLanguage = programmingTask!.LanguageId;
            var selectedDifficulty = programmingTask!.DifficultyId;

            EditViewModel editViewModel = new EditViewModel
            {
                IsInvalid = isFailedToValid,
                ProgrammingTask = programmingTask,
                Languages = new SelectList(await languages.ToListAsync(), "Id", "Name", selectedLanguage),
                Difficulties = new SelectList(await difficulties.ToListAsync(), "Id", "Name", selectedDifficulty)
            };

            return View(editViewModel);
        }
    }
}