using eProdaja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class ProizvodiService : IProizvodiService
    {
        List<Proizvodi> proizvodi = new List<Proizvodi>() {
            new Proizvodi()
            {
                 Cijena=23,
                JedinicaMjereId=1,
                Sifra="112",
                Naziv="Majica",
                ProizvodId=1,
            }
        };
        public IList<Proizvodi> Get()
        {
            return proizvodi;
        }
    }
}
