using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class DenemeController : ControllerBase
    {
        [HttpGet]
        public List<string> Isimler(int id)
        {
            return new List<string>
            {
                "Ahmet", "Ayşe", "Fatma"
            };
        }

        [HttpGet]
        public IActionResult Isimler2()
        {
            return new JsonResult(new List<string>
            {
                "Ahmet", "Ayşe", "Fatma"
            });
        }

        [HttpGet]
        [LoginKontrol]
        public IActionResult Isimler3(int id, string adi)
        {
            if (id == 0)
            {
                return NotFound();
            }
            else if (id == 1)
            {
                return Unauthorized();
            }
            else if (id == 2)
            {
                return BadRequest("TCKN numarası zorunludur");
            }
            else
            {
                return Ok(new List<string>
                {
                    "Ahmet", "Ayşe", "Fatma"
                });
            }
        }

        [HttpPost]
        public ServisSonucu Kaydet(Ogrenci ogrenci)
        {
            return new ServisSonucu
            {
                Sonuc = false,
                Mesaj = "TCKN numarası zorunludur"
            };
        }

        [HttpPost]
        public bool Kaydet2([FromForm] Ogrenci ogrenci)
        {
            return true;
        }

        //[HttpGet]
        //public IActionResult YemekleriGetir(string kullanici, string sifre)
        //{
        //    if (kullanici == "admin" && sifre == "123")
        //        return Ok(Yemek.Olustur());
        //    else
        //        return Unauthorized();
        //}

        [HttpGet]
        [LoginKontrol]
        public IActionResult YemekleriGetir()
        {
            return Ok(YemekTest.Olustur());
        }
    }
}
