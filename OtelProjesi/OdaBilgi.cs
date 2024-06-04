using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelProjesi
{
    class OdaBilgi
    {
        public string alanKisi { get; set; }
        public string durum_oku { get; set; }
        public string bilgi { get; set; }
        public string butonAdi { get; set; }
        DataBase db = new DataBase();
        internal string durum;

        public void odaDegerleri(int odaNo)
        {
            if (db.baglanti.State == System.Data.ConnectionState.Open)
            {
                db.baglanti.Close();
            }
            try
            {
                db.baglanti.Open();

                
                //SqlCommand odaA1 = new SqlCommand("select * from odalar where oda_adi = @odaAdi and durumu = @durum", db.baglanti);
                //odaAl.Parameters.AddWithValue("@odaAdi", oda_adi);
                //odaAl.Parameters.AddWithValue("@durum", durumu);
                SqlCommand odaA1 = new SqlCommand("select * from odalar where id = @odaNo", db.baglanti);
                odaA1.Parameters.AddWithValue("@odaNo", odaNo);
                SqlDataReader odaA1_Oku = odaA1.ExecuteReader();
                if(odaA1_Oku.Read())
                {
                    
                    alanKisi = odaA1_Oku["odayiAlan"].ToString();
                  
                    durum_oku = odaA1_Oku["durumu"].ToString();

                    butonAdi = odaA1_Oku["butonAdi"].ToString();

                }
                odaA1.Dispose();
                odaA1_Oku.Close();

            }
            catch (Exception hata) { System.Windows.Forms.MessageBox.Show("153" + hata); }
            finally
            {
                db.baglanti.Close();
            }
        }
    }
}
