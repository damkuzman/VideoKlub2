using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.FilmSO
{
    public class IzbrisiFilmSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            BibliotekaKlasa.Film f = odo as BibliotekaKlasa.Film;

            return Broker.Broker.dajSesiju().obrisi(f);
        }
    }
}
