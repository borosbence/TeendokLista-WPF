using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.DAL;

namespace TeendokLista.Data.Repositories
{
    public class FelhasznaloRepository
    {
        private TeendokContext db = new TeendokContextFactory().CreateDbContext();
        
        public bool Authenticate(string username, string password)
        {
            // Ezzel a felhasználónévvel létezik e rekord
            var dbUser = db.Felhasznalok.AsNoTracking().SingleOrDefault(x => x.Felhasznalonev.Equals(username));
            if (dbUser != null)
            {
                // Só lekérése titkosításhoz
                //var salt = dbUser.id;
                // Begépelt jelszó titkosítása
                //var password = Hash.Encrypt(view.Password + salt);

                // Rekord keresése
                var user = db.Felhasznalok.AsNoTracking().SingleOrDefault(x => x.Felhasznalonev.Equals(username) && x.Jelszo.Equals(password));
                if (user != null)
                {
                    return true;
                    // CurrentUser.Id = user.id;
                }
                else
                {
                    // Hibás login
                    return false;
                }
            }
            else
            {
                // Felhasználó nem létezik
                return false;
            }
        }
    }
}
