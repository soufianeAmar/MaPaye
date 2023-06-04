using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.ExpressApp.Win;

namespace MaPaye.Win
{
    public partial class SplashScreenForm : Form
    {
        public SplashScreenForm()
        {
            InitializeComponent();
        }

        private void pictureEdit2_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void SplashScreenForm_Load(object sender, EventArgs e)
        {

        }

        private void marqueeProgressBarControl1_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void marqueeProgressBarControl1_EditValueChanged_1(object sender, EventArgs e)
        {
            this.Text = "Chargement...";
            
        }
    }

    public class MySplash : ISplash
    {
        static private SplashScreenForm form;
        private static bool isStarted = false;
        public void Start()
        {
            isStarted = true;
            form = new SplashScreenForm();
            form.Show();
            System.Windows.Forms.Application.DoEvents();
        }
        public void Stop()
        {
            if (form != null)
            {
                form.Hide();
                form.Close();
                form = null;
            }
            isStarted = false;
        }
        public void SetDisplayText(string displayText)
        {
        }
        public bool IsStarted
        {
            get { return isStarted; }
        }
    }
}
