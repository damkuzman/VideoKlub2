using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using System.Threading;
using BibliotekaKlasa;
using SistemseOperacije;

namespace Server
{

    using SistemseOperacije.ClanSO;
    using SistemseOperacije.FilmSO;
    using SistemseOperacije.ZaduzenjeSO;
    using SistemseOperacije.Zaposleni;


    public class Obrada
    {
        BinaryFormatter formater;
        NetworkStream tok;

        public Obrada(NetworkStream tok)
        {
            formater = new BinaryFormatter();
            this.tok = tok;
            ThreadStart ts = obradaZahteva;
            Thread nit = new Thread(ts);
            nit.Start();
        }

        private void obradaZahteva()
        {
            try
            {
                int operacija = 0;
                while (true)
                {
                    TransferKlasa transfer = formater.Deserialize(tok) as TransferKlasa;
                    operacija = transfer.Operacija;
                    switch (transfer.Operacija)
                    {
                        case ((int)Operacije.KrirajClana):
                            KreirajNovogClanaSO kc = new KreirajNovogClanaSO();
                            transfer.Rezultat = kc.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.ZapamtiClana):
                            ZapamtiClanaSO zc = new ZapamtiClanaSO();
                            transfer.Rezultat = zc.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.VratiSveClanove):
                            PrikaziClanoveSO pc = new PrikaziClanoveSO();
                            transfer.Rezultat = pc.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.IzmeniClana):
                            IzmeniClanaSO ic = new IzmeniClanaSO();
                            transfer.Rezultat = ic.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case ((int)Operacije.ObrisiClana):
                            IzbrisiClanaSO oc = new IzbrisiClanaSO();
                            transfer.Rezultat = oc.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.KreirajFilm):
                            KreirajNoviFilmSO kf = new KreirajNoviFilmSO();
                            transfer.Rezultat = kf.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case ((int)Operacije.ZapamtiFilm):
                            ZapamtiFilmSO zf = new ZapamtiFilmSO();
                            transfer.Rezultat = zf.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                        case ((int)Operacije.VratiSveFilmove):
                            VratiFilmSO pf = new VratiFilmSO();
                            transfer.Rezultat = pf.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.IzmeniFilm):
                            IzmeniFilmSO izf = new IzmeniFilmSO();
                            transfer.Rezultat = izf.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;
                            
                        case ((int)Operacije.ObrisiFilm):
                            IzbrisiFilmSO izfl = new IzbrisiFilmSO();
                            transfer.Rezultat = izfl.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.Login):
                            LoginSO lso = new LoginSO();
                            transfer.TransferObjekat = lso.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.KreirajZaduzenje):
                            KreirajNovoZaduzenjeSO knz = new KreirajNovoZaduzenjeSO();
                            transfer.TransferObjekat = knz.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.SacuvajZaduzenje):
                            ZapamtiZaduzenjeSO zzso = new ZapamtiZaduzenjeSO();
                            transfer.TransferObjekat = zzso.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.VratiZaduzenja):
                            VratiZaduzenjaSO vzso = new VratiZaduzenjaSO();
                            transfer.TransferObjekat = vzso.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        case ((int)Operacije.Razduzi):
                            RazduziSO rso = new RazduziSO();
                            transfer.TransferObjekat = rso.IzvrsiSO(transfer.TransferObjekat as OpstiDomenskiObjekat);
                            formater.Serialize(tok, transfer);
                            break;

                        
                       
                           
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Prekid niti:" + ex.Message);
            }
        }
    }
}
