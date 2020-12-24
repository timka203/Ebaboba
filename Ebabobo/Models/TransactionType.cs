using Ebabobo.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ebabobo.Models
{
    public class TransactionType : ICrud
    {
        public string TransactionTypeId { get; set; }
        public string Name { get; set; }

        public TransactionType() { }

        public TransactionType(string id)
        {
            QueryLite query = new QueryLite("*Connection string here*");
            query.Add($"select * from TransactionType where @TransactionTypeId = {id}");
            query.AddParameter("TransactionTypeId", id.ToString());
            var dt = query.ExecuteAndGet();

            this.TransactionTypeId = id;
            this.Name = dt.Rows[0]["Name"].ToString();

            query.Clear();
        }

        public void Update()
        {
            QueryLite query = new QueryLite(ConfigurationManager.ConnectionStrings["EbabobaConnectionString"].ConnectionString);

            Dictionary<string, string> updates = new Dictionary<string, string>();
            updates.Add("Name", this.Name);

            query.Add("update tt");
            query.AddUpdates(updates);
            query.Add("from TransactionType tt where TransactionTypeId = @TransactionTypeId");
            query.AddParameter("@TransactionTypeId", this.TransactionTypeId);
            query.Execute();
            query.Clear();
        }

        public void Insert()
        {
            QueryLite query = new QueryLite(ConfigurationManager.ConnectionStrings["EbabobaConnectionString"].ConnectionString);

            query.Add("insert into TransactionType");
            query.AddInsertValues(new List<string>() { this.Name });

            query.Execute();
            query.Clear();
        }

        public DataTable SelectAll()
        {
            QueryLite query = new QueryLite(ConfigurationManager.ConnectionStrings["EbabobaConnectionString"].ConnectionString);
            query.Add($"select * from TransactionType");
            var returnValue = query.ExecuteAndGet();
            query.Clear();
            return returnValue;
        }

        public void Delete()
        {
            QueryLite query = new QueryLite(ConfigurationManager.ConnectionStrings["EbabobaConnectionString"].ConnectionString);
            query.Add($"Delete from TransactionType where TransactionTypeId = @TransactionTypeId");
            query.AddParameter("@TransactionTypeId", this.TransactionTypeId);
            query.Execute();
            query.Clear();
        }
    }
}
