using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;
using Broker;

namespace SistemseOperacije.ClanSO
{
    public class KreirajNovogClanaSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            BibliotekaKlasa.Clan cl = new BibliotekaKlasa.Clan();
            cl.ClanID = Broker.Broker.dajSesiju().dajSifru(odo);
            return cl;

        }
    }
}
