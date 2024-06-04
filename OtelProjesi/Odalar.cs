using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace OtelProjesi
{
    public partial class Odalar : Form
    {
        public Odalar()
        {
            InitializeComponent();
        }
        ArrayList odalar = new ArrayList();
        private void Odalar_Load(object sender, EventArgs e)
        {
            string oda_Adi = "";

            string yeni_Deger = "";
            

            for (int i = 0; i < this.Controls.Count; i++)
            {
                oda_Adi = Convert.ToString(this.Controls.Find("oda" + i.ToString(), true).FirstOrDefault() as Button);
                yeni_Deger = oda_Adi.Split(':').Last();
                odalar.Add(yeni_Deger);
                
            }
            
               odalarinDurumu();
            
       
        }
        public void odalarinDurumu()
        {
            OdaBilgi oda = new OdaBilgi();
            try
            {
                //foreach (string odanın_adi in odalar)
                    for (int i = 1; i <= 21; i++)
                {
                    oda.odaDegerleri(i);
                    
                    if (oda.durum_oku == "Dolu")
                    {
                      
                        this.Controls.Find(oda.butonAdi,true)[0].BackColor = Color.Red;
                        //this.Controls.Find(oda.butonAdi, true)[0].Text = ("ODA " + i) + "\n" + oda.alanKisi; 
                       
                    }
                    else
                    {
                       
                        this.Controls.Find(oda.butonAdi, true)[0].BackColor = Color.Green;
                     
                    }

                }
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("150" + hata); }
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        } 
        int mouseX, mouseY;

        

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {

            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;
            timer1.Enabled = true;

        }

        private void label1_MouseUp(object sender, MouseEventArgs e)
        {
            timer1.Enabled=false;
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void oda1_Click(object sender, EventArgs e)
        {
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            anaEkran frm2 = new anaEkran();
            frm2.Show();
            this.Close();
        }


    }
}
