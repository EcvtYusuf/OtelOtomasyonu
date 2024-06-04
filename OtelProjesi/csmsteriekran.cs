using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace OtelProjesi
{
    internal class csmsteriekran
    {
        DataBase db = new DataBase();
        public DataTable tablola()
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();

            }
            try
            {
                db.baglanti.Open();
                SqlCommand veriAl = new SqlCommand("select * from musteriler", db.baglanti);
                SqlDataAdapter adaptor = new SqlDataAdapter(veriAl);
                DataTable tablo = new DataTable();
                adaptor.Fill(tablo);
                return tablo;





            }
            catch { return null; }
            finally
            {
                db.baglanti.Close();
            }

        }
       
        public string durum { get; set; }
        public string sildurum { get; set; }
        public void guncelleMusteri(int id, string adi, string soyadi, string cinsiyet, string telefon, string mail, string tcno, string odaAdi, string ucret, DateTime giristarihi, DateTime cikistarihi)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();

            }
            try
            { 
                db.baglanti.Open();
               

                
               
                SqlCommand guncelleme = new SqlCommand("update musteriler set ad=@adi, soyad = @soyadi, cinsiyet=@cinsiyet, telefon=@telefon, mail=@mail, tc=@tc,oda=@oda,ucret=@ucret,giris=@giris,cikis=@cikis where id=@id", db.baglanti);
                guncelleme.Parameters.AddWithValue("@adi", adi);
                guncelleme.Parameters.AddWithValue("@soyadi", soyadi);
                guncelleme.Parameters.AddWithValue("@cinsiyet", cinsiyet);
                guncelleme.Parameters.AddWithValue("@telefon", telefon);
                guncelleme.Parameters.AddWithValue("@mail", mail);
                guncelleme.Parameters.AddWithValue("@tc", tcno);
                guncelleme.Parameters.AddWithValue("@oda", odaAdi);
                guncelleme.Parameters.AddWithValue("@ucret", ucret);
                guncelleme.Parameters.AddWithValue("@giris", giristarihi);
                guncelleme.Parameters.AddWithValue("@cikis", cikistarihi);
                guncelleme.Parameters.AddWithValue("@id", id);
                guncelleme.ExecuteNonQuery();
                durum = adi + " " + soyadi + " İsimli kişinin verileri Güncellenmiştir..";
                System.Windows.Forms.MessageBox.Show(durum);
             



            }
            catch { }
            finally
            {
                db.baglanti.Close();

            }


        }
        public void silMusteri(int id)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                string odaNoS = "0";

                SqlCommand odaA1 = new SqlCommand("select * from musteriler where id = @id", db.baglanti);
                odaA1.Parameters.AddWithValue("@id", id);
                SqlDataReader odaA1_Oku = odaA1.ExecuteReader();
                if (odaA1_Oku.Read())
                {

                    odaNoS = odaA1_Oku["oda"].ToString();

                }
                odaA1.Dispose();
                odaA1_Oku.Close();

                int odaNo = int.Parse(odaNoS);


                SqlCommand vsil = new SqlCommand("delete from musteriler where id=@id ", db.baglanti);
                vsil.Parameters.AddWithValue("@id", id);
                sildurum = "Silme İşlemi Başarılı..";
                System.Windows.Forms.MessageBox.Show(sildurum);
                vsil.ExecuteNonQuery();

                SqlCommand guncelle = new SqlCommand("update odalar set odayiAlan = NULL, durumu='Boş' where id = @odaNo", db.baglanti);
                guncelle.Parameters.AddWithValue("@odaNo", odaNo);
                guncelle.ExecuteNonQuery();
                guncelle.Dispose();

            }
            catch (Exception hata){ System.Windows.Forms.MessageBox.Show("153" + hata); }
            finally
            {
                db.baglanti.Close();
            }



        }
        public DataTable araMusteri(string adi)
        {
            if (db.baglanti.State == ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();
                SqlCommand ara = new SqlCommand("select * from musteriler where ad LIKE '%' + @ad + '%' ", db.baglanti);
                ara.Parameters.AddWithValue("@ad", adi);
                SqlDataAdapter da = new SqlDataAdapter(ara);
                DataTable tablo = new DataTable();
               da.Fill(tablo);
                return tablo;






            }
            catch { return null; }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
