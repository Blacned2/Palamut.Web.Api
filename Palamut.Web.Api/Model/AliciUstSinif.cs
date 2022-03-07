using MyWebApi.Model;
using PagedList;
using System.Linq;

namespace Palamut.Web.Api.Model
{
    public class AliciUstSinif
    {
        public IPagedList<Alici> Alicilar { get; set; }
        public int MaxPage { get; set; }
    }
}
