using Client.FormIhm.ServiceReferencePim;
using System;
using System.Windows.Forms;

namespace Client.FormIhm
{
    partial class BagageSelectForm
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

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.BagageSelected = (BagageDefinition)this.bagageList.SelectedItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidCastException excp)
            {
                MessageBox.Show("Erreur de sélection");
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.BagageSelected = null;
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bagageList = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.bagageList);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 238);
            this.panel1.TabIndex = 0;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(519, 203);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(12, 203);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // bagageList
            // 
            this.bagageList.Dock = System.Windows.Forms.DockStyle.Top;
            this.bagageList.FormattingEnabled = true;
            this.bagageList.Location = new System.Drawing.Point(0, 0);
            this.bagageList.Name = "bagageList";
            this.bagageList.Size = new System.Drawing.Size(606, 186);
            this.bagageList.TabIndex = 0;
            // 
            // BagageSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 238);
            this.Controls.Add(this.panel1);
            this.Name = "BagageSelectForm";
            this.Text = "SelectBagage";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ListBox bagageList;
    }
}

