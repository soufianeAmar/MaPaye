using DevExpress.Xpo;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MaPaye.Module
{
    public partial class ParamètresIndemnité : Form
    {
        Session Session;
        public List<string> parametresIndem = new List<string>();
        public List<bool> valeures = new List<bool>();

        public ParamètresIndemnité(Session session)
        {
            InitializeComponent();
        }

        private void checkEdit1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkEdit1.Checked)
            {
                foreach (CheckedListBoxItem item in checkedListBoxControl1.Items)
                {
                    item.CheckState = CheckState.Checked;
                }
            }
            else
            {
                foreach (CheckedListBoxItem item in checkedListBoxControl1.Items)
                {
                    item.CheckState = CheckState.Unchecked;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBoxControl1.Items.Count; i++)
            {
                CheckedListBoxItem item = (CheckedListBoxItem)checkedListBoxControl1.GetItem(i);
                string parametre = item.Value.ToString();
                parametresIndem.Add(parametre);
                bool valeure = Convert.ToBoolean(item.CheckState);
                valeures.Add(valeure);
            }
        }
    }
}
