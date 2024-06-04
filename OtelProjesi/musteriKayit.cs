using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelProjesi
{
    class musteriKayit
    {
        public string kisininAdi_soyadi { get; set; }
        DataBase db = new DataBase();
        public static void odaGuncelle(int odaNo, string kisiAdSoyad)
        {
            DataBase db = new DataBase();
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
            
              
                db.baglanti.Open();
                SqlCommand guncelle = new SqlCommand("update odalar set odayiAlan=@alanKisi, durumu=@durum where id = @odaNo", db.baglanti);
                guncelle.Parameters.AddWithValue("@alanKisi", kisiAdSoyad);
                guncelle.Parameters.AddWithValue("@durum", "Dolu");            
                guncelle.Parameters.AddWithValue("@odaNo", odaNo);
                guncelle.ExecuteNonQuery();
                guncelle.Dispose();
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("151" + hata); }
            
            finally
            {
                db.baglanti.Close();
            }
        }
        public void kayitAl(string adi, string soyadi, string cinsiyet, string telefon, string mail, string tcno, string odaAdi, string ucret, DateTime giristarihi, DateTime cıkıstarihi)
        {
            Odalar oda = new Odalar();
            oda.odalarinDurumu();

            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand kayit_Al = new SqlCommand("insert into musteriler values(@adi,@soyadi,@cinsiyet,@telefon,@mail,@tc,@oda,@ucret,@giris,@cikis)", db.baglanti);
                kayit_Al.Parameters.AddWithValue("@adi", adi);
                kayit_Al.Parameters.AddWithValue("@soyadi", soyadi);
                kayit_Al.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                kayit_Al.Parameters.AddWithValue("@telefon", telefon);
                kayit_Al.Parameters.AddWithValue("@mail", mail);
                kayit_Al.Parameters.AddWithValue("@tc", tcno);
                kayit_Al.Parameters.AddWithValue("@oda", odaAdi);
                kayit_Al.Parameters.AddWithValue("@ucret", ucret);
                kayit_Al.Parameters.AddWithValue("@giris", giristarihi);
                kayit_Al.Parameters.AddWithValue("@cikis", cıkıstarihi);
                kayit_Al.ExecuteNonQuery();
                System.Windows.Forms.MessageBox.Show("Müşteri kaydı, başarılı bir şekilde oluşmuştursss : " + odaAdi + " isimli oda :" + adi + " " + soyadi + " isimli kişiye verilmiştir.", "Bilgi", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                kayit_Al.Dispose();

                

                int odaNo = int.Parse(odaAdi);
                kisininAdi_soyadi = adi + " " + soyadi;
                odaGuncelle(odaNo, kisininAdi_soyadi);
            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("152" + hata); }
            
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
