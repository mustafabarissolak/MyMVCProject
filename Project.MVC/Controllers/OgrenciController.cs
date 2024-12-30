using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.MVC.Models;

namespace Project.MVC.Controllers
{
    public class OgrenciController : Controller
    {
        private readonly DataContext _dataContext;
        public OgrenciController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = _dataContext.Ogrenciler;
            return View(ogrenciler);
        }

        public async Task<IActionResult> Details(int id)
        {
            var ogrenci = await _dataContext.Ogrenciler.FirstOrDefaultAsync(o => o.Id == id);
            if (ogrenci == null)
                return NotFound();
            return View(ogrenci);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _dataContext.Ogrenciler.Add(ogrenci);
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ogrenci);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var ogrenci = await _dataContext.Ogrenciler.FirstOrDefaultAsync(o => o.Id == id);
            if (ogrenci == null)
                return NotFound();
            return View(ogrenci);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Ogrenci updatedOgrenci)
        {
            var ogrenci = await _dataContext.Ogrenciler.FindAsync(id);
            if (ogrenci == null) 
                return NotFound();

            if (ModelState.IsValid)
            {
                ogrenci.Name = updatedOgrenci.Name;
                ogrenci.Surname = updatedOgrenci.Surname;
                await _dataContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(updatedOgrenci);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var ogrenci = await _dataContext.Ogrenciler.FindAsync(id);
            if (ogrenci == null)
                return NotFound();
            return View(ogrenci);

        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ogrenci = await _dataContext.Ogrenciler.FindAsync(id);
            _dataContext.Ogrenciler.Remove(ogrenci);
            await _dataContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
