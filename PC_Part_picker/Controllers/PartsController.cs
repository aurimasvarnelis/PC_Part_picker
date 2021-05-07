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
    public class PartsController : Controller
    {
        private readonly PartPickerContext _context;

        public PartsController(PartPickerContext context)
        {
            _context = context;
        }

        // GET: Parts
        public IActionResult Index()
        {
            /*CPU cpu = new List<CPU>()
            {
                Name = "ryzen"
            };
            GPU gpu = new GPU()
            {
                Name = "gefroce"
            };
            PartViewModel partViewModel = new PartViewModel()
            {
                CPU = cpu,
                GPU = gpu

            };*/
            PartViewModel partViewModel = new PartViewModel();
            partViewModel.CPU = _context.Cpu.ToList();
            partViewModel.GPU = _context.Gpu.ToList();
            return View(partViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> _ListCPU()
        {
            return View("Index", _context.Cpu.ToList());
        }
        [HttpGet]
        public async Task<IActionResult> _ListGPU()
        {
            return View("Index", _context.Gpu.ToList());
        }

        // GET: Parts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Cpu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        public async Task<IActionResult> _DetailsCPU(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpu = await _context.Cpu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cpu == null)
            {
                return NotFound();
            }

            return View(cpu);
        }

        public async Task<IActionResult> _DetailsGPU(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpu == null)
            {
                return NotFound();
            }

            return View(gpu);
        }

        // GET: Parts/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Parts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Model,Description,Rating,Price,Manufacturer,Color")] Part part)
        {
            if (ModelState.IsValid)
            {
                _context.Add(part);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(part);
        }

        // GET: Parts/Create
        public async Task<IActionResult> _CreateCPU()
        {
            return PartialView("_CreateCPU");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _CreateCPU([Bind("Id,Name,Model,Description,Rating,Price,Manufacturer,Color,Cores,Frequency,Series,Consumption")] CPU cpu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cpu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return PartialView(cpu);
        }

        // GET: Parts/Create
        public IActionResult CreateGPU()
        {
            return View("_CreateGPU");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _CreateGPU([Bind("Id,Name,Model,Description,Rating,Price,Manufacturer,Color,Memory,Frequency,MemoryType,Consumption")] GPU gpu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gpu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gpu);
        }

        // GET: Parts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Cpu.FindAsync(id);
            if (part == null)
            {
                return NotFound();
            }
            return View(part);
        }

        // POST: Parts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Model,Description,Rating,Price,Manufacturer,Color")] Part part)
        {
            if (id != part.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(part);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CPUExists(part.Id))
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
            return View(part);
        }

        public async Task<IActionResult> _EditCPU(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpu = await _context.Cpu.FindAsync(id);
            if (cpu == null)
            {
                return NotFound();
            }
            return View(cpu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditCPU(int id, [Bind("Id,Name,Model,Description,Rating,Price,Manufacturer,Color,Cores,Frequency,Series,Consumption")] CPU cpu)
        {
            if (id != cpu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cpu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CPUExists(cpu.Id))
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
            return View(cpu);
        }

        public async Task<IActionResult> _EditGPU(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpu.FindAsync(id);
            if (gpu == null)
            {
                return NotFound();
            }
            return View(gpu);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _EditGPU(int id, [Bind("Id,Name,Model,Description,Rating,Price,Manufacturer,Color,Memory,Frequency,MemoryType,Consumption")] GPU gpu)
        {
            if (id != gpu.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gpu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CPUExists(gpu.Id))
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
            return View(gpu);
        }

        // GET: Parts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var part = await _context.Cpu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (part == null)
            {
                return NotFound();
            }

            return View(part);
        }

        public async Task<IActionResult> _DeleteCPU(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cpu = await _context.Cpu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cpu == null)
            {
                return NotFound();
            }

            return View(cpu);
        }

        public async Task<IActionResult> _DeleteGPU(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gpu = await _context.Gpu
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gpu == null)
            {
                return NotFound();
            }

            return View(gpu);
        }

        // POST: Parts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var part = await _context.Cpu.FindAsync(id);
            _context.Cpu.Remove(part);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("_DeleteCPU")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _DeleteConfirmedCPU(int id)
        {
            var cpu = await _context.Cpu.FindAsync(id);
            _context.Cpu.Remove(cpu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost, ActionName("_DeleteGPU")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> _DeleteConfirmedGPU(int id)
        {
            var gpu = await _context.Gpu.FindAsync(id);
            _context.Gpu.Remove(gpu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PartExists(int id)
        {
            return _context.Cpu.Any(e => e.Id == id);
        }

        private bool CPUExists(int id)
        {
            return _context.Cpu.Any(e => e.Id == id);
        }
        private bool GPUExists(int id)
        {
            return _context.Gpu.Any(e => e.Id == id);
        }

    }
}
