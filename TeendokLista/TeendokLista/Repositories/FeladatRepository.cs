using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Models;

namespace TeendokLista.Repositories
{
    public class FeladatRepository
    {
        private TeendokContext db;
        public FeladatRepository()
        {
            db = new TeendokContext();
        }
        
        public List<Feladat> GetAll()
        {
            return db.Feladatok.OrderByDescending(x => x.Hatarido).ToList();
        }

        public Feladat GetById(int id)
        {
            return db.Feladatok.Find(id);
        }

        public void Delete(int id)
        {
            var feladat = db.Feladatok.Find(id);
            if (feladat != null)
            {
                db.Feladatok.Remove(feladat);
                db.SaveChanges();
            }
        }

        public void Save(Feladat feladat)
        {
            // TODO: A jelenlegi felhasználó id-jának lekérdezése

            // Megkeressük a db-ben
            var letezik = db.Feladatok.AsNoTracking().Any(x => x.Id == feladat.Id);

            // Ha már létezik
            if (letezik)
            {
                db.Entry(feladat).State = EntityState.Modified;
            }
            else
            {
                db.Feladatok.Add(feladat);
            }

            db.SaveChanges();
        }
    }
}