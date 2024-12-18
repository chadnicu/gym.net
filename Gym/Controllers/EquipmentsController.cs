﻿using System;
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
    public class EquipmentsController : Controller
    {
        private readonly GymContext _context;

        public EquipmentsController(GymContext context)
        {
            _context = context;
        }

        // pagina cu paginari, sorting, filtering
        public async Task<IActionResult> Paginated(int? branch, string name, int page = 1,
            SortOption sortOrder = SortOption.NameAsc)
        {
            int pageSize = 10;

            // Filtering
            IQueryable<Equipment> equipments = _context.Equipments.Include(x => x.Branch);

            if (branch != null && branch != 0)
            {
                equipments = equipments.Where(p => p.BranchId == branch);
            }
            if (!string.IsNullOrEmpty(name))
            {
                equipments = equipments.Where(p => p.Name.Contains(name));
            }

            // Sorting
            equipments = sortOrder switch
            {
                SortOption.NameDesc => equipments.OrderByDescending(s => s.Name),
                SortOption.BrandAsc => equipments.OrderBy(s => s.Brand),
                SortOption.BrandDesc => equipments.OrderByDescending(s => s.Brand),
                SortOption.PriceAsc => equipments.OrderBy(s => s.Price),
                SortOption.PriceDesc => equipments.OrderByDescending(s => s.Price),
                SortOption.PurchasedAtAsc => equipments.OrderBy(s => s.PurchasedAt),
                SortOption.PurchasedAtDesc => equipments.OrderByDescending(s => s.PurchasedAt),
                SortOption.BranchAsc => equipments.OrderBy(s => s.Branch.City),
                SortOption.BranchDesc => equipments.OrderByDescending(s => s.Branch.City),
                _ => equipments.OrderBy(s => s.Name),
            };

            // Pagination
            var count = await equipments.CountAsync();
            var items = await equipments.Skip((page - 1) * pageSize).Take(pageSize).Select(e=>new EquipmentViewModel(e)).ToListAsync();

            // Create view model
            PaginationViewModel viewModel = new PaginationViewModel
            {
                EquipmentViewModel = items,
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModel(sortOrder),
                FilterViewModel = new FilterViewModel(await _context.Branches.ToListAsync(), branch, name)
            };

            return View(viewModel);
        }

        // GET: Equipments
        public async Task<IActionResult> Index()
        {
            var gymContext = _context.Equipments.Include(e => e.Branch).Select(e=>new EquipmentViewModel(e));
            return View(await gymContext.ToListAsync());
        }

        // GET: Equipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments
                .Include(e => e.Branch)
                .FirstOrDefaultAsync(m => m.EquipmentId == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(new EquipmentViewModel(equipment));
        }

        // GET: Equipments/Create
        public IActionResult Create()
        {
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address");
            return View();
        }

        // POST: Equipments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EquipmentId,Name,Brand,MuscleGroup,Price,PurchasedAt,BranchId")] Equipment equipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address", equipment.BranchId);
            return View(equipment);
        }

        // GET: Equipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address", equipment.BranchId);
            return View(equipment);
        }

        // POST: Equipments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EquipmentId,Name,Brand,MuscleGroup,Price,PurchasedAt,BranchId")] Equipment equipment)
        {
            if (id != equipment.EquipmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(equipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EquipmentExists(equipment.EquipmentId))
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
            ViewData["BranchId"] = new SelectList(_context.Branches, "BranchId", "Address", equipment.BranchId);
            return View(equipment);
        }

        // GET: Equipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipment = await _context.Equipments
                .Include(e => e.Branch)
                .FirstOrDefaultAsync(m => m.EquipmentId == id);
            if (equipment == null)
            {
                return NotFound();
            }

            return View(new EquipmentViewModel(equipment));
        }

        // POST: Equipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment != null)
            {
                _context.Equipments.Remove(equipment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EquipmentExists(int id)
        {
            return _context.Equipments.Any(e => e.EquipmentId == id);
        }
    }
}
