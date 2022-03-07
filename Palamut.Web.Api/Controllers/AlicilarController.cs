using Microsoft.AspNetCore.Mvc;
using MyWebApi.Context;
using MyWebApi.Model;
using System.Linq;
using Faker;
using PagedList;
using Palamut.Web.Api.Model;
using System;

namespace MyWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlicilarController : ControllerBase
    {
        private readonly PalamutContext _context;
        public AlicilarController(PalamutContext context)
        {
            this._context = context;

            #region Dummy Data
            //for(int i = 0; i < 10; i++)
            //{
            //    var urun = new Urun();
            //    urun.Stok = Faker.RandomNumber.Next(1,50);
            //    urun.UrunName = Faker.Name.FullName();
            //    urun.UrunFiyat = Faker.RandomNumber.Next(1,500);

            //    _context.Add(urun);
            //    _context.SaveChanges();
            //}
            
            //for (int i = 0; i < 100; i++)
            //{
            //    var alici = new Alici();
            //    alici.Address = Faker.Address.City();
            //    alici.AliciName = Faker.Name.FullName();
            //    alici.AliciTelNo = Faker.Phone.Number();
            //    _context.Add(alici);
            //    _context.SaveChanges();
            //}



            #endregion

        }
        [HttpGet, Route("AliciList/{page}")]
        public ActionResult<AliciUstSinif> AliciList(int page)
        {
            var alicilar = _context.Alicilar.OrderByDescending(desc => desc.AliciID).ToPagedList(page, 10);
            AliciUstSinif aliciUstSinif = new AliciUstSinif();
            var maxPage = _context.Alicilar.Count();

            aliciUstSinif.Alicilar = alicilar;
            aliciUstSinif.MaxPage = maxPage;
            return aliciUstSinif;
        }

        [HttpGet, Route("SingleAlici/{id}")]
        public ActionResult<Alici> SingleAlici(int id)
        {
            var alici = _context.Alicilar.Where(u => u.AliciID == id).FirstOrDefault();

            return alici;
        }

        [HttpPost, Route("AliciEkleGuncelle/")]
        public ActionResult AliciEkleGuncelle(int? id, Alici alici)
        {
            if (id == null)
            {
                _context.Add(alici);
                _context.SaveChanges();
            }
            else
            {
                var Editalici = (from u in _context.Alicilar
                                 where u.AliciID == id
                                 select u).FirstOrDefault();

                Editalici.AliciName = alici.AliciName;
                Editalici.Address = alici.Address;
                Editalici.AliciTelNo = alici.AliciTelNo;

                _context.Update(Editalici);
                _context.SaveChanges();
            }

            return Ok();
        }
        [HttpDelete, Route("AliciSil/{id}")]
        public ActionResult AliciSil(int id)
        {
            var alici = (from u in _context.Alicilar
                         where u.AliciID == id
                         select u).FirstOrDefault();
            if (alici != null)
            {
                _context.Remove(alici);
                _context.SaveChanges();
            }
            return Ok();
        }

    }
}
