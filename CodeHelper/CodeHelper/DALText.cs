using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public static class DALText
    {
        public static StringBuilder DapperText = new StringBuilder();

        public static StringBuilder DataAccessText = new StringBuilder();

        public static string FinalDAL()
        {
            DealParameter.GetFinalParameter();
            if (Singleton<Condition>.Instance.DLLName == DLLName.Dapper)
            {
                GetDapperText();
                return DapperText.ToString();
            }
            else
            {
                GetDataAccessText();
                return DataAccessText.ToString();
            }
        }

        private static void GetDapperText()
        {
            DapperText.Clear();
            DapperText.Append(GetHeader());
            DapperText.Append(GetDapperBody());
            //DapperText.Append(GetDapperFooter());
        }

        private static StringBuilder GetHeader()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DAL类中:\r\n");
            sb.Append("\r\n");
            sb.Append("/// <summary>\r\n");
            sb.Append("///\r\n");
            sb.Append("/// </summary>\r\n");
            if (Singleton<Condition>.Instance.OperationType == OperationType.Add || Singleton<Condition>.Instance.OperationType == OperationType.Update)
            {
                sb.Append("/// <param name=\"" + Singleton<Condition>.Instance.CDataTable + "s\">    </param>\r\n");
            }
            else
            {
                foreach (string choose in Singleton<Condition>.Instance.ChoosenParameters)
                {
                    sb.Append("/// <param name=\"" + choose + "\">    </param>\r\n");
                }
            }
            sb.Append("/// <returns></returns>\r\n");
            sb.Append(Singleton<Condition>.Instance.DALAccessType + " static ");
            if (Singleton<Condition>.Instance.OperationType == OperationType.Add || Singleton<Condition>.Instance.OperationType == OperationType.Update)
            {
                sb.Append("ReturnInfo");
            }
            else
            {
                //sb.Append(Singleton<Condition>.Instance.DALReturnType);
                if (Singleton<Condition>.Instance.DALReturnType.Contains("Entity"))
                {
                    if (Singleton<Condition>.Instance.DALReturnType.Contains("List"))
                    {
                        sb.Append("List<");
                    }
                    sb.Append(Singleton<Condition>.Instance.CDataTable);
                    if (Singleton<Condition>.Instance.DALReturnType.Contains("List"))
                    {
                        sb.Append(">");
                    }
                }
                else if (Singleton<Condition>.Instance.DALReturnType.Contains("Dto"))
                {
                    if (Singleton<Condition>.Instance.DALReturnType.Contains("List"))
                    {
                        sb.Append("List<");
                    }
                    sb.Append(Singleton<Condition>.Instance.CDataTable+"OutputDto");
                    if (Singleton<Condition>.Instance.DALReturnType.Contains("List"))
                    {
                        sb.Append(">");
                    }
                }
                else
                {
                    sb.Append(Singleton<Condition>.Instance.DALReturnType);
                }
            }
            sb.Append(" " + Singleton<Condition>.Instance.OperationType + Singleton<Condition>.Instance.CDataTable + "(");
            if (Singleton<Condition>.Instance.OperationType == OperationType.Add || Singleton<Condition>.Instance.OperationType == OperationType.Update)
            {
                if (Singleton<Condition>.Instance.DALReturnType.Contains("List"))
                {
                    sb.Append("List<" + Singleton<Condition>.Instance.CDataTable);
                    if (Singleton<Condition>.Instance.DALReturnType.Contains("Dto"))
                    {
                        sb.Append("InputDto");
                    }
                    sb.Append("> " + Singleton<Condition>.Instance.CDataTable + "s");
                }
                else
                {
                    sb.Append(Singleton<Condition>.Instance.CDataTable);
                    if (Singleton<Condition>.Instance.DALReturnType.Contains("Dto"))
                    {
                        sb.Append("InputDto");
                    }
                    sb.Append(" " + Singleton<Condition>.Instance.CDataTable + "s");
                }
                //sb.Append("List<" + Singleton<Condition>.Instance.CDataTable+"> "+Singleton<Condition>.Instance.CDataTable+"s");                
            }
            else
            {
                for (int i = 0; i < Singleton<Condition>.Instance.FinalParameters.Count; i++)
                {
                    if (i == Singleton<Condition>.Instance.FinalParameters.Count - 1)
                    {
                        sb.Append(Singleton<Condition>.Instance.FinalParameters[i].DALType + " " + Singleton<Condition>.Instance.FinalParameters[i].ColumnName);
                    }
                    else
                    {
                        sb.Append(Singleton<Condition>.Instance.FinalParameters[i].DALType + " " + Singleton<Condition>.Instance.FinalParameters[i].ColumnName + ",");
                    }
                }
            }
            sb.Append(")\r\n");
            sb.Append("{\r\n");
            return sb;
        }

        private static StringBuilder GetDapperBody()
        {
            StringBuilder sb = new StringBuilder();
            //前几行
            sb.Append(GetDapperBodyFirstLines());
            if (Singleton<Condition>.Instance.OperationType == OperationType.Add || Singleton<Condition>.Instance.OperationType == OperationType.Update)
            {
                sb.Append("\tif(sb.Length == 0)\r\n");
                sb.Append("\t{\r\n");
                sb.Append("\t\tusing (var conn = new SqlConnection(con))\r\n");
                sb.Append("\t\t{\r\n");
                sb.Append("\t\t\tconn.Open();\r\n");
                sb.Append("\t\t\ttry\r\n");
                sb.Append("\t\t\t{\r\n");
                sb.Append("\t\t\t\tvar a = conn.Execute(@\""+GetSql()+"\","+Singleton<Condition>.Instance.CDataTable+"s);\r\n");
                sb.Append("\t\t\t\tif(a>0)\r\n");
                sb.Append("\t\t\t\t{\r\n");
                sb.Append("\t\t\t\t\tRInfo.IsSuccess = true;\r\n");
                sb.Append("\t\t\t\t}\r\n");
                sb.Append("\t\t\t}\r\n");
                sb.Append("\t\t\tcatch (Exception ex)\r\n");
                sb.Append("\t\t\t{\r\n");
                sb.Append("\t\t\t\tsb.Append(ex.Message);\r\n");
                sb.Append("\t\t\t\tRInfo.IsSuccess = false;\r\n");
                sb.Append("\t\t\t\tRInfo.ErrorInfo = sb.ToString();\r\n");
                sb.Append("\t\t\t}\r\n");
                //sb.Append("\t\t\t\treturn RInfo;\r\n");
                sb.Append("\t\t\tfinally\r\n");
                sb.Append("\t\t\t{\r\n");
                sb.Append("\t\t\t\tconn.Close();\r\n");
                sb.Append("\t\t\t}\r\n");
                sb.Append("\t\t}\r\n");
                sb.Append("\t}\r\n");
                sb.Append("\telse\r\n");
                sb.Append("\t{\r\n");
                sb.Append("\t\tRInfo.IsSuccess = false;\r\n");
                //sb.Append("\t\tsb.Append(\"不存在ID为\" + ATID + \"的考勤模板.\");\r\n");
                sb.Append("\t\tRInfo.ErrorInfo = sb.ToString();\r\n");
                sb.Append("\t}\r\n");
                sb.Append("\treturn RInfo;\r\n");
                sb.Append("}\r\n");
            }
            else
            {
                sb.Append("\tusing (var conn = new SqlConnection(con))\r\n");
                sb.Append("\t{\r\n");
                sb.Append("\t\tconn.Open();\r\n");
                //sb.Append("\t\ttry\r\n");
                //sb.Append("\t\t{\r\n");
                if (Singleton<Condition>.Instance.OperationType == OperationType.Delete)
                {
                    sb.Append("\t\tvar a = conn.Execute(@\"" + GetSql() + "\",new {");
                    for (int i = 0; i < Singleton<Condition>.Instance.ChoosenParameters.Count; i++)
                    {
                        sb.Append(Singleton<Condition>.Instance.ChoosenParameters[i] + "=" + Singleton<Condition>.Instance.ChoosenParameters[i]);
                        if (i < Singleton<Condition>.Instance.ChoosenParameters.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("});\r\n");
                }
                else
                {
                    sb.Append("\t\tvar a = conn.Query<");
                    if (Singleton<Condition>.Instance.DALReturnType.Contains("Entity") || Singleton<Condition>.Instance.DALReturnType.Contains("Output"))
                    {
                        sb.Append(Singleton<Condition>.Instance.CDataTable);
                        if (Singleton<Condition>.Instance.DALReturnType.Contains("Output"))
                        {
                            sb.Append("OutputDto");
                        }
                    }
                    else if (Singleton<Condition>.Instance.DALReturnType.Contains("bool"))
                    {
                        sb.Append("int");
                    }
                    else
                    {
                        sb.Append(Singleton<Condition>.Instance.DALReturnType);
                    }
                    sb.Append(">(@\"" + GetSql() + "\",new {");
                    for (int i = 0; i < Singleton<Condition>.Instance.ChoosenParameters.Count; i++)
                    {
                        sb.Append(Singleton<Condition>.Instance.ChoosenParameters[i] + "=" + Singleton<Condition>.Instance.ChoosenParameters[i]);
                        if (i < Singleton<Condition>.Instance.ChoosenParameters.Count - 1)
                        {
                            sb.Append(",");
                        }
                    }
                    sb.Append("});\r\n");
                    //sb.Append(">(@\"" + GetSql() + "\"," + Singleton<Condition>.Instance.CDataTable + "s);\r\n");
                }

                //sb.Append("\t}\r\n");
                //sb.Append("\t\tcatch (Exception ex)\r\n");
                //sb.Append("\t\t{\r\n");

                //sb.Append("\t\t}\r\n");
                //sb.Append("\t\tfinally\r\n");
                //sb.Append("\t\t{\r\n");
                sb.Append("\t\tconn.Close();\r\n");
                if (Singleton<Condition>.Instance.DALReturnType == "bool")
                {
                    sb.Append("\t\treturn a.FirstOrDefault()>0;\r\n");
                }
                else if (Singleton<Condition>.Instance.DALReturnType.Contains("List"))
                {
                    sb.Append("\t\treturn a.ToList();\r\n");
                }
                else
                {
                    sb.Append("\t\treturn a.FirstOrDefault();\r\n");
                }
                //else if (Singleton<Condition>.Instance.DALReturnType == "int" || Singleton<Condition>.Instance.DALReturnType == "string")
                //{
                //    sb.Append("\t\treturn a.FirstOrDefault();\r\n");
                //}
                //else if (Singleton<Condition>.Instance.DALReturnType == "bool")
                //{
                //    sb.Append("\t\treturn a.FirstOrDefault()>0;\r\n");
                //}
                //else if (Singleton<Condition>.Instance.DALReturnType == "bool")
                //{
                //    sb.Append("\t\treturn a.FirstOrDefault()>0;\r\n");
                //}
                //sb.Append("\t\t}\r\n");
                sb.Append("\t}\r\n");
                sb.Append("}\r\n");
            }



            //sb.Append("\t\t}\r\n");
            //sb.Append("\t\tcatch (Exception ex)\r\n");
            //sb.Append("\t\t{\r\n");

            //sb.Append("\t\t}\r\n");
            //sb.Append("\t\tfinally\r\n");
            //sb.Append("\t\t{\r\n");
            //sb.Append("\t\tconn.Close();\r\n");
            //sb.Append("\t\t}\r\n");
            //sb.Append("\t}\r\n");
            //if (Singleton<Condition>.Instance.DALReturnType == "int" || Singleton<Condition>.Instance.DALReturnType == "bool")
            //{
            //    sb.Append("int iReturn=0;");
            //}
            //else if (Singleton<Condition>.Instance.DALReturnType == "string")
            //{
            //    sb.Append("string iReturn = string.Empty;");
            //}
            //else if (Singleton<Condition>.Instance.DALReturnType.Contains("List<Entity"))
            //{
            //    sb.Append("List<Entity." + Singleton<Condition>.Instance.CDataTable + "> list=new List<Entity." + Singleton<Condition>.Instance.CDataTable + ">();");
            //}
            //else
            //{
            //    sb.Append("Entity." + Singleton<Condition>.Instance.CDataTable + " entity=null;");
            //}
            //sb.Append("\r\n");
            return sb;
        }

        #region using之前的   GetDapperBodyFirstLines() 
        //using之前的
        private static StringBuilder GetDapperBodyFirstLines()
        {
            StringBuilder sb = new StringBuilder();
            if (Singleton<Condition>.Instance.OperationType == OperationType.Add || Singleton<Condition>.Instance.OperationType == OperationType.Delete || Singleton<Condition>.Instance.OperationType == OperationType.Update)
            {
                sb.Append("\tReturnInfo RInfo=new ReturnInfo();\r\n");
                sb.Append("\tStringBuilder sb = new StringBuilder();\r\n");
                if (Singleton<Condition>.Instance.OperationType != OperationType.Delete)
                {
                    if (Singleton<Condition>.Instance.DALReturnType.Contains("List"))
                    {
                        sb.Append("\tforeach(" + Singleton<Condition>.Instance.CDataTable);
                        if (Singleton<Condition>.Instance.DALReturnType.Contains("Dto"))
                        {
                            sb.Append("InputDto");
                        }
                        sb.Append(" " + Singleton<Condition>.Instance.CDataTable + " in " + Singleton<Condition>.Instance.CDataTable + "s");
                        sb.Append(")\r\n");
                        sb.Append("\t{\r\n");
                        sb.Append("\t\tsb.Append(Helper.Validate" + Singleton<Condition>.Instance.CDataTable);
                        if (Singleton<Condition>.Instance.DALReturnType.Contains("Dto"))
                        {
                            sb.Append("InputDto");
                        }
                        sb.Append("(" + Singleton<Condition>.Instance.CDataTable + "));\r\n");
                        sb.Append("\t}\r\n");
                    }
                    else
                    {
                        sb.Append("\tsb.Append(Helper.Validate" + Singleton<Condition>.Instance.CDataTable);
                        if (Singleton<Condition>.Instance.DALReturnType.Contains("Dto"))
                        {
                            sb.Append("InputDto");
                        }
                        sb.Append("(" + Singleton<Condition>.Instance.CDataTable + "s));\r\n");
                    }
                }
                
            }
            else
            {
                //sb.Append("\t");
                //if (Singleton<Condition>.Instance.DALReturnType == "int" || Singleton<Condition>.Instance.DALReturnType == "bool")
                //{
                //    sb.Append("int iReturn=0;");
                //}
                //else if (Singleton<Condition>.Instance.DALReturnType == "string")
                //{
                //    sb.Append("string iReturn = string.Empty;");
                //}
                //else if (Singleton<Condition>.Instance.DALReturnType.Contains("List<Entity"))
                //{
                //    sb.Append("List<Entity." + Singleton<Condition>.Instance.CDataTable + "> list=new List<Entity." + Singleton<Condition>.Instance.CDataTable + ">();");
                //}
                //else if (Singleton<Condition>.Instance.DALReturnType.Contains("Entity"))
                //{
                //    sb.Append("Entity." + Singleton<Condition>.Instance.CDataTable + " entity=null;");
                //}
                //else if (Singleton<Condition>.Instance.DALReturnType.Contains("List<Output"))
                //{
                //    sb.Append("List<" + Singleton<Condition>.Instance.CDataTable + "OutputDto> list=new List<" + Singleton<Condition>.Instance.CDataTable + "OutputDto>();");
                //}
                //else if (Singleton<Condition>.Instance.DALReturnType.Contains("Output"))
                //{
                //    sb.Append(Singleton<Condition>.Instance.CDataTable + "OutputDto entity=null;");
                //}
                //sb.Append("\r\n");
            }
            return sb;
        }
        #endregion

        #region Sql语句 GetSql
        private static StringBuilder GetSql()
        {
            StringBuilder sb = new StringBuilder();
            if (Singleton<Condition>.Instance.OperationType == OperationType.Add)
            {
                sb.Append("Insert into [" + Singleton<Condition>.Instance.CDataTable + "](");
                for (int i = 0; i < Singleton<Condition>.Instance.ChoosenParameters.Count; i++)
                {
                    sb.Append(Singleton<Condition>.Instance.ChoosenParameters[i]);
                    if (i < Singleton<Condition>.Instance.ChoosenParameters.Count-1)
                    {
                        sb.Append(",");

                    }
                }
                sb.Append(") values (");
                for (int i = 0; i < Singleton<Condition>.Instance.ChoosenParameters.Count; i++)
                {
                    sb.Append("@"+Singleton<Condition>.Instance.ChoosenParameters[i]);
                    if (i < Singleton<Condition>.Instance.ChoosenParameters.Count - 1)
                    {
                        sb.Append(",");

                    }
                }
                sb.Append(")");
            }
            else if (Singleton<Condition>.Instance.OperationType == OperationType.Update)
            {
                sb.Append("update ["+Singleton<Condition>.Instance.CDataTable+"] set ");
                for (int i = 0; i < Singleton<Condition>.Instance.ChoosenParameters.Count; i++)
                {
                    sb.Append(Singleton<Condition>.Instance.ChoosenParameters[i]+"=");
                    sb.Append("@" + Singleton<Condition>.Instance.ChoosenParameters[i]);
                    if (i < Singleton<Condition>.Instance.ChoosenParameters.Count - 1)
                    {
                        sb.Append(",");
                    }
                }
                sb.Append(" where ID=@ID");
            }
            else if (Singleton<Condition>.Instance.OperationType == OperationType.Delete)
            {
                sb.Append("delete from [" + Singleton<Condition>.Instance.CDataTable + "] where ");
                for (int i = 0; i < Singleton<Condition>.Instance.ChoosenParameters.Count; i++)
                {
                    sb.Append(Singleton<Condition>.Instance.ChoosenParameters[i] + "=");
                    sb.Append("@" + Singleton<Condition>.Instance.ChoosenParameters[i]);
                    if (i < Singleton<Condition>.Instance.ChoosenParameters.Count - 1)
                    {
                        sb.Append(" and ");
                    }
                }
            }
            else if (Singleton<Condition>.Instance.OperationType == OperationType.IsExists)
            {
                sb.Append("select count(*) from [" + Singleton<Condition>.Instance.CDataTable + "] where ");
                for (int i = 0; i < Singleton<Condition>.Instance.ChoosenParameters.Count; i++)
                {
                    sb.Append(Singleton<Condition>.Instance.ChoosenParameters[i] + "=");
                    sb.Append("@" + Singleton<Condition>.Instance.ChoosenParameters[i]);
                    if (i < Singleton<Condition>.Instance.ChoosenParameters.Count - 1)
                    {
                        sb.Append(" and ");
                    }
                }
            }
            else if (Singleton<Condition>.Instance.OperationType == OperationType.Get)
            {
                sb.Append("select * from [" + Singleton<Condition>.Instance.CDataTable + "] where ");
                for (int i = 0; i < Singleton<Condition>.Instance.ChoosenParameters.Count; i++)
                {
                    sb.Append(Singleton<Condition>.Instance.ChoosenParameters[i] + "=");
                    sb.Append("@" + Singleton<Condition>.Instance.ChoosenParameters[i]);
                    if (i < Singleton<Condition>.Instance.ChoosenParameters.Count - 1)
                    {
                        sb.Append(" and ");
                    }
                }
            }
            else if (Singleton<Condition>.Instance.OperationType == OperationType.GetAll)
            {
                sb.Append("select * from [" + Singleton<Condition>.Instance.CDataTable + "]");
            }
            return sb;
        }
        #endregion

        //private static StringBuilder GetDapperFooter()
        //{
        //    StringBuilder sb = new StringBuilder();

        //    return sb;
        //}

        private static void GetDataAccessText()
        {
            DataAccessText.Clear();
            DataAccessText.Append(GetHeader());
            DataAccessText.Append(GetDataAccessBody());
            DataAccessText.Append(GetDataAccessFooter());
        }

        private static StringBuilder GetDataAccessBody()
        {
            StringBuilder sb = new StringBuilder();

            return sb;
        }

        private static StringBuilder GetDataAccessFooter()
        {
            StringBuilder sb = new StringBuilder();

            return sb;
        }
    }
}
