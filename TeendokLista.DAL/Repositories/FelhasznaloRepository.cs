using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.DAL.Models;

namespace TeendokLista.DAL.Repositories
{
    public class FelhasznaloRepository
    {
        private TeendokContext db = new TeendokContext();
        
        public async Task<bool> Authenticate(string username, string password)
        {
            // Ezzel a felhasználónévvel létezik e rekord
            var dbUser = await db.Felhasznalok.SingleOrDefaultAsync(x => x.Felhasznalonev.Equals(username)).ConfigureAwait(false);
            if (dbUser != null)
            {
                // Só lekérése titkosításhoz
                //var salt = dbUser.id;
                // Begépelt jelszó titkosítása
                //var password = Hash.Encrypt(view.Password + salt);

                // Rekord keresése
                var user = await db.Felhasznalok.SingleOrDefaultAsync(x => x.Felhasznalonev.Equals(username) && x.Jelszo.Equals(password)).ConfigureAwait(false);
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
