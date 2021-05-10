﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC_Part_picker.Data;
using PC_Part_picker.Models;

namespace PC_Part_picker.Controllers
{
    public class BuildsController : Controller
    {
        private readonly PartPickerContext _context;

        public BuildsController(PartPickerContext context)
        {
            _context = context;
        }

        // GET: Builds
        public async Task<IActionResult> Index()
        {
            return View(await _context.Build.ToListAsync());
        }

        public async Task<IActionResult> AllBuildsPage()
        {
            return View(await _context.Build.ToListAsync());
        }
        public async Task<IActionResult> CompareBuildsPage()
        {
            return View(await _context.Build.ToListAsync());
        }

        public IActionResult CreateBuildPage()
        {
            return View("CreateBuild");
        }



        // GET: Builds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var build = await _context.Build
                .FirstOrDefaultAsync(m => m.Id == id);
            if (build == null)
            {
                return NotFound();
            }

            return View(build);
        }

        // GET: Builds/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Builds/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Rating,RatingCount,Price,Publication,Status")] Build build)
        {
            if (ModelState.IsValid)
            {
                _context.Add(build);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(build);
        }

        // GET: Builds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var build = await _context.Build.FindAsync(id);
            if (build == null)
            {
                return NotFound();
            }
            return View(build);
        }

        // POST: Builds/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Rating,RatingCount,Price,Publication,Status")] Build build)
        {
            if (id != build.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(build);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildExists(build.Id))
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
            return View(build);
        }

        // GET: Builds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var build = await _context.Build
                .FirstOrDefaultAsync(m => m.Id == id);
            if (build == null)
            {
                return NotFound();
            }

            return View(build);
        }

        // POST: Builds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var build = await _context.Build.FindAsync(id);
            _context.Build.Remove(build);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildExists(int id)
        {
            return _context.Build.Any(e => e.Id == id);
        }

        public IActionResult CpuList()
        {
            return View(_context.Cpu.ToList());
        }

        public IActionResult CoolerList()
        {
            return View(_context.Cooler.ToList());
        }

        public IActionResult MotherboardList()
        {
            return View(_context.Motherboard.ToList());
        }

        public IActionResult AddCpu(int? id)
        {
            //var part =  _context.Cpu
            //    .FirstOrDefaultAsync(m => m.Id == id);
            var buildId = GetUnfinishedBuild();
            var build = _context.Build
                .FirstOrDefault(m => m.Id == buildId);

            var cpu = _context.Cpu.Find(id);

            build.Cpu = cpu;          

            return View("CreateBuild", build);
        }

        public IActionResult AddCooler(int? id)
        {
            var buildId = GetUnfinishedBuild();
            var build = _context.Build
                .FirstOrDefault(m => m.Id == buildId);

            var cooler = _context.Cooler.Find(id);

            build.Cooler = cooler;

            return View("CreateBuild", build);
        }

        public IActionResult AddMotherboard(int? id)
        {
            var buildId = GetUnfinishedBuild();
            var build = _context.Build
                .FirstOrDefault(m => m.Id == buildId);

            var motherboard = _context.Motherboard.Find(id);

            build.Motherboard = motherboard;

            return View("CreateBuild", build);
        }

        public int GetUnfinishedBuild()
        {
            var build = _context.Build.Where(m => m.Status == "unfinished").FirstOrDefault();

            if (build == null)
            {
                build = new Build();
                build.Status = "unfinished";
                _context.Add(build);
                _context.SaveChanges();
            }
            return build.Id; 
        }

    }
}
