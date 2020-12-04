using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreWebApi.Common.DBContext
{
    public static class DBContextExtension
    {
        public static IServiceCollection AddDBContext(this IServiceCollection services, string ConnectString)
        {
            return services.AddTransient<IDBContext>(x => new DBContext(ConnectString));
        }
    }
}
