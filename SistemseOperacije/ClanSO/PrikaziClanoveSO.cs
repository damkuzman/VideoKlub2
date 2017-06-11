using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.ClanSO
{
    public class PrikaziClanoveSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            return Broker.Broker.dajSesiju().dajSve(odo);

        }
    }
}
