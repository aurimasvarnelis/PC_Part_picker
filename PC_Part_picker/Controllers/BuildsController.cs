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
            var build = GetUnfinishedBuild();;
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

    }
}
