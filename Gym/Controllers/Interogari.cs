using Gym.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Gym.Controllers
{
    public class Interogari : Controller
    {
        private readonly GymContext _context;

        public Interogari(GymContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> One()
        {
            var gymContext = _context.Equipments.Include(e => e.Branch).Where(e => e.Branch.Address == "Strada Socoleni 7");
            return View(await gymContext.ToListAsync());
        }

        public async Task<IActionResult> Two()
        {
            var gymContext = _context.Equipments.Include(e => e.Branch).Where(e => e.PurchasedAt.Year < 2024);
            return View(await gymContext.ToListAsync());
        }

        public async Task<IActionResult> Three()
        {
            var gymContext = _context.Equipments.Include(e => e.Branch).Where(e => e.MuscleGroup == "Chest");
            return View(await gymContext.ToListAsync());
        }
        public async Task<IActionResult> Four()
        {
            var currentDate = DateTime.Now;
            var gymContext = _context.Clients.Where(c =>
             (currentDate.Year - c.BirthDate.Year > 32) ||
           (currentDate.Year - c.BirthDate.Year == 32 &&
           (c.BirthDate.Month < currentDate.Month ||
            (c.BirthDate.Month == currentDate.Month && c.BirthDate.Day <= currentDate.Day)))
            );
            return View(await gymContext.ToListAsync());
        }

        public async Task<IActionResult> Five(int age = 18)
        {
            ViewData["SelectedAge"] = age;

            var currentDate = DateTime.Now;
            var gymContext = _context.Clients.Where(c => !(
             (currentDate.Year - c.BirthDate.Year > age) ||
           (currentDate.Year - c.BirthDate.Year == age &&
           (c.BirthDate.Month < currentDate.Month ||
            (c.BirthDate.Month == currentDate.Month && c.BirthDate.Day <= currentDate.Day)))
            ));
            return View(await gymContext.ToListAsync());
        }

        public async Task<IActionResult> Six()
        {
            var gymContext = _context.Branches.Include(b => b.Equipments)
                .Where(b => b.City == "Chișinău");
            return View(await gymContext.ToListAsync());
        }

        public async Task<IActionResult> Seven()
        {
            var gymContext = _context.Branches.Include(b => b.Equipments)
                .Where(b => b.Founded.Year == 2017);
            return View(await gymContext.ToListAsync());
        }

        public async Task<IActionResult> Eight()
        {
            var gymContext = _context.Clients.Include(c => c.Subscriptions)
                .Where(c => c.Subscriptions.Any(s => s.Expires > DateTime.Now));
            return View(await gymContext.ToListAsync());
        }

        public async Task<IActionResult> Nine(string firstName = "Nicolae")
        {
            ViewData["SelectedName"] = firstName;

            var gymContext = _context.Clients
                .Where(c => c.FirstName == firstName);
            return View(await gymContext.ToListAsync());
        }

        public async Task<IActionResult> Ten(string searchString = "")
        {
            ViewData["SelectedString"] = searchString;

            var gymContext = _context.Equipments
                .Where(e => e.Name.Contains(searchString));
            return View(await gymContext.ToListAsync());
        }

    }
}