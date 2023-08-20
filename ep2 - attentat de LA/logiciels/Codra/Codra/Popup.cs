using System;
using System.Windows.Forms;

namespace Codra
{
    public partial class Popup : Form
    {
        public bool mdpValide = false;
        string mdp;
        string mdpInput = "";

        public Popup(string mdp)
        {
            InitializeComponent();
            this.mdp = mdp;
        }

        private void b_valider_Click(object sender, EventArgs e)
        {
            mdpInput = tb_mdp.Text;
            Close();
        }



        private void tb_mdp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mdpInput = tb_mdp.Text;
                this.Close();
            }
        }

        private void Popup_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mdp == mdpInput.ToLower())
                mdpValide = true;
        }

    }
}
