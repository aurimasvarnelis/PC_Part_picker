﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC_Part_picker.Data;
using PC_Part_picker.Models;
using System.Web;

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

        public IActionResult AllBuildsPage()
        {
            var allBuilds = _context.Build
                .Include(i => i.Cpu)
                .Include(i => i.Cooler)
                .Include(i => i.Motherboard)
                .Include(i => i.Ram)
                .Include(i => i.Storage)
                .Include(i => i.Gpu)
                .Include(i => i.Psu)
                .Include(i => i.Case).Where(s => s.Status == "finished").ToList();
            return View("AllBuildsPage", allBuilds);
        }

        public IActionResult CompareBuildsPage()
        {
            int firstBuild;
            int secondBuild;
            if (TempData["CompareFirstBuild"] != null)
            {
                firstBuild = (int)TempData["CompareFirstBuild"];
            }
            else{
                firstBuild = -1;
            }
            if (TempData["CompareSecondBuild"] != null)
            {
                secondBuild = (int)TempData["CompareSecondBuild"];
            }
            else
            {
                secondBuild = -1;
            }
            
            ViewBag.CompareFirstBuild = _context.Build.Include(i => i.Cpu)
                .Include(i => i.Cooler)
                .Include(i => i.Motherboard)
                .Include(i => i.Ram)
                .Include(i => i.Storage)
                .Include(i => i.Gpu)
                .Include(i => i.Psu)
                .Include(i => i.Case).Where(s => s.Status == "finished").FirstOrDefault(x => x.Id == firstBuild);
            //.Find(TempData["CompareFirstBuild"]);
            ViewBag.CompareSecondBuild = _context.Build.Include(i => i.Cpu)
                .Include(i => i.Cooler)
                .Include(i => i.Motherboard)
                .Include(i => i.Ram)
                .Include(i => i.Storage)
                .Include(i => i.Gpu)
                .Include(i => i.Psu)
                .Include(i => i.Case).Where(s => s.Status == "finished").FirstOrDefault(x => x.Id == secondBuild);
               // .Find(TempData["CompareSecondBuild"]).Include(i => i.Cpu);
            return View("CompareBuildsPage");
        }
        public IActionResult BuildsPage(string buildPlace, int? first, int? second)
        {
            if (buildPlace.CompareTo("first") == 0) {
                ViewBag.ComparePlace = "first";
            }
            else
            {
                ViewBag.ComparePlace = "second";
            }
            ViewBag.CompareFirstBuildId = first;
            ViewBag.CompareSecondBuildId = second;

            var allBuilds = _context.Build.Include(i => i.Cpu)
                .Include(i => i.Cooler)
                .Include(i => i.Motherboard)
                .Include(i => i.Ram)
                .Include(i => i.Storage)
                .Include(i => i.Gpu)
                .Include(i => i.Psu)
                .Include(i => i.Case).Where(s => s.Status == "finished").ToList();
            return View("ListBuilds", allBuilds);
        }
        public IActionResult AddBuild(int? id, string place, int? first, int? second)
        {
            if (place.CompareTo("first") == 0)
            {
                TempData["CompareFirstBuild"] = id;
                TempData["CompareSecondBuild"] = second;
            }
            else
            {
                TempData["CompareFirstBuild"] = first;
                TempData["CompareSecondBuild"] = id;
            }
            return RedirectToAction(nameof(CompareBuildsPage));
        }

        public IActionResult GenerateBuildPage()
        {
            ViewBag.GeneratedBuild = null;
            return View("BuildGenerationPage");
        }

        [HttpPost]
        public IActionResult GenerateBuild(BuildGenerationSelect option)
        {
            var number = option.Id;
            int from = 0;
            int to = 2000;
            switch (number)
            {
                case 1:
                    from = 0;
                    to = 100;
                    break;
                case 2:
                    from = 100;
                    to = 500;
                    break;
                case 3:
                    from = 500;
                    to = 1000;
                    break;
                case 4:
                    from = 1000;
                    to = 10000;
                    break;
            }

            Build build = _context.Build
                .Include(i => i.Cpu)
                .Include(i => i.Cooler)
                .Include(i => i.Motherboard)
                .Include(i => i.Ram)
                .Include(i => i.Storage)
                .Include(i => i.Gpu)
                .Include(i => i.Psu)
                .Include(i => i.Case)
                .Where(s => s.Status == "finished")
                .Where(s => s.Price >= from)
                .Where(s => s.Price <= to)
                .OrderByDescending(s => s.Rating)
                .FirstOrDefault();
            ViewBag.GeneratedBuild = build;
            if(build == null)
            {
                ViewBag.GenerateBuildError = "No matching build found";
                TempData["GenerateError"] = "No matching build found";
            }
            else
            {
                ViewBag.GenerateBuildError = "";
                TempData["GenerateError"] = null;
            }
            return View("BuildGenerationPage");
        }

        public IActionResult CreateBuildPage()
        {      
            var build = GetUnfinishedBuild();
            return View("CreateBuildPage", build);
        }
        private bool BuildExists(int id)
        {
            return _context.Build.Any(e => e.Id == id);
        }

        public IActionResult ListPart(string partName)
        {
            if (partName == "cpu")
                return View("ListCpu",_context.Cpu.ToList());
            else if (partName == "cooler")
                return View("ListCooler", _context.Cooler.ToList());
            else if (partName == "motherboard")
                return View("ListMotherboard", _context.Motherboard.ToList());
            else if (partName == "ram")
                return View("ListRam", _context.Ram.ToList());
            else if (partName == "storage")
                return View("ListStorage", _context.Storage.ToList());
            else if (partName == "gpu")
                return View("ListGpu", _context.Gpu.ToList());
            else if (partName == "psu")
                return View("ListPsu", _context.Psu.ToList());
            else if (partName == "case")
                return View("ListCase", _context.Case.ToList());
            return NotFound();
        }
        public IActionResult AddPart(int? id, string partName)
        {
            var build = GetUnfinishedBuild();

            if (partName == "cpu")
            {
                var part = _context.Cpu.Find(id);
                build.Cpu = part;
            }
            else if (partName == "cooler")
            {
                var part = _context.Cooler.Find(id);
                build.Cooler = part;
            }
            else if (partName == "motherboard")
            {
                var part = _context.Motherboard.Find(id);
                build.Motherboard = part;
            }
            else if (partName == "ram")
            {
                var part = _context.Ram.Find(id);
                build.Ram = part;
            }
            else if (partName == "storage")
            {
                var part = _context.Storage.Find(id);
                build.Storage = part;
            }
            else if (partName == "gpu")
            {
                var part = _context.Gpu.Find(id);
                build.Gpu = part;
            }
            else if (partName == "psu")
            {
                var part = _context.Psu.Find(id);
                build.Psu = part;
            }
            else if (partName == "case")
            {
                var part = _context.Case.Find(id);
                build.Case = part;
            }

            _context.Update(build);
            _context.SaveChanges();

            return RedirectToAction(nameof(CreateBuildPage));
        }
        public IActionResult DetailsPart(int? id, string partName)
        {
            if (partName == "cpu")
            {
                var part = _context.Cpu
                    .FirstOrDefault(m => m.Id == id);
                return View("DetailsCpu", part);
            }       
            else if (partName == "cooler")
            {
                var part = _context.Cooler
                    .FirstOrDefault(m => m.Id == id);
                return View("DetailsCooler", part);
            }
            else if (partName == "motherboard")
            {
                var part = _context.Motherboard
                    .FirstOrDefault(m => m.Id == id);
                return View("DetailsMotherboard", part);
            }
            else if (partName == "ram")
            {
                var part = _context.Ram
                    .FirstOrDefault(m => m.Id == id);
                return View("DetailsRam", part);
            }
            else if (partName == "storage")
            {
                var part = _context.Storage
                    .FirstOrDefault(m => m.Id == id);
                return View("DetailsStorage", part);
            }
            else if (partName == "gpu")
            {
                var part = _context.Gpu
                    .FirstOrDefault(m => m.Id == id);
                return View("DetailsGpu", part);
            }
            else if (partName == "psu")
            {
                var part = _context.Psu
                    .FirstOrDefault(m => m.Id == id);
                return View("DetailsPsu", part);
            }
            else if (partName == "case")
            {
                var part = _context.Case
                    .FirstOrDefault(m => m.Id == id);
                return View("DetailsCase", part);
            }

            return NotFound();
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
                .Where(s => s.Status == "unfinished")
                .FirstOrDefault();
    
            if (build == null)
            {
                build = new Build();
                build.Status = "unfinished";

                _context.Add(build);
                _context.SaveChanges();
            }
            return build; 
        }
        public IActionResult DeletePart(int? id, string partName)
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
                .FirstOrDefault(m => m.Id == id);

            if(partName == "cpu")
                build.Cpu = null;
            else if (partName == "cooler")
                build.Cooler = null;
            else if (partName == "motherboard")
                build.Motherboard = null;
            else if (partName == "ram")
                build.Ram = null;
            else if (partName == "storage")
                build.Storage = null;
            else if (partName == "gpu")
                build.Gpu = null;
            else if (partName == "psu")
                build.Psu = null;
            else if (partName == "case")
                build.Case = null;

            _context.Update(build);
            _context.SaveChanges();

            return RedirectToAction(nameof(CreateBuildPage));
        }



        public IActionResult FinishBuild()
        {
            var build = GetUnfinishedBuild();
            if(build.Cpu != null && build.Cooler != null && build.Motherboard != null && build.Ram != null 
                && build.Storage != null && build.Gpu != null && build.Psu != null && build.Case != null)
            {
                build.Status = "finished";
                build.Price = build.Cpu.Price +
                    build.Cooler.Price +
                    build.Motherboard.Price +
                    build.Ram.Price +
                    build.Storage.Price +
                    build.Gpu.Price +
                    build.Psu.Price +
                    build.Case.Price;
                _context.Update(build);
                _context.SaveChanges();
                TempData["Success"] = "Build was saved";
            }
            else
            {
                TempData["Error"] = "Not all parts selected";   
            }
            
            return RedirectToAction(nameof(CreateBuildPage));
        }

        public IActionResult RecommendPart(string partName)
        {
            var build = GetUnfinishedBuild();
            if (partName == "cpu")
            {
                return View("ListCpu", _context.Cpu.ToList().OrderByDescending(s => s.Rating));
            }
            return RedirectToAction(nameof(CreateBuildPage));
        }

        /*public List<object> GetUsedParts(string partName)
        {
            var builds = _context.Build
                .Include(i => i.Cpu)
                .Include(i => i.Cooler)
                .Include(i => i.Motherboard)
                .Include(i => i.Ram)
                .Include(i => i.Storage)
                .Include(i => i.Gpu)
                .Include(i => i.Psu)
                .Include(i => i.Case)
                .Where(s => s.Status == "finished")
                .ToList();
            
            if (partName == "cpu")
            {
                var parts = builds
                    .GroupBy(x => x.Cpu.Id)
                    .OrderByDescending(g => g.Count())
                    .Select(x => x.Key)
                    .ToList();
                return parts;
                //return View("ListCpu", _context.Cpu.ToList().OrderByDescending(s => s.Rating));
            }
            //return RedirectToAction(nameof(CreateBuildPage));
        }*/

    }
}
