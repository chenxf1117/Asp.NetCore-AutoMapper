using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Common.DBContext
{
    public interface IDBContext
    {
        SqlSugarClient DB { get; }
    }
}
