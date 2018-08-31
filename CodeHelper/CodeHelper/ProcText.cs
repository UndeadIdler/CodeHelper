using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public static class ProcText
    {
        //存储过程中传入的参数
        public static string ProcParameters()
        {
            string s = string.Empty;
            //for (int i = 0; i < Singleton<Condition>.Instance.FinalParameters.Count; i++)
            //{
            //    s += "@" + Singleton<Condition>.Instance.FinalParameters[i][0] + "\t";
            //    if (Singleton<Condition>.Instance.FinalParameters[i][6] == string.Empty)
            //    {
            //        s += Singleton<Condition>.Instance.FinalParameters[i][1];
            //    }
            //    else
            //    {
            //        s += Singleton<Condition>.Instance.FinalParameters[i][1] + "(" + Singleton<Condition>.Instance.FinalParameters[i][6] + ")";
            //    }
            //    if (i < Singleton<Condition>.Instance.FinalParameters.Count - 1)
            //    {
            //        s += ",\r\n";
            //    }
            //    else
            //    {
            //        s += "\r\n";
            //    }
            //}
            return s;
        }

        //存储过程的as之后的
        public static string ProcString()
        {
            string s = "as\r\n";
            //s += "Begin\r\n";
            //s += "Set    NOCOUNT    ON;\r\n";
            //s += "Set XACT_ABORT ON;\r\n";
            //s += "begin   tran  ok\r\n";
            if (Singleton<Condition>.Instance.OperationType != OperationType.Add && Singleton<Condition>.Instance.OperationType != OperationType.Update)
            {
                if (Singleton<Condition>.Instance.OperationType== OperationType.Delete)
                {
                    //s += "Begin\r\n";
                    //s += "Set    NOCOUNT    ON;\r\n";
                    //s += "Set XACT_ABORT ON;\r\n";
                    //s += "begin   tran  ok\r\n";
                    //s += "Delete from [" + Singleton<Condition>.Instance.CDataTable + "]\r\n";
                    //for (int i = 0; i < Singleton<Condition>.Instance.FinalParameters.Count; i++)
                    //{
                    //    if (i == 0)
                    //    {
                    //        s += "where ";
                    //    }
                    //    else
                    //    {
                    //        s += " and ";
                    //    }
                    //    s += Singleton<Condition>.Instance.FinalParameters[i][0] + "=@" + Singleton<Condition>.Instance.FinalParameters[i][0];
                    //    s += "\r\n";
                    //}
                    //s += "if  @@error<>0\r\n";
                    //s += "begin\r\n";
                    //s += "rollback   tran ok\r\n";
                    //s += "return -1\r\n";
                    //s += "end\r\n";
                    //s += "else\r\n";
                    //s += "commit  tran ok\r\n";
                    //s += "return 1\r\n";
                    //s += "End\r\n";
                }
                //else if (Singleton<Condition>.Instance.OperationType == OperationType.IsExists || Singleton<Condition>.Instance.CBPType.Contains("Get"))
                else
                {
                    //s += "Select * from [" + Singleton<Condition>.Instance.CDataTable + "]";
                    //s += "\r\n";
                    //for (int i = 0; i < Singleton<Condition>.Instance.FinalParameters.Count; i++)
                    //{
                    //    if (i == 0)
                    //    {
                    //        s += "where ";
                    //    }
                    //    else
                    //    {
                    //        s += " and ";
                    //    }
                    //    s += Singleton<Condition>.Instance.FinalParameters[i][0] + "=@" + Singleton<Condition>.Instance.FinalParameters[i][0];
                    //    s += "\r\n";
                    //}
                }


            }
            else if (Singleton<Condition>.Instance.OperationType == OperationType.Update)
            {
                //s += "Begin\r\n";
                //s += "Set    NOCOUNT    ON;\r\n";
                //s += "Set XACT_ABORT ON;\r\n";
                //s += "begin   tran  ok\r\n";

                //s += Singleton<Condition>.Instance.OperationType.ToString() + "\t[" + Singleton<Condition>.Instance.CDataTable + "]\r\n";
                //for (int i = 0; i < Singleton<Condition>.Instance.FinalParameters.Count; i++)
                //{
                //    if (i == 0)
                //    {
                //        s += "set " + Singleton<Condition>.Instance.FinalParameters[i][0] + "=@" + Singleton<Condition>.Instance.FinalParameters[i][0];
                //    }
                //    else
                //    {
                //        s += ",\r\n" + Singleton<Condition>.Instance.FinalParameters[i][0] + "=@" + Singleton<Condition>.Instance.FinalParameters[i][0];
                //    }
                //}
                //s += "\r\n";
                //s += "where ID=@ID\r\n";
                //s += "if  @@error<>0\r\n";
                //s += "begin\r\n";
                //s += "rollback   tran ok\r\n";
                //s += "return -1\r\n";
                //s += "end\r\n";
                //s += "else\r\n";
                //s += "commit  tran ok\r\n";
                //s += "return 1\r\n";
                //s += "End\r\n";
            }
            else
            {
                //s += "Begin\r\n";
                //s += "Set    NOCOUNT    ON;\r\n";
                //s += "Set XACT_ABORT ON;\r\n";
                //s += "begin   tran  ok\r\n";
                //s += "Insert into [" + Singleton<Condition>.Instance.CDataTable + "]\r\n";
                //for (int i = 0; i < Singleton<Condition>.Instance.FinalParameters.Count; i++)
                //{
                //    if (i == 0)
                //    {
                //        s += "(" + Singleton<Condition>.Instance.FinalParameters[i][0];
                //    }
                //    else
                //    {
                //        s += ",\r\n" + Singleton<Condition>.Instance.FinalParameters[i][0];
                //    }
                //}
                //s += ")\r\n";
                //s += "values (\r\n";
                //for (int i = 0; i < Singleton<Condition>.Instance.FinalParameters.Count; i++)
                //{
                //    if (i == 0)
                //    {
                //        s += "@" + Singleton<Condition>.Instance.FinalParameters[i][0];
                //    }
                //    else
                //    {
                //        s += ",\r\n@" + Singleton<Condition>.Instance.FinalParameters[i][0];
                //    }
                //}
                //s += ")\r\n";
                //s += "if  @@error<>0\r\n";
                //s += "begin\r\n";
                //s += "rollback   tran ok\r\n";
                //s += "return -1\r\n";
                //s += "end\r\n";
                //s += "else\r\n";
                //s += "commit  tran ok\r\n";
                //if (Singleton<Condition>.Instance.IsProcReturnID == true)
                //{
                //    s += "return @@IDENTITY\r\n";
                //}
                //else
                //{
                //    s += "return 1\r\n";
                //}
                //s += "End\r\n";

            }


            return s;

        }


    }
}
