using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
namespace WebDataParse
{
    class YDFunction
    {
        public static string ConnectionString
        {
            get
            {
                return "Server=localhost;Database=WebDataParse;UID=root;Password=yydos123;";
            }
        }
      public static MySqlConnection GetConnection()
   {
       MySqlConnection Conn = new MySqlConnection();
          
       Conn.ConnectionString = ConnectionString;
       return Conn;
   }

    }
}
