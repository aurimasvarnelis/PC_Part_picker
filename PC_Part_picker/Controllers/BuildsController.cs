using System;
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
            //var build = _context.Build
            //    .FirstOrDefault(m => m.Id == buildId);
            //var build = _context.Build.Find(buildId);
            var build = GetUnfinishedBuild();
            

            //build.Cpu = _context.Cpu.First();
            return View("CreateBuildPage", build);
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
            var build = GetUnfinishedBuild();

            var cpu = _context.Cpu.Find(id);

            build.Cpu = cpu;
            _context.Update(build);
            _context.SaveChanges();
            //return RedirectToAction(nameof(CreateBuildPage));
            return View("CreateBuildPage", build);
        }

        
        public IActionResult AddCooler(int? id)
        {
            var build = GetUnfinishedBuild();

            var cooler = _context.Cooler.Find(id);

            build.Cooler = cooler;
            _context.Update(build);
            _context.SaveChanges();

            //return RedirectToAction(nameof(CreateBuildPage), build);
            return View("CreateBuildPage", build);
        }

        
        public IActionResult AddMotherboard(int? id)
        {
            var build = GetUnfinishedBuild();

            var motherboard = _context.Motherboard.Find(id);

            build.Motherboard = motherboard;
            _context.Update(build);
            _context.SaveChanges();

            return RedirectToAction(nameof(CreateBuildPage));
            //return View("CreateBuildPage", build);
        }

        public IActionResult AddRam(int? id)
        {
            var build = GetUnfinishedBuild();

            var ram = _context.Ram.Find(id);

            build.Ram = ram;
            _context.Update(build);
            _context.SaveChanges();

            return RedirectToAction(nameof(CreateBuildPage));
        }

        public IActionResult AddStorage(int? id)
        {
            var build = GetUnfinishedBuild();

            var storage = _context.Storage.Find(id);

            build.Storage = storage;
            _context.Update(build);
            _context.SaveChanges();

            return RedirectToAction(nameof(CreateBuildPage));
        }

        public IActionResult AddGpu(int? id)
        {
            var build = GetUnfinishedBuild();

            var gpu = _context.Gpu.Find(id);

            build.Gpu = gpu;
            _context.Update(build);
            _context.SaveChanges();

            return RedirectToAction(nameof(CreateBuildPage));
        }

        public IActionResult AddPsu(int? id)
        {
            var build = GetUnfinishedBuild();

            var psu = _context.Psu.Find(id);

            build.Psu = psu;
            _context.Update(build);
            _context.SaveChanges();

            return RedirectToAction(nameof(CreateBuildPage));
        }

        public IActionResult AddCase(int? id)
        {
            var build = GetUnfinishedBuild();

            var pc_case = _context.Case.Find(id);

            build.Case = pc_case;
            _context.Update(build);
            _context.SaveChanges();

            return RedirectToAction(nameof(CreateBuildPage));
        }

        public Build GetUnfinishedBuild()
        {
            var build = _context.Build
                .Include(i => i.Cpu)
                .Include(i => i.Cooler)
                .Include(i => i.Motherboard)
                .Include(i => i.Ram)
                .Include(i => i.Storage)
                .Include(i => i.Gpu)
                .Include(i => i.Psu)
                .Include(i => i.Case)
                .Where(s => s.Status == "unfinished").FirstOrDefault();
    
            if (build == null)
            {
                build = new Build();
                build.Status = "unfinished";

                _context.Add(build);
                _context.SaveChanges();
            }
            return build; 
        }

    }
}
