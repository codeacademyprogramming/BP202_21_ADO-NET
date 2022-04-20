using System;
using System.Data.SqlClient;

namespace StadiumsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Server=DESKTOP-BU4GQ1K\SQLEXPRESS;Database=BP202Stadiums;Trusted_Connection=TRUE");


            //Insert
            //string query = "INSERT INTO Stadiums (Name,HourlyPrice,Capacity) VALUES ('Std1',25,14)";

            //con.Open();
            //SqlCommand cmd = new SqlCommand(query, con);
            //int rowCount = cmd.ExecuteNonQuery();
            //con.Close();

            //Console.WriteLine(rowCount);


            //Select
            string query = "SELECT * FROM Stadiums";
            con.Open();
            SqlCommand cmd = new SqlCommand(query, con);

            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine(dr["Id"]+" - "+dr[1]+" - "+dr.GetDecimal(2));
            }

            dr.Close();
            con.Close();

        }
    }
}
