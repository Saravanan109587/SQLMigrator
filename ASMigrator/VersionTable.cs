using FluentMigrator.Runner.VersionTableInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMigrator
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
