using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using KontrolerAL;
using BibliotekaKlasa;
using System.Windows.Forms;


namespace KontrolerI
{
    public class ZaposleniKI
    {
        KAL kal = new KAL();
        public void povezisesaserverom() 
        {
            kal.poveziSeSaServerom();
        }

        public Zaposleni login(TextBox user, TextBox pass) 
        {
            Zaposleni z = new Zaposleni();
            z.Username = user.Text;
            z.Pass = pass.Text;
            Zaposleni zl = kal.login(z) as Zaposleni;
            if (zl!=null)
            {
                return zl;
            }
            else return null;

        }
    }
}
