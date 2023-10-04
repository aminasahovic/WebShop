using AutoMapper;
using eProdaja.Model;
using eProdaja.Model.Requests;
using eProdaja.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eProdaja.Services
{
    public class KorisniciService : IKorisniciService
    {
        EProdajaContext context;
        IMapper mapper;

        public KorisniciService(EProdajaContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Model.Korisnici> GetKorisnici()
        {
            var entityData = context.Korisnicis.ToList();
            return mapper.Map<List<Model.Korisnici>>(entityData);
        }

        public Model.Korisnici Insert(KorisniciInsertRequest request)
        {
            var entity = new Database.Korisnici();
            mapper.Map(request, entity);

            entity.LozinkaSalt = GenerateSalt();
            entity.LozinkaHash = GenerateHash(entity.LozinkaSalt, request.Password);

            context.Korisnicis.Add(entity);
            context.SaveChanges();

            return mapper.Map<Model.Korisnici>(entity);

        }
        public Model.Korisnici Update(int id, KorisniciUpdateRequest request)
        {
            var entity = context.Korisnicis.Find(id);
            mapper.Map(request, entity);

            context.SaveChanges();
            return mapper.Map<Model.Korisnici>(entity);

        }


        public static string GenerateSalt()
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            var byteArray = new byte[16];
            provider.GetBytes(byteArray);


            return Convert.ToBase64String(byteArray);
        }
        public static string GenerateHash(string salt, string password)
        {
            byte[] src = Convert.FromBase64String(salt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

       
    }
}
