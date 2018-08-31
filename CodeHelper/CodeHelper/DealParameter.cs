using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public static class DealParameter
    {
        public static void GetFinalParameter()
        {
            foreach (string choose in Singleton<Condition>.Instance.ChoosenParameters)
            {
                OriginalParameter op = Singleton<Condition>.Instance.ALLParameters.Find(o => o.ColumnName == choose);
                FinalParameter fp = new FinalParameter();
                fp.IsNullable = op.IsNullable;
                fp.ColumnName = op.ColumnName;
                fp.DALType = GetType(op.DataType);
                fp.DALLength = DealParameterLength(fp.DALType, op.MaxLength);
                fp.EntityType = GetEntityType(op.DataType, fp.IsNullable);
                fp.ProcLength = ProcLength(fp.DALType, op.MaxLength);
                fp.Description = op.Description;
                Singleton<Condition>.Instance.FinalParameters.Add(fp);
            }
        }

        public static string GetEntityType(string type,bool IsNullable)
        {
            StringBuilder  EntityType = new StringBuilder();
            if (type == "bigint")
            {
                EntityType.Append("long");
            }
            else if (type.Contains("binary") || type == "image" || type == "timestamp")
            {
                EntityType.Append("byte[]");
            }
            else if (type == "bit")
            {
                EntityType.Append("bool");
            }
            else if (type.Contains("date"))
            {
                if (type.Contains("offset"))
                {
                    EntityType.Append("DateTimeOffset");
                }
                else
                {
                    EntityType.Append("DateTime");
                }
            }
            else if (type.Contains("decimal") || type.Contains("money") || type.Contains("numeric"))
            {
                EntityType.Append("decimal");
            }
            else if (type == "float")
            {
                EntityType.Append("double");
            }
            else if (type == "geography")
            {
                EntityType.Append("DbGeography");
            }
            else if (type == "geometry")
            {
                EntityType.Append("DbGeometry");
            }
            else if (type == "int")
            {
                EntityType.Append("int");
            }
            else if (type == "real")
            {
                EntityType.Append("float");
            }
            else if (type == "smallint")
            {
                EntityType.Append("short");
            }
            else if (type == "time(7)")
            {
                EntityType.Append("TimeSpan");
            }
            else if (type == "uniqueidentifier")
            {
                EntityType.Append("Guid");
            }
            else
            {
                EntityType.Append("string");
            }
            if (IsNullable)
            {
                if (EntityType.ToString() != "string")
                {
                    EntityType.Append("?");
                }
            }
            return EntityType.ToString();
        }

        public static string GetType(string type)
        {
            string Ftype = "";
            if (type == "bit")
            {
                Ftype = "bool";
            }
            else if (type.Contains("int"))
            {
                Ftype = "int";
            }
            else if (type.Contains("numeric") || type.Contains("decimal"))
            {
                Ftype = "decimal";
            }
            else if (type.Contains("datetime"))
            {
                Ftype = "DateTime";
            }
            else if (type.Contains("float"))
            {
                Ftype = "double";
            }
            else if (type.Contains("char") || type.Contains("text"))
            {
                Ftype = "string";
            }
            return Ftype;
        }

        public static int DealParameterLength(string type, string length)
        {
            int i = 0;
            if (type == "int")
            {
                i = 32;
            }
            else if (type == "string")
            {
                if (length != string.Empty && length != "-1")
                {
                    i = int.Parse(length);
                }
            }
            else if (type == "double")
            {
                i = 64;
            }
            else if (type == "bool")
            {
                i = 4;
            }
            return i;
        }

        //处理存储过程里的参数长度
        public static string ProcLength(string type, string length)
        {
            string s = string.Empty;
            if (type == "string")
            {
                if (length == string.Empty || length == "-1")
                {
                    s = "MAX";
                }
                else
                {
                    s = length;
                }
            }
            return s;
        }

    }
}
