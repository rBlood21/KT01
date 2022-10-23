using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace KT01.Core
{
    public class AlbumServices
    {
        string ConnStr = @"Data Source=Blood;Initial Catalog=QL_BaiHat;Integrated Security=True";
        public List<Models.Album> GetAll()
        {
            List<Models.Album> list = new List<Models.Album>();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = @"select * from tbl_Album";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Models.Album(
                        int.Parse(reader[0].ToString()),
                        reader[1].ToString(),
                        DateTime.Parse(reader[2].ToString()),
                        reader[3].ToString()
                        ));
                }
            }
            return list;
        }
        public int Create(string name, string path)
        {
            if (CheckAlbumNameExist(name))
            {
                return 0;
            }
            using(SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = @"insert into tbl_Album
                                values
                                (@name ,GETDATE(), @path)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@path", path);

                cmd.ExecuteNonQuery();
            }
            return 1;
        }
        public bool CheckAlbumNameExist(string name)
        {
            return GetAll().Where(x => x.Ten.Equals(name)).FirstOrDefault() != null ? true : false;
        }
        public List<Models.BaiHat> GetBaiHatsInAlbum(string maAB)
        {          
            List<Models.BaiHat> list = new List<Models.BaiHat>();
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = @"select bh.MaBH, bh.TenBH, bh.MaTL, bh.MaNS from tbl_BaiHat bh
                                join tbl_ChiTietAlbum a
                                on bh.MaBH = a.MaBH
                                where a.MaAB = @maab";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maab", maAB);

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
        public void DeleteBaiHat(string maBH, string maAB)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                string query = @"delete from tbl_ChiTietAlbum where MaBH = @maBH and MaAB = @maAB";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maBH", maBH);
                cmd.Parameters.AddWithValue("@maAB", maAB);

                cmd.ExecuteNonQuery();
            }
        }
    }
}