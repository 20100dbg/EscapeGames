using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace FkDecryptor
{
    class Program
    {
        static int port = 31337;
        static IPAddress ip = IPAddress.Parse("169.254.72.10");
        static int nbTry = 3;

        static void Main(string[] args)
        {
            int x = (int)(Console.LargestWindowWidth * 0.8);
            int y = (int)(Console.LargestWindowHeight * 0.8);

            Console.SetWindowSize(x, y);

            Thread.Sleep(100);
            DisplayText("Formule decryptor | Loading...");


            Boolean accessGranted = false;
            string dataMsg = File.ReadAllText("message.txt");
            dataMsg = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(dataMsg));


            if (!CheckDongle())
            {
                DisplayText("[!] DONGLE NOT DETECTED");
            }
            else
            {
                DisplayText("[+] Dongle detected");

                if (CheckNetwork())
                {
                    DisplayText("[+] Remote access established");
                    DisplayText("> BEGIN MESSAGE\n");
                    DisplayText(dataMsg, delay:1);
                    DisplayText("> END MESSAGE");

                    DisplayText("\n[+] Press Enter to continue");
                    Console.ReadLine();

                    int i = 1;
                    do
                    {
                        DisplayText("[?] Nom de l'élément chimique retenu (essai " + i + "/3) : ", newline:false);
                        String uInput = Console.ReadLine().ToLower();

                        if (uInput.Length > 0)
                        {
                            if (uInput == "béryllium" || uInput == "beryllium")
                            {
                                accessGranted = true;
                                DisplayData();
                            }
                            else
                                i++;
                        }

                    } while (!accessGranted && i < 4);

                    if (i >= 4) Fail();
                }
                else
                    DisplayText("[!] NETWORK FAILED");
            }

            DisplayText("\n[+] END OF PROGRAM");
            Console.Read();
        }

        static bool CheckNetwork()
        {
            int x = 0;
            bool connected = false;
            while (!connected && x++ < nbTry)
            {
                DisplayText("[+] Checking remote access");
                connected = CheckRemote(ip, port);
                Thread.Sleep(500);
            } 

            return connected;
        }


        static void Fail()
        {
            DisplayText("[!] FAIL MATCHING PASSWORD");
            DisplayText("[!] ERASING DATA ...");
            DisplayText("[!] ERASING DATA ...");
        }

        static bool CheckRemote(IPAddress ip, int port)
        {
            bool connected = false;
            TcpClient tc = new TcpClient();

            try
            {
                tc.Connect(ip, port);
                connected = true;
            }
            catch (Exception e)
            {
                DisplayText("[!] CRITICAL : CheckRemote FAILED");
                connected = false;
            }

            return connected;
        }

        static bool CheckDongle()
        {
            int x = 0;
            bool dongle = false;
            while (!dongle && x++ < nbTry)
            {
                DisplayText("[+] Checking dongle");
                dongle = (File.Exists("D:\\data.lock"));
                Thread.Sleep(2000);
            }

            return dongle;
        }


        static void DisplayText(string str, int delay = 30, bool newline = true, int delayAfter = 300)
        {
            for (int i = 0; i < str.Length; i++)
            {
                Console.Write(str[i]);
                Thread.Sleep(delay);
            }
            if (newline) Console.WriteLine();
            Thread.Sleep(delayAfter);
        }

        static void DisplayData()
        {
            String fkpwd = "4A228D4FEE39-CB4EA68CB51B23F400B-B00BS-A36F3B2748CEA3F5714D8498-89BB4A0C7";

            DisplayText("[+] Password accepted");
            DisplayText("[+] Acquiring cypher");

            DisplayText(fkpwd, delay:10);

            DisplayText("[+] Access granted");
            DisplayText("[+] Decrypting file");
            DisplayText("[+] Display data");
            DisplayText("");

            DisplayText("[?] Numéro de la formule correcte : ");
            String numFomule = Console.ReadLine();

            DisplayText("[?] Numéro atomique du Béryllium : ");
            String numAtomique = Console.ReadLine();

            DisplayText("[?] Nombre de liaisons doubles : ");
            String nbLiaisons = Console.ReadLine();

            if (numFomule == "7" && numAtomique == "4" && nbLiaisons == "6")
            {
                DisplayText("[+] La poche à antidote est sous le fauteuil");
                DisplayText("[+] Code du cadenas : 937");
            }
        }
    }
}