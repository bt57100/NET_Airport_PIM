using MyAirport.Pim.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.FormIhm
{

    public partial class BagageSelectForm : Form
    {
        public List<BagageDefinition> bagages { get; set; }

        public BagageSelectForm()
        {
            InitializeComponent();
        }

        public void refresh()
        {
            bagageList.Items.Clear();
            foreach(BagageDefinition bagage in bagages)
            {
                bagageList.Items.Add(bagage);
            }
        }
    }
}
