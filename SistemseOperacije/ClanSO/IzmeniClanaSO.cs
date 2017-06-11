using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.ClanSO
{
    public class IzmeniClanaSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            int brojac = 0;
            BibliotekaKlasa.Clan c = odo as BibliotekaKlasa.Clan;

            brojac = Broker.Broker.dajSesiju().azuriraj(odo);
            return brojac;
        }
    }
}
