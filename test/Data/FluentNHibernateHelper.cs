using FluentNHibernate.Cfg.Db;
using FluentNHibernate.Cfg;
using NHibernate;
using ISession = NHibernate.ISession;
using NHibernate.Tool.hbm2ddl;

namespace BlazorNhiber1.Data
{
    public class FluentNHibernateHelper
    {
        public static ISessionFactory _sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get { return _sessionFactory == null ? _sessionFactory = OpenConect() : _sessionFactory; }//check đã được tạo sessionfactory thì dùng luôn, ko tạo lại
        }
        public static ISessionFactory OpenConect()
        {
            string connectionString = @"Data Source=DESKTOP-HEC7UUE\HIHI;Initial Catalog=QLSV;Integrated Security=True";

            var sessionFactory = Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.
                ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<SinhVien>()).
                ExposeConfiguration(cfg => new SchemaExport(cfg)
                .Create(false, false))
                .BuildSessionFactory();
            return sessionFactory;
        }
        public static ISession OpenSession()
        {
            try
            {
                return SessionFactory.OpenSession();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
