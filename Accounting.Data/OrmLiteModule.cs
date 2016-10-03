using Accounting.Contracts;
using Ninject.Modules;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using System;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Accounting.Data
{
    public class OrmLiteModule : NinjectModule
    {
        private readonly string dbConnectionString;
        private Language locale;
        private bool loaded;

        public OrmLiteModule(string dbConnectionString, Language locale = Language.Russian)
        {
            this.dbConnectionString = dbConnectionString;
            this.locale = locale;
        }

        public override void Load()
        {
            if (loaded)
                throw new Exception("Module should be inited only once");
            loaded = true;

            Kernel.Bind<IDbConnectionFactory>().ToMethod(c =>
            {
                var dbFactory = new OrmLiteConnectionFactory(dbConnectionString,
                    SqlServerOrmLiteDialectProvider.Instance);
                dbFactory.ConnectionFilter = x =>
                {
                    x.ExecuteSql("SET LANGUAGE " + this.locale);
                    return Profiler.Current != null ? new ProfiledDbConnection(x, Profiler.Current) : x;
                };
                return dbFactory;
            });

            //Kernel.Bind<ISnapshotsReader>().To<SnapshotsReader>();
        }
    }
}
