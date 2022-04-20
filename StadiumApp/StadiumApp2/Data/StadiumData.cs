using StadiumApp2.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace StadiumApp2.Data
{
    internal class StadiumData
    {
        public void Add(Stadium stadium)
        {
            using(SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = $"INSERT INTO Stadiums (Name,HourlyPrice,Capacity) Values ('{stadium.Name}',{stadium.HourlyPrice},{stadium.Capacity})";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Stadium> GetAll()
        {
            List<Stadium> stadiums = new List<Stadium>();
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "SELECT * FROM Stadiums";
                SqlCommand cmd = new SqlCommand(query,con);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Stadium stadium = new Stadium
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourlyPrice = dr.GetDecimal(2),
                            Capacity = dr.GetByte(3)
                        };

                        stadiums.Add(stadium);
                    }
                }
            }


            return stadiums;
        }

        public Stadium GetById(int id)
        {
            Stadium stadium = null;
            using (SqlConnection con = new SqlConnection(Sql.ConnectionString))
            {
                con.Open();
                string query = "SELECT * FROM Stadiums WHERE  Id=@id";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", id);

                using(SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        stadium = new Stadium
                        {
                            Id = dr.GetInt32(0),
                            Name = dr.GetString(1),
                            HourlyPrice = dr.GetDecimal(2),
                            Capacity = dr.GetByte(3)
                        };
                    }
                }
            }
            return stadium;

        }


    }
}
