using Ebabobo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Ebabobo.Data
{
    public class DbManager
    {
        public void Delete(ICrud entity)
        {
            entity.Delete();
        }

        public void Insert(ICrud entity)
        {
            entity.Insert();
        }

        public DataTable SelectAll(ICrud entity)
        {
            return entity.SelectAll();
        }

        public void Update(ICrud entity)
        {
            entity.Update();
        }
    }
}
