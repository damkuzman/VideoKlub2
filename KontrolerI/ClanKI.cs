using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BibliotekaKlasa;
using KontrolerAL;


namespace KontrolerI
{
    public class ClanKI
    {
        KAL kal = new KAL();

        public void poveziSeSaServerom() 
        {
            kal.poveziSeSaServerom();
        }
        
        public void kreirajClana(TextBox tb) 
        {
            Clan c = kal.kreirajClana() as Clan;

            tb.Text = c.ClanID.ToString();
        }

        public TransferKlasa zapamtiClana(TextBox sifra, TextBox ime, TextBox prezime, TextBox adresa, TextBox brMob, TextBox brLK) 
        {
            Clan c = new Clan();
            c.ClanID = int.Parse( sifra.Text);
            c.Ime = ime.Text;
            c.Prezime = prezime.Text;
            c.Adresa = adresa.Text;
            c.BrojMobilnog = brMob.Text;
            c.BrojLK = brLK.Text;
            return kal.Zapamti(c);
        }

        public void napuniKombo(ComboBox kombo) 
        {
            List<OpstiDomenskiObjekat> listaodo = kal.prikaziClanove();
            List<Clan> listaClanova = listaodo.OfType<Clan>().ToList<Clan>();
            
            kombo.DisplayMember = "ClanID";
            kombo.ValueMember = "ClanID";
            kombo.DataSource = listaClanova;
        }

        public void popuniPolja(ComboBox kombo, TextBox ime, TextBox prezime, TextBox adresa, TextBox brMob, TextBox brLK) 
        {
            Clan c = kombo.SelectedItem as Clan;
            ime.Text = c.Ime;
            prezime.Text = c.Prezime;
            adresa.Text = c.Adresa;
            brMob.Text = c.BrojMobilnog;
            brLK.Text = c.BrojLK;
        }

        public TransferKlasa izmeniClana(ComboBox kombo, TextBox ime, TextBox prezime, TextBox adresa, TextBox brMob, TextBox brLK)
        {
            Clan c = kombo.SelectedItem as Clan;

            c.Ime = ime.Text;
            c.Prezime = prezime.Text;
            c.Adresa = adresa.Text;
            c.BrojMobilnog = brMob.Text;
            c.BrojLK = brLK.Text;
            return kal.izmeniClana(c);
        }

        public TransferKlasa obrisiClana(ComboBox kombo)
        {
            return kal.izbrisiClana(kombo.SelectedItem as Clan);
        }
    }
}
