namespace Codra
{
    partial class Popup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_mdp = new System.Windows.Forms.TextBox();
            this.b_valider = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_mdp
            // 
            this.tb_mdp.AcceptsReturn = true;
            this.tb_mdp.Location = new System.Drawing.Point(96, 21);
            this.tb_mdp.Name = "tb_mdp";
            this.tb_mdp.Size = new System.Drawing.Size(159, 20);
            this.tb_mdp.TabIndex = 0;
            this.tb_mdp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tb_mdp_KeyDown);
            // 
            // b_valider
            // 
            this.b_valider.Location = new System.Drawing.Point(261, 20);
            this.b_valider.Name = "b_valider";
            this.b_valider.Size = new System.Drawing.Size(75, 20);
            this.b_valider.TabIndex = 1;
            this.b_valider.Text = "Valider";
            this.b_valider.UseVisualStyleBackColor = true;
            this.b_valider.Click += new System.EventHandler(this.b_valider_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mot de passe :";
            // 
            // Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 61);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_valider);
            this.Controls.Add(this.tb_mdp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Popup";
            this.Text = "Popup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Popup_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_mdp;
        private System.Windows.Forms.Button b_valider;
        private System.Windows.Forms.Label label1;
    }
}