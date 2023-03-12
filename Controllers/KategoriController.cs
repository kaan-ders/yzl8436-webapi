using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Entity;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KategoriController : ControllerBase
    {
        private YemekContext _context;
        public KategoriController(YemekContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<Kategori> Listele()
        {
            return _context.Kategori.ToList();
        }

        [HttpGet]
        public Kategori Getir(int id)
        {
            return _context.Kategori.FirstOrDefault(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Kaydet(Kategori model)
        {
            if (string.IsNullOrEmpty(model.Adi))
                return BadRequest("Adı alanı boş olamaz");

            _context.Kategori.Add(model);
            _context.SaveChanges();

            return Ok(true);
        }

        [HttpPatch]
        public IActionResult Güncelle(Kategori model)
        {
            if (string.IsNullOrEmpty(model.Adi) || model.Id != 0)
                return BadRequest("Adı alanı boş olamaz");

            var entity = _context.Kategori.FirstOrDefault(x => x.Id == model.Id);
            if(entity == null)
                return BadRequest("Yanlış ID");

            entity.Adi = model.Adi;

            _context.Kategori.Update(entity);
            _context.SaveChanges();

            return Ok(true);
        }

        [HttpDelete]
        public bool Sil(int id)
        {
            var model = _context.Kategori.FirstOrDefault(x => x.Id == id);

            if (model == null)
                return false;
            else
            {
                _context.Kategori.Remove(model);
                _context.SaveChanges();

                return true;
            }
        }
    }
}
