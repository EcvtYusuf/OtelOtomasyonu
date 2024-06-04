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
    
    
        public partial class rezForm : Form
        {
            public rezForm()
            {
                InitializeComponent();
            }


        private void rezForm_Load(object sender, EventArgs e)
        {
            textBoxTel.MaxLength = 11;
            textBoxTC.MaxLength = 11;
            updateRoomColors();
        }

        private void label1_MouseUp_1(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;
        }

        int mouseX;
        int mouseY;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            this.Left = MousePosition.X - mouseX;
            this.Top = MousePosition.Y - mouseY;
        }
        private void label1_MouseDown_1(object sender, MouseEventArgs e)
        {
            mouseX = MousePosition.X - this.Left;
            mouseY = MousePosition.Y - this.Top;
            timer1.Enabled = true;

        }

 
        private void button1_Click(object sender, EventArgs e)
        {
            anaEkran frm2 = new anaEkran();
            frm2.Show();
            this.Close();
        }

        ArrayList odalar = new ArrayList();
            public void koltukYazdir()
            {
                string oda = "";
                for (int i = 0; i < odalar.Count; i++)
                {
                    oda += odalar[i].ToString() + ",";
                }
                if (odalar.Count >= 1)
                {
                    oda = oda.Remove(oda.Length - 1, 1);
                }
                textOdaBox.Text = oda;
            }
            private void odaTikla(object sender, EventArgs e)
            {
                if (((Button)sender).BackColor == Color.Green)
                {
                    ((Button)sender).BackColor = Color.Orange;
                    if (!odalar.Contains(((Button)sender).Text))
                    {
                        odalar.Add(((Button)sender).Text);
                    }
                    koltukYazdir();
                }
                else if (((Button)sender).BackColor == Color.Orange)
                {
                    ((Button)sender).BackColor = Color.Green;
                    if (odalar.Contains(((Button)sender).Text))
                    {
                        odalar.Remove(((Button)sender).Text);
                    }
                    koltukYazdir();
                }
            }
            public DateTime giristarihi { get; set; }
            public DateTime cıkıstarihi { get; set; }
            private void button2_Click(object sender, EventArgs e)
            {
                giristarihi = Convert.ToDateTime(dateTimePicker1.Value);
                cıkıstarihi = Convert.ToDateTime(dateTimePicker2.Value);
                musteriKayit kayit = new musteriKayit();
                for (int i = 0; i < odalar.Count; i++)
                {
                    string oda = odalar[i].ToString();
                    kayit.kayitAl(textBoxAd.Text, textBoxSoyAd.Text, comboBoxCns.Text, textBoxTel.Text, textBoxMail.Text, textBoxTC.Text, textOdaBox.Text, textBoxucret.Text, giristarihi, cıkıstarihi);
                }
            }


        public void updateRoomColors()
        {
            DataBase db = new DataBase();
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand donustur = new SqlCommand("select * from odalar where durumu=@durum", db.baglanti);
                donustur.Parameters.AddWithValue("@durum", "Dolu");
                SqlDataReader donustur_Oku = donustur.ExecuteReader();
                while (donustur_Oku.Read())
                {
                    string buton_adi = donustur_Oku["butonAdi"].ToString();
                    string durum = donustur_Oku["durumu"].ToString();
                    if (buton_adi == "oda1" && durum == "Dolu")
                    {
                        oda1.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda2" && durum == "Dolu")
                    {
                        oda2.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda3" && durum == "Dolu")
                    {
                        oda3.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda4" && durum == "Dolu")
                    {
                        oda4.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda5" && durum == "Dolu")
                    {
                        oda5.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda6" && durum == "Dolu")
                    {
                        oda6.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda7" && durum == "Dolu")
                    {
                        oda7.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda8" && durum == "Dolu")
                    {
                        oda8.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda9" && durum == "Dolu")
                    {
                        oda9.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda10" && durum == "Dolu")
                    {
                        oda10.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda11" && durum == "Dolu")
                    {
                        oda11.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda12" && durum == "Dolu")
                    {
                        oda12.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda13" && durum == "Dolu")
                    {
                        oda13.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda14" && durum == "Dolu")
                    {
                        oda14.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda15" && durum == "Dolu")
                    {
                        oda15.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda16" && durum == "Dolu")
                    {
                        oda16.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda17" && durum == "Dolu")
                    {
                        oda17.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda18" && durum == "Dolu")
                    {
                        oda18.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda19" && durum == "Dolu")
                    {
                        oda19.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda20" && durum == "Dolu")
                    {
                        oda20.BackColor = Color.Red;
                    }
                    if (buton_adi == "oda21" && durum == "Dolu")
                    {
                        oda21.BackColor = Color.Red;
                    }
                }
                donustur.Dispose();
                donustur_Oku.Close();
                db.baglanti.Close();
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("154" + hata); }

            finally
            {
                db.baglanti.Close();
            }
        }


            private void tmr2_Tick(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void textBoxTC_TextChanged(object sender, EventArgs e)
        {

        }
    }
         


}

