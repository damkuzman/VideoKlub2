using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.ClanSO
{
    public class IzbrisiClanaSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            BibliotekaKlasa.Clan c = odo as BibliotekaKlasa.Clan;

            return Broker.Broker.dajSesiju().obrisi(c);
        }
    }
}
