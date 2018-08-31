using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using System.Configuration;


namespace CodeHelper
{
    public enum DataBaseType
    {
        AccessClient,
        OracleClient,
        SqlClient
    }


    public class DataBase : DBOperatorBase
    {
        public DataBase()
        {

        }

        public override IDBTypeElementFactory GetDBTypeElementFactory()
        {
            if (DataBaseType.SqlClient == Config.dataBaseType)
            {
                return new SqlDBTypeElementFactory();
            }
            else if (DataBaseType.OracleClient == Config.dataBaseType)
            {
                return new OracleDBTypeElementFactory();
            }

            return new OleDBTypeElementFactory();
        }
    }

    public static class Config
    {
        public static DataBaseType dataBaseType = DataBaseType.SqlClient;
    }

}

