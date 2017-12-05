using System.Windows.Forms;

namespace Client.FormIhm
{
    partial class Pim
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
            this.components = new System.ComponentModel.Container();
            this.Commandes = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.réinitialiserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bagageIdButton = new System.Windows.Forms.Button();
            this.bagageIataButton = new System.Windows.Forms.Button();
            this.bagageIdTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.rushCheckBox = new System.Windows.Forms.CheckBox();
            this.classTextBox = new System.Windows.Forms.TextBox();
            this.continuationCheckBox = new System.Windows.Forms.CheckBox();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.explotationDayTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lineTextBox = new System.Windows.Forms.TextBox();
            this.companyTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.searchControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.saveNewButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.prioritySave = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.destinationSave = new System.Windows.Forms.TextBox();
            this.codeIataLabel = new System.Windows.Forms.Label();
            this.rushSave = new System.Windows.Forms.CheckBox();
            this.classSave = new System.Windows.Forms.TextBox();
            this.continueSave = new System.Windows.Forms.CheckBox();
            this.codeIataSave = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lineSave = new System.Windows.Forms.TextBox();
            this.companySave = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Commandes.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.searchControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Commandes
            // 
            this.Commandes.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.réinitialiserToolStripMenuItem});
            this.Commandes.Name = "contextMenuStrip1";
            this.Commandes.Size = new System.Drawing.Size(135, 26);
            // 
            // réinitialiserToolStripMenuItem
            // 
            this.réinitialiserToolStripMenuItem.Name = "réinitialiserToolStripMenuItem";
            this.réinitialiserToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.réinitialiserToolStripMenuItem.Text = "Réinitialiser";
            // 
            // clearButton
            // 
            this.clearButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.clearButton.Location = new System.Drawing.Point(0, 0);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(83, 26);
            this.clearButton.TabIndex = 22;
            this.clearButton.Text = "Réinitialiser";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveButton.Location = new System.Drawing.Point(459, 0);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(83, 26);
            this.saveButton.TabIndex = 21;
            this.saveButton.Text = "Sauvegarder";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.bagageIdButton);
            this.groupBox1.Controls.Add(this.bagageIataButton);
            this.groupBox1.Controls.Add(this.bagageIdTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(542, 58);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rechercher";
            // 
            // bagageIdButton
            // 
            this.bagageIdButton.Location = new System.Drawing.Point(426, 16);
            this.bagageIdButton.Name = "bagageIdButton";
            this.bagageIdButton.Size = new System.Drawing.Size(83, 23);
            this.bagageIdButton.TabIndex = 4;
            this.bagageIdButton.Text = "by ID";
            this.bagageIdButton.UseVisualStyleBackColor = true;
            // 
            // bagageIataButton
            // 
            this.bagageIataButton.Location = new System.Drawing.Point(331, 16);
            this.bagageIataButton.Name = "bagageIataButton";
            this.bagageIataButton.Size = new System.Drawing.Size(83, 23);
            this.bagageIataButton.TabIndex = 3;
            this.bagageIataButton.Text = "by IATA code";
            this.bagageIataButton.UseVisualStyleBackColor = true;
            // 
            // bagageIdTextBox
            // 
            this.bagageIdTextBox.Location = new System.Drawing.Point(97, 19);
            this.bagageIdTextBox.Name = "bagageIdTextBox";
            this.bagageIdTextBox.Size = new System.Drawing.Size(219, 20);
            this.bagageIdTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code Iata / ID :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 58);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(542, 176);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Résultat";
            // 
            // groupBox4
            // 
            this.groupBox4.AutoSize = true;
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.rushCheckBox);
            this.groupBox4.Controls.Add(this.classTextBox);
            this.groupBox4.Controls.Add(this.continuationCheckBox);
            this.groupBox4.Controls.Add(this.destinationTextBox);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(301, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(238, 157);
            this.groupBox4.TabIndex = 14;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Bagage";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 28);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Itinéraire :";
            // 
            // rushCheckBox
            // 
            this.rushCheckBox.AutoSize = true;
            this.rushCheckBox.Location = new System.Drawing.Point(114, 120);
            this.rushCheckBox.Name = "rushCheckBox";
            this.rushCheckBox.Size = new System.Drawing.Size(51, 17);
            this.rushCheckBox.TabIndex = 20;
            this.rushCheckBox.Text = "Rush";
            this.rushCheckBox.UseVisualStyleBackColor = true;
            // 
            // classTextBox
            // 
            this.classTextBox.Location = new System.Drawing.Point(114, 69);
            this.classTextBox.Name = "classTextBox";
            this.classTextBox.Size = new System.Drawing.Size(118, 20);
            this.classTextBox.TabIndex = 18;
            // 
            // continuationCheckBox
            // 
            this.continuationCheckBox.AutoSize = true;
            this.continuationCheckBox.Location = new System.Drawing.Point(114, 97);
            this.continuationCheckBox.Name = "continuationCheckBox";
            this.continuationCheckBox.Size = new System.Drawing.Size(85, 17);
            this.continuationCheckBox.TabIndex = 19;
            this.continuationCheckBox.Text = "Continuation";
            this.continuationCheckBox.UseVisualStyleBackColor = true;
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Location = new System.Drawing.Point(114, 28);
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(118, 20);
            this.destinationTextBox.TabIndex = 16;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Classe bagage :";
            // 
            // groupBox3
            // 
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.explotationDayTextBox);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lineTextBox);
            this.groupBox3.Controls.Add(this.companyTextBox);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 157);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Vol";
            // 
            // explotationDayTextBox
            // 
            this.explotationDayTextBox.Location = new System.Drawing.Point(114, 94);
            this.explotationDayTextBox.Name = "explotationDayTextBox";
            this.explotationDayTextBox.Size = new System.Drawing.Size(118, 20);
            this.explotationDayTextBox.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Compagnie :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 97);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Jour d\'exploitation :";
            // 
            // lineTextBox
            // 
            this.lineTextBox.Location = new System.Drawing.Point(114, 59);
            this.lineTextBox.Name = "lineTextBox";
            this.lineTextBox.Size = new System.Drawing.Size(118, 20);
            this.lineTextBox.TabIndex = 10;
            // 
            // companyTextBox
            // 
            this.companyTextBox.Location = new System.Drawing.Point(114, 21);
            this.companyTextBox.Name = "companyTextBox";
            this.companyTextBox.Size = new System.Drawing.Size(118, 20);
            this.companyTextBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 9;
            this.label7.Text = "Ligne :";
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.panel2);
            this.panel5.Controls.Add(this.groupBox2);
            this.panel5.Controls.Add(this.groupBox1);
            this.panel5.Location = new System.Drawing.Point(5, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(542, 263);
            this.panel5.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.clearButton);
            this.panel2.Controls.Add(this.saveButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 237);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(542, 26);
            this.panel2.TabIndex = 23;
            // 
            // searchControl
            // 
            this.searchControl.AccessibleName = "";
            this.searchControl.Controls.Add(this.tabPage1);
            this.searchControl.Controls.Add(this.tabPage2);
            this.searchControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchControl.Location = new System.Drawing.Point(0, 0);
            this.searchControl.Name = "searchControl";
            this.searchControl.SelectedIndex = 0;
            this.searchControl.Size = new System.Drawing.Size(568, 300);
            this.searchControl.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(560, 274);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search/Modify";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(560, 274);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Create";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.saveNewButton);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(3, 249);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(554, 22);
            this.panel3.TabIndex = 24;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Left;
            this.button2.Location = new System.Drawing.Point(0, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 22);
            this.button2.TabIndex = 23;
            this.button2.Text = "Réinitialiser";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // saveNewButton
            // 
            this.saveNewButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.saveNewButton.Location = new System.Drawing.Point(471, 0);
            this.saveNewButton.Name = "saveNewButton";
            this.saveNewButton.Size = new System.Drawing.Size(83, 22);
            this.saveNewButton.TabIndex = 22;
            this.saveNewButton.Text = "Sauvegarder";
            this.saveNewButton.UseVisualStyleBackColor = true;
            this.saveNewButton.Click += new System.EventHandler(this.saveNewButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox6);
            this.groupBox5.Controls.Add(this.groupBox7);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(554, 208);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Création";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.prioritySave);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.destinationSave);
            this.groupBox6.Controls.Add(this.codeIataLabel);
            this.groupBox6.Controls.Add(this.rushSave);
            this.groupBox6.Controls.Add(this.classSave);
            this.groupBox6.Controls.Add(this.continueSave);
            this.groupBox6.Controls.Add(this.codeIataSave);
            this.groupBox6.Controls.Add(this.label3);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox6.Location = new System.Drawing.Point(297, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(254, 189);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Bagage";
            // 
            // prioritySave
            // 
            this.prioritySave.AutoSize = true;
            this.prioritySave.Location = new System.Drawing.Point(114, 165);
            this.prioritySave.Name = "prioritySave";
            this.prioritySave.Size = new System.Drawing.Size(69, 17);
            this.prioritySave.TabIndex = 21;
            this.prioritySave.Text = "Prioritaire";
            this.prioritySave.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 21;
            this.label14.Text = "Itinéraire :";
            // 
            // destinationSave
            // 
            this.destinationSave.Location = new System.Drawing.Point(114, 59);
            this.destinationSave.Name = "destinationSave";
            this.destinationSave.Size = new System.Drawing.Size(118, 20);
            this.destinationSave.TabIndex = 17;
            // 
            // codeIataLabel
            // 
            this.codeIataLabel.AutoSize = true;
            this.codeIataLabel.Location = new System.Drawing.Point(6, 24);
            this.codeIataLabel.Name = "codeIataLabel";
            this.codeIataLabel.Size = new System.Drawing.Size(96, 13);
            this.codeIataLabel.TabIndex = 14;
            this.codeIataLabel.Text = "Code Iata complet:";
            // 
            // rushSave
            // 
            this.rushSave.AutoSize = true;
            this.rushSave.Location = new System.Drawing.Point(114, 142);
            this.rushSave.Name = "rushSave";
            this.rushSave.Size = new System.Drawing.Size(51, 17);
            this.rushSave.TabIndex = 20;
            this.rushSave.Text = "Rush";
            this.rushSave.UseVisualStyleBackColor = true;
            // 
            // classSave
            // 
            this.classSave.Location = new System.Drawing.Point(114, 91);
            this.classSave.Name = "classSave";
            this.classSave.Size = new System.Drawing.Size(118, 20);
            this.classSave.TabIndex = 18;
            // 
            // continueSave
            // 
            this.continueSave.AutoSize = true;
            this.continueSave.Location = new System.Drawing.Point(114, 119);
            this.continueSave.Name = "continueSave";
            this.continueSave.Size = new System.Drawing.Size(85, 17);
            this.continueSave.TabIndex = 19;
            this.continueSave.Text = "Continuation";
            this.continueSave.UseVisualStyleBackColor = true;
            // 
            // codeIataSave
            // 
            this.codeIataSave.Location = new System.Drawing.Point(114, 24);
            this.codeIataSave.Name = "codeIataSave";
            this.codeIataSave.Size = new System.Drawing.Size(118, 20);
            this.codeIataSave.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Classe bagage :";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label4);
            this.groupBox7.Controls.Add(this.lineSave);
            this.groupBox7.Controls.Add(this.companySave);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(3, 16);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(254, 189);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Vol";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Code Iata compagnie :";
            // 
            // lineSave
            // 
            this.lineSave.Location = new System.Drawing.Point(114, 59);
            this.lineSave.Name = "lineSave";
            this.lineSave.Size = new System.Drawing.Size(118, 20);
            this.lineSave.TabIndex = 10;
            // 
            // companySave
            // 
            this.companySave.Location = new System.Drawing.Point(134, 21);
            this.companySave.Name = "companySave";
            this.companySave.Size = new System.Drawing.Size(98, 20);
            this.companySave.TabIndex = 8;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 59);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(39, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Ligne :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Left;
            this.label12.Enabled = false;
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "label12";
            this.label12.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Dock = System.Windows.Forms.DockStyle.Right;
            this.label13.Location = new System.Drawing.Point(527, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 11;
            this.label13.Text = "label13";
            this.label13.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 306);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(568, 17);
            this.panel1.TabIndex = 12;
            // 
            // Pim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 323);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.searchControl);
            this.Name = "Pim";
            this.Text = "pimForm";
            this.Commandes.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.searchControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private ContextMenuStrip Commandes;
        private ToolStripMenuItem réinitialiserToolStripMenuItem;
        private Button clearButton;
        private Button saveButton;
        private GroupBox groupBox1;
        private Button bagageIdButton;
        private Button bagageIataButton;
        private TextBox bagageIdTextBox;
        private Label label2;
        private GroupBox groupBox2;
        private GroupBox groupBox4;
        private Label label9;
        private CheckBox rushCheckBox;
        private TextBox classTextBox;
        private CheckBox continuationCheckBox;
        private TextBox destinationTextBox;
        private Label label10;
        private GroupBox groupBox3;
        private TextBox explotationDayTextBox;
        private Label label6;
        private Label label8;
        private TextBox lineTextBox;
        private TextBox companyTextBox;
        private Label label7;
        private Panel panel5;
        private TabControl searchControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private CheckBox rushSave;
        private TextBox classSave;
        private CheckBox continueSave;
        private Label label3;
        private GroupBox groupBox7;
        private Label label4;
        private TextBox lineSave;
        private TextBox companySave;
        private Label label11;
        private Button button2;
        private Button saveNewButton;
        private Label label12;
        private Label label13;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Label label14;
        private TextBox destinationSave;
        private Label codeIataLabel;
        private TextBox codeIataSave;
        private CheckBox prioritySave;
    }
}

