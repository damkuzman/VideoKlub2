using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.Zaposleni
{
    public class LoginSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            return Broker.Broker.dajSesiju().dajZaUslovVise(odo);

        }
    }
}
