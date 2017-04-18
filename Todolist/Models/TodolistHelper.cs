using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Todolist.Models
{
    struct TodolistItem
    {
        public int Id;
        public String Title;
        public int Complete;

        public TodolistItem(int id, String title, int complete)
        {
            this.Id = id;
            this.Title = title;
            this.Complete = complete;
        }
    }

    public static class TodolistHelper
    {
        private static String connectString = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=182.254.139.139" +
                                              ")(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=orcl" +
                                              ")));Persist Security Info=True;User ID=todolist;Password=todolist;";


        public static Object ExecuteReader(string sql)
        {
            using (OracleConnection conn = new OracleConnection(connectString))
            {
                conn.Open();
                using (OracleCommand com = conn.CreateCommand())
                {
                    List<TodolistItem> list = new List<TodolistItem>();
                    com.CommandText = sql;
                    OracleDataReader reader = com.ExecuteReader();
                    while (reader.Read())
                        list.Add(new TodolistItem(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2)));
                    return list;
                }
            }
        }

        public static int ExecuteNonQuery(string sql)
        {
            using (OracleConnection conn = new OracleConnection(connectString))
            {
                conn.Open();
                using (OracleCommand com = conn.CreateCommand())
                {
                    com.CommandText = sql;
                    return com.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql)
        {
            using (OracleConnection conn = new OracleConnection(connectString))
            {
                conn.Open();
                using (OracleCommand com = conn.CreateCommand())
                {
                    com.CommandText = sql;
                    com.Parameters.Clear();
                    return com.ExecuteScalar();
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql)
        {
            using (OracleConnection conn = new OracleConnection(connectString))
            {
                conn.Open();
                using (OracleCommand com = conn.CreateCommand())
                {
                    com.CommandText = sql;
                    com.Parameters.Clear();
                    DataSet dataset = new DataSet();
                    OracleDataAdapter adapter = new OracleDataAdapter(com);
                    adapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }
    }
}