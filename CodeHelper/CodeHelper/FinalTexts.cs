using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeHelper
{
    public static class FinalTexts
    {
        //public static string EntityTexts()
        //{
        //    //string Rt = String.Format("{0} class {1}\r\n{\r\n", Singleton<Condition>.Instance.CEntityType, Singleton<Condition>.Instance.CDataTable);
        //    string Rt = String.Format("{0} class {1}\r\n", Singleton<Condition>.Instance.CEntityType, Singleton<Condition>.Instance.CDataTable);
        //    Rt += "{\r\n";
        //    for (int i = 0; i < Singleton<Condition>.Instance.CParameters.Count; i++)
        //    {
        //        string OName = DealData.GetOriginalNameAndType(Singleton<Condition>.Instance.CParameters[i].ToString())[0];
        //        string Type = DealData.GetOriginalNameAndType(Singleton<Condition>.Instance.CParameters[i].ToString())[1];
        //        string Lower = DealData.GetNames(OName)[0];
        //        string Upper = DealData.GetNames(OName)[1];
        //        string FType = DealData.DealType(Type);

        //        Rt += "\t/// <param name=\"" + Upper + "\">    </param>\r\n";
        //        Rt += String.Format("\tprivate {0} {1};\r\n", FType, Lower);
        //        //Rt += String.Format("\tPublic {0} {1}\r\n\t{\r\n", Type, Upper);
        //        Rt += String.Format("\tpublic {0} {1}\r\n", FType, Upper);
        //        Rt += "\t{\r\n";
        //        Rt += "\t\tget { return " + Lower + "; }\r\n";
        //        //Rt += "\t\tset { " + Lower + "= value; }\r\n\t\r\n\r\n";
        //        Rt += "\t\tset { " + Lower + "= value; }\r\n";
        //        Rt += "\t}\r\n";
        //        Rt += "\r\n";
        //    }
        //    Rt += "}";
        //    return Rt;
        //}


        //public static string DALTexts()
        //{
        //    //string Rt = Notes.NoteTexts();
        //    string Rt = "DAL类中:\r\n";
        //    Rt += "\r\n";
        //    Rt += Notes.NoteTexts();
        //    Rt += String.Format("{0} static {1} {2}{3}({4})\r\n", Singleton<Condition>.Instance.CDALType, Singleton<Condition>.Instance.DALReturnType, Singleton<Condition>.Instance.OperationType, Singleton<Condition>.Instance.CDataTable, DALText.DealDALParameterString());
        //    Rt += "{\r\n";
        //    Rt += "\t" + DALText.DALFirstLine(Singleton<Condition>.Instance.DALReturnType.Trim()) + "\r\n";
        //    Rt += "\tDBOperatorBase db = new DataBase();\r\n";
        //    Rt += "\tIDBTypeElementFactory dbFactory = db.GetDBTypeElementFactory();\r\n";
        //    //try
        //    Rt += "\ttry\r\n";
        //    Rt += "\t{\r\n";
        //    if (Singleton<Condition>.Instance.CommandType == DALCommandType.Text)
        //    {
        //        Rt += DALText.MakeInParam();
        //        if (Singleton<Condition>.Instance.CBDaBSql == "查询")
        //        {
        //            Rt += "\t\tIDataReader dataReader = db.ExecuteReader(ConnectionStringXX, CommandType.Text," + DALText.DALCommandText() + ", null);\r\n";
        //            Rt += "\t\twhile(dataReader.Read())\r\n";
        //            Rt += "\t\t{\r\n";
        //            if (Singleton<Condition>.Instance.DALReturnType == "bool")
        //            {
        //                Rt += "\t\t\tiReturn = 1;\r\n";
        //            }
        //            else if (Singleton<Condition>.Instance.DALReturnType.Contains("Entity"))
        //            {
        //                Rt += DALText.DALEntity();
        //                string ReturnType = "Entity." + Singleton<Condition>.Instance.CDataTable;
        //                if (Singleton<Condition>.Instance.DALReturnType != ReturnType)
        //                {
        //                    Rt += "\t\t\tlist.Add(entity);\r\n";
        //                }
        //            }
        //            else if (Singleton<Condition>.Instance.DALReturnType == "string")
        //            {
        //                Rt += "\t\t\tiReturn = dataReader[\"XX\"].ToString();\r\n";
        //            }
        //            else if (Singleton<Condition>.Instance.DALReturnType == "int")
        //            {
        //                Rt += "\t\t\tiReturn = DataHelper.ParseToInt(dataReader[\"XX\"].ToString());\r\n";
        //            }

        //            Rt += "\t\t}\r\n";
        //        }
        //        else
        //        {
        //            Rt += "\t\tiReturn = db.ExecuteNonQuery(dbFactory.GetConnection(ConnectionStringXX), true, CommandType.Text, " + DALText.DALCommandText() + ", null);\r\n";
        //            if (Singleton<Condition>.Instance.IsDALReturnID == true)
        //            {
        //                Rt += "\t\tiReturn = int.Parse(prams[" + (Singleton<Condition>.Instance.FinalParameters.Count).ToString() + "].Value.ToString());\r\n";
        //            }
        //        }

        //    }
        //    else
        //    {
        //        //Rt += "\t\t";
        //        Rt += DALText.MakeInParam();
        //        if (Singleton<Condition>.Instance.CBDaBSql == "查询")
        //        {
        //            Rt += "\t\tIDataReader dataReader = db.ExecuteReader(ConnectionStringXX, CommandType.StoredProcedure,\"proc_" + Singleton<Condition>.Instance.CDataTable + "_" + Singleton<Condition>.Instance.OperationType.ToString() + "\", prams);\r\n";
        //            Rt += "\t\twhile(dataReader.Read())\r\n";
        //            Rt += "\t\t{\r\n";
        //            if (Singleton<Condition>.Instance.DALReturnType == "bool")
        //            {
        //                Rt += "\t\t\tiReturn = 1;\r\n";
        //            }
        //            else if (Singleton<Condition>.Instance.DALReturnType.Contains("Entity"))
        //            {
        //                Rt += DALText.DALEntity();
        //                string ReturnType = "Entity." + Singleton<Condition>.Instance.CDataTable;
        //                if (Singleton<Condition>.Instance.DALReturnType != ReturnType)
        //                {
        //                    Rt += "\t\t\tlist.Add(entity);\r\n";
        //                }
        //            }
        //            else if (Singleton<Condition>.Instance.DALReturnType == "string")
        //            {
        //                Rt += "\t\t\tiReturn = dataReader[\"XX\"].ToString();\r\n";
        //            }
        //            else if (Singleton<Condition>.Instance.DALReturnType == "int")
        //            {
        //                Rt += "\t\t\tiReturn = DataHelper.ParseToInt(dataReader[\"XX\"].ToString());\r\n";
        //            }

        //            Rt += "\t\t}\r\n";
        //        }
        //        else
        //        {
        //            Rt += "\t\tiReturn = db.ExecuteNonQuery(dbFactory.GetConnection(ConnectionStringXX), true, CommandType.StoredProcedure, \"proc_" + Singleton<Condition>.Instance.CDataTable + "_" + Singleton<Condition>.Instance.OperationType + "\", prams);\r\n";
        //            if (Singleton<Condition>.Instance.IsDALReturnID == true && Singleton<Condition>.Instance.OperationType.ToString() == "Add")
        //            {
        //                Rt += "\t\tiReturn = int.Parse(prams[" + (Singleton<Condition>.Instance.FinalParameters.Count).ToString() + "].Value.ToString());\r\n";
        //            }

        //        }
        //    }



        //    Rt += "\t}\r\n";
        //    //catch
        //    Rt += "\tcatch(Exception ex)\r\n";
        //    Rt += "\t{\r\n";
        //    Rt += "\t\t\r\n";
        //    Rt += "\t}\r\n";
        //    //finally
        //    Rt += "\tfinally\r\n";
        //    Rt += "\t{\r\n";
        //    Rt += "\t\tdb.Conn.Close();\r\n";
        //    Rt += "\t}\r\n";
        //    Rt += "\t" + DALText.DALLastReturn(Singleton<Condition>.Instance.DALReturnType) + "\r\n";
        //    Rt += "}\r\n\r\n\r\n";
        //    Rt += BLLText.DealBLLText();
        //    return Rt;
        //}

        //public static string ProcTexts()
        //{
        //    string Rt = "set ANSI_NULLS ON\r\n";
        //    Rt += "set QUOTED_IDENTIFIER ON\r\n";
        //    Rt += "GO\r\n";
        //    Rt += "\r\n";
        //    Rt += "create proc [dbo].[proc_" + Singleton<Condition>.Instance.CDataTable + "_" + Singleton<Condition>.Instance.CBPType + "]\r\n";
        //    Rt += ProcText.ProcParameters();
        //    Rt += ProcText.ProcString();
        //    //for (int i = 0; i < Singleton<Condition>.Instance.FinalParameters.Count; i++)
        //    //{
        //    //    if (i < Singleton<Condition>.Instance.FinalParameters.Count - 1)
        //    //    {
        //    //        //Rt += "@"+;
        //    //    }
        //    //}
        //    //Rt += "@";
        //    return Rt;
        //}

    }
}
