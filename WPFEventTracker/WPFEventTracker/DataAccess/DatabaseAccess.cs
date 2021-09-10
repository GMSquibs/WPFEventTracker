﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFEventTracker.Models;

namespace WPFEventTracker.DataAccess
{
    public class DatabaseAccess: IDisposable
    {
        private SqlConnectionStringBuilder _sqlsb;
        public List<Location> _locations;
        public DatabaseAccess()
        {
            string localConnection = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\GitRepo\\WPFEventTracker\\WPFEventTracker\\WPFEventTracker\\EventTracker.mdf;Integrated Security=True;Connect Timeout=30";
            SqlSb = new SqlConnectionStringBuilder(localConnection);
        }

        public SqlConnectionStringBuilder SqlSb
        {
            get { return _sqlsb; }
            set { _sqlsb = value; }
        }

        public DataTable GetLocations()
        {
            _locations = new List<Location>();
            try 
            {
                using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
                {
                    conn.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = conn;
                    command.CommandText = $"SELECT * FROM vw_Locations";
                    command.CommandTimeout = 30;

                    DataTable dt = new DataTable();
                    SqlDataAdapter a = new SqlDataAdapter(command);
                    a.Fill(dt);                        
                    
                    conn.Close();
                    return dt;
                }
            } 
            catch(Exception e) 
            {
                string error = e.Message;
                return null;
            } 
 
        }

        public DbDataReader GetClients()
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Clients";
                command.CommandTimeout = 30;

                return command.ExecuteReader();
            }
        }

        public DbDataReader GetEmployees()
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Employees";
                command.CommandTimeout = 30;

                return command.ExecuteReader();
            }
        }

        public DbDataReader GetMenu()
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = "SELECT * FROM Menu";
                command.CommandTimeout = 30;

                return command.ExecuteReader();
            }
        }

        public void CreateLocation(string locationName, string locationOwnerFirstName, string locationOwnerLastName, string locationContactNumber,
            string address1, string address2, string city, string state, string zipCode)
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand locationCommand = new SqlCommand();
                locationCommand.Connection = conn;
                locationCommand.CommandType = CommandType.StoredProcedure;
                locationCommand.CommandText = "CreateLocation";
                locationCommand.CommandTimeout = 30;

                locationCommand.Parameters.AddRange(
                    new[]
                    {
                        new SqlParameter("@LocationName", SqlDbType.VarChar) { Value = locationName  },
                        new SqlParameter("@LocationOwnerFirstName", SqlDbType.VarChar) { Value = locationOwnerFirstName },
                        new SqlParameter("@LocationOwnerLastName", SqlDbType.VarChar) { Value = locationOwnerLastName },
                        new SqlParameter("@LocationContactNumber", SqlDbType.VarChar) { Value = locationContactNumber },
                        new SqlParameter("@LocationName", SqlDbType.VarChar) { Value = locationName  }
                    });

                locationCommand.ExecuteReader();
                conn.Close();
            }

            if (!string.IsNullOrEmpty(address1) || !string.IsNullOrEmpty(address2) || !string.IsNullOrEmpty(city) ||
                !string.IsNullOrEmpty(state) || !string.IsNullOrEmpty(zipCode))
            {
                CreateAddress(address1, address2,  city, state,  zipCode);
            }
        }

        public void CreateAddress(string address1, string address2, string city, string state, string zipCode)
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand addressCommand = new SqlCommand();
                addressCommand.Connection = conn;
                addressCommand.CommandType = CommandType.StoredProcedure;
                addressCommand.CommandText = "CreateAddress";
                addressCommand.CommandTimeout = 30;

                addressCommand.Parameters.AddRange(
                    new[]
                    {
                        new SqlParameter("@Address1", SqlDbType.VarChar) { Value = address1 },
                        new SqlParameter("@Address2", SqlDbType.VarChar) { Value = address2 },
                        new SqlParameter("@City", SqlDbType.VarChar) { Value = city},
                        new SqlParameter("@State", SqlDbType.VarChar) { Value = state },
                        new SqlParameter("@ZipCode", SqlDbType.VarChar) { Value = zipCode  }
                    });

                addressCommand.ExecuteReader();
                conn.Close();
            }
        }

public void Dispose()
        {
            if (this != null)
            {
                this.Dispose();
            }            
        }
    }
}
