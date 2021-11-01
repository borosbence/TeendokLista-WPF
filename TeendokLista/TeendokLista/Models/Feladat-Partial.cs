using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeendokLista.Services;

namespace TeendokLista.Models
{
    public partial class Feladat
    {
        public Feladat()
        {
            Cim = "Cím";
            Szoveg = "Jegyzet...";
            Hatarido = DateTime.Now;
            Teljesitve = false;
            FelhasznaloId = CurrentUser.Id;
        }
    }
}
