using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class DatabaseTraffic
    {
        /// <summary>
        /// Save data to Database
        /// </summary>
        /// <param name="command">Sql command with data</param>
        public static void SaveToDb(SqlCommand command)
        {
            string CS = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = command;
                cmd.Connection = con;

                con.Open();
                cmd.ExecuteNonQuery();
            } 
        }

        public static void SaveBasePerson(PersonBase person)
        {
            if (person != null)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sproc_InsertBasePerson";

                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@Email", person.Email);

                SaveToDb(command);
            }
        }

        public static void SaveFullPerson(PersonFull person)
        {
            if (person != null)
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "sproc_InsertFullPerson";

                command.Parameters.AddWithValue("@FirstName", person.FirstName);
                command.Parameters.AddWithValue("@LastName", person.LastName);
                command.Parameters.AddWithValue("@Email", person.Email);
                command.Parameters.AddWithValue("@Street", person.Address.Street);
                command.Parameters.AddWithValue("@Suite", person.Address.Suite);
                command.Parameters.AddWithValue("@City", person.Address.City);
                command.Parameters.AddWithValue("@ZipCode", person.Address.ZipCode);
                command.Parameters.AddWithValue("@Website", person.WebSite);
                command.Parameters.AddWithValue("@Phone", person.Phone);

                SaveToDb(command);
            }
        }
    }
}