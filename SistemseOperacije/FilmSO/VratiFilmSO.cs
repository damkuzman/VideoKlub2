using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.FilmSO
{
    public class VratiFilmSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            return Broker.Broker.dajSesiju().dajSve(odo);

        }
    }
}
