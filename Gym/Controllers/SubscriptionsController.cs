using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gym.Data;
using Gym.Models;
using Gym.Models.ViewModels;

namespace Gym.Controllers
{
    public class SubscriptionsController : Controller
    {
        private readonly GymContext _context;

        public SubscriptionsController(GymContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Purchase()
        {
            var branches = await _context.Branches.ToListAsync();
            var viewModel = new PurchaseSubscriptionViewModel
            {
                Branches = branches,
                AvailableDurations = new List<int> { 1, 3, 6, 12 },
                // BirthDate = DateTime.Today.AddYears(-18)
            };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Purchase(PurchaseSubscriptionViewModel model)
        {
            if (!ModelState.IsValid)
            {
                await PopulateViewModel(model);
                return View(model);
            }

            try
            {
                var client = await GetOrCreateClient(model);
                await CreateSubscription(model, client);
                TempData["SuccessMessage"] = "Subscription purchased successfully!";
                return RedirectToAction(nameof(Purchase));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error details: {ex.Message}");
                await PopulateViewModel(model);
                return View(model);
            }
        }

        private async Task<Client> GetOrCreateClient(PurchaseSubscriptionViewModel model)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.Email == model.Email);

            if (client != null) return client;

            int nextClientId = await _context.Clients.AnyAsync()
                ? await _context.Clients.MaxAsync(c => c.ClientId) + 1
                : 1;

            client = new Client
            {
                ClientId = nextClientId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                BirthDate = model.BirthDate
            };

            _context.Clients.Add(client);
            await _context.SaveChangesAsync();
            return client;
        }

        private async Task CreateSubscription(PurchaseSubscriptionViewModel model, Client client)
        {
            var subscription = new Subscription
            {
                Started = DateTime.Now,
                Expires = DateTime.Now.AddMonths(model.Duration),
                ClientId = client.ClientId,
                BranchId = model.BranchId
            };

            _context.Subscriptions.Add(subscription);
            await _context.SaveChangesAsync();
        }

        private async Task PopulateViewModel(PurchaseSubscriptionViewModel model)
        {
            model.Branches = await _context.Branches.ToListAsync();
            model.AvailableDurations = new List<int> { 1, 3, 6, 12 };
        }

        // GET: Subscriptions
        public async Task<IActionResult> Index()
        {
            var gymContext = _context.Subscriptions.Include(s => s.Branch).Include(s => s.Client);
            return View(await gymContext.ToListAsync());
        }

        // GET: Subscriptions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .Include(s => s.Branch)
                .Include(s => s.Client)
                .FirstOrDefaultAsync(m => m.SubscriptionId == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // GET: Subscriptions/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address");
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email");
            return View();
        }

        // POST: Subscriptions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubscriptionId,Started,Expires,ClientId,BranchId")] Subscription subscription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subscription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address", subscription.BranchId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", subscription.ClientId);
            return View(subscription);
        }

        // GET: Subscriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address", subscription.BranchId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", subscription.ClientId);
            return View(subscription);
        }

        // POST: Subscriptions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubscriptionId,Started,Expires,ClientId,BranchId")] Subscription subscription)
        {
            if (id != subscription.SubscriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subscription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubscriptionExists(subscription.SubscriptionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address", subscription.BranchId);
            ViewData["ClientId"] = new SelectList(_context.Clients, "ClientId", "Email", subscription.ClientId);
            return View(subscription);
        }

        // GET: Subscriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subscription = await _context.Subscriptions
                .Include(s => s.Branch)
                .Include(s => s.Client)
                .FirstOrDefaultAsync(m => m.SubscriptionId == id);
            if (subscription == null)
            {
                return NotFound();
            }

            return View(subscription);
        }

        // POST: Subscriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subscription = await _context.Subscriptions.FindAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubscriptionExists(int id)
        {
            return _context.Subscriptions.Any(e => e.SubscriptionId == id);
        }
    }
}
