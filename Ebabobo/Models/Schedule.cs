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
    public class Schedule : ICrud
    {
        public string ScheduleId { get; set; }
        public string CardId { get; set; }
        public string Date { get; set; }
        public string Frequency { get; set; }
        public string Sum { get; set; }
        public string TypeId { get; set; }

        public Schedule() { }
        public Schedule(string id)
        {
            QueryLite query = new QueryLite(ConfigurationManager.ConnectionStrings["EbabobaConnectionString"].ConnectionString);
            query.Add($"select * from Schedule where @ScheduleId = {id}");
            query.AddParameter("ScheduleId", id.ToString());
            var dt = query.ExecuteAndGet();

            this.ScheduleId = id;
            this.CardId = dt.Rows[0]["Name"].ToString();
            this.Date = dt.Rows[0]["Date"].ToString();
            this.Frequency = dt.Rows[0]["Frequency"].ToString();
            this.Sum = dt.Rows[0]["Sum"].ToString();
            this.TypeId = dt.Rows[0]["TypeId"].ToString();

            query.Clear();
        }

        public void Update()
        {
            QueryLite query = new QueryLite(ConfigurationManager.ConnectionStrings["EbabobaConnectionString"].ConnectionString);

            Dictionary<string, string> updates = new Dictionary<string, string>();
            updates.Add("CardId", this.CardId);
            updates.Add("Date", this.Date);
            updates.Add("Frequency", this.Frequency);
            updates.Add("Sum", this.Sum);
            updates.Add("TypeId", this.TypeId);


            query.Add("update cr");
            query.AddUpdates(updates);
            query.Add("from Currency cr where ScheduleId = @ScheduleId");
            query.AddParameter("@ScheduleId", this.ScheduleId);
            query.Execute();
            query.Clear();
        }

        public void Insert()
        {
            QueryLite query = new QueryLite(ConfigurationManager.ConnectionStrings["EbabobaConnectionString"].ConnectionString);

            query.Add("insert into Schedule");
            query.AddInsertValues(new List<string>() { this.CardId, this.Date, this.Frequency, this.Sum, this.TypeId });

            query.Execute();
            query.Clear();
        }

        public DataTable SelectAll()
        {
            QueryLite query = new QueryLite(ConfigurationManager.ConnectionStrings["EbabobaConnectionString"].ConnectionString);
            query.Add($"select * from Schedule");
            var returnValue = query.ExecuteAndGet();
            query.Clear();
            return returnValue;
        }

        public void Delete()
        {
            QueryLite query = new QueryLite(ConfigurationManager.ConnectionStrings["EbabobaConnectionString"].ConnectionString);
            query.Add($"Delete from Schedule where ScheduleId = @ScheduleId");
            query.AddParameter("@ScheduleId", this.ScheduleId);
            query.Execute();
            query.Clear();
        }
    }
}
