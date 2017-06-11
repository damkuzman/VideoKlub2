using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KontrolerAL;
using System.Windows.Forms;
using BibliotekaKlasa;

namespace KontrolerI
{
    public class ZaduzenjeKI
    {
        KAL kal = new KAL();
        public void povezisesaserverom() 
        {
            kal.poveziSeSaServerom();
        }

        public void postaviZaglavlje(DataGridView dg) 
        {
            List<Film> filmovi = new List<Film>();
            List<OpstiDomenskiObjekat> listaodo= kal.prikaziFilmove();
            filmovi = listaodo.OfType<Film>().ToList<Film>();
            DataGridViewTextBoxColumn rbr = new DataGridViewTextBoxColumn();
            rbr.HeaderText = "Redni Broj";
            rbr.Name ="rbrDG";
            rbr.ReadOnly = true;

            DataGridViewComboBoxColumn kombo = new DataGridViewComboBoxColumn();
            
            foreach (Film f in filmovi) 
            {
                kombo.Items.Add(f);
            }
            kombo.Items.Add("-");
            kombo.DefaultCellStyle.NullValue = "-";
            kombo.HeaderText = "Film";
            kombo.Name = "filmDG";
            kombo.DisplayMember = "Naziv";
            kombo.ValueMember = "FilmID";
            

            dg.Columns.Add(rbr);
            dg.Columns.Add(kombo);


            
        }

        public void postaviZaglavljePrikaz(DataGridView dg)
        {

            DataGridViewTextBoxColumn id = new DataGridViewTextBoxColumn();
            id.Name = "idDG";
            id.HeaderText = "Sifra Zaduzenja";

            DataGridViewTextBoxColumn datumz = new DataGridViewTextBoxColumn();
            datumz.Name = "datumzDG";
            datumz.HeaderText = "Datum Zaduzenja";
            DataGridViewTextBoxColumn datumr = new DataGridViewTextBoxColumn();
            datumr.Name = "datumrDG";
            datumr.HeaderText = "Datum Zaduzenja";
            DataGridViewTextBoxColumn ukupanIznos = new DataGridViewTextBoxColumn();
            ukupanIznos.Name = "ukupanIDG";
            ukupanIznos.HeaderText = "Ukupan Iznos";
            
         
            dg.Columns.Add(id);
            dg.Columns.Add(datumz);
            dg.Columns.Add(datumr);
            dg.Columns.Add(ukupanIznos);
            




        }

        public void napuniDG(DataGridView dg, List<StavkaZaduzenja> lista)
        {
            int i = 0;
            foreach (StavkaZaduzenja sz in lista) 
            {
                dg["rbrDG", i].Value = sz.RBr;
                dg["filmDG", i].Value = sz.FilmID;
                i++;
            }
        }

        public void izracunajZaduzenje(DataGridViewCell film, TextBox text) 
        {

            int sifraF = Convert.ToInt32(film.Value) ;

            List<Film> filmovi = kal.prikaziFilmove().OfType<Film>().ToList<Film>();

            double  ukIznos = double.Parse(text.Text);

                foreach(Film f in filmovi)
                {
                if(f.FilmID==sifraF)ukIznos += f.Cena;
                }
            
            text.Text = ukIznos.ToString();
        }


        public void kreirajZaduzenje(TextBox text) 
        {
            text.Text = kal.kreirajZaduzenje();
        }

        public void popuniKombo(ComboBox kombo) 
        {
            kombo.DisplayMember = "Ime";
            kombo.DataSource = kal.prikaziClanove().OfType<Clan>().ToList<Clan>();
        }

        public void sacuvajZaduzenje(TextBox txtSifra, TextBox txtUkIznos, DateTimePicker dtpZaduzenje, DateTimePicker dtpRazduzenje, DataGridView dgUnosStavke, ComboBox cmbClan)
        {
            Zaduzenje z = new Zaduzenje();
            z.ZaduzenjeID = Convert.ToInt32(txtSifra.Text);
            z.UkIznos = Convert.ToInt32(txtUkIznos.Text);
            z.DatumZaduzenja = dtpZaduzenje.Value;
            z.DatumRazduzenja = dtpRazduzenje.Value;
            z.Zaduzen = true;
            z.ClanID = (cmbClan.SelectedItem as Clan).ClanID;

            for (int i = 0; i < dgUnosStavke.RowCount; i++)
            {
                if (dgUnosStavke[1, i].Value != null) 
                {
                    StavkaZaduzenja sz = new StavkaZaduzenja();
                    sz.ZaduzenjeID = z.ZaduzenjeID;
                    sz.FilmID = Convert.ToInt32(dgUnosStavke[1, i].Value);
                    sz.RBr = Convert.ToInt32(dgUnosStavke[0, i].Value);
                    z.ListaStavki.Add(sz);
                }
            }


           int a= kal.sacuvajZaduzenje(z);
           if (a == 0) MessageBox.Show("Neuspesan unos");
           else MessageBox.Show("Uspesno ste uneli zaduzenje");

        }

        public void popuniGridPrikaz(DataGridView dgPrikaz, ComboBox kombo)
        {
            Zaduzenje z = new Zaduzenje();
            z.ClanID = (kombo.SelectedItem as Clan).ClanID;
            List<Zaduzenje> zaduzenja = kal.vratiZaduzenja(z).OfType<Zaduzenje>().ToList<Zaduzenje>();

            dgPrikaz.Rows.Clear();
            if (zaduzenja.Count > 0) dgPrikaz.Rows.Add(zaduzenja.Count);
            int i = 0;
            foreach (Zaduzenje za in zaduzenja) 
            {
                dgPrikaz[0, i].Value = za.ZaduzenjeID;
                dgPrikaz[1, i].Value = za.DatumZaduzenja.ToShortDateString();
                dgPrikaz[2, i].Value = za.DatumRazduzenja.ToShortDateString();
                dgPrikaz[3, i].Value = za.UkIznos;
                i++;
            }
        }

        public void razduzi(DataGridView dgPrikaz, ComboBox combo)
        {
            DataGridViewSelectedRowCollection red = dgPrikaz.SelectedRows;
            

            Zaduzenje z = new Zaduzenje();
            z.ZaduzenjeID =Convert.ToInt32( red[0].Cells[0].Value);
            z.DatumZaduzenja = Convert.ToDateTime(red[0].Cells[1].Value);
            z.DatumRazduzenja = Convert.ToDateTime(red[0].Cells[2].Value);
            z.UkIznos = Convert.ToInt32(red[0].Cells[3].Value);
            z.ClanID = (combo.SelectedItem as Clan).ClanID;
            z.Zaduzen = false;
            kal.razduzi(z);

            popuniGridPrikaz(dgPrikaz, combo);
        }
    }
}
