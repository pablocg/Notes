using System.Configuration;
using Notes.NH;

namespace Notes.SchemaGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = ConfigurationManager.ConnectionStrings["NoteDB"].ConnectionString;

            var helper = new NHibernateHelper(connectionString);

            helper.CreateSchema();
        }
    }
}
