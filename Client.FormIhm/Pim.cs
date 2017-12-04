﻿using Client.FormIhm.ServiceReferencePim;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.ServiceModel;
using System.Windows.Forms;

namespace Client.FormIhm
{
    public partial class Pim : System.Windows.Forms.Form
    {
        private ServiceReferencePim.ServicePimClient proxy = new ServiceReferencePim.ServicePimClient();
        private BagageDefinition selectedBagage;
        private PimState state;
        public event PimStateEventHandler PimStateChanged;
        public delegate void PimStateEventHandler(object sender, PimState state);

        private PimState State
        {
            get { return this.state; }
            set { OnPimStateChanged(value); }
        }

        private void OnPimStateChanged(PimState newState)
        {
            if (newState != this.state)
            {
                this.state = newState;
                PimStateChanged(this, this.state);
                switch (newState)
                {
                    case PimState.CreateBagage:
                        createBagage();
                        break;
                    case PimState.DisplayBagage:
                        displayBagage();
                        displayBagage(selectedBagage);
                        break;
                    case PimState.SelectBagage:
                        selectBagage();
                        break;
                    case PimState.WaitingBagage:
                        waitingBagage();
                        break;
                    default:
                        disconnect();
                        break;
                }
            }
        }

        public Pim()
        {
            InitializeComponent();
            PimStateChanged += PIM_PimStateChanged;
            bagageIdButton.Click += new EventHandler(this.bagageIdButton_Click);
            bagageIataButton.Click += new EventHandler(this.bagageIataButton_Click);
            clearButton.Click += new EventHandler(this.clearButton_Click);
            disconnect();
            this.state = PimState.Disconnect;
        }

        public void disconnect()
        {
            bagageIdTextBox.Enabled = true;
            clearButton.Enabled = true;
            bagageIdButton.Enabled = true;
            bagageIataButton.Enabled = true;
            companyTextBox.Enabled = false;
            lineTextBox.Enabled = false;
            explotationDayTextBox.Enabled = false;
            destinationTextBox.Enabled = false;
            classTextBox.Enabled = false;
            continuationCheckBox.Enabled = false;
            rushCheckBox.Enabled = false;
            saveButton.Enabled = false;
        }

        public void waitingBagage()
        {
            bagageIdTextBox.Enabled = true;
            clearButton.Enabled = true;
            bagageIdButton.Enabled = true;
            bagageIataButton.Enabled = true;
            companyTextBox.Enabled = false;
            lineTextBox.Enabled = false;
            explotationDayTextBox.Enabled = false;
            destinationTextBox.Enabled = false;
            classTextBox.Enabled = false;
            continuationCheckBox.Enabled = false;
            rushCheckBox.Enabled = false;
            saveButton.Enabled = false;
        }

        public void selectBagage()
        {
            bagageIdTextBox.Enabled = true;
            clearButton.Enabled = true;
            bagageIdButton.Enabled = true;
            bagageIataButton.Enabled = true;
            companyTextBox.Enabled = true;
            lineTextBox.Enabled = true;
            explotationDayTextBox.Enabled = true;
            destinationTextBox.Enabled = true;
            classTextBox.Enabled = true;
            continuationCheckBox.Enabled = true;
            rushCheckBox.Enabled = true;
            saveButton.Enabled = true;
        }

        public void createBagage()
        {

        }

        public void displayBagage()
        {

        }


        private void bagageIdButton_Click(object sender, EventArgs e)
        {
            BagageDefinition bagage = null;
            int id = Convert.ToInt32(bagageIdTextBox.Text);
            try
            {
                bagage = proxy.GetBagageById(id);
            }
            catch (AggregateException excp)
            {
                this.label12.Text += "Une erreur de communication c'est produite dans le traitement de votre demande";
                this.label12.Text += excp.Message;
                this.label12.Visible = true;
            }
            catch (Exception excp)
            {
                this.label12.Text += "Une erreur s'est produite dans le traitement de votre demande";
                this.label12.Text += excp.Message;
                this.label12.Visible = true;
            }

            if (bagage != null)
            {
                this.selectedBagage = bagage;
                State = PimState.DisplayBagage;
            }
            else
            {
                this.label12.Text += "Message : Pas de bagage trouvé pour l'id ";
                this.label12.Text += bagageIdTextBox.Text;
                this.label12.Visible = true;
            }
        }

        private void bagageIataButton_Click(object sender, EventArgs e)
        {
            BagageDefinition bagages = null;
            label12.Text = "Message : ";
            try
            {
                bagages = proxy.GetBagageByCodeIata(bagageIdTextBox.Text);
                this.selectedBagage = bagages;
            }
            catch (FaultException<MultipleBagageFault> excp)
            {
                BagageSelectForm bagageSelectForm = new BagageSelectForm();
                bagageSelectForm.Bagages = new List<BagageDefinition>(excp.Detail.ListBagages);
                bagageSelectForm.refresh();
                var result = bagageSelectForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    this.selectedBagage = bagageSelectForm.BagageSelected;
                    State = PimState.DisplayBagage;
                }
            }
            catch (FaultException excp)
            {
                this.label12.Text += "Une erreur s'est produite dans le traitement de plusieurs bagages";
                this.label12.Text += excp.Message;
                this.label12.Visible = true;
            }
            catch (AggregateException excp)
            {
                this.label12.Text += "Une erreur de communication c'est produite dans le traitement de votre demande";
                this.label12.Text += excp.Message;
                this.label12.Visible = true;
            }
            catch (Exception excp)
            {
                this.label12.Text += "Une erreur s'est produite dans le traitement de votre demande";
                this.label12.Text += excp.Message;
                this.label12.Visible = true;
            }


            if (selectedBagage != null)
            {
                State = PimState.DisplayBagage;
            }
            else
            {
                this.label12.Text += "Pas de bagage trouvé pour le code iata ";
                this.label12.Text += bagageIdTextBox.Text;
                this.label12.Visible = true;
            }

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            bagageIdTextBox.Text = "";
            companyTextBox.Text = "";
            lineTextBox.Text = "";
            explotationDayTextBox.Text = "";
            destinationTextBox.Text = "";
            classTextBox.Text = "";
            label12.Text = "Message : ";
            label12.Visible = false;
            continuationCheckBox.Checked = false;
            rushCheckBox.Checked = false;
            State = PimState.Disconnect;
        }

        void PIM_PimStateChanged(object sender, PimState state)
        {
            label13.Visible = true;
            label13.Text = "StateChanged :" + state;
        }

        public void displayBagage(BagageDefinition selectedBagage)
        {
            if (selectedBagage != null)
            {
                companyTextBox.Text = selectedBagage.Compagnie;
                lineTextBox.Text = selectedBagage.Ligne;
                explotationDayTextBox.Text = selectedBagage.DateVol.ToString("yyyy-MM-dd");
                destinationTextBox.Text = selectedBagage.Itineraire;
                classTextBox.Text = selectedBagage.Prioritaire ? "Prioritaire" : "Non prioritaire";
                continuationCheckBox.Checked = selectedBagage.EnContinuation;
                rushCheckBox.Checked = selectedBagage.Rush;
                State = PimState.SelectBagage;
            }
            else
            {
                MessageBox.Show("Bagage not found ");
            }
        }

        private void saveNewButton_Click(object sender, EventArgs e)
        {
            BagageDefinition bagage = new BagageDefinition();
            bagage.CodeIata = codeIataSave.Text;
            bagage.Compagnie = companySave.Text;
            bagage.DateVol = DateTime.ParseExact(daySave.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            bagage.EnContinuation = continueSave.Checked;
            bagage.Itineraire = destinationSave.Text;
            bagage.Ligne = lineSave.Text;
            bagage.Prioritaire = prioritySave.Checked;
            bagage.Rush = rushSave.Checked;
            
            try
            {
                proxy.CreateBagage(bagage);
            }
            catch (AggregateException excp)
            {
                this.label12.Text += "Une erreur de communication c'est produite dans le traitement de votre demande";
                this.label12.Text += excp.Message;
                this.label12.Visible = true;
            }
            catch (Exception excp)
            {
                this.label12.Text += "Une erreur s'est produite dans le traitement de votre demande";
                this.label12.Text += excp.Message;
                this.label12.Visible = true;
            }
        }

        private void daySave_TextChanged(object sender, EventArgs e)
        {
            daySave.Text = "";
        }
    }
}