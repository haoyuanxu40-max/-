using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace 系統端.Models
{
    public class DBmanager
    {
        private readonly string connStr = "Data Source=(localdb)\\MSSQLLocalDB;Database=delivery;User ID=harry;Password=vupaua1831129;Trusted_Connection=True";
        public List<Package> getPackages()
        {
            List<Package> packages = new List<Package>();

            SqlConnection sqlConnection = new SqlConnection(connStr);
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Package");
            sqlCommand.Connection = sqlConnection;
            sqlConnection.Open();

            SqlDataReader reader = sqlCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Package package = new Package
                    {
                        ID = reader.GetInt32(reader.GetOrdinal("id")),
                        PID = reader.GetString(reader.GetOrdinal("pid")),
                        Name = reader.GetString(reader.GetOrdinal("name")),
                        PhoneNumber = reader.GetString(reader.GetOrdinal("phonenumber")),
                        STA = reader.GetBoolean(reader.GetOrdinal("status")),
                        Date = reader.GetDateTime(reader.GetOrdinal("date"))
                    };
                       packages.Add(package);
                }
            }
            else
            {
                Console.WriteLine("資料庫為空！");
            }
            sqlConnection.Close();
            return packages;
        }

        public void newPackage(Package user)
        {
            SqlConnection sqlconnection = new SqlConnection(connStr);
            SqlCommand sqlcommand = new SqlCommand(@"INSERT INTO Package(PID,Name,PhoneNumber,STA) VALUES(@PID,@Name,@PhoneNumber,@STA)");
            sqlcommand.Connection = sqlconnection;

            sqlcommand.Parameters.Add(new SqlParameter("@PID", user.PID));
            sqlcommand.Parameters.Add(new SqlParameter("@Name", user.Name));
            sqlcommand.Parameters.Add(new SqlParameter("@PhoneNumber", user.PhoneNumber));
            sqlcommand.Parameters.Add(new SqlParameter("@STA", user.STA));

            sqlconnection.Open();
            sqlcommand.ExecuteNonQuery();
            sqlconnection.Close();
        }
    }
}

