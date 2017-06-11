using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.ZaduzenjeSO
{
    public class VratiZaduzenjaSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo) 
        {
            return Broker.Broker.dajSesiju().dajSveZaUslov(odo);
        }
    }
}
