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
            ///Um diese Klassen benutzen zu können, müssen Sie den Namespace MySql.Data in den
            ///using-Direktiven (siehe oben) hinzufügen. 
            ///
            ///Jetzt können wir als Erstes eine Verbindung zur Datenbank herstellen. In einem sog.
            ///Connection-String geben wir die nötigen Verbindungsinformationen an:
            ///- Server-Adresse/IP
            ///- Name der Datenbank
            ///- User, der auf die Datenbank zugreifen darf und
            ///- Passwort (Sicherheitskriterien beachten!)
            ///Natürlich müssen Datenbank und User auf der Datenbank existieren.
            MySqlConnection con = new MySqlConnection(@"SERVER = myadmin.bfks.bplaced.net;DATABASE=bfks;UID=bfks_group;PASSWORD=*************;"); //PW wegen Git seperat gespeichert

            //Nachdem die Zugangsdaten gesetzt wurden, können wir den "Kanal" zur Datenbank öffnen.
            con.Open();  //Jetzt greift unser Programm über das Netzwerk/lokal auf die Datenbank zu.

            ///Nun können wir einen SQL-Befehl an die DB senden, der Daten in eine Tabelle einfügt. 
            ///Dies geht im einfachsten Fall über SQL-Befehle als String.
            string insert = "INSERT INTO SmartHome (DateTime, TempValue, HumidValue, PressureValue) VALUES ('2022-03-03', 2, 3, 4)";
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

        ///Diese Methode für den Datensatz in die Datenbank ein. Siehe Info-Pool      
        public void InsertData(TempValue t, HumidValue h, PressureValue p, DateTime dt, string ipa)
        {


        }


    }
}
