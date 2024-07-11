using add_migration.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace add_migration.Controllers
{
    public class StudentsController : Controller
    {
        private readonly DbContextClass _context;

        public StudentsController(DbContextClass context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var students = await _context.Student.ToListAsync();
            return Json(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Student.Add(student);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(student).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Student.FindAsync(id);
            if (student != null)
            {
                _context.Student.Remove(student);
                await _context.SaveChangesAsync();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }

}
