using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace Ebabobo.Data
{
    public class QueryLite
    {
        public string query { get; set; }

        private string connectionString = string.Empty;
        private Dictionary<string, string> parameters = new Dictionary<string, string>();
        public QueryLite(string connectionString)
        {
            this.connectionString =
                Convert.ToString(connectionString);
        }

        public void Add(string queryPart)
        {
            query += " " + queryPart;
        }

        public void AddInsertValues(List<string> values)
        {
            values = values.Select(x => "N'" + x + "'").ToList();
            string temp = " values (" + string.Join(", ", values) + ")";
            this.Add(temp);
        }

        public void AddUpdates(Dictionary<string, string> updates)
        {
            string temp = "set";
            foreach (var upd in updates)
            {
                if (upd.Value != null)
                    temp += " " + upd.Key + " = '" + upd.Value + "',";
                else
                    temp += " " + upd.Key + " = null,";
            }
            this.Add(temp.Remove(temp.Length - 1));
        }

        public void AddWheres(Dictionary<string, string> wheres)
        {
            string temp = "where 1=1";
            foreach (var whr in wheres)
            {
                temp += " and " + whr.Key + " = '" + whr.Value + "'";
            }
            this.Add(temp);
        }
        public void AddParameter(string key, string value)
        {
            this.parameters.Add(key, value);
        }
        public void RemoveLastLetterFromQuery()
        {
            this.query = (this.query.Remove(this.query.Length - 1));
        }
        public void Clear()
        {
            this.query = string.Empty;
            parameters.Clear();
        }

        internal void Execute()
        {
            using (SqlConnection cnn = new SqlConnection(Convert.ToString(connectionString)))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand(this.query, cnn);
                if (this.parameters.Any())
                {
                    foreach (var param in this.parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }
                command.ExecuteNonQuery();
                cnn.Close();
            }
        }

        internal DataTable ExecuteAndGet()
        {
            using (SqlConnection cnn = new SqlConnection(Convert.ToString(connectionString)))
            {
                cnn.Open();
                SqlCommand command = new SqlCommand(this.query, cnn);
                if (this.parameters.Any())
                {
                    foreach (var param in this.parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }
                SqlDataReader sqr = command.ExecuteReader();
                DataSet ds = new DataSet();
                ds.Load(sqr, LoadOption.PreserveChanges, "");
                sqr.Close();
                return ds.Tables[0];
            }
        }
    }
}
