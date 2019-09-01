using FluentMigrator.Runner.VersionTableInfo;

namespace SQLMigratorCore
{
    [VersionTableMetaData]
    public class VersionTable : IVersionTableMetaData
    {
        object context;

        public string ColumnName
        {
            get { return "Version"; }
        }

        public string SchemaName
        {
            get { return ""; }
        }

        public string TableName
        {
            get { return "__AS_Migration_VersionInfo"; }
        }

        public string UniqueIndexName
        {
            get { return "UC_Version"; }
        }

        public virtual string AppliedOnColumnName
        {
            get { return "AppliedOn"; }
        }

        public virtual string DescriptionColumnName
        {
            get { return "Description"; }
        }

        public object ApplicationContext
        {
            get
            {
                return context;
            }

            set
            {
                context = value;
            }
        }

        public bool OwnsSchema
        {
            get
            {
                return false;
            }
        }
    }
}
