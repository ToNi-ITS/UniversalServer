using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace UniversalServer.Model
{
    public delegate EventHandler ErrorEventHandler(string msg);
    public class DBAccess
    {

        public DBAccess()
        {
            //Hier die Verbindung zur DB herstellen. Siehe Info-Pool
            //Verbindungsdaten dürfen "hard codiert" werden.
            MySqlConnection con = new MySqlConnection(@"SERVER = localhost;DATABASE=smarthome;USERID=bfks;PASSWORD=bfks;");
            con.Open();
        }

        ///Diese Methode für den Datensatz in die Datenbank ein. Siehe Info-Pool      
        public void InsertData(DateTime dt, TempValue t, HumidValue h, PressureValue p, string ipa)
        {
            ///Nun können wir einen SQL-Befehl an die DB senden, der Daten in eine Tabelle einfügt. 
            ///Dies geht im einfachsten Fall über SQL-Befehle als String.
            string insert = "INSERT INTO sensor VALUES(28-04-2022, 33, 74, 456)";
            //Damit der MySQL-Server das SQL-Statement verarbeiten kann, müssen wir es in einen MySqlCommand-Objekt umwandeln.
            //Dafür erstellen wir ein MySqlCommand-Objekt mit new...
            MySqlCommand cmd = new MySqlCommand();
            //..und fügen die nötigen Informationen hinzu:
            cmd.CommandText = insert;
            cmd.Connection = con; //Damit weiß der Command, welche Verbindung er zum DB-Server verwenden soll.

            //Mit ExecuteNonQuery() führen wir den Command auf der DB aus.
            cmd.ExecuteNonQuery();

            //So, wenn alles funktioniert hat, solle nun in der Datenbank ein Eintrag in der Tabelle tbldemo vorhanden sein.
            //Überprüfen Sie dies....

        }


    }
}
