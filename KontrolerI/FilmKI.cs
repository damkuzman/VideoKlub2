using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KontrolerAL;
using BibliotekaKlasa;
using System.Windows.Forms;

namespace KontrolerI
{
    public class FilmKI
    {
        KAL kal = new KAL();
        public void poveziSeSaServerom() 
        {
            kal.poveziSeSaServerom();
        }


        public void kreirajFilm(TextBox sifra)
        {
            Film f = kal.kreirajFilm() as Film;
            sifra.Text = f.FilmID.ToString();


        }

        public TransferKlasa zapamtiFilm(TextBox sifra, TextBox naziv, ComboBox zanr, TextBox reziser, TextBox trajanje, TextBox kolicina, TextBox cena) 
        {
            Film f = new Film();
            f.FilmID = Convert.ToInt32(sifra.Text);
            f.Naziv = naziv.Text;
            f.Zanr = zanr.SelectedItem.ToString();
            f.Reziser = reziser.Text;
            f.Trajanje = Convert.ToInt32(trajanje.Text);
            f.Kolicina = Convert.ToInt32(kolicina.Text);
            f.Cena = Convert.ToInt32(cena.Text);

            return kal.ZapamtiFilm(f);
            

        }

        public void napuniKombo(ComboBox kombo)
        {
            List<OpstiDomenskiObjekat> listaodo = kal.prikaziFilmove();
            List<Film> listaFilmova = listaodo.OfType<Film>().ToList<Film>();

            kombo.DisplayMember = "Naziv";
            kombo.ValueMember = "FilmID";
            kombo.DataSource = listaFilmova;
        }

        public void popuniPolja(ComboBox kombo, ComboBox zanr, TextBox reziser, TextBox trajanje, TextBox kolicina, TextBox cena) 
        {
            Film f = kombo.SelectedItem as Film;
            zanr.Text = f.Zanr;
            reziser.Text = f.Reziser;
            trajanje.Text = f.Trajanje.ToString();
            kolicina.Text = f.Kolicina.ToString();
            cena.Text = f.Cena.ToString();

        }

        public TransferKlasa izmeniFilm(ComboBox kombo, ComboBox zanr, TextBox reziser, TextBox trajanje, TextBox kolicina, TextBox cena)  
        {
            Film f = new Film();
            f = kombo.SelectedItem as Film;
            f.Zanr = zanr.SelectedItem.ToString();
            f.Reziser = reziser.Text;
            f.Trajanje = Convert.ToInt32(trajanje.Text);
            f.Kolicina = Convert.ToInt32(kolicina.Text);
            f.Cena = Convert.ToInt32(cena.Text);

            return kal.izmeniFilm(f);

        }

        public TransferKlasa obrisiFilm(ComboBox kombo) 
        {
            Film f = kombo.SelectedItem as Film;
            return kal.izbrisiFilm(f);
           
        }
    }
}
