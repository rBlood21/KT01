using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KT01.Core
{
    public class BHServices
    {
        string ConnStr = @"Data Source=Blood;Initial Catalog=QL_BaiHat;Integrated Security=True";
        public List<Models.BaiHat> GetAll()
        {
            List<Models.BaiHat> list = new List<Models.BaiHat>();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = @"select * from tbl_BaiHat";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Models.BaiHat(
                        int.Parse(reader[0].ToString()),
                        reader[1].ToString(),
                        int.Parse(reader[2].ToString()),
                        int.Parse(reader[3].ToString())
                        ));
                }
            }
            return list;
        }
    }
}