using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.ZaduzenjeSO
{
    public class KreirajNovoZaduzenjeSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            BibliotekaKlasa.Zaduzenje z = new BibliotekaKlasa.Zaduzenje();
            z.ZaduzenjeID = Broker.Broker.dajSesiju().dajSifru(odo);
            return z.ZaduzenjeID;

        }
    }
}
