namespace OtelProjesi
{
    public partial class gEkrani : Form
    {
        public gEkrani()
        {
            InitializeComponent();
        }
        


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kGiris kgrs = new kGiris();
            anaEkran frm2 =new anaEkran();
           



            if (textBox1.Text == string.Empty || textBox2.Text == string.Empty)
            {
                MessageBox.Show("Lütfen Kullanýcý Adý Ve Þifre Giriniz..", "Hata | Hotel Pro",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text != "admin" && textBox2.Text != string.Empty)
            {
                MessageBox.Show("Kullanýcý Þifresini Yanlýþ Girdiniz", "Hata | Hotel Pro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox1.Text == "admin" && textBox2.Text == "admin")
            {
                frm2.Show();
                this.Hide();
            }

        else
        {

           kgrs.girisEkrani(textBox1.Text, textBox2.Text, DateTime.Now);
           string bilgiTut= textBox1.Text + textBox2.Text.ToString();
            
             if (kgrs.girisKontrol == bilgiTut)
            {
                    frm2.Show();
                    this.Hide();
            }


         }
           
               
                


                
                

            
            
            
        }

        private void gEkrani_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.CheckState==CheckState.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
                checkBox1.Text = "Gizle";



             

            }
            else
            {
                textBox2.UseSystemPasswordChar=true;
                checkBox1.Text = "Göster";
            }
        }
    }
}