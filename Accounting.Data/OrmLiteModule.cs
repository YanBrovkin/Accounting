using Accounting.Contracts;
using Ninject;
using Ninject.Modules;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using System;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using System.Collections.Generic;
using Accounting.Contracts.References;
using Accounting.Contracts.DTO;
using Accounting.Data.References;

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

            // Readers
            //Kernel.Bind<ISnapshotsReader>().To<SnapshotsReader>();
            Kernel.Bind<IRead<GetSKUSpecification, List<SKU>>>().To<SKUReader>();
        }
    }
}
