using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Codra
{
    public partial class ChatWindow : Form
    {
        List<string> listPseudo = new List<string>();
        List<string> listChans = new List<string>();
        List<string> listCurrentPseudo = new List<string>();
        string mdp = "semaphore";
        string chanOPE = "vengeance";
        string nomLocal = "Abou Abdel Al Faransi";
        List<string> listNomsComplices = new List<string>();

        int compteurLog = 0;
        string[] logText;

        string currentChan = "";
        Task animateChan;
        bool animating = false;
        bool utilCompromis = false;

        public ChatWindow()
        {
            InitializeComponent();

            
            listPseudo.AddRange(new string[] { "Arleston", "Bédu", "Cabu", "Carali", "Charb", "Chard", "Christophe", "Cosey", "Derib", "Édika", "Paul Gavarni", "André Gill", "Gos", "Greg", "Gus", "Hergé", "Hervé", "Horn", "Jidéhem", "Jijé", "Jonko", "Laudec", "Lambil", "Malik", "Maliki", "Mitacq", "Peyo", "Reiser", "Sennep", "Marc Sleen", "TaDuc", "Tibet", "Tronchet", "Turk", "Voutch", "Walt", "Wiaz", "Yslaire", "Zep", "Zidrou", "Grimdal", "Raptor", "PetiteFée", "Pewfan", "Seltade", "Kairrin", "Potaaato", "Neptendus", "RainbowMan", "Exominiate", "Meyriu", "Ectobiologiste", "ItsGodHere", "MaxMadMen", "TankerTanker", "Felipero", "TheFlyingBat", "JustEpic", "LeGrandBlond", "Azalee", "OarisKiller", "LeHamster", "Dialove", "Frexs", "Rofaly", "GeoMan", "Kirna", "Gruty", "Fridame", "Fluxy", "Drastics", "Grimace", "Viiper", "xXSerpentXx", "Cristobal", "Scubrina", "Xanoneq", "McTimley", "LittleDank", "Rocketman", "AlCapone", "AnTiiCZzZ", "AudaciouS", "CaSHFloW", "chRoNiCz", "ClowN", "DyNaMIKz", "HoRIZoN", "iDeaan", "InFINITy", "iPaNiiCz", "MerCifieD", "MoSTWanTeD", "MyStiCaaLz", "NeFaRiouZ", "NuvkleZ", "OwnZ", "ReLaoDeD", "Anastasia", "Bullet", "Cardiac", "Crips", "Damani", "Deathnew", "Diapers", "Escobar", "Forensics", "Hoptoad", "Illuminatus", "Janste", "Krush", "Messih", "Mooney", "Neal", "Necrew", "Ownage", "Rostov", "Thug", "Thumb", "Vendetta", "Yelawolf", "Zeus", "Zookeeper", "2Late", "Adren4lynne", "FuRii0uS", "H0STiLi7i", "Hir0", "inSI0us", "M4GIIKZ", "MySt3Ry", "N0buN4g4", "N1rVaNa", "PR0diiGy", "Re4lity", "Sh4DoW", "SiL3nT", "ZyM3R" });
            listChans.AddRange(new string[] { "wiedi", "smartos", "393VGH3978", "quake", "semageek", "torrentz", "War3z", "ircbar", "politics", "efnet.org", "quakenet", "helpme", "vengeance", "omnios", "h4ck3rs", "mr_robot", "freenode", "MindForge", "Lunatic", "VirtualLife", "yocto", "ubuntu", "ayatana", "bzr" });
            listNomsComplices.AddRange(new string[] { "Baker Al Belgiki", "Moussa Qurayshi", "Omar" });
            ReadLog();
        }

        private void ReadLog()
        {
            logText = File.ReadAllLines("log.txt");
        }

        delegate void AddTextCallback(string txt);

        public void AddText(string txt)
        {
            if (tb_texteChat.InvokeRequired)
            {
                AddTextCallback d = new AddTextCallback(AddText);
                this.Invoke(d, new object[] { txt });
            }
            else
                tb_texteChat.AppendText(Environment.NewLine + txt);
        }

        public void AddChat(string pseudo, string txt)
        {
            if (currentChan != "")
                AddText("["+ GetTime() + "] " + pseudo + " : " + txt);
        }

        public string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        private void b_envoyer_Click(object sender, EventArgs e)
        {
            HandleInput(tb_texteInput.Text);
            tb_texteInput.Clear();
        }

        public void HandleInput(string txt)
        {
            if (txt.StartsWith("/"))
            {
                string[] tab = txt.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                if (tab[0] == "/help")
                {
                    //AddText("__Réponse " + txt);
                    //AddText("_______________________________________________________________________________");
                    //AddText(txt);
                    if (tab.Length == 1)
                    {
                        AddText("Commandes disponibles :");
                        AddText("/help /list /join /quit /whoami /clear");
                        AddText("Obtenir de l'aide sur une commande : /help commande");
                    }
                    else if (tab.Length == 2)
                    {
                        string cmd = tab[1].TrimStart(new char[] { '/' });
                        if (cmd == "list") AddText("/list chans : Liste les canaux" + Environment.NewLine + "/list users : Liste les utilisateurs");
                        else if (cmd == "help") AddText("/help : Donne une aide sur les commandes");
                        else if (cmd == "join") AddText("/join : Se connecter à un canal");
                        else if (cmd == "quit") AddText("/quit : Quitter un canal");
                        else if (cmd == "whoami") AddText("/whoami : Donne le nom de l'utilisateur courant");
                        else if (cmd == "clear") AddText("/clear : efface le contenu du chat");
                    }

                }
                else if (tab[0] == "/list" && tab.Length == 2)
                {
                    if (tab[1] == "users")
                    {
                        if (currentChan == "vengeance") RemplirLisbox(listNomsComplices);
                        else if (currentChan != "") RemplirLisbox(listCurrentPseudo);
                        else AddText("Pas de canal rejoint");
                    }
                    else if (tab[1] == "chans")
                    {
                        AddText("Liste des canaux :");
                        AddText(string.Join(", ", listChans));
                        RemplirLisbox(listChans);
                    }

                }
                else if (tab[0] == "/join")
                {
                    if (tab.Length == 2)
                    {
                        if (listChans.Contains(tab[1]))
                        {
                            tb_texteChat.Clear();
                            if (currentChan != "")
                                AddText("Déconnexion du canal " + currentChan);

                            currentChan = tab[1];
                            lb_liste.Items.Clear();
                            AddText("Vous avez rejoint le canal " + currentChan);

                            if (currentChan != chanOPE)
                            {
                                listCurrentPseudo = GetListPseudo();
                                animating = true;
                                animateChan = Task.Run(() => { AnimateChan(); });
                            }
                            else
                                animating = false;
                        }
                        else
                            AddText(tab[1] + " : canal non trouvé");
                    }
                    else
                        AddText("Canal non renseigné");
                }
                else if (tab[0] == "/quit")
                {
                    if (currentChan != "")
                    {
                        animating = false;
                        tb_texteChat.Clear();
                        lb_liste.Items.Clear();

                        AddText("Vous avez quitté le canal " + currentChan);
                        currentChan = "";
                        if (animateChan != null) animateChan.Wait(1);
                    }
                }
                else if (tab[0] == "/clear")
                {
                    tb_texteChat.Clear();
                }
                else if (tab[0] == "/whoami")
                {
                    AddText("Vous êtes connectés en tant que " + nomLocal);
                }
                else
                {
                    AddText("Commande inconnue");
                }
            }
            else
            {
                AddChat(nomLocal, txt);

                if (currentChan == chanOPE && !utilCompromis)
                {
                    utilCompromis = true;
                    Task.Run(() => {
                        System.Threading.Thread.Sleep(2500);
                        AddChat(listNomsComplices[0], "Qu'est-ce que tu fais là ? Tu es censé tout préparer");
                        System.Threading.Thread.Sleep(5700);
                        AddChat(listNomsComplices[1], "La position est compromise. Efface tout");
                        System.Threading.Thread.Sleep(9900);
                        AddChat(listNomsComplices[2], "Déconnectez le du logiciel !");
                    });

                }
            }
        }


        private void AnimateChan()
        {
            Random rng = new Random();
            do
            {
                System.Threading.Thread.Sleep(rng.Next(15,90) * 100);
                if (animating)
                {
                    string pseudo = listCurrentPseudo[rng.Next(0, listCurrentPseudo.Count)];
                    AddChat(pseudo, logText[compteurLog]);
                    if (++compteurLog >= logText.Length) compteurLog = 0;
                }

            } while (animating);

        }


        public void RemplirLisbox(List<string> liste)
        {
            lb_liste.Items.Clear();
            
            for (int i = 0; i < liste.Count; i++)
            {
                lb_liste.Items.Add(liste[i]);
            }
        }


        public List<string> GetListPseudo()
        {
            Random rng = new Random();
            int nbPseudo = rng.Next(15, 65);

            List<string> list = new List<string>();

            for (int i = 0; i < listPseudo.Count; i++)
            {
                if (rng.Next(0,100) % 5 == 0)
                    list.Add(listPseudo[i]);
            }

            return list;
        }


        private void tb_texteInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')//(char)13)
            {
                HandleInput(tb_texteInput.Text);
                e.Handled = true;
                tb_texteInput.Clear();

            }
        }

        private void ChatWindow_Shown(object sender, EventArgs e)
        {
            Popup p = new Popup(mdp);
            p.ShowDialog();

            if (!p.mdpValide)
            {
                MessageBox.Show("MDP incorrect");
                this.Close();
            }
            else
            {
                AddText("Connexion en cours...");
                AddText("Connexion établie au serveur IRC 82.118.154.83");
                AddText("Taper /help pour lister les commandes");
                tb_texteInput.Focus();
            }
        }

        private void lb_liste_DoubleClick(object sender, EventArgs e)
        {
            if (lb_liste.SelectedIndex > -1)
            {
                tb_texteInput.AppendText(lb_liste.Items[lb_liste.SelectedIndex].ToString());
            }
        }
    }
}
