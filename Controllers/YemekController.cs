using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models.Entity;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class YemekController : ControllerBase
    {
        private YemekContext _context;
        public YemekController(YemekContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Yemek> MenuGetir(int restoranId, int? kategoriId)
        {
            if (kategoriId != null)
                return _context.Yemek.Include(x=> x.Kategori).Include(x=> x.Restoran)
                    .Where(x => x.KategoriId == kategoriId && x.RestoranId == restoranId).ToList();
            else
                return _context.Yemek.Include(x => x.Kategori).Include(x => x.Restoran)
                    .Where(x => x.RestoranId == restoranId).ToList();
        }

        [HttpPost]
        public IActionResult Kaydet(Yemek model)
        {
            if (ModelState.IsValid == false || model.RestoranId == 0 || model.KategoriId == 0)
                return BadRequest("Zorunlu alanlar boş olamaz");

            _context.Yemek.Add(model);
            _context.SaveChanges();

            return Ok(true);
        }

        [HttpDelete]
        public bool Sil(int id)
        {
            var model = _context.Yemek.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return false;
            else
            {
                _context.Yemek.Remove(model);
                _context.SaveChanges();

                return true;
            }
        }


    }
}
