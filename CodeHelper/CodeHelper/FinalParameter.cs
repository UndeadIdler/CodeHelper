using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public class FinalParameter
    {
        public string ColumnName { get; set; }

        public string EntityType { get; set; }

        public string DALType { get; set; }

        public int DALLength { get; set; }

        public string ProcLength { get; set; }

        public Boolean IsNullable { get; set; }

        public string Description { get; set; }
    }
}
