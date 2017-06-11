using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Broker;
using BibliotekaKlasa;

namespace SistemseOperacije
{
    using Broker;
    public abstract class OpstaSO
    {
        List<OpstiDomenskiObjekat> lista;
        public List<OpstiDomenskiObjekat> Lista
        {
            get { return lista; }
            set { lista = value; }
        }

        public object IzvrsiSO(OpstiDomenskiObjekat odo)
        {
            object rezultat = null;
            Broker.dajSesiju().OtvoriKonekciju();
            Broker.dajSesiju().ZapocniTransakciju();
            try
            {
                rezultat = Izvrsi(odo);
                Broker.dajSesiju().PotvrdiTransakciju();
            }
            catch (Exception ex)
            {
                Broker.dajSesiju().PonistiTransakciju();
                throw ex;
            }
            finally
            {
                Broker.dajSesiju().ZatvoriKonekciju();
            }
            return rezultat;
        }

        protected virtual object Izvrsi(OpstiDomenskiObjekat odo)
        {
            return null;
        }
    }
}
