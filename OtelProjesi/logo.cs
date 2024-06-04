using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelProjesi
{
    public partial class logo : Form
    {
        public logo()
        {
            InitializeComponent();
        }
        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(!islem)
            {
                this.Opacity += 0.009;
            }
            if (this.Opacity==1.0)
            {
                islem = true;


            }
            if(islem)
            {
                this.Opacity -= 0.009;
                if (this.Opacity==0)
                {
                    gEkrani grs = new gEkrani();
                    grs.Show();
                    timer1.Enabled = false;
                    this.Hide();

                }
            }
        }

        private void logo_Load(object sender, EventArgs e)
        {
            
        }
    }
}
