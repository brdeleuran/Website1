using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Website.Models
{
    public class DatabaseHelper : IDisposable
    {
        private string ConnectionString { get; set; }
        public DatabaseHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["PizzaDB"].ConnectionString;
        }

        public int GetRows(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM " + table, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return int.Parse(reader[0].ToString());
                }
            }
        }

        public int GetColumns(string table)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd =
                new SqlCommand(
                    "SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + table + "'",
                    conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return int.Parse(reader[0].ToString());
                }
            }
        }

        public int GetRowsOfStoredProcedure(string procedureName, string[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd =
                new SqlCommand(
                    "exec('exec " + procedureName + " " + string.Join(",", parameters) + "; select @@RowCount')",
                    conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    reader.Read();
                    return int.Parse(reader[0].ToString());
                }
            }
        }


        public void PutToppingOnPizza(string pizzaName, string toppingName)
        {
            NonQueryProcedure("PutToppingOnPizza", new[] { "PizzaName", "ToppingName" }, new[] { pizzaName, toppingName });
        }

        public void CreateItem(string tableName, string itemName, int price)
        {
            NonQueryProcedure("CreateItem", new[] { "TableName", "ItemName", "Price" }, new[] { tableName, itemName, price.ToString() });
        }

        public void NonQueryProcedure(string procedureName, string[] parameterNames, string[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn) { CommandType = CommandType.StoredProcedure })
            {
                for (int i = 0; i < parameterNames.Length; i++) cmd.Parameters.AddWithValue(parameterNames[i], parameters[i]);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }


        public string[] QueryProcedure1D(string procedureName, string[] parameterNames, string[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn) { CommandType = CommandType.StoredProcedure })
            {
                conn.Open();
                for (int i = 0; i < parameterNames.Length; i++) cmd.Parameters.AddWithValue(parameterNames[i], parameters[i]);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string> output = new List<string>();
                    while (reader.Read())
                    {
                        output.Add(reader[0].ToString());
                    }
                    return output.ToArray();
                }
            }
        }

        public string[][] QueryProcedure(string procedureName, string[] parameterNames, string[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(procedureName, conn) { CommandType = CommandType.StoredProcedure })
            {
                conn.Open();
                for (int i = 0; i < parameterNames.Length; i++) 
                    cmd.Parameters.AddWithValue(parameterNames[i], parameters[i]);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string[]> output = new List<string[]>();
                    for (int i = 0; reader.Read(); i++)
                    {
                        output.Add(new string[reader.FieldCount]);
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            output[i][j] = reader[j].ToString();
                        }
                    }
                    return output.ToArray();
                }
            }
        }

        public string[][] Query(string select, string from, string extra)
        {
            string cmdStr = "SELECT " + select + " FROM " + from + " " + extra;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string[]> output = new List<string[]>();
                    for (int i = 0; reader.Read(); i++)
                    {
                        output.Add(new string[reader.FieldCount]);
                        for (int j = 0; j < reader.FieldCount; j++)
                        {
                            output[i][j] = reader[j].ToString();
                        }
                    }
                    return output.ToArray();
                }
            }
        }

        public string[] Query1D(string select, string from, string extra)
        {
            string cmdStr = "SELECT " + select + " FROM " + from + " " + extra;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            using (SqlCommand cmd = new SqlCommand(cmdStr, conn))
            {
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    List<string> output = new List<string>();
                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            output.Add(reader[i].ToString());
                        }
                    }
                    return output.ToArray();
                }
            }
        }

        public void Dispose()
        {
            ConnectionString = null;
        }
    }
}
