using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Net.Sockets;
using BibliotekaKlasa;
using System.Net;
using System.Threading;

namespace Server
{
    public class Server
    {
        BinaryFormatter formater = new BinaryFormatter();
        Socket soket;
        NetworkStream tok;

        public bool pokreniServer()
        {
            try
            {
                soket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                soket.Bind(new IPEndPoint(IPAddress.Any, 9000));
                ThreadStart ts = obradiKlijenta;
                Thread nit = new Thread(ts);
                nit.Start();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        private void obradiKlijenta()
        {
            soket.Listen(5);
            while (true)
            {
                Socket klijent = soket.Accept();
                tok = new NetworkStream(klijent);
                Obrada nit = new Obrada(tok);
            }
        }


    
    }
}