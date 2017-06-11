using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliotekaKlasa;

namespace SistemseOperacije.ZaduzenjeSO
{
    public class ZapamtiZaduzenjeSO:OpstaSO
    {
        protected override object Izvrsi(OpstiDomenskiObjekat odo)
        {
            Zaduzenje z = odo as Zaduzenje;
            int br=0;
            if (Broker.Broker.dajSesiju().ubaci(odo) != 0) 
            {
                foreach (StavkaZaduzenja sz in z.ListaStavki) 
                {
                   br+= Broker.Broker.dajSesiju().ubaci(sz);
                }
            }

            if (br == z.ListaStavki.Count()) return br;
            else return 0;
        }
    }
}
