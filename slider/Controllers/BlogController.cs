using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using slider.Data;
using slider.Models;

namespace slider.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Blog> blogs = await _context.Blogs.Where(m => !m.SoftDeleted).ToListAsync();

            return View(blogs);
        }
    }
}
