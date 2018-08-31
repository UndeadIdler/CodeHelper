using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public class OriginalParameter
    {
        public string ColumnName { get; set; }

        public string DataType { get; set; }

        public string MaxLength { get; set; }

        public Boolean IsNullable { get; set; }

        public string Description { get; set; }
    }
}
