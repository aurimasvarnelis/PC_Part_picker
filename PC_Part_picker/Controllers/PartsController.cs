using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PC_Part_picker.Data;
using PC_Part_picker.Models;
using PC_Part_picker.ViewModels;


namespace PC_Part_picker.Controllers
{
    public class PartsController : Controller
    {
        private readonly PartPickerContext _context;

        public PartsController(PartPickerContext context)
        {
            _context = context;
        }

        public IActionResult PartListPage()
        {
            PartViewModel partViewModel = new PartViewModel();
            partViewModel.Cpu = _context.Cpu.ToList();
            partViewModel.Cooler = _context.Cooler.ToList();
            partViewModel.Motherboard = _context.Motherboard.ToList();
            partViewModel.Ram = _context.Ram.ToList();
            partViewModel.Storage = _context.Storage.ToList();
            partViewModel.Gpu = _context.Gpu.ToList();
            partViewModel.Psu = _context.Psu.ToList();
            partViewModel.Case = _context.Case.ToList();
            return View(partViewModel);
        }

        public IActionResult ListPart(string partName)
        {
            if (partName == "cpu")
                return View("PartListPage", _context.Cpu.ToList());
            else if (partName == "cooler")
                return View("PartListPage", _context.Cooler.ToList());
            else if (partName == "motherboard")
                return View("PartListPage", _context.Motherboard.ToList());
            else if (partName == "ram")
                return View("PartListPage", _context.Ram.ToList());
            else if (partName == "storage")
                return View("PartListPage", _context.Storage.ToList());
            else if (partName == "gpu")
                return View("PartListPage", _context.Gpu.ToList());
            else if (partName == "psu")
                return View("PartListPage", _context.Psu.ToList());
            else if (partName == "case")
                return View("PartListPage", _context.Case.ToList());
            return NotFound();
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

        // GET: Parts/Create
        public IActionResult CreatePart(string partName)
        {
            if (partName == "cpu")
                return View("CreateCpu");
            else if (partName == "cooler")
                return View("CreateCooler");
            else if (partName == "motherboard")
                return View("CreateMotherboard");
            else if (partName == "ram")
                return View("CreateRam");
            else if (partName == "storage")
                return View("CreateStorage");
            else if (partName == "gpu")
                return View("CreateGpu");
            else if (partName == "psu")
                return View("CreatePsu");
            else if (partName == "case")
                return View("CreateCase");
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCPU([Bind("Id,Name,Model,Rating,Price,Manufacturer,Color,Cores,Frequency,Series,Consumption")] CPU cpu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cpu);
                _context.SaveChanges();
                return RedirectToAction(nameof(PartListPage));
            }
            return View("CreateCpu", cpu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateGPU([Bind("Id,Name,Model,Rating,Price,Manufacturer,Color,Memory,Frequency,MemoryType,Consumption")] GPU gpu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gpu);
                _context.SaveChanges();
                return RedirectToAction(nameof(PartListPage));
            }
            return View("CreateGpu", gpu);
        }

        public IActionResult EditPart(int? id, string partName)
        {
            if (partName == "cpu")
            {
                var part = _context.Cpu.Find(id);
                return View("EditCpu", part);
            }
            else if (partName == "cooler")
            {
                var part = _context.Cooler.Find(id);
                return View("EditCooler", part);
            }
            else if (partName == "motherboard")
            {
                var part = _context.Motherboard.Find(id);
                return View("EditMotherboard", part);
            }
            else if (partName == "ram")
            {
                var part = _context.Ram.Find(id);
                return View("EditRam", part);
            }
            else if (partName == "storage")
            {
                var part = _context.Storage.Find(id);
                return View("EditStorage", part);
            }
            else if (partName == "gpu")
            {
                var part = _context.Gpu.Find(id);
                return View("EditGpu", part);
            }
            else if (partName == "psu")
            {
                var part = _context.Psu.Find(id);
                return View("EditPsu", part);
            }
            else if (partName == "case")
            {
                var part = _context.Case.Find(id);
                return View("EditCase", part);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditCpu(int id, [Bind("Id,Name,Model,Rating,Price,Manufacturer,Color,Cores,Frequency,Series,Consumption")] CPU cpu)
        {
            if (ModelState.IsValid)
            {
                _context.Update(cpu);
                _context.SaveChanges();
                return RedirectToAction(nameof(PartListPage));
            }
            return View(cpu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditGpu(int id, [Bind("Id,Name,Model,Rating,Price,Manufacturer,Color,Memory,Frequency,MemoryType,Consumption")] GPU gpu)
        {
            if (ModelState.IsValid)
            {
                _context.Update(gpu);
                _context.SaveChanges();
                return RedirectToAction(nameof(PartListPage));
            }
            return View(gpu);
        }

        public IActionResult DeletePart(int? id, string partName)
        {
            if (partName == "cpu")
            {
                var part = _context.Cpu.Find(id);
                return View("DeleteCpu", part);
            }
            else if (partName == "cooler")
            {
                var part = _context.Cooler.Find(id);
                return View("DeleteCooler", part);
            }
            else if (partName == "motherboard")
            {
                var part = _context.Motherboard.Find(id);
                return View("DeleteMotherboard", part);
            }
            else if (partName == "ram")
            {
                var part = _context.Ram.Find(id);
                return View("DeleteRam", part);
            }
            else if (partName == "storage")
            {
                var part = _context.Storage.Find(id);
                return View("DeleteStorage", part);
            }
            else if (partName == "gpu")
            {
                var part = _context.Gpu.Find(id);
                return View("DeleteGpu", part);
            }
            else if (partName == "psu")
            {
                var part = _context.Psu.Find(id);
                return View("DeletePsu", part);
            }
            else if (partName == "case")
            {
                var part = _context.Case.Find(id);
                return View("DeleteCase", part);
            }
            return NotFound();
        }

        [HttpPost, ActionName("DeletePart")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmedPart(int id, string partName)
        {
            if (partName == "cpu")
            {
                var part = _context.Cpu.Find(id);
                _context.Cpu.Remove(part);
            }
            else if (partName == "cooler")
            {
                var part = _context.Cooler.Find(id);
                _context.Cooler.Remove(part);
            }
            else if (partName == "motherboard")
            {
                var part = _context.Motherboard.Find(id);
                _context.Motherboard.Remove(part);
            }
            else if (partName == "ram")
            {
                var part = _context.Ram.Find(id);
                _context.Ram.Remove(part);
            }
            else if (partName == "storage")
            {
                var part = _context.Storage.Find(id);
                _context.Storage.Remove(part);
            }
            else if (partName == "gpu")
            {
                var part = _context.Gpu.Find(id);
                _context.Gpu.Remove(part);
            }
            else if (partName == "psu")
            {
                var part = _context.Psu.Find(id);
                _context.Psu.Remove(part);
            }
            else if (partName == "case")
            {
                var part = _context.Case.Find(id);
                _context.Case.Remove(part);
            }          
            _context.SaveChanges();
            return RedirectToAction(nameof(PartListPage));
        }

    }
}
