using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

namespace MediaIntegrator
{
    class FileWatch
    {
        //variabler för att spara sökvägarna.
        private string fileSavePath;
        private string fileLookPath;
        //Nytt objekt av filesysremwatcher.
        FileSystemWatcher fw = new FileSystemWatcher();
        public void fileWatch(string folderPath)
        {
            //Sätter sökvägen till variablen i den här klassen.
            this.fileLookPath = folderPath;
            //Sätter även sökvägwn till filesystem watcher path
            fw.Path = folderPath;
            //Övervakar denna csv fil
            fw.Filter = "Produkter.txt";
            //Kollar efter senaste write.
            fw.NotifyFilter = NotifyFilters.LastWrite;
            //När den ändrats så kör vi fuleUpdate funktionen
            fw.Changed += new FileSystemEventHandler(fileUpdate);
            //Startar filesystemwatcher
            fw.EnableRaisingEvents = true;

        }

        public void savePath(string savePath)
        {
            //Sätter savepath till klassens variabel.
            this.fileSavePath = savePath;
        }

        private void readFile()
        {
            //finns filen inte så gör vi inget 
            if (!File.Exists(fileLookPath + "\\Produkter.txt"))
            {
                Console.WriteLine("No file bro");
            }
            else
            {
                //Letar efter filen och sökvägen för att läsa csv filen
                TextReader tr = new StreamReader(fileLookPath+"\\Produkter.txt");
                //Sätter ett nytt objekt av xmlserttings
                XmlWriterSettings setting = new XmlWriterSettings();
                //indent true för att få snyggare struktur på xml dokumentet
                setting.Indent = true;
                //ny xml writer som skriver till den xml filen som skapas
                XmlWriter xw = XmlWriter.Create(fileSavePath + "\\xmlConverted.xml", setting);
                //Sträng för att hålla nuvarande rad.
                string r;
                //skriver start deklarationen och start taggen
                xw.WriteStartDocument();
                xw.WriteStartElement("Inventory");
                //Så länge som raden inte är tom/null så läser vi nästa.
                while ((r = tr.ReadLine()) != null)
                {
                    try
                    {
                        //Samma read file funktion som jag hade i mediastore, funkar .
                        //Det här skapar index out of bound exception, vet inte varför och har inte kunnat lösa det, så tystar det.
                        //Det är fem fält i arrayen men går utanför ändå.
                        //Dålig kanske men :PP

                        //Skapar en array för att hålla alla substrängar som skapas vid varje , 
                        string[] splitted = r.Split(',');
                        //Sätter respektive attribut till en ny sträng.
                        string idText = splitted[0];
                        string nameText = splitted[1];
                        string priceText = splitted[2];
                        string amountText = splitted[3];
                        string supplierText = splitted[4];

                        //För varje rad/objekt som finns i filen vi läser så skriver vi ut detta, det motsvarar ett item
                        
                        xw.WriteStartElement("Item");
                        xw.WriteElementString("Name", nameText);
                        xw.WriteElementString("Count", amountText);
                        xw.WriteElementString("Price", priceText);
                        xw.WriteElementString("Comment", "none");
                        xw.WriteElementString("Artist", "none");
                        xw.WriteElementString("Publisher", supplierText);
                        xw.WriteElementString("Genre", "none");
                        xw.WriteElementString("Year", "0");
                        xw.WriteElementString("ProductID", idText);
                        xw.WriteEndElement();
                    }
                    catch
                    {

                    }
                    

                }
                //Sen stänger vi inventoryt
                xw.WriteEndElement();
                //Stänger text reader
                tr.Close();
                //Stänger xmlwriter 
                xw.Close();
            }
        }

        private void fileUpdate(object s, FileSystemEventArgs e)
        {
            /*Sleep metod för att filesystenm watcher öppnar 2 events direkt efter varandra
             * Har läst lite om det och det verkar lite oklar, vissa säger att det är en bugg och andra att det ska vara så
             * Provade lösa det med att stänga av raisingevents och köra funktionen asynkront men det gick heller inte, så sleep it is.
             * 
             * 
             */
            Thread.Sleep(200);
            readFile();
        }
    }
}
