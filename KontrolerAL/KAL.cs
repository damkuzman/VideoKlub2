using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using BibliotekaKlasa;

namespace KontrolerAL
{
    public class KAL
    {
        TcpClient klijent;
        NetworkStream tok;
        BinaryFormatter formater = new BinaryFormatter();

        public bool poveziSeSaServerom()
        {
            try
            {
                klijent = new TcpClient("127.0.0.1", 9000);
                tok = klijent.GetStream();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public OpstiDomenskiObjekat kreirajClana()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.KrirajClana;
            transfer.TransferObjekat = new Clan();
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as OpstiDomenskiObjekat;

        }


        public TransferKlasa Zapamti(Clan c)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.ZapamtiClana;
            transfer.TransferObjekat = c;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer;

        }

        public List<OpstiDomenskiObjekat> prikaziClanove()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.VratiSveClanove;
            transfer.TransferObjekat = new Clan();
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as List<OpstiDomenskiObjekat>;
        }

        public TransferKlasa izmeniClana(Clan c)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.IzmeniClana;
            transfer.TransferObjekat = c;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer;

        }

        public TransferKlasa izbrisiClana(Clan c)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.ObrisiClana;
            transfer.TransferObjekat = c;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer;

        }

        public OpstiDomenskiObjekat kreirajFilm()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.KreirajFilm;
            transfer.TransferObjekat = new Film();
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as OpstiDomenskiObjekat;

        }

        public TransferKlasa ZapamtiFilm(Film f)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.ZapamtiFilm;
            transfer.TransferObjekat = f;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer;

        }

        public List<OpstiDomenskiObjekat> prikaziFilmove()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.VratiSveFilmove;
            transfer.TransferObjekat = new Film();
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.Rezultat as List<OpstiDomenskiObjekat>;
        }

        public TransferKlasa izmeniFilm(Film f)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.IzmeniFilm;
            transfer.TransferObjekat = f;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer;

        }


        public TransferKlasa izbrisiFilm(Film f)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.ObrisiFilm;
            transfer.TransferObjekat = f;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer;

        }

        public OpstiDomenskiObjekat login(Zaposleni z)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Login;
            transfer.TransferObjekat = z;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as OpstiDomenskiObjekat;

        }

        public string kreirajZaduzenje()
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.KreirajZaduzenje;
            transfer.TransferObjekat = new Zaduzenje();
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat.ToString();

        }

        public int sacuvajZaduzenje(Zaduzenje z)
        {

            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.SacuvajZaduzenje;
            transfer.TransferObjekat = z;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.TransferObjekat;
        }

        public List<OpstiDomenskiObjekat> vratiZaduzenja(Zaduzenje z)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.VratiZaduzenja;
            transfer.TransferObjekat = z;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return transfer.TransferObjekat as List<OpstiDomenskiObjekat>;
        }

        public int razduzi(Zaduzenje z)
        {
            TransferKlasa transfer = new TransferKlasa();
            transfer.Operacija = (int)Operacije.Razduzi;
            transfer.TransferObjekat = z;
            formater.Serialize(tok, transfer);
            transfer = formater.Deserialize(tok) as TransferKlasa;
            return (int)transfer.TransferObjekat ;
        }
    }
}
