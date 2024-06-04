using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace OtelProjesi
{
    class kGiris
    {
        DataBase dBase = new DataBase();
        public string kullaniciAdi_tut { get; set; }
        public string kullaniciSifre_tut { get; set; }
        public string girisKontrol { get; set; }



        public void girisEkrani(string kullaniciAdi, string kullaniciSifre, DateTime tarih)
        {
            if (dBase.baglanti.State == System.Data.ConnectionState.Open)
            {
                dBase.baglanti.Close();

            }
            try
            {
                dBase.baglanti.Open();
                SqlCommand loginName = new SqlCommand("select kullaniciAdi from kullaniciBilgileri where kullaniciAdi = @kulAdi", dBase.baglanti);
                loginName.Parameters.AddWithValue("kulAdi", kullaniciAdi);
                SqlDataReader kulAdi_Oku = loginName.ExecuteReader();
                if (kulAdi_Oku.Read())
                {
                    kullaniciAdi_tut = kulAdi_Oku["kullaniciAdi"].ToString();
                    SqlCommand loginSifre = new SqlCommand("select kullaniciSifre from kullaniciBilgileri where kullaniciSifre = @sifre", dBase.baglanti);
                    loginSifre.Parameters.AddWithValue("@sifre", kullaniciSifre);
                    SqlDataReader loginSifre_oku = loginSifre.ExecuteReader();
                    

                    if (loginSifre_oku.Read())
                    {
                        kullaniciSifre_tut = loginSifre_oku["kullaniciSifre"].ToString();
                        girisKontrol = kullaniciAdi_tut + "" + kullaniciSifre_tut;
                        SqlCommand dateUpdate = new SqlCommand("Update kullaniciBilgileri set girisTarihi = @tarih where kullaniciAdi = @kulAdi AND kullaniciSifre = @kulsifre ", dBase.baglanti);
                        dateUpdate.Parameters.AddWithValue("@tarih", tarih);
                        dateUpdate.Parameters.AddWithValue("@kulAdi", kullaniciAdi_tut);
                        dateUpdate.Parameters.AddWithValue("@kulsifre", kullaniciSifre_tut);
                        dateUpdate.ExecuteNonQuery();
                        dateUpdate.Dispose();



                    }
                    else 
                    {
                        MessageBox.Show("Kullanici Şifre Yanliş Girdiniz..", "Hata | Hotel Pro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    loginSifre.Dispose();
                    loginSifre_oku.Close();

                }
                else
                {
                    MessageBox.Show("Kullanici Adi Yanliş Girdiniz..", "Hata | Hotel Pro", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                loginName.Dispose();
                kulAdi_Oku.Close();
                dBase.baglanti.Close();
               



            }
            catch
            {


            }
            finally
            {
                dBase.baglanti.Close();
            }
        }
    }
}
