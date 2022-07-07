using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using VitaCoreTestTask.Data.Interfaces;
using VitaCoreTestTask.Models;
using VitaCoreTestTask.Data.ViewModels;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace VitaCoreTestTask.Controllers
{
    public class VisitLogController : Controller
    {
        private readonly VCappContext _context;
        private readonly IVisitLog _visitLog;
        private readonly IRenderedService _renderedService;

        public VisitLogController(VCappContext context, IVisitLog visitLog, IRenderedService renderedService)
        {
            _context = context;
            _visitLog = visitLog;
            _renderedService = renderedService;
        }
        // GET: PetOwnerController
        public ActionResult Index(string searchString)
        {
            IEnumerable<VisitLog> visitLogs = _visitLog.visitLogs;

            if (!string.IsNullOrEmpty(searchString))
            {
                visitLogs = _visitLog.visitLogs.Where(s => s.PetOwner.Fullname!.Contains(searchString));
            }

            var visitlogVM = new VisitLogVM()
            {
                visitLogs = visitLogs
            };

            return View(visitlogVM);
        }

        // GET: PetOwnerController/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VisitLog visitLog = _visitLog.GetVisitLog(id);
            if (visitLog == null)
            {
                return NotFound();
            }

            var visitLogReviewVM = new VisitLogReviewVM
            {
                VisitLog = visitLog,
                RenderedServices = _renderedService.GetServicesByVisitLogId(id)
            };


            return View(visitLogReviewVM);
        }

        // GET: PetOwnerController/Create
        public IActionResult Create()
        {
            var PetOwnerQuery = _context.PetOwners.Select(a => new SelectListItem()
            {
                Value = a.Id_PetOwner.ToString(),
                Text = a.Fullname
            }).ToList();

            var PetQuery = _context.Pets.Include(c=>c.Species).Include(p=>p.Breed).Select(a => new SelectListItem()
            {
                Value = a.Id_Pet.ToString(),
                Text = $"{a.Species.Name} | {a.Breed.Name} | {a.Color}"
            }).ToList();

            var visitLogAddEditVM = new VisitLogAddEditVM
            {
                PetOwnerList = PetOwnerQuery,
                PetList = PetQuery
            };

            return View(visitLogAddEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_VisitLog,Date,Id_PetOwner,Id_Pet")] VisitLogAddEditVM visitLogAddEditVM)
        {
            if (ModelState.IsValid)
            {
                var visitLog = new VisitLog
                {
                    Date = visitLogAddEditVM.Date,
                    Id_PetOwner = visitLogAddEditVM.Id_PetOwner,
                    Id_Pet = visitLogAddEditVM.Id_Pet
                };
                _context.Add(visitLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(visitLogAddEditVM);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var PetOwnerQuery = _context.PetOwners.Select(a => new SelectListItem()
            {
                Value = a.Id_PetOwner.ToString(),
                Text = a.Fullname
            }).ToList();

            var PetQuery = _context.Pets.Include(c => c.Species).Include(p => p.Breed).Select(a => new SelectListItem()
            {
                Value = a.Id_Pet.ToString(),
                Text = $"{a.Species.Name} | {a.Breed.Name} | {a.Color}"
            }).ToList();

            var visitLog = await _context.VisitLogs.FindAsync(id);

            if (visitLog == null)
            {
                return NotFound();
            }

            var visitLogAddEditVM = new VisitLogAddEditVM
            {
                PetOwnerList = PetOwnerQuery,
                PetList = PetQuery,
                Date = visitLog.Date,
                Id_Pet= visitLog.Id_Pet,
                Id_PetOwner = visitLog.Id_PetOwner,
                Id_VisitLog = visitLog.Id_VisitLog
            };
            
            return View(visitLogAddEditVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_VisitLog,Date,Id_PetOwner,Id_Pet")] VisitLogAddEditVM visitLogAddEditVM)
        {
            if (id != visitLogAddEditVM.Id_VisitLog)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var visitLog = new VisitLog
                {
                    Id_VisitLog = visitLogAddEditVM.Id_VisitLog,
                    Id_PetOwner = visitLogAddEditVM.Id_PetOwner,
                    Id_Pet = visitLogAddEditVM.Id_Pet,
                    Date = visitLogAddEditVM.Date
                };
                try
                {
                    _context.Update(visitLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VisitLogExists(visitLogAddEditVM.Id_VisitLog))
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
            return View(visitLogAddEditVM);
        }

        // GET: PetOwnerController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitLog = _context.VisitLogs
                .FirstOrDefault(m => m.Id_VisitLog == id);
            if (visitLog == null)
            {
                return NotFound();
            }

            return View(visitLog);
        }

        // POST: PetOwnerController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var visitLog = _context.VisitLogs.Find(id);
            _context.VisitLogs.Remove(visitLog);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool VisitLogExists(int id)
        {
            return _context.VisitLogs.Any(e => e.Id_VisitLog == id);
        }
    }
}
