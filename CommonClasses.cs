using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace FaceRegconizer
{
    class CommonClasses
    {
        public SqlDataReader rdr = null;
        public DataTable dtable = new DataTable();
        public SqlConnection con = null;
        public SqlCommand cmd = null;
        public DataSet ds;
        public SqlDataAdapter da;
    }
}
