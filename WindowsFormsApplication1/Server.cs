using System;
using System.ServiceModel;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Server : Form
    {
        public Server()
        {
            InitializeComponent();
        }

        private ServiceHost host = null;

        private void buttonCreate_Click(object sender, EventArgs e)
        {
            host = new ServiceHost(typeof(ServicePim.ServicePim));
            host.Closed += host_State;
            host.Closing += host_State;
            host.Faulted += host_State;
            host.Opened += host_State;
            host.Opening += host_State;
            this.textBoxState.Text = "Created";
        }

        private void host_State(object sender, EventArgs e)
        {
            this.textBoxState.Text = this.host.State.ToString();
        }


        private void buttonOpen_Click(object sender, EventArgs e)
        {
            if (this.host != null)
            {
                if (this.host.State == CommunicationState.Opened)
                {
                    this.host.Close();
                    this.buttonOpen.Text = "Ouvrir";
                }
                else
                {
                    this.host.Open();
                    this.listBox1.Items.Clear();
                    foreach (var item in host.Description.Behaviors)
                    {
                        if (item is ServiceBehaviorAttribute)
                        {
                            this.listBox1.Items.Add(((ServiceBehaviorAttribute)item).InstanceContextMode.ToString());
                        }
                    }
                    foreach (var item in host.Description.Endpoints)
                    {
                        this.listBox1.Items.Add(item.Name);
                    }
                    this.buttonOpen.Text = "Fermer";
                }
            }
        }
    }

}
