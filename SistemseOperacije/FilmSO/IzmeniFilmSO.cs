using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.FilmSO
{
    public class IzmeniFilmSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            int brojac = 0;
            BibliotekaKlasa.Film f = odo as BibliotekaKlasa.Film;

            brojac = Broker.Broker.dajSesiju().azuriraj(odo);
            return brojac;
        }
    }
}
