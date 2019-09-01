 
using FluentMigrator;
using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using System.Reflection;

namespace SQLMigrator
{
    public class MigrationsRunner
    {

        public class MigrationOptions : IMigrationProcessorOptions
        {
            public bool PreviewOnly { get; set; }
            public string ProviderSwitches { get; set; }
            public int? Timeout { get; set; }
        }

        public class MigrationVersionAttribute : MigrationAttribute
        {
            public MigrationVersionAttribute(int major, int minor = 0, int majorRev = 0, int minorRev = 0)
                : base(CalculateValue(major, minor, majorRev, minorRev))
            {


            }

            private static long CalculateValue(int major, int minor = 0, int majorRev = 0, int minorRev = 0)
            {
                long val = (major * 4000000000000L) + (minor * 100000000) + (1000000 * majorRev) + (10000 * minorRev);
                return val;
            }
        }

        public static void MigrateToLatest(string ASDBConection,Assembly asm)
        {
            MigrateASDBToLates(ASDBConection, asm);

        }

        private static void MigrateASDBToLates(string connectionString, Assembly asm)
        {
            //put log for net later
            TextWriterAnnouncer announcer = new TextWriterAnnouncer(s => System.Diagnostics.Debug.WriteLine(s));

            RunnerContext migrationContext = new RunnerContext(announcer)
            {
                Tags = MigrationTags.MigTagList
            };

            MigrationOptions options = new MigrationOptions { PreviewOnly = false, Timeout = 60 };

            FluentMigrator.Runner.Processors.SqlServer.SqlServer2012ProcessorFactory factory =
                new FluentMigrator.Runner.Processors.SqlServer.SqlServer2012ProcessorFactory();

            using (var processor = factory.Create(connectionString, announcer, options))
            {
                MigrationRunner runner = new MigrationRunner(asm, migrationContext, processor);
                runner.MigrateUp();

            }
        }
    }
}
