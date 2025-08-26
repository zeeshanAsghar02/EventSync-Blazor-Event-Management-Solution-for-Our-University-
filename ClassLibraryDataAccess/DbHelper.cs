using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDataAccess
{
    internal class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection("Data Source=FINESSIN\\SQLEXPRESS;Initial Catalog=EventSync;Integrated Security=True;Encrypt=False");
            return con;
        }

    }
}
