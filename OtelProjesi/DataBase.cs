using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OtelProjesi
{
    public class DataBase
    {
        public SqlConnection baglanti = new SqlConnection(@"Data Source=RGSGFD;Initial Catalog=otelOtomasyon;Integrated Security=True;MultipleActiveResultSets=True");
    }
}
