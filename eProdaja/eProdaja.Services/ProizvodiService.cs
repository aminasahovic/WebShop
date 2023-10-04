//using eProdaja.Model;
//using eProdaja.Services.Database;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace eProdaja.Services
//{
//    public class ProizvodiService : IProizvodiService
//    {
//        EProdajaContext context;
//        public ProizvodiService(EProdajaContext context)
//        {
//            this.context = context;
//        }
//        List<Model.Proizvodi> proizvodi = new List<Model.Proizvodi>() {
//            new Model.Proizvodi()
//            //{
//                 Cijena=23,
//                JedinicaMjereId=1,
//                Sifra="112",
//                Naziv="Majica",
//                ProizvodId=1,
//            }
//        };
//    public IList<Model.Proizvodi> Get()
//    {
//        var proizvodii = context.Proizvodis.ToList();
//        return proizvodi;
//    }
//}
//}
