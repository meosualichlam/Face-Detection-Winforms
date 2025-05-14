using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; 

namespace FaceRegconizer
{
    public class ConnectionString
    {
        // Truy xuất chuỗi kết nối từ app.config
        public string DBConn = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    }
}
