using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace CodeHelper
{
    public partial class Parameters : UserControl
    {
        public Parameters()
        {
            InitializeComponent();
        }

        private void Parameters_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            Singleton<Condition>.Instance.ALLParameters.Clear();
            Singleton<Condition>.Instance.ChoosenParameters.Clear();
            Singleton<Condition>.Instance.FinalParameters.Clear();
            GetParameters();
            groupBox2.Text = string.Format("选择表{0}中的参数", Singleton<ConnectionString>.Instance.DataTable);
            if (Singleton<Condition>.Instance.ResultType == ResultType.DAL || Singleton<Condition>.Instance.ResultType == ResultType.Entity)
            {
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                radioButton3.Enabled = true;
                radioButton4.Enabled = true;
                radioButton1.Checked = true;
            }
            else
            {
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
            }
        }

        public string ConString;

        public List<string> GetParameters()
        {
            List<string> Return = new List<string>();
            DBOperatorBase db = new DataBase();
            IDBTypeElementFactory dbFactory = db.GetDBTypeElementFactory();
            ConString = Singleton<ConnectionString>.Instance.ToString();
            try
            {
                //IDataReader dataReader = db.ExecuteReader(ConString, CommandType.Text, "SELECT     TABLE_CATALOG AS [Database], TABLE_SCHEMA AS Owner, TABLE_NAME AS TableName, COLUMN_NAME AS ColumnName,  ORDINAL_POSITION AS OrdinalPosition, COLUMN_DEFAULT AS DefaultSetting, case IS_NULLABLE when 'NO' then 'False' else 'True' END as Is_Nullable,DATA_TYPE AS DataType,  CHARACTER_MAXIMUM_LENGTH AS MaxLength, DATETIME_PRECISION AS DatePrecision,COLUMNPROPERTY(object_id(TABLE_NAME), COLUMN_NAME, 'IsIdentity') as IsIdentity FROM         INFORMATION_SCHEMA.COLUMNS WHERE    (TABLE_NAME = '" + Singleton<ConnectionString>.Instance.DataTable + "')", null);
                IDataReader dataReader = db.ExecuteReader(ConString, CommandType.Text, "SELECT 表名 = case when a.colorder=1 then d.name else '' end,表说明= case when a.colorder=1 then isnull(f.value,'') else '' end,字段序号= a.colorder,字段名= a.name,标识= case when COLUMNPROPERTY( a.id,a.name,'IsIdentity')=1 then '√'else '' end,主键= case when exists(SELECT 1 FROM sysobjects where xtype='PK' and parent_obj=a.id and name in (SELECT name FROM sysindexes WHERE indid in( SELECT indid FROM sysindexkeys WHERE id = a.id AND colid=a.colid))) then '√' else '' end, 类型= b.name,占用字节数 = a.length,长度= COLUMNPROPERTY(a.id,a.name,'PRECISION'),小数位数= isnull(COLUMNPROPERTY(a.id,a.name,'Scale'),0),允许空= case when a.isnullable=1 then '√'else '' end,默认值= isnull(e.text,''),字段说明= isnull(g.[value],'') FROM syscolumns a left join systypes b on a.xusertype=b.xusertype inner join sysobjects d on a.id=d.id  and d.xtype='U' and  d.name<>'dtproperties' left join  syscomments e on a.cdefault=e.id left join sys.extended_properties g on a.id=G.major_id and a.colid=g.minor_id left join sys.extended_properties f on d.id=f.major_id and f.minor_id=0 where d.name='" + Singleton<ConnectionString>.Instance.DataTable + "' order by a.id,a.colorder", null);
                while (dataReader.Read())
                {
                    checkedListBox1.Items.Add(String.Format("{0}\t{1}\t{2}\t{3}\t{4}", dataReader["字段名"].ToString(), dataReader["类型"].ToString(), dataReader["长度"].ToString(), dataReader["允许空"].ToString(), dataReader["字段说明"].ToString()));
                    OriginalParameter op = new OriginalParameter();
                    op.ColumnName = dataReader["字段名"].ToString();
                    op.DataType = dataReader["类型"].ToString();
                    if (dataReader["允许空"].ToString() == "√")
                    {
                        op.IsNullable = true;
                    }
                    else
                    {
                        op.IsNullable = false;
                    }
                    op.MaxLength = dataReader["长度"].ToString();
                    op.Description = dataReader["字段说明"].ToString();
                    Singleton<Condition>.Instance.ALLParameters.Add(op);
                    //Singleton<Condition>.Instance.AllParameterNames.Add(string.Format("{0}\t{1}", dataReader["ColumnName"].ToString(), dataReader["DataType"].ToString()));
                }
            }
            catch
            {

            }
            finally
            {
                db.Conn.Close();
            }
            return Return;
        }

        private void cBAll_CheckedChanged(object sender, EventArgs e)
        {
            if (cBAll.Checked)
            {
                cBAllNot.Checked = false;
                for (int a = 0; a < checkedListBox1.Items.Count; a++)
                    checkedListBox1.SetItemChecked(a, true);
            }
            else
            {
                cBAllNot.Checked = true;
                for (int a = 0; a < checkedListBox1.Items.Count; a++)
                    checkedListBox1.SetItemChecked(a, false);
            }
        }

        private void cBAllNot_CheckedChanged(object sender, EventArgs e)
        {
            if (cBAllNot.Checked)
            {
                cBAll.Checked = false;
                for (int a = 0; a < checkedListBox1.Items.Count; a++)
                    checkedListBox1.SetItemChecked(a, false);
            }
            else
            {
                cBAll.Checked = true;
                for (int a = 0; a < checkedListBox1.Items.Count; a++)
                    checkedListBox1.SetItemChecked(a, true);
            }
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            Singleton<Condition>.Instance.ChoosenParameters.Clear();
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
                {
                    string[] s = checkedListBox1.CheckedItems[i].ToString().Trim().Split('\t');
                    Singleton<Condition>.Instance.ChoosenParameters.Add(s[0]);
                    //Singleton<Condition>.Instance.ChoosenParameters.Add(checkedListBox1.CheckedItems[i].ToString().Trim());

                }
                MessageBox.Show("参数选择成功");
            }
            else
            {
                MessageBox.Show("请选择参数");
            }

        }

        private void btReturn_Click(object sender, EventArgs e)
        {
            groupBox2.Controls.Clear();
            groupBox2.Text = string.Empty;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (Singleton<Condition>.Instance.ResultType==ResultType.Entity)
                {
                    Singleton<Condition>.Instance.EntityAccessType = radioButton1.Text.Trim();
                }
                else
                {
                    Singleton<Condition>.Instance.DALAccessType = radioButton1.Text.Trim();
                }
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                if (Singleton<Condition>.Instance.ResultType == ResultType.Entity)
                {
                    Singleton<Condition>.Instance.EntityAccessType = radioButton3.Text.Trim();
                }
                else
                {
                    Singleton<Condition>.Instance.DALAccessType = radioButton3.Text.Trim();
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (Singleton<Condition>.Instance.ResultType == ResultType.Entity)
                {
                    Singleton<Condition>.Instance.EntityAccessType = radioButton2.Text.Trim();
                }
                else
                {
                    Singleton<Condition>.Instance.DALAccessType = radioButton2.Text.Trim();
                }
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                if (Singleton<Condition>.Instance.ResultType == ResultType.Entity)
                {
                    Singleton<Condition>.Instance.EntityAccessType = radioButton4.Text.Trim();
                }
                else
                {
                    Singleton<Condition>.Instance.DALAccessType = radioButton4.Text.Trim();
                }
            }
        }
    }
}
