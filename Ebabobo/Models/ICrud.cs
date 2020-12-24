using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Ebabobo.Models
{
    public interface ICrud
    {
        void Update();
        void Insert();
        DataTable SelectAll();
        void Delete();
    }
}
