using LinqTasks.Data;
using LinqTasks.Models.Home;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        /* GET: ProgrammingTasks */
        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            IQueryable<ProgrammingTask> programmingTasks = _dbContext
                .ProgrammingTasks
                .Include(task => 
                    task.Difficulty)
                .AsNoTracking();

            return View(await programmingTasks.ToListAsync());
        }

        /* GET: Create ProgrammingTask */
        [HttpGet("{action}")]
        public async Task<IActionResult> Create(int? difficultyId)
        {
            await PopulateDropDownListsAsync(difficultyId);
            return View(nameof(Create));
        }

        /* POST: Create ProgrammingTask */
        [HttpPost("{action}")]
        public async Task<IActionResult> Create(ProgrammingTask programmingTask)
        {
            if (programmingTask.DifficultyId == 1 && programmingTask.Result.IsNullOrEmpty())
            {
                ModelState.AddModelError("Result", "Для задач уровня 1 необходимо добавить результат вывода");
            }

            if (!ModelState.IsValid)
            {
                await PopulateDropDownListsAsync(programmingTask.DifficultyId);
                ViewData["isFailedToValid"] = true;
                return View(nameof(Create));
            }

            _dbContext.Add(programmingTask);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /* GET: Edit ProgrammingTask */
        [HttpGet("{action}")]
        public async Task<IActionResult> Edit(int? id)
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

            await PopulateDropDownListsAsync(programmingTask.DifficultyId);
            return View(programmingTask);
        }

        /* POST: Edit ProgrammingTask */
        [HttpPost("{action}")]
        public async Task<IActionResult> Edit(ProgrammingTask programmingTask)
        {
            if (programmingTask.DifficultyId == 1 && programmingTask.Result == null)
            {
                ModelState.AddModelError("Result", "Для задач уровня 1 необходимо добавить результат вывода");
            }

            if (!ModelState.IsValid)
            {
                await PopulateDropDownListsAsync(programmingTask.DifficultyId);
                ViewData["isFailedToValid"] = true;
                return View(programmingTask);
            }

            _dbContext.Update(programmingTask);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        /* POST: Delete ProgrammingTask */
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

        /* Private Methods: */
        /* PopulateSelectListsToCreateViewAsync() */
        private async Task PopulateDropDownListsAsync(int? selectedDifficultyId)
        {
            IQueryable<Language> languages = _dbContext.Languages
                .OrderBy(language =>
                    language.Name);

            IQueryable<Difficulty> difficulties = _dbContext.Difficulties;

            selectedDifficultyId ??= 1;
            Difficulty selectedDifficulty = await _dbContext.Difficulties.FirstAsync(difficulty => difficulty.Id == selectedDifficultyId.Value);

            ViewData["Languages"] = new SelectList(languages.AsNoTracking(), "Id", "Name");
            ViewData["Difficulties"] = new SelectList(difficulties.AsNoTracking(), "Id", "Name", selectedDifficulty);
        }
    }
}