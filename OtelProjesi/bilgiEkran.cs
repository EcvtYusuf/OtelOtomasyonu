using System;
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
    public partial class bilgiEkran : Form
    {
        public bilgiEkran()
        {
            InitializeComponent();
        }

        private void bilgiEkran_Load(object sender, EventArgs e)
        {
            csmsteriekran nm = new csmsteriekran();
            dataGridView1.DataSource = nm.tablola();
            textBoxTC.MaxLength = 11;
            textBoxTel.MaxLength = 11;  
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        int mouseX, mouseY;



            

        
        private void timer1_Tick(object sender, EventArgs e)
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

        private void label1_MouseUp_1(object sender, MouseEventArgs e)
        {
            timer1.Enabled = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

           lblid.Text = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells["id"].Value);

            textBoxAd.Text = dataGridView1.Rows[e.RowIndex].Cells["ad"].Value.ToString();

            textBoxSoyAd.Text = dataGridView1.Rows[e.RowIndex].Cells["soyad"].Value.ToString();

            comboBoxCns.Text = dataGridView1.Rows[e.RowIndex].Cells["cinsiyet"].Value.ToString();

            textBoxTel.Text = dataGridView1.Rows[e.RowIndex].Cells["telefon"].Value.ToString();

            textBoxMail.Text = dataGridView1.Rows[e.RowIndex].Cells["mail"].Value.ToString();

            textBoxTC.Text = dataGridView1.Rows[e.RowIndex].Cells["tc"].Value.ToString();

            textOdaBox.Text = dataGridView1.Rows[e.RowIndex].Cells["oda"].Value.ToString();

            textBoxucret.Text = dataGridView1.Rows[e.RowIndex].Cells["ucret"].Value.ToString();

            dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["giris"].Value.ToString());

            dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["cikis"].Value.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            csmsteriekran mg = new csmsteriekran();
            dataGridView1.DataSource = mg.tablola();


        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBoxAd.Text = "";
            textBoxSoyAd.Text = "";
            comboBoxCns.Text = "";
            textBoxTel.Text = "";
            textBoxMail.Text = "";
            textBoxTC.Text = "";
            textOdaBox.Text = "";
            textBoxucret.Text = "";
            textara.Text = "";
            dateTimePicker1.Value=Convert.ToDateTime(DateTime.Now.ToLongDateString());
            dateTimePicker2.Value = Convert.ToDateTime(DateTime.Now.ToLongDateString());



        }
        public DateTime giristarihi { get; set; }
        public DateTime cikistarihi { get; set; }
        

        private void button2_Click(object sender, EventArgs e)//güncelleme
        {
            giristarihi= Convert.ToDateTime(dateTimePicker1.Value);
            cikistarihi = Convert.ToDateTime(dateTimePicker2.Value);
            int id = Convert.ToInt16(lblid.Text);
            csmsteriekran be = new csmsteriekran();
            be.guncelleMusteri(id, textBoxAd.Text, textBoxSoyAd.Text, comboBoxCns.Text, textBoxTel.Text, textBoxMail.Text, textBoxTC.Text, textOdaBox.Text, textBoxucret.Text, giristarihi, cikistarihi);
            dataGridView1.DataSource = be.tablola;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt16(lblid.Text);
                csmsteriekran ms = new csmsteriekran();
                ms.silMusteri(id);
                dataGridView1.DataSource = ms.tablola();
               

                



            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("153" + hata); }





            }

        private void button6_Click(object sender, EventArgs e)
        {
            csmsteriekran ay = new csmsteriekran();
            dataGridView1.DataSource = ay.araMusteri(textara.Text);
            
        }


        private void button1_Click(object sender, EventArgs e)//form geçiş
        {
            anaEkran frm2 = new anaEkran();
            frm2.Show();
            this.Close();
        }

        
    }
}
