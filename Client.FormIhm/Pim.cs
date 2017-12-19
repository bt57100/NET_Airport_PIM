using Client.FormIhm.ServiceReferencePim;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Windows.Forms;

namespace Client.FormIhm
{
    /// <summary>
    /// Form client
    /// </summary>
    public partial class Pim : System.Windows.Forms.Form
    {
        private ServicePimClient proxy = new ServicePimClient();
        private BagageDefinition selectedBagage;
        private PimState state;
        public event PimStateEventHandler PimStateChanged;
        public delegate void PimStateEventHandler(object sender, PimState state);

        private PimState State
        {
            get { return this.state; }
            set { OnPimStateChanged(value); }
        }

        /// <summary>
        /// Action on pim state changed
        /// </summary>
        /// <param name="newState"></param>
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

        /// <summary>
        /// Constructor
        /// </summary>
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

        /// <summary>
        /// Initial state: disconnect/waiting for user action
        /// </summary>
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

        /// <summary>
        /// State waiting bagage
        /// </summary>
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

        /// <summary>
        /// State bagage selected
        /// </summary>
        public void selectBagage()
        {
            bagageIdTextBox.Enabled = true;
            clearButton.Enabled = true;
            bagageIdButton.Enabled = true;
            bagageIataButton.Enabled = true;
            lineTextBox.Enabled = true;
            destinationTextBox.Enabled = true;
            classTextBox.Enabled = true;
            continuationCheckBox.Enabled = true;
            rushCheckBox.Enabled = true;
            saveButton.Enabled = true;
        }

        /// <summary>
        /// State create bagage
        /// </summary>
        public void createBagage()
        {
            // may be needed in the project future
        }

        /// <summary>
        /// State display bagage
        /// </summary>
        public void displayBagage()
        {
            // may be needed in the project future
        }

        /// <summary>
        /// Search bagage by id button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bagageIdButton_Click(object sender, EventArgs e)
        {
            BagageDefinition bagage = null;
            int id = Convert.ToInt32(bagageIdTextBox.Text);
            // Get bagage display, display message if error
            try
            {
                bagage = proxy.GetBagageById(id);
            }
            catch (AggregateException)
            {
                this.label12.Text += "Une erreur de communication c'est produite dans le traitement de votre demande";
                this.label12.Visible = true;
            }
            catch (Exception)
            {
                this.label12.Text += "Une erreur s'est produite dans le traitement de votre demande";
                this.label12.Visible = true;
            }

            if (bagage != null)
            {
                // if found, display it
                this.selectedBagage = bagage;
                State = PimState.DisplayBagage;
            }
            else
            {
                // if not found display message
                String tempId = bagageIdTextBox.Text;
                clearSearch();
                bagageIdTextBox.Text = tempId;
                this.label12.Text += " Pas de bagage trouvé pour l'id ";
                this.label12.Text += bagageIdTextBox.Text;
                this.label12.Visible = true;
            }
        }

        /// <summary>
        /// Search bagage by code iata on button action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bagageIataButton_Click(object sender, EventArgs e)
        {
            BagageDefinition bagages = null;
            label12.Text = "Message : ";
            //Get bagage by iata code
            try
            {
                bagages = proxy.GetBagageByCodeIata(bagageIdTextBox.Text);
                this.selectedBagage = bagages;
            }
            catch (FaultException<MultipleBagageFault> excp)
            {
                // if MultipleBagageFault exception open bagage select form to select a bagage
                BagageSelectForm bagageSelectForm = new BagageSelectForm();
                bagageSelectForm.Bagages = new List<BagageDefinition>(excp.Detail.ListBagages);
                bagageSelectForm.refresh();
                var result = bagageSelectForm.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    // if selected, 
                    this.selectedBagage = bagageSelectForm.BagageSelected;
                    State = PimState.DisplayBagage;
                }
                else if(result == DialogResult.Cancel)
                {
                    // if cancel return to previous state and clear the search tab
                    this.selectedBagage = null;
                    clearSearch();
                    State = PimState.Disconnect;
                }
            }
            catch (FaultException)
            {
                this.label12.Text += "Une erreur s'est produite dans le traitement de plusieurs bagages";
                this.label12.Visible = true;
            }
            catch (AggregateException)
            {
                this.label12.Text += "Une erreur de communication c'est produite dans le traitement de votre demande";
                this.label12.Visible = true;
            }
            catch (Exception)
            {
                this.label12.Text += "Une erreur s'est produite dans le traitement de votre demande";
                this.label12.Visible = true;
            }


            if (selectedBagage != null)
            {
                // if found display it
                State = PimState.DisplayBagage;
            }
            else
            {
                // if not found, clear all and display message
                String tempIata = bagageIdTextBox.Text;
                clearSearch();
                bagageIdTextBox.Text = tempIata;
                this.label12.Text += "Pas de bagage trouvé pour le code iata ";
                this.label12.Text += bagageIdTextBox.Text;
                this.label12.Visible = true;
            }

        }

        /// <summary>
        /// Clear all fields in search tab on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearButton_Click(object sender, EventArgs e)
        {
            clearSearch();
        }

        /// <summary>
        /// Clear all fields in search tab
        /// </summary>
        private void clearSearch()
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

        /// <summary>
        /// Change display state on state change
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="state"></param>
        private void PIM_PimStateChanged(object sender, PimState state)
        {
            label13.Visible = true;
            label13.Text = "StateChanged :" + state;
        }

        /// <summary>
        /// Display a bagage
        /// </summary>
        /// <param name="selectedBagage"></param>
        public void displayBagage(BagageDefinition selectedBagage)
        {
            if (selectedBagage != null)
            {
                // if found, display
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
                // if not found, display a message
                MessageBox.Show("Bagage not found ");
            }
        }

        /// <summary>
        /// Create a new bagage on button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveNewButton_Click(object sender, EventArgs e)
        {
            String codeIata = codeIataSave.Text;
            if (codeIata.Length == 12 && codeIata.Substring(codeIata.Length - 2).Equals("00"))
            {
                // if the iata code correspond to the format ____XXXXXX00
                BagageDefinition bagage = new BagageDefinition();
                bagage.CodeIata = codeIataSave.Text;
                bagage.Compagnie = companySave.Text;
                bagage.EnContinuation = continueSave.Checked;
                bagage.Itineraire = destinationSave.Text;
                bagage.Ligne = lineSave.Text;
                bagage.Prioritaire = prioritySave.Checked;
                bagage.Rush = rushSave.Checked;

                // save in the database and display a message whether it is saved
                try
                {
                    bagage.IdBagage = proxy.CreateBagage(bagage);
                    State = PimState.CreateBagage;
                    MessageBox.Show("Bagage saved ! id=" + bagage.IdBagage);
                }
                catch (FaultException excp)
                {
                    this.label12.Text += excp.Message;
                    this.label12.Visible = true;
                }
                catch (AggregateException)
                {
                    this.label12.Text += "Une erreur de communication s'est produite dans le traitement de votre demande";
                    this.label12.Visible = true;
                }
                catch (Exception)
                {
                    this.label12.Text += "Une erreur s'est produite dans le traitement de votre demande";
                    this.label12.Visible = true;
                }
            }
            else
            {
                // if iata code format does not coresspond, display a message
                label12.Text = "Message : Le code iata ne correspond pas au bon format 12 caractères finissant par 00";
            }
        }

        /// <summary>
        /// Update a bagage, company and creation date cannot be modified
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            BagageDefinition bagage = new BagageDefinition();
            bagage.IdBagage = selectedBagage.IdBagage;
            bagage.CodeIata = selectedBagage.CodeIata;
            bagage.EnContinuation = continuationCheckBox.Checked;
            bagage.Itineraire = destinationTextBox.Text;
            bagage.Ligne = lineTextBox.Text;
            bagage.Prioritaire = !(classTextBox.Text.Equals("") || classTextBox.Text.Equals("Non prioritaire"));
            bagage.Rush = rushCheckBox.Checked;

            // update in the database and display a message whether it is updated
            try
            {
                selectedBagage = proxy.UpdateBagage(bagage);
                State = PimState.DisplayBagage;
                MessageBox.Show("Bagage saved ! id=" + bagage.IdBagage);
            }
            catch (FaultException excp)
            {
                this.label12.Text += excp.Message;
                this.label12.Visible = true;
            }
            catch (AggregateException)
            {
                this.label12.Text += "Une erreur de communication s'est produite dans le traitement de votre demande";
                this.label12.Visible = true;
            }
            catch (Exception)
            {
                this.label12.Text += "Une erreur s'est produite dans le traitement de votre demande";
                this.label12.Visible = true;
            }
        }

        /// <summary>
        /// Clear all fields in the create tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void resetSave_Click(object sender, EventArgs e)
        {
            companySave.Text = "";
            lineSave.Text = "";
            codeIataSave.Text = "";
            destinationSave.Text = "";
            continueSave.Checked = false;
            rushSave.Checked = false;
            prioritySave.Checked = false;
        }
    }
}
