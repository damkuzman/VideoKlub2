using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.FilmSO
{
    public class KreirajNoviFilmSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            BibliotekaKlasa.Film f = new BibliotekaKlasa.Film();
            f.FilmID = Broker.Broker.dajSesiju().dajSifru(odo);
            return f;

        }
    }
}
