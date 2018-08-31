using System;
using System.Collections.Generic;
using System.Text;


namespace CodeHelper
{
    public class ConnectionString
    {
        private string dataSource;
        public string DataSource
        {
            get { return dataSource; }
            set { dataSource = value; }
        }

        private string userID;
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private string passWord;
        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }

        private string dataBase;
        public string DataBase
        {
            get { return dataBase; }
            set { dataBase = value; }
        }

        private string dataTable;
        public string DataTable
        {
            get { return dataTable; }
            set { dataTable = value; }
        }

        public override string ToString()
        {
            string s = String.Format("Data Source={0};User ID={1};Password={2};Initial Catalog={3}", this.DataSource, this.UserID, this.PassWord, this.DataBase);
            return s;
        }


    }
}
