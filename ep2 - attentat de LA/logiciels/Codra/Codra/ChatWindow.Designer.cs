namespace Codra
{
    partial class ChatWindow
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_texteChat = new System.Windows.Forms.TextBox();
            this.lb_liste = new System.Windows.Forms.ListBox();
            this.tb_texteInput = new System.Windows.Forms.TextBox();
            this.b_envoyer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_texteChat
            // 
            this.tb_texteChat.Location = new System.Drawing.Point(12, 12);
            this.tb_texteChat.Multiline = true;
            this.tb_texteChat.Name = "tb_texteChat";
            this.tb_texteChat.Size = new System.Drawing.Size(483, 238);
            this.tb_texteChat.TabIndex = 3;
            // 
            // lb_liste
            // 
            this.lb_liste.FormattingEnabled = true;
            this.lb_liste.Location = new System.Drawing.Point(501, 12);
            this.lb_liste.Name = "lb_liste";
            this.lb_liste.Size = new System.Drawing.Size(120, 238);
            this.lb_liste.TabIndex = 4;
            this.lb_liste.DoubleClick += new System.EventHandler(this.lb_liste_DoubleClick);
            // 
            // tb_texteInput
            // 
            this.tb_texteInput.Location = new System.Drawing.Point(12, 256);
            this.tb_texteInput.Multiline = true;
            this.tb_texteInput.Name = "tb_texteInput";
            this.tb_texteInput.Size = new System.Drawing.Size(483, 52);
            this.tb_texteInput.TabIndex = 1;
            this.tb_texteInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_texteInput_KeyPress);
            // 
            // b_envoyer
            // 
            this.b_envoyer.Location = new System.Drawing.Point(501, 256);
            this.b_envoyer.Name = "b_envoyer";
            this.b_envoyer.Size = new System.Drawing.Size(120, 52);
            this.b_envoyer.TabIndex = 2;
            this.b_envoyer.Text = "Envoyer";
            this.b_envoyer.UseVisualStyleBackColor = true;
            this.b_envoyer.Click += new System.EventHandler(this.b_envoyer_Click);
            // 
            // ChatWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 317);
            this.Controls.Add(this.b_envoyer);
            this.Controls.Add(this.tb_texteInput);
            this.Controls.Add(this.lb_liste);
            this.Controls.Add(this.tb_texteChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "ChatWindow";
            this.Text = "ChatWindow";
            this.Shown += new System.EventHandler(this.ChatWindow_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_texteChat;
        private System.Windows.Forms.ListBox lb_liste;
        private System.Windows.Forms.TextBox tb_texteInput;
        private System.Windows.Forms.Button b_envoyer;
    }
}

