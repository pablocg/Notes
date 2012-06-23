using System.Reflection;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;

namespace Notes.NH
{
    public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        private readonly string _connectionString;

        public NHibernateHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ISessionFactory SessionFactory {
            get { return _sessionFactory ?? (_sessionFactory = Configuration.BuildSessionFactory()); }
        }

        protected Configuration Configuration
        {
            get {
                var configuration = new Configuration();

                //Get mappings from this assembly.
                var mapper = new ModelMapper();
                mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
                var domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();

                //Configure database.
                configuration.DataBaseIntegration(db =>
                {
                    db.Dialect<MsSql2008Dialect>();
                    db.ConnectionString = _connectionString;
                });

                //Add mapping after setting db.
                configuration.AddMapping(domainMapping);
                
                return configuration;
            }
        }

        public void CreateSchema()
        {
            new SchemaExport(Configuration).Create(true, true);
        }


    }
}
