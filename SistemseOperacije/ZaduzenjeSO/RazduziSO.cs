using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemseOperacije.ZaduzenjeSO
{
    public class RazduziSO:OpstaSO
    {
        protected override object Izvrsi(BibliotekaKlasa.OpstiDomenskiObjekat odo)
        {
            return Broker.Broker.dajSesiju().azuriraj(odo);
        }
    }
}
