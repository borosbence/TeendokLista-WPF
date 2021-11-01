using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TeendokLista.Models;
using TeendokLista.Services;

namespace TeendokLista.Repositories
{
    public class FelhasznaloRepository
    {
        private TeendokContext db;
        public FelhasznaloRepository()
        {
            db = new TeendokContext();
        }

        public string Authenticate(string username, string password)
        {
            if (!db.Database.CanConnect())
            {
                return Application.Current.Resources["dbFail"].ToString();
            }
            // TODO: kötelező mezők validátorral
            // Ezzel a felhasználónévvel létezik e rekord
            var dbUser = db.Felhasznalok.AsNoTracking().SingleOrDefault(x => x.Felhasznalonev.Equals(username));
            if (dbUser != null && !string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                // Begépelt jelszó titkosítása, ezt el kell menteni az adatbázisba!
                var passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
                // Jelszó ellenőrzése
                bool verified = BCrypt.Net.BCrypt.Verify(password, dbUser.Jelszo);
                if (verified)
                {
                    CurrentUser.Id = dbUser.Id;
                    CurrentUser.UserName = dbUser.Felhasznalonev;
                    return Application.Current.Resources["loginSuccess"].ToString();
                }
                else
                {
                    // Hibás login
                    return Application.Current.Resources["loginFail"].ToString();
                }
            }
            else
            {
                // Felhasználó nem létezik
                return Application.Current.Resources["loginNoUser"].ToString();
            }
        }
    }
}
