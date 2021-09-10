using System;
using System.Collections.Generic;
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

        }

        public List<Location> GetLocations()
        {
            using (SqlConnection conn = new SqlConnection(_sqlsb.ConnectionString))
            {
                conn.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = conn;
                command.CommandText = $"SELECT * FROM Locations l " +
                                       "LEFT JOIN Addresses a on l.Addressid = a.Id";
                command.CommandTimeout = 30;

                using (var rdr = command.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        Address locationAddress = null;
                        if (rdr["AddressId"].ToString() != null)
                        {
                            locationAddress = new Address()
                            {
                                Address1 = rdr["Address1"].ToString(),
                                Address2 = rdr["Address2"].ToString(),
                                City = rdr["City"].ToString(),
                                State = rdr["State"].ToString(),
                                Zip = rdr["ZipCode"].ToString()
                            };
                        }

                        Location newLocation = new Location()
                        {
                            LocationName = rdr["LocationName"].ToString(),
                            LocationAddress = locationAddress,
                            LocationContactNumber = rdr["LocationContactNumber"].ToString(),
                            LocationOwnerFirstName = rdr["LocationOwnerFirstName"].ToString(),
                            LocationOwnerLastName = rdr["LocationOwnerLastName"].ToString()
                        };

                        _locations.Add(newLocation);
                        
                    }
                }
                return _locations;
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

        public void Dispose()
        {
            if (this != null)
            {
                this.Dispose();
            }            
        }
    }
}
