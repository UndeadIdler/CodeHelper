using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public static class EntityText
    {
        public static StringBuilder Header=new StringBuilder();

        public static StringBuilder Text = new StringBuilder();

        public static StringBuilder Summary = new StringBuilder();

        public static StringBuilder Footer = new StringBuilder();

        private static void GetSummary()
        {
//            StringBuilder summary = new StringBuilder();
            Summary.Append("\t/// <summary>\r\n");
            Summary.Append("\t/// \r\n");
            Summary.Append("\t/// </summary>\r\n");
//            return summary;
        }

        private static StringBuilder GetSummary(string Description)
        {
            StringBuilder summary = new StringBuilder();
            summary.Append("\t/// <summary>\r\n");
            summary.Append("\t/// " + Description + "\r\n");
            summary.Append("\t/// </summary>\r\n");
            return summary;
        }

        private static void GetHeader()
        {
            Header.Append("/// <summary>\r\n");
            Header.Append("/// \r\n");
            Header.Append("/// </summary>\r\n");
            Header.Append(Singleton<Condition>.Instance.EntityAccessType+" class "+Singleton<Condition>.Instance.CDataTable);
            if (Singleton<Condition>.Instance.EntityType != EntityType.Entity)
            {
                Header.Append(Singleton<Condition>.Instance.EntityType.ToString());
            }
            if (Singleton<Condition>.Instance.EntityType == EntityType.InputDto)
            {
                Header.Append(":IEntity");
            }
            Header.Append("\r\n");
            Header.Append("{\r\n");
        }

        private static void GetText()
        {
            DealParameter.GetFinalParameter();
            foreach (FinalParameter fp in Singleton<Condition>.Instance.FinalParameters)
            {
                Text.Append(GetSummary(fp.Description));
                if (Singleton<Condition>.Instance.EntityType == EntityType.InputDto)
                {
                    Text.Append(GetDataAnnotation(fp));
                }
                Text.Append(GetTextLine(fp));
                Text.Append("\t\r\n");
            }
        }

        private static StringBuilder GetDataAnnotation(FinalParameter fp)
        {
            StringBuilder sb = new StringBuilder();
            if (!fp.IsNullable)
            {
                sb.Append("\t[Required]\r\n");
            }
            if (fp.EntityType.Contains("string")&&fp.DALLength>0)
            {
                sb.Append("\t[StringLength(maximumLength: "+fp.DALLength+", ErrorMessage = \"长度不能超过"+fp.DALLength+"\")]\r\n");
            }
            sb.Append("\t[DisplayName(\""+fp.Description+"\")]\r\n");
            return sb;
        }

        private static StringBuilder GetTextLine(FinalParameter fp)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\t"+Singleton<Condition>.Instance.EntityAccessType+" "+fp.EntityType+" "+fp.ColumnName+" {get;set;}\r\n");
            return sb;
        }

        private static void GetFooter()
        {
            Footer.Append("}\r\n");
        }

        public static string FinalEntity()
        {
            Header.Clear();
            Summary.Clear();
            Text.Clear();
            Footer.Clear();
            GetSummary();
            GetHeader();
            GetText();
            GetFooter();
            StringBuilder sb = new StringBuilder();
            sb.Append(Header);
            sb.Append(Text);
            sb.Append(Footer);
            return sb.ToString();
        }
    }
}
