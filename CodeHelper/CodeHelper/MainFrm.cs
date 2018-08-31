using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CodeHelper
{
    public partial class MainFrm : Form
    {
        public MainFrm()
        {
            InitializeComponent();
        }

        public string[] Keys;

        private void Form1_Load(object sender, EventArgs e)
        {
            Keys = ConfigurationManager.AppSettings.AllKeys;
            foreach (string Key in Keys)
            {
                cBDataSource.Items.Add(Key);
            }
            string Value = ConfigurationManager.AppSettings[Keys[0]];
            string[] values = Value.Split(';');
            Singleton<ConnectionString>.Instance.DataSource = values[0];
            Singleton<ConnectionString>.Instance.UserID = values[1];
            Singleton<ConnectionString>.Instance.PassWord = values[2];
            tBUserName.Text = values[1].Split('=')[1];
            tBPW.Text = values[2].Split('=')[1];
            cBDataSource.SelectedIndex = 0;
            List<string> DLLName = Enum.GetNames(typeof(DLLName)).ToList();
            foreach (string name in DLLName)
            {
                cBDLLName.Items.Add(name);
            }
            cBDLLName.SelectedIndex = 0;
            List<string> ResultType = Enum.GetNames(typeof(ResultType)).ToList();
            foreach (string result in ResultType)
            {
                cBResultType.Items.Add(result);
            }
            cBResultType.SelectedIndex = 0;
            groupBox3.Controls.Clear();
            BuildEntity be = new BuildEntity();
            groupBox3.Controls.Add(be);

            Singleton<Condition>.Instance.ALLParameters = new  List<OriginalParameter>();
            Singleton<Condition>.Instance.FinalParameters = new List<FinalParameter>();
            Singleton<Condition>.Instance.ChoosenParameters = new List<string>();

            //Singleton<Condition>.Instance.CreatedParameters = new List<string>();
            //Singleton<Condition>.Instance.FCreatedParameters = new List<string[]>();
            //Singleton<Condition>.Instance.AllCreatedParameterNames = new List<string>();

            //Singleton<Condition>.Instance.UpdatedParameters = new List<string>();
            //Singleton<Condition>.Instance.FUpdatedParameters = new List<string[]>();
            //Singleton<Condition>.Instance.AllUpdatedParameterNames = new List<string>();

            //Singleton<Condition>.Instance.AuditedParameters = new List<string>();
            //Singleton<Condition>.Instance.FAuditedParameters = new List<string[]>();
            //Singleton<Condition>.Instance.AllAuditedParameterNames = new List<string>();

            //Singleton<Condition>.Instance.DeletedParameters = new List<string>();
            //Singleton<Condition>.Instance.FDeletedParameters = new List<string[]>();
            //Singleton<Condition>.Instance.AllDeletedParameterNames = new List<string>();


            //Singleton<Condition>.Instance.All.type = Type.All;
            //Singleton<Condition>.Instance.Create.type = Type.Create;
            //Singleton<Condition>.Instance.Update.type = Type.Update;
            //Singleton<Condition>.Instance.Delete.type = Type.Delete;
            //Singleton<Condition>.Instance.Audit.type = Type.Audit;
        }

        //public ConnectionString Conn=new ConnectionString();

        public string ConString;

        private void cBDataSource_TextChanged(object sender, EventArgs e)
        {
            Singleton<ConnectionString>.Instance.DataSource = cBDataSource.Text.Trim();
        }

        private void cBDataSource_SelectedValueChanged(object sender, EventArgs e)
        {
            Singleton<ConnectionString>.Instance.DataSource = cBDataSource.Text.Trim();
            int i = cBDataSource.SelectedIndex;
            string Value = ConfigurationManager.AppSettings[Keys[i]];
            string[] values = Value.Split(';');
            tBUserName.Text = values[1].Split('=')[1];
            tBPW.Text = values[2].Split('=')[1];
        }

        private void cBDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            Singleton<ConnectionString>.Instance.DataSource = cBDataSource.Text.Trim();
            int i = cBDataSource.SelectedIndex;
            string Value = ConfigurationManager.AppSettings[Keys[i]];
            string[] values = Value.Split(';');
            tBUserName.Text = values[1].Split('=')[1];
            tBPW.Text = values[2].Split('=')[1];
        }

        private void btLogin_Click(object sender, EventArgs e)
        {
            if (tBPW.Text != string.Empty && tBUserName.Text != string.Empty && cBDataSource.Text != string.Empty)
            {
                DBOperatorBase db = new DataBase();
                IDBTypeElementFactory dbFactory = db.GetDBTypeElementFactory();
                Singleton<ConnectionString>.Instance.DataBase = "master";
                //String ConString = String.Format("Data Source={0};User ID={1};Password={2};Initial Catalog={3}", Conn.DataSource, Conn.UserID, Conn.PassWord, Conn.DataBase);
                ConString = Singleton<ConnectionString>.Instance.ToString();
                try
                {
                    IDataReader dataReader = db.ExecuteReader(ConString, CommandType.Text, "SELECT Name FROM Master..SysDatabases ORDER BY Name", null);

                    if (dataReader.Read())
                    {
                        //iReturn = 1;
                        cBDatabase.Items.Clear();
                        MessageBox.Show("登陆成功");
                        cBDatabase.Items.Add(dataReader["Name"].ToString().Trim());
                        while (dataReader.Read())
                        {
                            cBDatabase.Items.Add(dataReader["Name"].ToString().Trim());
                        }
                        if (cBDatabase.Items.Count > 1)
                        {
                            cBDatabase.SelectedIndex = 0;
                            listBox1.SelectedIndex = 0;
                        }
                        //修改配置文件
                        //if (!cBDataSource.Items.Contains(Singleton<ConnectionString>.Instance.DataSource))
                        //{
                        //    cBDataSource.Items.Add(Singleton<ConnectionString>.Instance.DataSource);
                        //}


                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        Configs.UpdateAppSettingsItemValue(config, Singleton<ConnectionString>.Instance.DataSource, String.Format("Data Source={0};User ID={1};Password={2};Initial Catalog=master", Singleton<ConnectionString>.Instance.DataSource, Singleton<ConnectionString>.Instance.UserID, Singleton<ConnectionString>.Instance.PassWord, Singleton<ConnectionString>.Instance.DataBase));

                        cBDataSource.Items.Clear();
                        Keys = ConfigurationManager.AppSettings.AllKeys;
                        foreach (string Key in Keys)
                        {
                            cBDataSource.Items.Add(Key);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该数据库没有内容");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("用户{0}登陆失败", Singleton<ConnectionString>.Instance.UserID));
                }
                finally
                {
                    db.Conn.Close();
                }
            }
            else
            {

                MessageBox.Show("请选择正确的参数并重试!");

            }

        }

        private void tBUserName_TextChanged(object sender, EventArgs e)
        {
            Singleton<ConnectionString>.Instance.UserID = tBUserName.Text.Trim();
        }

        private void tBPW_TextChanged(object sender, EventArgs e)
        {
            Singleton<ConnectionString>.Instance.PassWord = tBPW.Text.Trim();
        }

        private void cBDatabase_SelectedIndexChanged(object sender, EventArgs e)
        {
            Singleton<ConnectionString>.Instance.DataBase = cBDatabase.SelectedItem.ToString();
            listBox1.Items.Clear();
            Singleton<Condition>.Instance.ChoosenParameters.Clear();

            DBOperatorBase db = new DataBase();
            IDBTypeElementFactory dbFactory = db.GetDBTypeElementFactory();
            //String ConString = String.Format("Data Source={0};User ID={1};Password={2};Database={3}", Conn.DataSource, Conn.UserID, Conn.PassWord, Conn.DataBase);
            ConString = Singleton<ConnectionString>.Instance.ToString();
            try
            {
                IDataReader dataReader = db.ExecuteReader(ConString, CommandType.Text, "SELECT Name FROM " + Singleton<ConnectionString>.Instance.DataBase + "..SysObjects Where XType='U' ORDER BY Name", null);

                while (dataReader.Read())
                {
                    listBox1.Items.Add(dataReader["Name"].ToString().Trim());
                }
                if (listBox1.Items.Count > 1)
                {
                    listBox1.SelectedIndex = 0;
                }

            }
            catch (Exception ex)
            {
                //throw ex;
                //Logger.Logger.Trace(ex);
            }
            finally
            {
                db.Conn.Close();
            }


        }

        private void btChoose_Click(object sender, EventArgs e)
        {
            groupBox4.Controls.Clear();
            //Singleton<Condition>.Instance.All.Parameter.Clear();
            Parameters pm = new Parameters();
            groupBox4.Controls.Add(pm);
            #region 得到所有参数
            DBOperatorBase db = new DataBase();
            IDBTypeElementFactory dbFactory = db.GetDBTypeElementFactory();
            IDataReader dataReader = db.ExecuteReader(ConString, CommandType.Text, "SELECT     TABLE_CATALOG AS [Database], TABLE_SCHEMA AS Owner, TABLE_NAME AS TableName, COLUMN_NAME AS ColumnName,  ORDINAL_POSITION AS OrdinalPosition, COLUMN_DEFAULT AS DefaultSetting, IS_NULLABLE AS IsNullable, DATA_TYPE AS DataType,  CHARACTER_MAXIMUM_LENGTH AS MaxLength, DATETIME_PRECISION AS DatePrecision,COLUMNPROPERTY(object_id(TABLE_NAME), COLUMN_NAME, 'IsIdentity') as IsIdentity FROM         INFORMATION_SCHEMA.COLUMNS WHERE     (TABLE_NAME = '" + Singleton<ConnectionString>.Instance.DataTable + "')", null);
            while (dataReader.Read())
            {
                //Parameter p = new Parameter();
                //p.IsNullable = DealData.GetIsNull(dataReader["IsNullable"].ToString());
                //p.Lower = DealData.GetLower(dataReader["ColumnName"].ToString());
                //p._Lower = DealData.Get_Lower(dataReader["ColumnName"].ToString());
                //p.Upper = DealData.GetUpper(dataReader["ColumnName"].ToString());
                //p.Type = DealData.GetType(dataReader["DataType"].ToString());
                //p.Length = DealData.GetLength(p.Type, dataReader["MaxLength"].ToString()).ToString();
                //p.OriginalName = dataReader["ColumnName"].ToString();
                //Singleton<Condition>.Instance.All.Parameter.Add(p);
            }
            dataReader = db.ExecuteReader(ConString, CommandType.Text, "SELECT TABLE_NAME,COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME='" + Singleton<ConnectionString>.Instance.DataTable + "'", null);
            while (dataReader.Read())
            {
                string Name = dataReader["COLUMN_NAME"].ToString();
                Singleton<Condition>.Instance.KeyInfo.Name = Name;
                //Parameter p = Singleton<Condition>.Instance.All.Parameter.Find(s => s.OriginalName == Name);
                //Singleton<Condition>.Instance.KeyInfo.Lower = p.Lower;
                //Singleton<Condition>.Instance.KeyInfo._Lower = p._Lower;
                //Singleton<Condition>.Instance.KeyInfo.Upper = p.Upper;
                //Singleton<Condition>.Instance.KeyInfo.Type = p.Type;
            }
            db.Conn.Close();
            #endregion
            //Conditions con = new Conditions();
            //groupBox4.Controls.Add(con);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Singleton<ConnectionString>.Instance.DataTable = listBox1.SelectedItem.ToString();
            Singleton<Condition>.Instance.CDataTable = listBox1.SelectedItem.ToString();
            groupBox4.Controls.Clear();
            //Singleton<Condition>.Instance.CParameters.Clear();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Singleton<ConnectionString>.Instance.DataTable = listBox1.SelectedItem.ToString();
            Singleton<Condition>.Instance.CDataTable = listBox1.SelectedItem.ToString();
            groupBox4.Controls.Clear();
            //Singleton<Condition>.Instance.CParameters.Clear();
        }

        private void btBuild_Click(object sender, EventArgs e)
        {
            groupBox4.Controls.Clear();
            FinalText ft = new FinalText();
            //ShowCode sc = new ShowCode();
            groupBox4.Controls.Add(ft);
            
        }

        private void cBResultType_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupBox3.Controls.Clear();
            Singleton<Condition>.Instance.ResultType = (ResultType)Enum.Parse(typeof(ResultType), cBResultType.SelectedItem.ToString());
            if (Singleton<Condition>.Instance.ResultType == ResultType.Entity)
            {
                BuildEntity b = new BuildEntity();
                groupBox3.Controls.Add(b);
            }
            else if (Singleton<Condition>.Instance.ResultType == ResultType.Proc)
            {
                BuildProc b = new BuildProc();
                groupBox3.Controls.Add(b);
            }
            else if (Singleton<Condition>.Instance.ResultType == ResultType.DAL)
            {
                BuildDALandBLL b = new BuildDALandBLL();
                groupBox3.Controls.Add(b);
            }
        }

        private void cBDLLName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Singleton<Condition>.Instance.DLLName = (DLLName)Enum.Parse(typeof(DLLName), cBDLLName.SelectedItem.ToString());
        }
    }
}

