using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLMigrator
{ 
    public abstract class SQLMigrations : Migration
    {

    }

    public class MigrationTags
    {
        public static  List<string> MigTagList;
    }
    public class MigTag : TagsAttribute
    {

        public MigTag(params string[] tagNames) : base(tagNames)
        {
 
        }


        public MigTag(string tagName1) : base(tagName1)
        {
             
        }

        public MigTag(TagBehavior behavior, params string[] tagNames) : base(behavior, tagNames)
        {

        }

        public MigTag(string tagName1, string tagName2) : base(tagName1, tagName2)
        {

        }

        public MigTag(string tagName1, string tagName2, string tagName3) : base(tagName1, tagName2, tagName3)
        {

        }

        public MigTag(string tagName1, string tagName2, string tagName3, string tagName4) : base(tagName1, tagName2, tagName3, tagName4)
        {

        }
    }
}
