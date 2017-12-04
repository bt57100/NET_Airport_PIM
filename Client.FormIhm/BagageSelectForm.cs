using Client.FormIhm.ServiceReferencePim;
using System;
using System.Collections.Generic;

namespace Client.FormIhm
{

    public partial class BagageSelectForm : System.Windows.Forms.Form
    {
        public BagageDefinition BagageSelected { get; set; }
        public List<BagageDefinition> Bagages { get; set; }

        public BagageSelectForm()
        {
            InitializeComponent();
            okButton.Click += new EventHandler(this.okButton_Click);
        }

        public void refresh()
        {
            bagageList.Items.Clear();
            foreach(BagageDefinition bagage in Bagages)
            {
                bagageList.Items.Add(bagage);
            }
        }
    }
}
